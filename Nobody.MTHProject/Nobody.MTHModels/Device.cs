using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    public class Device
    {
        public string IPAddress { get; set; }
        public int Port { get; set; }

        public List<Group> GroupList { get; set; }
    }
}
