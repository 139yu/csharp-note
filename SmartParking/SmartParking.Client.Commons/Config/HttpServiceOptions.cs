using System;

namespace SmartParking.Client.Commons.Models
{
    public class HttpServiceOptions
    {
        public string BaseAddress { get; set; } = "http://localhost:5000";
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
        public int RetryCount { get; set; } = 3;
        public int CircuitBreakerSeconds { get; set; } = 30;
        public int CircuitBreakerOpenInterval { get; set; } = 3;
    }
}