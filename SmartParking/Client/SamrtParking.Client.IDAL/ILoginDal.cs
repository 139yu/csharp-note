using System;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.Models;

namespace SamrtParking.Client.IDAL
{
    public interface ILoginDal
    {
        Task<ResponseResult<LoginResponse>> Login(UserLoginModel userLogin);
    }
}