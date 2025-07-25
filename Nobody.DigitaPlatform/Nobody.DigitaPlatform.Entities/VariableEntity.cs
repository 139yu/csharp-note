using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Entities
{
    public class VariableEntity
    {

        public int Id { get; set; }
        public string DeviceNum { get; set; }
        public string VarNum { get; set; }
        public string Header { get; set; }
        public string Address { get; set; }
        public double Offset { get; set; }
        public double Modulus { get; set; }
    }
}
