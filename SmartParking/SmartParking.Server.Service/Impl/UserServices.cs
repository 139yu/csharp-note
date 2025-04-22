using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Common.Configs;
using SmartParking.Server.Common.Entities.Response;
using SmartParking.Server.Common.Heplers;
using SmartParking.Server.Models;

namespace SmartParking.Server.Service.Impl
{
    public class UserServices: BaseService, IUserService
    {
        public UserServices(IDBConfig.IDBConfig dbConfig) : base(dbConfig){}
        public UserLoginEntity Login(string username, string password)
        {
            password = encryptPassword(password);
            UserEntity userEntity = this.Query<UserModel>(u => u.Username == username && u.Password == password)
                .Select(u => new UserEntity()
                {
                    Username = u.Username,
                    RealName = u.RealName,
                    Birthday = u.Birthday,
                    UserId = u.UserId
                }).FirstOrDefault();
            if (userEntity != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userEntity.Username));
                claims.Add(new Claim("userId", userEntity.UserId.ToString()));
                claims.Add(new Claim("realName", userEntity.RealName));
                string token = JwtHelper.GenerateTokenHS256(JwtConfiguration.JwtSecret, claims);
                return new UserLoginEntity()
                {
                    Token = token,
                    User = userEntity
                };
            }
            return null;
        }

        public void register(string username, string password, string realName, DateTime birthday)
        {
            var exits = this.Query<UserModel>(u => u.Username == username).Any();
            if (exits)
            {
                throw new Exception($"用户名 {username} 已存在");
            }

            var userModel = new UserModel()
            {
                Username = username,
                Password = encryptPassword(password),
                RealName = realName,
                Birthday = birthday,
                IsDeleted = 0
            };
            Insert(userModel);
        }


        private string encryptPassword(string password)
        {
            return MD5Helper.GetMD5Hash($"{MD5Helper.GetMD5Hash(password)}|{password}");
        }
    }
}