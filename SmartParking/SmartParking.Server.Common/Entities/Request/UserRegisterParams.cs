using System;

namespace SmartParking.Server.Common.Entities.Request
{
    public class UserRegisterParams
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public DateTime Birthday { get; set; }
    }
}