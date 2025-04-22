using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SmartParking.Client.Commons.IServices
{
    public interface IHttpService
    {
        Task<TResponse?> SendAsync<TResponse>(HttpRequestMessage request,CancellationToken ct = default);
        Task<TResponse?> GetAsync<TResponse>(string uri,CancellationToken ct = default);
        Task<TResponse?> PostAsync<TResponse,TRequest>(string uri,TRequest request,CancellationToken ct = default);
        Task<TResponse?> PostFormAsync<TResponse>(string uri,Dictionary<string,string> requests,CancellationToken ct = default);
    }
}