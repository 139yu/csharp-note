using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.DeviceAccess.Base
{
    public class CommAddress
    {
        public CommAddress()
        {
        }

        public CommAddress(CommAddress commAddress)
        {
            this.VarNum = commAddress.VarNum;
        }

        public string VarNum { get; set; }
        public List<CommAddress> _addresses;

        public List<CommAddress> Variables
        {
            get => _addresses ??= new List<CommAddress>();
            set => _addresses = value;
        }

        public List<byte> valueBytes { get; set; }
    }
}