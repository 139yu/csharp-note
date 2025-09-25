using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    public class RecipeParam
    {
        public float TempHigh { get; set; }
        public float TempLow { get; set; }
        public float HumidityHigh { get; set; }
        public float HumidityLow { get; set; }
        public bool TempAlarmEnable { get; set; }
        public bool HumidityAlarmEnable { get; set; }
    }
}
