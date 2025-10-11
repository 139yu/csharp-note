using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SqlSugarDemo.entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("student")]
    public partial class Student
    {
           public Student(){


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
           /// Nullable:True
           /// </summary>
           [SugarColumn(ColumnName="stu_name")]           
           public string StuName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(ColumnName="birth_day")]           
           public DateTime? BirthDay {get;set;}

           /// <summary>
           /// Desc:
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="create_time")]           
           public DateTime CreateTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="is_delete")]           
           public int IsDelete {get;set;}

    }
}
