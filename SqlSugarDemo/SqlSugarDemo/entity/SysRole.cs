using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SqlSugarDemo.entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sys_role")]
    public partial class SysRole
    {
           public SysRole(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,ColumnName="id")]
           public long? Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>
           [SugarColumn(ColumnName="role_name")]           
           public string RoleName {get;set;}

    }
}
