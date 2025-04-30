using System;

namespace SmartParking.Client.Commons.Entity.Response
{
    public class LoginResponse
    {
        public UserEntity User { get; set; }
        public string Token { get; set; }
    }
    
}