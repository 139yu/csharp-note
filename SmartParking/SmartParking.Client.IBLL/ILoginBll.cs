using System;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Models.Response;
using SmartParking.Client.Start.Models;

namespace SmartParking.Client.IBLL
{
    public interface ILoginBll
    {
        Task<ResponseEntity<LoginResponse>> Login(UserLoginModel userLogin);
    }
}