using System;

namespace SmartParking.Client.Commons.Entity.Request
{
    public class UserRegisterParams
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public DateTime? Birthday { get; set; }
    }
}