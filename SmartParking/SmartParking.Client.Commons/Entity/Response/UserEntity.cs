using System;

namespace SmartParking.Client.Commons.Models.Response
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime? Birthday { get; set; }
        public string RealName { get; set; }
    }
}