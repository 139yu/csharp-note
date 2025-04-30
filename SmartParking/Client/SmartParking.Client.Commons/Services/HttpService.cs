using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using SmartParking.Client.Commons.Config;
using SmartParking.Client.Commons.Helper;
using SmartParking.Client.Commons.IServices;

namespace SmartParking.Client.Commons.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpService> _logger;
        private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;

        public HttpService(HttpClient httpClient, ILogger<HttpService> logger, HttpServiceOptions _options)
        {
            _httpClient = httpClient;
            _logger = logger;
            /*_jsonOptions = new JsonSerializerOptions()
            {
                // 采用驼峰写法，首字母小写
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                // 该属性设置为 true 时，在 JSON 反序列化过程中，System.Text.Json 会忽略 JSON 字段名称与 C# 对象属性名称之间的大小写差异。
                // 这意味着 JSON 中的字段名无论是大写、小写还是混合大小写，只要名称匹配（不考虑大小写），都能正确映射到对应的 C# 对象属性。
                PropertyNameCaseInsensitive = true,
            };*/
            ConfigHttpClient(_options);
            _retryPolicy = ConfigRetryTimeoutBreakerPolicy(_options);
        }

        #region 配置

        /// <summary>
        /// 配置超时、重试、熔断策略
        /// </summary>
        /// <param name="retryPolicy"></param>
        private IAsyncPolicy<HttpResponseMessage> ConfigRetryTimeoutBreakerPolicy(HttpServiceOptions options)
        {
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<TimeoutRejectedException>()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(options.RetryCount,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (outcome, timespan, retryAttempt, _) =>
                    {
                        _logger.LogWarning($"第 {retryAttempt} 次重试，状态码：{outcome.Result?.StatusCode}，" +
                                           $"等待 {timespan.TotalSeconds} 秒");
                    }
                );
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(options.Timeout.Seconds + 2);
            var circuitBreaker = HttpPolicyExtensions.HandleTransientHttpError()
                .Or<TimeoutRejectedException>()
                .CircuitBreakerAsync(options.CircuitBreakerOpenInterval,
                    TimeSpan.FromSeconds(options.CircuitBreakerSeconds));
            // 策略组合，重试在外，超时在内
            return Policy.WrapAsync(retryPolicy, timeoutPolicy, circuitBreaker);
        }

        /// <summary>
        /// 初始化HttpClient
        /// </summary>
        /// <param name="options"></param>
        private void ConfigHttpClient(HttpServiceOptions options)
        {
            _httpClient.BaseAddress = new Uri(options.BaseAddress);
            // 超时时间
            _httpClient.Timeout = options.Timeout;
            // 默认请求头
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            /*if (!string.IsNullOrEmpty(options.BearerToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", options.BearerToken);
            }*/
        }

        private void LogRequest(HttpRequestMessage request)
        {
            if (!_logger.IsEnabled(LogLevel.Information))
            {
                return;
            }

            var logContent = new StringBuilder()
                .AppendLine($"HTTP请求：{request.Method} {request.RequestUri}")
                .AppendLine($"请求头： {FormatHeaders(request.Headers)}");
            if (request.Content is StringContent content)
            {
                var body = content.ReadAsStringAsync().Result;
                logContent.AppendLine($"请求体： {SanitizeSensitiveData(body)}");
            }

            _logger.LogInformation(logContent.ToString());
        }

        /// <summary>
        /// 序列化响应
        /// </summary>
        /// <param name="response"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private async Task<TResponse?> ProcessResponse<TResponse>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                return JSONUtils.ToObject<TResponse>(content);
            }
            catch (JsonException e)
            {
                _logger.LogError(e, $"响应反序列化失败，原始内容：${SanitizeSensitiveData(content)}");
                throw new InvalidOperationException("响应数据格式错误", e);
            }
        }

        private static string SanitizeSensitiveData(string input)
        {
            // 正则表达式匹配敏感字段（如密码、token）
            const string pattern = @"(""(?:password|token|secret|api[_-]?key)""\s*:\s*)"".*?""";
            return Regex.Replace(input, pattern, "$1\"​**​*​**​\"", RegexOptions.IgnoreCase);
        }

        private StringContent SerializeJsonContent<TRequest>(TRequest request)
        {
            var json = JSONUtils.ToJsonString(request);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static string FormatHeaders(HttpHeaders headers)
        {
            return string.Join(", ", headers
                .Select(h => $"{h.Key}=[{string.Join(",", h.Value)}]"));
        }

        private void HandleException(Exception ex, HttpRequestMessage request)
        {
            var errorType = ex switch
            {
                HttpRequestException => "HTTP协议错误",
                TaskCanceledException => "请求超时",
                JsonException => "JSON解析错误",
                _ => "未知错误"
            };
        }

        #endregion


        public async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage request, CancellationToken ct = default)
        {
            using (request)
            {
                try
                {
                    LogRequest(request);
                    var response = await _retryPolicy.ExecuteAsync(async () =>
                    {
                        return await _httpClient.SendAsync(request, ct);
                    });
                    response.EnsureSuccessStatusCode();
                    return await ProcessResponse<TResponse>(response);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                    HandleException(e, request);
                    return default;
                }
            }
        }

        #region 通用工具方法

        public Task<TResponse> GetAsync<TResponse>(string uri, CancellationToken ct = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return SendAsync<TResponse>(request, ct);
        }

        public Task<TResponse> PostAsync<TResponse, TRequest>(string uri, TRequest requestData,
            CancellationToken ct = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = SerializeJsonContent(requestData)
            };
            return SendAsync<TResponse>(request, ct);
        }

        public Task<TResponse> PostFormAsync<TResponse>(string uri, Dictionary<string, string> formData,
            CancellationToken ct = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new FormUrlEncodedContent(formData)
            };
            return SendAsync<TResponse>(request, ct);
        }

        #endregion
    }
}