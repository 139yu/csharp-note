using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartParking.Server.Models;

namespace SmartParking.Server.EFCore
{
    public class EFCoreContext: DbContext
    {
        // 配置数据库连接
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=SmartParking;User Id=sa;Password=123456;Trusted_Connection=True")
                .LogTo(Console.WriteLine,LogLevel.Information)
                ;
        }
        
        public DbSet<UserModel> Users { get; set; }
    }
}
