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

        public SysAdmin Login(string uname,string pwd)
        {
            return adminService.Login(uname,pwd);
        }

        public List<SysAdmin> GetAdminList()
        {
            return adminService.GetAll();
        }

        public int Add(SysAdmin admin)
        {
            return adminService.Add(admin);
        }

        public bool Update(SysAdmin admin)
        {
            return adminService.Update(admin);
        }

        public bool Delete(int id)
        {
            return adminService.Delete(id);
        }
    }
}
