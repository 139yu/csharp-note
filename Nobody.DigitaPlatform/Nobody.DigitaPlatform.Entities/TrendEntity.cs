using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Entities
{
    public class TrendEntity
    {
        public string TNum { get; set; }
        public string TrendHeader { get; set; }

        public bool ShowLegend { get; set; }
        public List<TrendAxisEntity> TrendAxisList { get; set; }
        public List<TrendSeriesEntity> Series { get; set; }
    }
}