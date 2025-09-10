using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Entities
{
    public class ConditionEntity
    {
        public string VarNum { get; set; }
        public string CNum { get; set; }
        public string Operator { get; set; }
        public string CompareValue { get; set; }
        public string AlarmContent { get; set; }
        public List<UnionDeviceEntity> UnionDeviceList { get; set; }
    }
}
