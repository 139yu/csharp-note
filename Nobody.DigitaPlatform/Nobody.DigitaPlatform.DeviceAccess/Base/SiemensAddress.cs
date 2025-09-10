using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.DeviceAccess.Base
{
    internal class SiemensAddress : CommAddress
    {
        public SiemensAreaTypes AreaType { get; set; }
        public int DBNumber { get; set; }
        public int ByteAddress { get; set; }
        public byte BitAddress { get; set; }
        /// <summary>
        /// 读取字节数
        /// </summary>
        public int ByteCount { get; set; }
        public SiemensAddress()
        {
        }

        public SiemensAddress(SiemensAddress siemensAddress) : base(siemensAddress)
        {
            this.AreaType = siemensAddress.AreaType;
            this.DBNumber = siemensAddress.DBNumber;
            this.ByteAddress = siemensAddress.ByteAddress;
            this.BitAddress = siemensAddress.BitAddress;
            this.ByteCount = siemensAddress.ByteCount;
        }
    }
}