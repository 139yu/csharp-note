using System.Linq;
using System.Reflection;
using SqlSugar;

namespace SqlSugarDemo
{
    public class CodeFirstDemo
    {
        public static void Init()
        {
            var config = new ConnectionConfig()
            {
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                ConnectionString = "server=127.0.0.1;port=3306;user=root;password=root;database=sugar_demo;Charset=utf8"
            };
            using (var db = new SqlSugarClient(config))
            {
                db.DbMaintenance.CreateDatabase();
                var types = Assembly
                    .Load("SqlSugarDemo")
                    .GetTypes()
                    .AsEnumerable()
                    .Where(t => t.FullName.StartsWith("SqlSugarDemo.entity")).ToList();
                foreach (var type in types)
                {
                    db
                        .CodeFirst
                        //设置字符串默认长度
                        // .SetStringDefaultLength(200)
                        // 创建表
                        .InitTables(type);
                }
            }
        }
    }
}