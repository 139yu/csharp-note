using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    public class CommonMethods
    {
        public static Device Device { get; set; }

        public static Action<int,string> AddLogAction { get; set; }
    }
}
