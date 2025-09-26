using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHDAL
{
    public class AdminService : BaseDal<SysAdmin>
    {
        public SysAdmin Login(string uname,string pwd)
        {
            var admin = SQLSugarHelper.Db.Queryable<SysAdmin>()
                .Where(u => u.LoginName.Equals(uname) && u.LoginPwd.Equals(pwd)).First();
            return admin;
        }

    }
}
