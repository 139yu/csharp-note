using System;
using System.Threading.Tasks;
using SmartParking.Client.Commons.Models.Response;
using SmartParking.Client.Start.Models;

namespace SamrtParking.Client.IDAL
{
    public interface ILoginDal
    {
        Task<ResponseEntity<LoginResponse>> Login(UserLoginModel userLogin);
    }
}