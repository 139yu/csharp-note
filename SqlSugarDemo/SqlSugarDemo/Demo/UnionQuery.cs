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
    public class UnionQuery
    {
        public static readonly SqlSugarScope DB = new SqlSugarScope(new ConnectionConfig()
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

        [Test]
        public void InitData()
        {
            var types = Assembly.Load("SqlSugarDemo")
                .GetTypes()
                .AsEnumerable()
                .Where(t => t.FullName.StartsWith("SqlSugarDemo.entity"));
            foreach (var type in types)
            {
                DB.CodeFirst
                    .InitTables(type);
            }

            List<DeviceBrand> brands = new List<DeviceBrand>()
            {
                new DeviceBrand() { BrandName = "小安" },
                new DeviceBrand() { BrandName = "纵行" },
                new DeviceBrand() { BrandName = "泰比特" }
            };
            DB.Insertable<DeviceBrand>(brands).ExecuteCommand();
            var random = new Random();
            List<Device> devices = new List<Device>();
            for (int i = 0; i < 500; i++)
            {
                devices.Add(new Device()
                {
                    DevCode = random.Next(90000000, 99999999).ToString(),
                    BrandId = random.Next(0, 3),
                });
            }

            DB.Insertable<Device>(devices).ExecuteCommand();
        }

        [Test]
        public void Query()
        {
            var list = DB.Queryable<Device>()
                .LeftJoin<DeviceBrand>((d,b) => d.BrandId == b.Id)
                .Where(d => d.BrandId == 2)
                .Select((d,b) => new {DevId = d.Id,DevCode = d.DevCode,BrandName = b.BrandName})
                .ToList();
            Console.WriteLine(list);
        }
    }
}