using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                "Data Source=127.0.0.1;port=3306;user=root;database=sugar_demo;password=root;Charset=utf8;AllowLoadLocalInfile=true",
            IsAutoCloseConnection = true,
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
            }
        }

        /// <summary>
        /// 插入数据效率比较
        /// </summary>
        public static void CompareInsert()
        {
            using (var db = new SqlSugarClient(config))
            {
                List<SysDept> depts = new List<SysDept>();
                for (int i = 0; i < 1000000; i++)
                {
                    depts.Add(new SysDept()
                    {
                        DeptName = "Name_" + i
                    });
                }

                // 优点:综合性能比较平均，列少1万条也不慢，属于万写法,不加事务情况下部分库有失败回滚机质
                // 缺点:数据量超过5万以上占用内存会比较大些，内存小可以用下面2种方式处理
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                db.Insertable(depts).ExecuteCommand();
                stopwatch.Stop();
                Console.WriteLine($"普通方式插入1000000数据大概用时：${stopwatch.ElapsedMilliseconds / 1000}秒");
                //使用参数化内部分页插入
                //优点:500条以下速度最快，兼容所有类型和emoji，10万以上的大数据也能跑，就是慢些，内部分批量处理过了
                //缺点:500以上就开始慢了，要加事务才能回滚
                db.Deleteable<SysDept>().ExecuteCommand();
                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();
                db.Insertable(depts).UseParameter().ExecuteCommand();
                stopwatch1.Stop();
                Console.WriteLine($"参数化方式插入1000000数据大概用时：{stopwatch1.ElapsedMilliseconds / 1000}秒");
                //大数据写入(特色功能:大数据处理上比所有框架都要快30%)
                //优点:1000条以上性能无敌手
                //缺点:不支持数据库默认值， API功能简单， 小数据量并发执行不如普通插入，插入数据越大越适合用这个
                //PageSize表示每批传输10000条数据
                db.Deleteable<SysDept>().ExecuteCommand();
                Stopwatch stopwatch2 = new Stopwatch();
                stopwatch2.Start();
                db.Fastest<SysDept>().PageSize(10000).BulkCopy(depts);
                stopwatch2.Stop();
                Console.WriteLine($"分页方式插入1000000数据大概用时：${stopwatch2.ElapsedMilliseconds / 1000}秒");
            }
        }

        /// <summary>
        /// 调用实体内方法
        /// </summary>
        public static void CallEntityMethod()
        {
            using (var db = new SqlSugarClient(config))
            {
                db.Insertable(new SysDept()
                {
                    DeptName = "测试1"
                }).CallEntityMethod(d => d.GenerateDesc()).ExecuteCommand();
            }
        }

        /// <summary>
        /// 插入临时表
        /// </summary>
        public static void InsertTempTable()
        {
            using (var db = new SqlSugarClient(config))
            {
                // 长连接，确保临时表在同一个会话中可用
                db.Ado.OpenAlways();
                db.Ado.ExecuteCommand("CREATE TEMPORARY TABLE IF NOT EXISTS temp LIKE sys_user");
                db.Ado.ExecuteCommand("insert into temp select * from sys_user");
                var tempList = db.Queryable<dynamic>().AS("temp").ToList();
                Console.WriteLine(tempList);
            }
        }

        public static void Insert()
        {
            List<InsertTable> list = new List<InsertTable>();
            for (int i = 0; i < 100000; i++)
            {
                list.Add(new InsertTable()
                {
                    Id = SnowFlakeSingle.instance.NextId(),
                    InsertName = "插入顺序" + (i+ 1),
                    CreateTime = DateTime.Now
                });
            }

            using (var db = new SqlSugarClient(config))
            {
                db.Fastest<InsertTable>().PageSize(100000).BulkCopy(list);
            }
        }
    }
}