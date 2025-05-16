using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using SmartParking.Client.Commons.Config;
using SmartParking.Client.Commons.Entity.Request;
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
            _logger.LogError($"{errorType}: {ex.Message}");
        }

        private string BuilderUri(string uri, Dictionary<string, string> querys)
        {
            if (querys?.Count > 0)
            {
                var fullUri = _httpClient.BaseAddress != null
                    ? new Uri(_httpClient.BaseAddress, uri)
                    : new Uri(uri);

                var uriBuilder = new UriBuilder(fullUri);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                foreach (var kvp in querys)
                {
                    if (!string.IsNullOrEmpty(kvp.Value))
                    {
                        query[kvp.Key] = kvp.Value;
                    }
                }

                uriBuilder.Query = query.ToString();
                uri = uriBuilder.ToString();
            }

            return uri;
        }

        private string BuilderUri<T>(string uri, T request)
        {
            if (request != null)
            {
                var fullUri = _httpClient.BaseAddress != null
                    ? new Uri(_httpClient.BaseAddress, uri)
                    : new Uri(uri);
                var uriBuilder = new UriBuilder(fullUri);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                var type = request.GetType();
                foreach (var propertyInfo in type.GetProperties())
                {
                    var value = propertyInfo.GetValue(request);
                    if (value != null)
                    {
                        var propertyName = propertyInfo.Name;
                        query[propertyName] = value.ToString();
                    }
                }
                uriBuilder.Query = query.ToString();
                uri = uriBuilder.ToString();
            }

            return uri;
        }

        #endregion


        public async Task<TResponse> SendAsync<TResponse>(Func<HttpRequestMessage> requestFactory,
            CancellationToken ct = default)
        {
            try
            {
                var response = await _retryPolicy.ExecuteAsync(async () =>
                {
                    var request = requestFactory();
                    try
                    {
                        LogRequest(request);
                        var response = await _httpClient.SendAsync(request, ct);
                        response.EnsureSuccessStatusCode();
                        return response;
                    }
                    finally
                    {
                        if (request.Options.TryGetValue<IDisposable>(
                                new HttpRequestOptionsKey<IDisposable>("AttachedResources"), out var resources))
                        {
                            resources.Dispose();
                        }

                        request.Dispose();
                    }
                });
                return await ProcessResponse<TResponse>(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                HandleException(e, null);
            }

            return default;
        }

        #region 通用工具方法

        public Task<TResponse> GetAsync<TResponse>(string uri, Dictionary<string, string> querys = null,
            CancellationToken ct = default)
        {
            uri = BuilderUri(uri, querys);
            return SendAsync<TResponse>(() => new HttpRequestMessage(HttpMethod.Get, uri), ct);
        }

        public Task<TResponse> GetAsync<TResponse, TRequest>(string uri, TRequest request,
            CancellationToken ct = default)
        {
            uri = BuilderUri(uri, request);

            return SendAsync<TResponse>(() => new HttpRequestMessage(HttpMethod.Get, uri), ct);
        }

        public Task<TResponse> PostAsync<TResponse, TRequest>(string uri, TRequest requestData,
            CancellationToken ct = default)
        {
            return SendAsync<TResponse>(() => new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = SerializeJsonContent(requestData)
            }, ct);
        }

        public Task<TResponse> PostAsync<TResponse>(string uri, CancellationToken ct = default)
        {
            return SendAsync<TResponse>(() => new HttpRequestMessage(HttpMethod.Post, uri), ct);
        }

        public Task<TResponse> PostFormAsync<TResponse>(string uri, Dictionary<string, string> formData,
            CancellationToken ct = default)
        {
            return SendAsync<TResponse>(() => new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new FormUrlEncodedContent(formData)
            }, ct);
        }

        public Task<TResponse> PostFileAsync<TResponse>(
            string uri,
            string filepath,
            Dictionary<string, string> metadata = default,
            Action<double> progressCallback = default,
            CancellationToken ct = default)
        {
            if (!File.Exists(filepath))
            {
                _logger.LogError($"文件不存在：{filepath}");
                throw new Exception($"文件不存在：{filepath}");
            }

            Func<HttpRequestMessage> request = () =>
            {
                var filestream = File.OpenRead(filepath);

                var filename = Path.GetFileName(filepath);
                var totalLength = filestream.Length;
                var content = new MultipartFormDataContent();
                var fileContent = new ProgressStreamContent(filestream, bytesRead =>
                {
                    var progress = (double)bytesRead / totalLength * 100;
                    progressCallback?.Invoke(progress);
                });
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                content.Add(fileContent, "file", filename);
                if (metadata != null)
                {
                    foreach (var (key, value) in metadata)
                    {
                        content.Add(new StringContent(value), key);
                    }
                }

                return new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    Content = content
                };
            };


            return SendAsync<TResponse>(request, ct);
        }

        #endregion
    }

    public class ProgressStreamContent : StreamContent
    {
        private readonly Stream _stream;
        private readonly Action<long> _progressAction;

        public ProgressStreamContent(Stream stream, Action<long> progressAction) : base(stream)
        {
            _stream = stream;
            _progressAction = progressAction;
        }

        public ProgressStreamContent(Stream content) : base(content)
        {
        }

        public ProgressStreamContent(Stream content, int bufferSize) : base(content, bufferSize)
        {
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var buffer = new byte[1024];
            var totalRead = 0;
            int bytesRead;
            while ((bytesRead = await _stream.ReadAsync(buffer)) > 0)
            {
                await stream.WriteAsync(buffer.AsMemory(0, bytesRead));
                totalRead += bytesRead;
                _progressAction.Invoke(totalRead);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _stream?.Dispose();
            base.Dispose(disposing);
        }
    }
}