using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SamrtParking.Client.IDAL;
using SmartParking.Client.Commons.Entity.Request;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.Models;
using SmartParking.Client.IBLL;

namespace SmartParking.Client.BLL
{
    public class UserBll: IUserBll
    {
        private IUserDal _userDal;
        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public Task<ResponseResult<LoginResponse>> Login(UserLoginModel userLogin)
        {
            return _userDal.Login(userLogin);
        }

        public Task<ResponseResult<List<UserEntity>>> GetUserList(QueryUser queryUser)
        {
            return _userDal.GetUserList(queryUser);
        }

        public Task<ResponseResult> RegisterUser(UserRegisterParams userRegisterParams)
        {
            return _userDal.RegisterUser(userRegisterParams);
        }
    }
}