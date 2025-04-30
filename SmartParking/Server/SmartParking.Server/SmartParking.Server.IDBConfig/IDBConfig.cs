using System;
using Microsoft.EntityFrameworkCore;

namespace SmartParking.Server.IDBConfig
{
    public interface IDBConfig
    {
        DbContext GetDbContext();
    }
}
