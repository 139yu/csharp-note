using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SqlSugarDemo.entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("insert_table")]
    public partial class InsertTable
    {
           public InsertTable(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,ColumnName="id")]
           public long Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(ColumnName="insert_name")]           
           public string InsertName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(ColumnName="create_time")]           
           public DateTime? CreateTime {get;set;}

    }
}
