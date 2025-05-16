using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Request;

namespace SmartParking.Client.Commons.IServices
{
    public interface IHttpService
    {
        Task<TResponse?> SendAsync<TResponse>(Func<HttpRequestMessage> factory,CancellationToken ct = default);
        Task<TResponse?> GetAsync<TResponse>(string uri, Dictionary<string, string> querys = null,CancellationToken ct = default);

        public Task<TResponse> GetAsync<TResponse, TRequest>(string uri, TRequest request,
            CancellationToken ct = default);
        Task<TResponse?> PostAsync<TResponse,TRequest>(string uri,TRequest request,CancellationToken ct = default);
        Task<TResponse?> PostAsync<TResponse>(string uri,CancellationToken ct = default);
        Task<TResponse?> PostFormAsync<TResponse>(string uri,Dictionary<string,string> requests,CancellationToken ct = default);

        Task<TResponse> PostFileAsync<TResponse>(
            string uri,
            string filepath,
            Dictionary<string, string> metadata = default,
            Action<double> progressCallback = default,
            CancellationToken ct = default);
    }
}