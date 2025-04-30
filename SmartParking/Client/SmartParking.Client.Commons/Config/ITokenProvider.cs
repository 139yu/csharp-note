using System;

namespace SmartParking.Client.Commons.Config
{
    public interface ITokenProvider
    {
        string BearerToken { get; set; }
        event EventHandler TokenUpdated;
    }
}