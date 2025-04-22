
namespace SmartParking.Server.Common.Entities.Response
{
    public class UserLoginEntity
    {
        public UserEntity User { get; set; }
        public string Token { get; set; }
    }
}