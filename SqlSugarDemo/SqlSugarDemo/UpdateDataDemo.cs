using System;
using System.Collections.Generic;
using System.Diagnostics;
using SqlSugar;
using SqlSugarDemo.entity;

namespace SqlSugarDemo
{
    public class UpdateDataDemo
    {
        public static readonly SqlSugarScope DB = new SqlSugarScope(new ConnectionConfig()
        {
            DbType = DbType.MySql,
            IsAutoCloseConnection = true,
            ConnectionString = "Data Source=127.0.0.1;port=3306;user=root;database=sugar_demo;password=root;Charset=utf8;AllowLoadLocalInfile=true"
        }, db =>
        {
            db.Aop.OnLogExecuting = (sql, args) =>
            {
                // Console.WriteLine(UtilMethods.GetNativeSql(sql,args));
                // Console.WriteLine("----------------------------------------------");
            };

        });

        public static void UpdateData()
        {
            var dept = new SysDept()
            {
                Id = 11045318,
                DeptName = "测试4"
            };
            // 更新所有字段
            var count = DB.Updateable<SysDept>(dept).ExecuteCommand();
            dept = new SysDept()
            {
                Id = 11045318,
            };
            // 只更新修改字段，创建跟踪，字段的修改需要在Tracking方法之后
            DB.Tracking(dept);
            dept.DeptDesc = "按需更新";
            DB.Updateable(dept).ExecuteCommand();
            DB.ClearTracking();
            // 批量更新
            {
                /*List<InsertTable> list = DB.Queryable<InsertTable>()
                    .ToList();
                foreach (var insertTable in list)
                {
                    insertTable.CreateTime = DateTime.Now;
                }

                Stopwatch stopwatch = Stopwatch.StartNew();
                DB.Updateable<InsertTable>(list).ExecuteCommand();
                stopwatch.Stop();
                // 20s
                Console.WriteLine($"批量更新耗时：{stopwatch.ElapsedMilliseconds / 1000}秒");*/
            }
            
            // 大数据批量更新
            {
                /*List<InsertTable> list = DB.Queryable<InsertTable>()
                    .ToList();
                foreach (var insertTable in list)
                {
                    insertTable.CreateTime = DateTime.Now;
                }

                Stopwatch stopwatch = Stopwatch.StartNew();
                DB.Fastest<InsertTable>().BulkUpdate(list);
                stopwatch.Stop();
                // 2s
                Console.WriteLine($"大数据批量更新：{stopwatch.ElapsedMilliseconds / 1000}秒");*/
            }
            // 批量按需更新
            {
                /*List<InsertTable> list = DB.Queryable<InsertTable>().Take(20)
                    .ToList();
                DB.Tracking(list);
                for (var i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    item.InsertName = "New Name" + (i + 1);
                }

                DB.Updateable<InsertTable>(list).ExecuteCommand();*/
            }
            // 忽略某一列不跟新
            {
                var data = new InsertTable() { Id = 1971478668094083081,CreateTime = DateTime.Now,InsertName = "New Name1"};
                DB.Updateable(data).IgnoreColumns(d => new
                {
                    d.CreateTime
                })
                    // 只修改where指定的id
                    .Where(d => d.Id == 1971478668094083078)
                    .ExecuteCommand();
            }
            // 表达式更新
            {
                DB.Updateable<InsertTable>().SetColumns(d => new InsertTable()
                    {
                        CreateTime = DateTime.Now,
                        InsertName = "不知道取啥名"
                    })
                    .Where(it => it.Id == 1971478668089888768)
                    .ExecuteCommand();
            }
        }
        
    }
}