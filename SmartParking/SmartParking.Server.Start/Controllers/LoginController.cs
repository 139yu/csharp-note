using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Models;
using SmartParking.Server.Start.Models;

namespace SmartParking.Server.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {
        private IBaseService baseService;

        public LoginController(IBaseService _baseService)
        {
            this.baseService = _baseService;
        }
        [HttpPost]
        public UserModel Login([FromBody] LoginParamsModel loginParams)
        {
            Console.WriteLine($"Username: {loginParams.Username}, Password: {loginParams.Password}");
            var userModels = baseService.Query<UserModel>(u => u.Username == loginParams.Username && u.Password == loginParams.Password);
            var userModel = userModels.FirstOrDefault();
            
            return userModel;
        }
    }
}