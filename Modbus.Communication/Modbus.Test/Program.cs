using System;
using System.Collections.Generic;
using System.IO.Ports;
using Modbus.Communication.Common;
using Modbus.Communication.Modbus;

namespace Modbus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ModbusRtu modbusRtu = new ModbusRtu("COM1", 9600,8,Parity.None,StopBits.One);
            
            var readRegisters = modbusRtu.ReadRegisters<ushort>(1,(byte)FuncEnum.ReadHoldingRegister,0,2);
            Console.WriteLine(readRegisters);
        }
    }
}