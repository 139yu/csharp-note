using Nobody.MTHDAL;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHBLL
{
    public class AdminManager
    {
        private AdminService adminService;

        public AdminManager()
        {
            adminService = new AdminService();
        }

        public SysAdmin Login(SysAdmin admin)
        {
            return adminService.Login(admin);
        }

        public SysAdmin Login(string uname,string pwd)
        {
            return adminService.Login(uname,pwd);
        }

    }
}
