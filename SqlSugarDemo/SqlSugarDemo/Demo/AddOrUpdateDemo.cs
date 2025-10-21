using System;
using SqlSugar;
using SqlSugarDemo.entity;

namespace SqlSugarDemo
{
    public class AddOrUpdateDemo
    {
        public static readonly SqlSugarScope db = new SqlSugarScope(new ConnectionConfig()
        {
            DbType = DbType.MySql,
            IsAutoCloseConnection = true,
            ConnectionString = "Data Source=127.0.0.1;port=3306;user=root;database=sugar_demo;password=root;Charset=utf8;AllowLoadLocalInfile=true"
        }, db =>
        {
            db.Aop.OnLogExecuting = (sql, args) =>
            {
                Console.WriteLine(UtilMethods.GetNativeSql(sql,args));
                Console.WriteLine("----------------------------------------------");
            };

        });

        public static void Storageable()
        {
            var stu = new Student()
            {
                Id = 1,
                CreateTime = DateTime.Now
            };
            db.Storageable(stu)
                // id > 0更新数据
                .SplitUpdate(s => s.Item.Id > 0)
                // id == 0插入数据
                .SplitInsert(s => s.Item.Id == 0)
                .ExecuteCommand();
            // 满足更新数据条件，会先判断数据是否存在，存在更新，否则不操作
            stu.Id = 10000;
            stu.StuName = "测试用户";
            db.Storageable(stu)
                // id > 0更新数据
                .SplitUpdate(s => s.Item.Id > 0)
                // id == 0插入数据
                .SplitInsert(s => s.Item.Id == 0)
                .ExecuteCommand();
        }
    }
}