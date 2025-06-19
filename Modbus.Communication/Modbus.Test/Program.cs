using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using Modbus.Communication.Common;
using Modbus.Communication.Modbus;

namespace Modbus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ModbusBase modbus = new ModbusAscii("COM1", 9600,8,Parity.None,StopBits.One);
            // ModbusRtu modbus = new ModbusRtu("COM1", 9600,8,Parity.None,StopBits.One);
            
            var readRegisters = modbus.ReadRegisters<ushort>(1,(byte)FuncEnum.ReadHoldingRegister,0,3);
            if (!readRegisters.Status)
            {
                Console.WriteLine(readRegisters.Message);
                return;
            }
            for (var i = 0; i < readRegisters.Data.Count; i++)
            {
                Console.Write($"{readRegisters.Data[i]}，");
            }

            List<ushort> data = new List<ushort>();
            data.Add(12);
            data.Add(13);
            data.Add(14);
            data.Add(15);
            data.Add(16);
            var writeRegisters = modbus.WriteRegisters(1, 0, data);
            if (!writeRegisters.Status)
            {
                Console.WriteLine(writeRegisters.Message);
            }
        }

      
    }
}