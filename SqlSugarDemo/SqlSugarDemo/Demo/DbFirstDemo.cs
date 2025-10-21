using System.Text;
using SqlSugar;

namespace SqlSugarDemo
{
    public class DbFirstDemo
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

        public static void InitEntity()
        {
            DB.DbFirst
                // 添加SqlSugar特性
                .IsCreateAttribute()
                // 格式化类名、文件名、属性名
                .FormatClassName(FormatName)
                .FormatFileName(FormatName)
                .FormatPropertyName(FormatName)
                // 指定生成文件目录、命名空间
                .CreateClassFile("D:\\code\\githubCode\\csharp-note\\SqlSugarDemo\\SqlSugarDemo\\entity","SqlSugarDemo.entity");
        }

        public static string FormatName(string originName)
        {
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < originName.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(originName[i].ToString().ToUpper());
                }
                else if (originName[i] == '_')
                {
                    continue;
                }
                else if (i > 0 && originName[i - 1] == '_')
                {
                    sb.Append(originName[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(originName[i]);
                }
            }

            return sb.ToString();
        }
    }
}