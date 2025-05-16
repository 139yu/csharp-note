using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using SmartParking.Server.Models;

namespace SmartParking.Server.EFCore
{
    public class EFCoreContext : DbContext
    {
        // 配置数据库连接
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=SmartParking;User Id=sa;Password=123456;Trusted_Connection=True")
                .LogTo(Console.WriteLine, LogLevel.Information)
                ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //string 实体类的属性  long数据库的属性
            ValueConverter<string, long> timeValueConverter = new ValueConverter<string, long>(
                (str) => (DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).Ticks -
                          621355968000000000) / 10000000,
                (time) => new DateTime(time * 10000000 + 621355968000000000).ToString("yyyy-MM-dd HH:mm:ss")
            );
            modelBuilder.Entity<UpgradeFileModel>().Property(m => m.UploadTime)
                .HasConversion(timeValueConverter)
                ;
            ValueConverter<string, string> CodeUnicodeConverter =
                new ValueConverter<string, string>(str => UnicodeToCode(str), str => CodeToUniCode(str));
            modelBuilder.Entity<MenuModel>()
                .Property(m => m.MenuIcon).HasConversion(CodeUnicodeConverter)
                ;
        }

        /// <summary>
        /// 16进制转Unicorn
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string CodeToUniCode(string str)
        {
            if (str == null || string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            int code = Convert.ToInt32(str, 16);

            return char.ConvertFromUtf32(code);
        }

        /// <summary>
        /// Unicode转16进制
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string UnicodeToCode(string str)
        {
            if (str == null || string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var c in str)
            {
                int code = Convert.ToInt32(c);
                sb.Append(code.ToString("x"));
            }

            return sb.ToString();
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<UpgradeFileModel> UpgradeFiles { get; set; }

        public DbSet<MenuModel> MenuModels { get; set; }
    }
}