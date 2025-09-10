using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false,Inherited = false)]
    public class ExcelColumn: Attribute
    {
        public string Column { get; set; }
        public int Sort { get; set; }
        public ExcelColumn(string column, int sort = 0)
        {
            this.Column = column;
            Sort = sort;
        }
    }
}
