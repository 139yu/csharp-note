using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using SqlSugar;
using SqlSugarDemo.entity;

namespace SqlSugarDemo
{
    [TestFixture]
    public class SingleTableQueryDemo
    {
        public static readonly SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig()
        {
            DbType = DbType.MySql,
            IsAutoCloseConnection = true,
            ConnectionString =
                "Data Source=127.0.0.1;port=3306;user=root;database=sugar_demo;password=123456;Charset=utf8;AllowLoadLocalInfile=true"
        }, db =>
        {
            db.Aop.OnLogExecuting = (sql, args) =>
            {
                Console.WriteLine(UtilMethods.GetNativeSql(sql, args));
                Console.WriteLine("----------------------------------------------");
            };
        });

        public void InitData()
        {
            var types = Assembly
                .Load("SqlSugarDemo")
                .GetTypes()
                .AsEnumerable()
                .Where(t => t.FullName.StartsWith("SqlSugarDemo.entity")).ToList();
            foreach (var type in types)
            {
                Db
                    .CodeFirst
                    //设置字符串默认长度
                    // .SetStringDefaultLength(200)
                    // 创建表
                    .InitTables(type);
            }

            List<SysUser> users = new List<SysUser>();
            for (int i = 0; i < 500; i++)
            {
                users.Add(new SysUser()
                {
                    Username = "用户-" + (i + 1),
                    Password = "123456",
                    DeptId = i % 5,
                    Phone = "123456",
                    BirthDay = DateTime.Now.AddYears(-i)
                });
            }

            Db.Insertable<SysUser>(users).ExecuteCommand();
        }

        [Test]
        public void QueryFirst()
        {
            Db.Queryable<SysUser>()
                .Where(u => u.Username.Equals("用户-1") && u.Password.Equals("123456"))
                .ToList();
            Db.Queryable<SysUser>()
                .Where(u => u.Username.Equals("用户-1"))
                .Where(u => u.Password.Equals("123456"))
                .ToList();
        }

        [Test]
        public void QueryExpress()
        {
            string password = "1234";
            string username = "用户-2";
            // 动态拼接条件
            Expressionable<SysUser> exp = new Expressionable<SysUser>();
            exp.AndIF(!string.IsNullOrEmpty(password), u => u.Password.Equals(password));
            exp.AndIF(!string.IsNullOrEmpty(username), u => u.Username.Equals(username));
            Db.Queryable<SysUser>()
                .Where(exp.ToExpression())
                // 排除某一个字段，只支持单表
                .IgnoreColumns(u => u.Username)
                .ToList();
        }
    }
}