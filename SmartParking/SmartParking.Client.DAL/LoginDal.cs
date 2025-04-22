using System;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.IServices;
using SmartParking.Client.Commons.Models.Response;
using SmartParking.Client.Start.Models;

namespace SmartParking.Client.DAL
{
    public class LoginDal: ILoginDal
    {
        private IHttpService _httpService;
        public LoginDal(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public Task<ResponseEntity<LoginResponse>> Login(UserLoginModel userLogin)
        {
            return _httpService.PostAsync<ResponseEntity<LoginResponse>,UserLoginModel>("api/admin/login", userLogin);
        }
    }
}