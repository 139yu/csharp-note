using System;
using System.Collections.Generic;
using SqlSugar;
using SqlSugarDemo.entity;

namespace SqlSugarDemo
{
    public class AddDataDemo
    {
        private static ConnectionConfig config = new ConnectionConfig()
        {
            DbType = DbType.MySql,
            ConnectionString =
                "Data Source=127.0.0.1;port=3306;user=root;database=sugar_demo;password=root;Charset=utf8",
            IsAutoCloseConnection = true
        };

        public static void AddData()
        {
            using (var db = new SqlSugarClient(config))
            {
                var user = new SysUser()
                {
                    Username = "root", Password = "root", DeptId = 1, Phone = "178813245", BirthDay = DateTime.Now
                };

                // 删除数据并返回删除行数
                var delCount = db.Deleteable<SysUser>().ExecuteCommand();
                Console.WriteLine($"delete count: {delCount}");
                // 插入数据并返回自增id
                var id = db.Insertable<SysUser>(user).ExecuteReturnIdentity();
                // 插入数据并返回雪花id
                var snowflakeId = db.Insertable(new SysRole() { RoleName = "普通用户" })
                    .ExecuteReturnSnowflakeId();
                // 通过字典插入
                Dictionary<string, object> dict = new Dictionary<string, object>();
                // key与数据库字段一致
                dict.Add("role_name", "超级管理员");
                dict.Add("id", 15);
                // as：对应表名，返回受影响行数
                var rows = db.Insertable(dict).AS("sys_role").ExecuteCommand();
                Console.WriteLine($"return rows: {rows}");
                List<SysRole> roles = new List<SysRole>();
                for (int i = 0; i < 100; i++)
                {
                    roles.Add(new SysRole()
                    {
                        RoleName = "Name_" + i
                    });
                }

                // 优点:综合性能比较平均，列少1万条也不慢，属于万写法,不加事务情况下部分库有失败回滚机质
                // 缺点:数据量超过5万以上占用内存会比较大些，内存小可以用下面2种方式处理
                db.Insertable(roles).ExecuteCommand();
                //使用参数化内部分页插入
                //优点:500条以下速度最快，兼容所有类型和emoji，10万以上的大数据也能跑，就是慢些，内部分批量处理过了
                //缺点:500以上就开始慢了，要加事务才能回滚
                db.Insertable(roles).UseParameter().ExecuteCommand();
                //大数据写入(特色功能:大数据处理上比所有框架都要快30%)
                //优点:1000条以上性能无敌手
                //缺点:不支持数据库默认值， API功能简单， 小数据量并发执行不如普通插入，插入数据越大越适合用这个
                //PageSize表示每批传输10000条数据
                db.Fastest<SysRole>().PageSize(10000).BulkCopy(roles);
            }
        }
    }
}