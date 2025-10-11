using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    [SugarTable("SysAdmin")]
    public class SysAdmin
    {
        [SugarColumn(ColumnName ="LoginId",IsPrimaryKey =true,IsIdentity =true)]
        public int? LoginId { get; set; }
        [SugarColumn(ColumnName ="LoginName")]
        public string LoginName { get; set; }
        [SugarColumn(ColumnName = "LoginPwd")]
        public string LoginPwd {  get; set; }
        [SugarColumn(ColumnName = "ParamSet")]
        public bool ParamSet {  get; set; }
        [SugarColumn(ColumnName = "Recipe")]
        public bool Recipe {  get; set; }
        [SugarColumn(ColumnName = "HistoryLog")]
        public bool HistoryLog {  get; set; }
        [SugarColumn(ColumnName = "HistoryTrend")]
        public bool HistoryTrend {  get; set; }
        [SugarColumn(ColumnName = "UserManage")]
        public bool UserManage {  get; set; }
    }
}
