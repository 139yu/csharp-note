using System;

namespace SmartParking.Client.Commons.Models.Response
{
    public class LoginResponse
    {
        public UserEntity User { get; set; }
        public string Token { get; set; }
    }
    
}