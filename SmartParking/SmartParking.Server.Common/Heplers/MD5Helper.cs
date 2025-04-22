using System;
using System.Security.Cryptography;
using System.Text;

namespace SmartParking.Server.Common.Heplers
{
    public static class MD5Helper
    {
        public static string GetMD5Hash(string input,Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("input is null or empty");
            }
            encoding ??= Encoding.UTF8;
            using (var md5 = MD5.Create())
            {
                var bytes = encoding.GetBytes(input);
                var computeHash = md5.ComputeHash(bytes);
                return BytesToHex(computeHash);
            }
        }

        
        private static string BytesToHex(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}