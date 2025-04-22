using System;

namespace SmartParking.Client.Commons.Models
{
    public interface ITokenProvider
    {
        string? BearerToken { get; set; }
        event EventHandler TokenUpdated;
    }
}