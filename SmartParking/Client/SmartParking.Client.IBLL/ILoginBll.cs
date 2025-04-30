using System;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.Models;

namespace SmartParking.Client.IBLL
{
    public interface ILoginBll
    {
        Task<ResponseResult<LoginResponse>> Login(UserLoginModel userLogin);
    }
}