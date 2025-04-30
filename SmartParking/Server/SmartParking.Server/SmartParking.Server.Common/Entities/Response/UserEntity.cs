using System;

namespace SmartParking.Server.Common.Entities.Response
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime? Birthday { get; set; }
        public string RealName { get; set; }
    }
}