# SqlSugar

## DBFirst

```C#
internal class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConnectionConfig()
            {
                ConnectionString =
                    "server=127.0.0.1;port=3306;database=sqlsugar_demo;uid=root;pwd=123456;Charset=utf8;",
                IsAutoCloseConnection = true, DbType = DbType.MySql
            };
            using (SqlSugarClient db = new SqlSugarClient(config))
            {
                db.DbFirst.
                    // SqlSugar特性
                    IsCreateAttribute()
                    // 格式化文件名
                    .FormatFileName(FormatName)
                    // 格式化类名
                    .FormatClassName(FormatName)
                    .FormatPropertyName(FormatName)
                    //筛选表名
                    .Where(t => t.StartsWith("sys"))
                    // 带有默认值
                    .IsCreateDefaultValue()
                    // 可空类型
                    .StringNullable()
                    //自定义生成的实体类的模板
                    .SettingClassTemplate(t => t)
                    //自定义生成的实体类中构造函数的模板
                    .SettingConstructorTemplate(t => t)
                    //自定义生成的实体类中属性注释（摘要）的模板
                    .SettingPropertyDescriptionTemplate(t => t)
                    //自定义生成的实体类中每个属性的模板
                    // columnInfo：字段元信息/// temp：默认模板字符串/// targetType：映射类型
                    .SettingPropertyTemplate((columnInfo, temp, targetType) =>
                    {
                        return temp;
                    })
                    // 指定生成路径与命名空间
                    .CreateClassFile("G:\\Code\\C#\\SqlSugarDemo\\SqlSugarDemo\\Models",
                        "SqlSugarDemo.Models");
            }
        }

        /// <summary>
        /// 将字符串转成驼峰写法（sys_user --> SysUser）
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string FormatName(string name)
        {
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if (i == 0)
                {
                    sb.Append(c.ToString().ToUpper());
                }
                else if (name[i] == '_')
                {
                }
                else if (name[i - 1] == '_')
                {
                    sb.Append(c.ToString().ToUpper());
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
```

## CodeForst

需要配合SqlSugar的特性来使用，见[官网](https://www.donet5.com/Doc/1/1182)

```c#
public class CodeFirstDemo
    {
        public static void Init()
        {
            var config = new ConnectionConfig()
            {
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                ConnectionString =
                    "server=127.0.0.1;port=3306;user=root;password=123456;database=sqlsugar_codefirst;Charset=utf8;",
            };
            using (var db = new SqlSugarClient(config))
            {
                // 如果数据库不存在自动创建；不会重复创建；oracle和个别国产数据库不支持
                db.DbMaintenance.CreateDatabase();
                db
                    .CodeFirst
                    //设置字符串默认长度
                    // .SetStringDefaultLength(200)
                    // 创建表
                    .InitTables<SysUser>();
                // 使用反射批量创建表
                var types = Assembly
                    .Load("SqlSugarDemo")
                    .GetTypes()
                    .AsEnumerable()
                    .Where(t => t.FullName.StartsWith("SqlSugarDemo.Models")).ToList();
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
```

```C#
[SugarTable("sys_user")]
    // 唯一索引
    [SugarIndex("idx_un",nameof(SysUser.Username),OrderByType.Asc,true)]
    // 普通索引，{table}：占位符，还有{db}
    [SugarIndex("{table}_idx_rn",nameof(SysUser.RealName),OrderByType.Asc,false)]
    // 复合索引
    [SugarIndex("idx_urn",nameof(SysUser.Username),OrderByType.Asc,nameof(SysUser.RealName),OrderByType.Asc)]
    public partial class SysUser
    {
           public SysUser(){

            this.Gender =Convert.ToInt32("0");

           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="id")]
           public int Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="username")]           
           public string Username {get;set;} = null;

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(ColumnName="real_name",IsNullable = true)]           
           public string RealName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="password")]           
           public string Password {get;set;} = null;

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(ColumnName="dept_id")]           
           public int? DeptId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="gender")]           
           public int Gender {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(ColumnName="birthday")]           
           public DateTime? Birthday {get;set;}

    }
```

## 库表操作

`db.DbMaintenance`对象提供了对数据库、表、字段的操作的一系列方法。

## 增删改

插入数据，见[官网](https://www.donet5.com/Doc/1/1193)