using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Request;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.IServices;
using SmartParking.Client.Commons.Models;

namespace SmartParking.Client.DAL
{
    public class UserDal: IUserDal
    {
        private IHttpService _httpService;
        public UserDal(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task<ResponseResult<LoginResponse>> Login(UserLoginModel userLogin)
        {
            return _httpService.PostAsync<ResponseResult<LoginResponse>,UserLoginModel>("api/admin/login", userLogin);
        }

        public Task<ResponseResult<List<UserEntity>>> GetUserList(QueryUser queryUser)
        {
            return _httpService.GetAsync<ResponseResult<List<UserEntity>>,QueryUser>("api/admin/getUserList", queryUser);
        }

        public Task<ResponseResult> RegisterUser(UserRegisterParams userRegisterParams)
        {
            return _httpService.PostAsync<ResponseResult, UserRegisterParams>("api/admin/register", userRegisterParams);
        }
    }
}