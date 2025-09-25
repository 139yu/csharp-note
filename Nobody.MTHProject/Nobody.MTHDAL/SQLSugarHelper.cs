using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHDAL
{
    public class SQLSugarHelper
    {
        public static readonly SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig()
        {
            DbType = DbType.SqlServer,
            IsAutoCloseConnection = true,
            ConnectionString = "server=.;database=MultiTHMonitorDB;uid=sa;pwd=123456"
        }, db =>
        {
            db.Aop.OnLogExecuted = (sql,args) =>
            {
                Console.WriteLine(sql);
            };      
        });
    }
}
