using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Entity.Request;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.Models;

namespace SamrtParking.Client.IDAL
{
    public interface IUserDal
    {
        Task<ResponseResult<LoginResponse>> Login(UserLoginModel userLogin);

        Task<ResponseResult<List<UserEntity>>> GetUserList(QueryUser queryUser);
        Task<ResponseResult> RegisterUser(UserRegisterParams userRegisterParams);
    }
}