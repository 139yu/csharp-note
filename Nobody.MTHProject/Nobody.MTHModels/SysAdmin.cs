using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    public class SysAdmin
    {
        public int? LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd {  get; set; }  
        public bool ParamSet {  get; set; }
        public bool Recipe {  get; set; }
        public bool HistoryLog {  get; set; }
        public bool HistoryTrend {  get; set; }
        public bool UserManage {  get; set; }
    }
}
