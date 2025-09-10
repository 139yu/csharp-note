using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.DeviceAccess.Base
{
    public class ModbusAddress : CommAddress
    {
        public int FuncCode { get; set; }
        public int Length { get; set; }
        public int StartAddress { get; set; }
        public ModbusAddress()
        {
            
        }
        public ModbusAddress(ModbusAddress modbusAddress) : base(modbusAddress)
        {
            this.FuncCode = modbusAddress.FuncCode;
            this.Length = modbusAddress.Length;
            this.StartAddress = modbusAddress.StartAddress;
        }
    }
}