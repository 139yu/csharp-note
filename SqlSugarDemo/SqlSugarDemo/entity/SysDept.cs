using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SqlSugarDemo.entity
{
    ///<summary>
    ///部门
    ///</summary>
    [SugarTable("sys_dept")]
    public partial class SysDept
    {
           public SysDept(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="id")]
           public int Id {get;set;}

           /// <summary>
           /// Desc:部门名称
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="dept_name")]           
           public string DeptName {get;set;}

           /// <summary>
           /// Desc:部门描述
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(ColumnName="dept_desc")]           
           public string DeptDesc {get;set;}

           public void GenerateDesc()
           {
               DeptDesc = "描述：" + DeptName;
           }
    }
}
