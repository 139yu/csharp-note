using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SmartParking.Client.Commons.Config
{
    public class TokenAuthenticationHandler: DelegatingHandler
    {
        private string BearerToken;
        private readonly IUserTokenProvider _userTokenProvider;

        public TokenAuthenticationHandler(IUserTokenProvider userTokenProvider)
        {
            _userTokenProvider = userTokenProvider;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken ct)
        {
            if (!string.IsNullOrEmpty(_userTokenProvider.BearerToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _userTokenProvider.BearerToken);
            }
            return await base.SendAsync(request, ct);
        }
    }
}