using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHDAL
{
    public class AdminService
    {

        public SysAdmin Login(SysAdmin admin)
        {
            string sql = "select LoginId,LoginName,LoginPwd,ParamSet,Recipe,HistoryLog,HistoryTrend,UserManage from SysAdmin " +
                "where LoginName=@LoginName and LoginPwd=@LoginPwd";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginName",admin.LoginName) ,
                new SqlParameter("@LoginPwd",admin.LoginPwd) ,
            };
            var dataSet = SQLHelper.GetDataSet(sql, sqlParameters);
            if(dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 1)
            {
                var table = dataSet.Tables[0];
                admin.LoginId = Convert.ToInt32(table.Rows[0]["LoginId"]);
                admin.ParamSet = Convert.ToBoolean(table.Rows[0]["ParamSet"]);
                admin.Recipe = Convert.ToBoolean(table.Rows[0]["Recipe"]);
                admin.HistoryLog = Convert.ToBoolean(table.Rows[0]["HistoryLog"]);
                admin.HistoryTrend = Convert.ToBoolean(table.Rows[0]["HistoryTrend"]);
                admin.UserManage = Convert.ToBoolean(table.Rows[0]["UserManage"]);
                return admin;
            }
            return null;
        }

        public SysAdmin Login(string uname,string pwd)
        {
            var admin = SQLSugarHelper.Db.Queryable<SysAdmin>()
                .Where(u => u.LoginName.Equals(uname) && u.LoginPwd.Equals(pwd)).First();
            return admin;
        }
    }
}
