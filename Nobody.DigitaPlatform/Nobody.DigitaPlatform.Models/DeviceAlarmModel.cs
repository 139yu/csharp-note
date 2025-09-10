using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Models
{
    public class DeviceAlarmModel
    {
        public string AlarmNum { get; set; }
        public string CNum { get; set; }
        public string DNum { get; set; }
        public string VNum { get; set; }
        public string AlarmContent { get; set; }
        public string DateTime { get; set; }
        public int Level { get; set; }
        public int State { get; set; }
    }
}
