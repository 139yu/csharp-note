using System;
using SmartParking.Server.Common.Entities.Response;

namespace SamrtParking.Server.IService.Service
{
    public interface IUserService: IBaseService
    {
        UserLoginEntity Login(string username, string password);
        void register(string username, string password, string realName, DateTime birthday);
    }
}
