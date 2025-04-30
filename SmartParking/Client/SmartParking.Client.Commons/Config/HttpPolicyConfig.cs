using System;
using System.Net.Http;
using Polly;
using Polly.Extensions.Http;

namespace SmartParking.Client.Commons.Config
{
    public static class HttpPolicyConfig
    {
        public static IAsyncPolicy<HttpResponseMessage> GetPolicy(int retryCount = 3)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(int eventsBeforeBreaking =5)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(eventsBeforeBreaking, TimeSpan.FromSeconds(30));
        }
    }
}