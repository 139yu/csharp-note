using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Entities
{
    public class PropertyEntity
    {
        public int Id { get; set; }
        public string PropHeader { get; set; }
        public string PropName { get; set; }
        public string PropType { get; set; } // 0:文本框；1:下拉框
    }
}