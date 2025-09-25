using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    [SugarTable("SysLog")]
    public class SysLog
    {
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
        public int? Id { get; set; }
        /// <summary>
        /// 插入时间
        /// </summary>
        [SugarColumn(ColumnName = "InsertTime")]
        public string InsertTime { get; set; }
        /// <summary>
        /// 日志信息
        /// </summary>
        [SugarColumn(ColumnName = "Note")]
        public string Note { get; set; }
        /// <summary>
        /// 报警类型：触发/消除
        /// </summary>
        [SugarColumn(ColumnName = "AlarmType")]
        public string AlarmType { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        [SugarColumn(ColumnName = "Operator")]
        public string Operator { get; set; }
        /// <summary>
        /// 变量名
        /// </summary>
        [SugarColumn(ColumnName = "VarName")]
        public string VarName { get; set; }
    }
}
