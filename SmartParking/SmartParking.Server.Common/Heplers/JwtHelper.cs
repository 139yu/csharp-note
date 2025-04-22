using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace SmartParking.Server.Common.Heplers
{
    public static class JwtHelper
    {
        
        
        /// <summary>
        /// 生成 JWT 令牌 (RS256 非对称加密算法)
        /// </summary>
        /// <param name="secret">RSA 私钥（PEM格式）</param>
        /// <param name="claims">声明集合</param>
        /// <param name="expiresMin">有效期（分钟）</param>
        /// <param name="issuer">颁发者</param>
        /// <param name="audience">受众</param>
        /// <returns></returns>
        public static string GenerateTokenHS256(
            string secret,
            IEnumerable<Claim> claims,
            int expiresMin = 60,
            string issuer = null,
            string audience = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            return GenerateToken(securityKey, SecurityAlgorithms.HmacSha256,claims, expiresMin, issuer, audience);
        }
        /// <summary>
        /// 验证并解析 JWT 令牌 (HS256)
        /// </summary>
        public static string GenerateTokenRS256(string priavteKey,IEnumerable<Claim> claims,int expiresMin = 60,string issuer = null,string audience = null)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportFromPem(priavteKey);
                var securityKey = new RsaSecurityKey(rsa);
                return GenerateToken(securityKey,SecurityAlgorithms.RsaSha256,claims,expiresMin,issuer,audience);
            }
        }

        public static ClaimsPrincipal ValidateTokenHS256(string token,string secret,string issuer = null,string audience = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            return ValidateToken(token,securityKey,SecurityAlgorithms.HmacSha256,issuer,audience); 
        }
        /// <summary>
        /// 验证并解析 JWT 令牌 (RS256)
        /// </summary>
        public static ClaimsPrincipal ValidateTokenRS256(string token,string publicKey,string issuer = null,string audience = null)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportFromPem(publicKey);
                var securityKey = new RsaSecurityKey(rsa);
                return ValidateToken(token,securityKey,SecurityAlgorithms.RsaSha256,issuer,audience);
            }
        }
        /// <summary>
        /// 解析 JWT 令牌（不验证签名）
        /// </summary>
        public static JwtSecurityToken ReadToken(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token);
        }
        
        #region 私有方法
        private static string GenerateToken(SecurityKey securityKey, string algorithm,IEnumerable<Claim> claims,int expiresMin,string issuer,string audience)
        {
            var credentials = new SigningCredentials(securityKey, algorithm);
            var expires = DateTime.UtcNow.AddMinutes(expiresMin);
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static ClaimsPrincipal ValidateToken(string token,
            SecurityKey securityKey,string algorithm,string issuer,string audience)
        {
            
            var validator = new JwtSecurityTokenHandler();
            var validationParams = new TokenValidationParameters
            {
                ValidateIssuer = !string.IsNullOrEmpty(issuer),
                ValidIssuer = issuer,
                ValidateAudience = !string.IsNullOrEmpty(audience),
                ValidAudience = audience,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ClockSkew = TimeSpan.Zero
            };
            // 算法校验
            validationParams.SignatureValidator = (tokenHandler, parameters) =>
            {
                var tokenParts = token.Split('.');
                if (tokenParts.Length != 3)
                {
                    throw new SecurityTokenException("无效的JWT格式");
                }

                var headerJson = Base64UrlEncoder.DecodeBytes(tokenParts[0]).ToString();
                var header = JObject.Parse(headerJson);
                var alg = header["alg"].ToString();
                if (alg != algorithm)
                {
                    throw new SecurityTokenInvalidSignatureException($"无效的算法：{algorithm}");
                }

                return validator.ValidateToken(tokenParts[1], validationParams, out _).Identity as SecurityToken;
            };
            return validator.ValidateToken(token, validationParams, out _);
        }
        #endregion
    }
}