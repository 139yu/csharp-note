using System;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.IServices;
using SmartParking.Client.Commons.Models;

namespace SmartParking.Client.DAL
{
    public class LoginDal: ILoginDal
    {
        private IHttpService _httpService;
        public LoginDal(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task<ResponseResult<LoginResponse>> Login(UserLoginModel userLogin)
        {
            return _httpService.PostAsync<ResponseResult<LoginResponse>,UserLoginModel>("api/admin/login", userLogin);
        }
    }
}