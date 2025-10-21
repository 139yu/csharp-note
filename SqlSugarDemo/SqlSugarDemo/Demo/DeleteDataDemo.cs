using System;
using System.Collections.Generic;
using SqlSugar;
using SqlSugarDemo.entity;

namespace SqlSugarDemo
{
    public class DeleteDataDemo
    {
        public static readonly SqlSugarScope DB = new SqlSugarScope(new ConnectionConfig()
        {
            DbType = DbType.MySql,
            IsAutoCloseConnection = true,
            ConnectionString = "Data Source=127.0.0.1;port=3306;user=root;database=sugar_demo;password=root;Charset=utf8;AllowLoadLocalInfile=true"
        }, db =>
        {
            // 全局过滤器
            // db.QueryFilter.Add(new TableFilterItem<Student>(s => s.IsDelete == 0));
            db.Aop.OnLogExecuting = (sql, args) =>
            {
                Console.WriteLine(UtilMethods.GetNativeSql(sql,args));
                Console.WriteLine("----------------------------------------------");
            };

        });

        static DeleteDataDemo()
        {
            DB.DbMaintenance.TruncateTable<Student>();
            List<Student> students = new List<Student>();
            var random = new Random(5);
            for (int i = 0; i < 500; i++)
            {
                students.Add(new Student()
                {
                    StuName = "stu-name-" + i,
                    BirthDay = DateTime.Now.AddYears(-random.Next(0,20)),
                });
            }

            DB.Insertable(students).IgnoreColumns(d => new
            {
                d.CreateTime,d.IsDelete
            }).ExecuteCommand();
        }

        public static void DeleteDemo()
        {
            DB.Deleteable<Student>().Where(s => s.Id == 1).ExecuteCommand();

            DB.Deleteable<Student>().In(new int[]{1,3,4,}).ExecuteCommand();

            DB.Deleteable<Student>().In(s => s.Id, 5).ExecuteCommand();

            DB.Deleteable<object>().AS("Student").Where("id=@id", new { id = 20 }).ExecuteCommand();
        }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        public static void LogicDelete()
        {
            
            DB.Deleteable<Student>().Where(s => s.Id == 40)
                // 实体类中需要有IsDelete或IsDeleted字段
                .IsLogic()
                .ExecuteCommand();

            DB.Deleteable<Student>().Where(s => s.Id == 2)
                .IsLogic()
                // 指定逻辑删除字段，删除值，以及删除时间字段
                .ExecuteCommand("IsDelete", 1, "CreateTime");
        }
    }
}