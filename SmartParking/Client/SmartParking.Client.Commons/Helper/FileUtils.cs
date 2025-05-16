using System;
using System.IO;
using System.Security.Cryptography;

namespace SmartParking.Client.Commons.Helper
{
    public static class FileUtils
    {
        public static string GetFileMd5(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                throw new Exception("文件路径不能未空");
            }

            using var md5 = MD5.Create();
            using var filestream = File.OpenRead(filepath);
            var hashBytes = md5.ComputeHash(filestream);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}