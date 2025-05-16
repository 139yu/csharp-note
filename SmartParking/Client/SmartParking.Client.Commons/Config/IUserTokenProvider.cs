using System;
using SmartParking.Client.Commons.Entity.Response;

namespace SmartParking.Client.Commons.Config
{
    public interface IUserTokenProvider
    {
        public UserEntity CurrentUser { get; set; }
        
        string BearerToken { get; set; }
        event EventHandler TokenUpdated;
    }
}