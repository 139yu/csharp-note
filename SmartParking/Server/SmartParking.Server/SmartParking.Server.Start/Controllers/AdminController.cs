using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Common.Entities.Request;
using SmartParking.Server.Common.Entities.Response;

namespace SmartParking.Server.Start.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IUserService _userService;

        public AdminController(IUserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginParams loginParams)
        {
            var userLoginEntity = _userService.Login(loginParams.Username, loginParams.Password);
            if (userLoginEntity == null)
            {
                return Unauthorized(ResponseEntity.Failed("账号或密码错误"));
            }

            return Ok(ResponseEntity<UserLoginEntity>.Success(userLoginEntity));
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterParams registerParams)
        {
            try
            {
                _userService.register(registerParams.Username, password: registerParams.Password,
                    registerParams.RealName, registerParams.Birthday);
            }
            catch (Exception e)
            {
                return BadRequest(ResponseEntity.Failed(e.Message));
            }

            return Ok(ResponseEntity.Success());
        }

        [HttpGet]
        [Route("getUserList")]
        [Authorize]
        public IActionResult GetUserList([FromQuery] QueryUser queryUser)
        {
            int totalCount = 0;
            List<UserEntity> userList = _userService.GetUserList(queryUser,ref totalCount);
            return Ok(ResponseEntity<List<UserEntity>>.Success(userList));
        }
    }
}