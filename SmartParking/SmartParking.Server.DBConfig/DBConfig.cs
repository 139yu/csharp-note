using System;
using Microsoft.EntityFrameworkCore;
using SmartParking.Server.EFCore;

namespace SmartParking.Server.DBConfig
{
    public class DBConfig: IDBConfig.IDBConfig
    {
        private EFCoreContext dbContext;

        public DBConfig()
        {
            dbContext = new EFCoreContext();
        }
        public DbContext GetDbContext()
        {
            return dbContext;
        }
    }
}
