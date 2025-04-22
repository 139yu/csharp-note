using System;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Models.Response;
using SmartParking.Client.IBLL;
using SmartParking.Client.Start.Models;

namespace SmartParking.Client.BLL
{
    public class LoginBll: ILoginBll
    {
        private ILoginDal _loginDal;
        public LoginBll(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }
        public Task<ResponseEntity<LoginResponse>> Login(UserLoginModel userLogin)
        {
            return _loginDal.Login(userLogin);
        }
    }
}