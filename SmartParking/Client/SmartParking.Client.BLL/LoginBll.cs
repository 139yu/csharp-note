using System;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.Models;
using SmartParking.Client.IBLL;

namespace SmartParking.Client.BLL
{
    public class LoginBll: ILoginBll
    {
        private ILoginDal _loginDal;
        public LoginBll(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }
        public Task<ResponseResult<LoginResponse>> Login(UserLoginModel userLogin)
        {
            return _loginDal.Login(userLogin);
        }
    }
}