using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SqlSugarDemo.entity
{
    ///<summary>
    ///用户信息表
    ///</summary>
    [SugarTable("sys_user")]
    public partial class SysUser
    {
           public SysUser(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="id")]
           public int Id {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="username")]           
           public string Username {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="password")]           
           public string Password {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="phone")]           
           public string Phone {get;set;}

           /// <summary>
           /// Desc:部门ID
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="dept_id")]           
           public int DeptId {get;set;}

           /// <summary>
           /// Desc:出生时间
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="birth_day")]           
           public DateTime BirthDay {get;set;}

    }
}
