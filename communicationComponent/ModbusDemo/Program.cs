using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using Modbus.Device;

namespace ModbusDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SerialPort sp = new SerialPort("COM1", 9600,Parity.None, 8, StopBits.One);
            sp.Open();
            ModbusMaster master = ModbusSerialMaster.CreateRtu(sp);
            var readHoldingRegisters = master.ReadHoldingRegisters(1,0,2);
            foreach (var readHoldingRegister in readHoldingRegisters)
            {
                Console.WriteLine(readHoldingRegister);
            }

            Console.WriteLine("-----------");
            master.WriteSingleRegister(1,1,22);
            readHoldingRegisters = master.ReadHoldingRegisters(1,0,2);
            foreach (var readHoldingRegister in readHoldingRegisters)
            {
                Console.WriteLine(readHoldingRegister);
            }*/
            SerialPort sp = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            sp.Open();
            // ModbusMaster master = ModbusSerialMaster.CreateRtu(sp);
            // master.ReadHoldingRegisters(1, 0, 1);
            // ReadSingleRegister(sp);
            CreateASCII(sp);
            sp.Dispose();
        }

        public static void ReadSingleRegister(SerialPort sp)
        {
            List<byte> data = new List<byte>();
            data.Add(0x01); //从站地址
            data.Add(0x01); //功能码
            data.Add(0x00); //寄存器地址
            data.Add(0x00);
            data.Add(0x00); //读取长度
            data.Add(0x01);
            var crc16Bytes = Crc16.ComputeChecksum(data);
            data.Add(crc16Bytes[1]);
            data.Add(crc16Bytes[0]);
            sp.Write(data.ToArray(), 0, data.Count);
            var id = new byte[1];
            sp.Read(id, 0, 1);
            var code = new byte[1];
            sp.Read(code, 0, 1);
            var err = new byte[1];
            sp.Read(err, 0, 1);
            Console.WriteLine(11);
        }

        public static void CreateASCII(SerialPort sp)
        {
            List<byte> data = new List<byte>();
            data.Add(0x01); // 从站地址
            data.Add(0x03); // 功能码
            data.Add(0x00); // 寄存器地址高位
            data.Add(0x01); // 寄存器地址低位
            data.Add(0x00); // 寄存器数量高位
            data.Add(0x01); // 寄存器数量低位

            // 构造ASCII报文
            StringBuilder sb = new StringBuilder();
            sb.Append(":");
            foreach (byte b in data)
            {
                sb.Append(b.ToString("X2")); // 正确：将字节转为大写十六进制字符串
            }

            // 计算LRC时传入原始字节数组，而非十六进制字符串！
            string lrc = CalculateLRC(data.ToArray());
            sb.Append(lrc).Append("\r\n");

            // 发送报文
            byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());
            sp.Write(bytes, 0, bytes.Length);
        }


        public static string CalculateLRC(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                throw new ArgumentException("输入数据不能为空");

            byte sum = 0;
            foreach (byte b in bytes)
            {
                sum += b;
            }
            byte lrc = (byte)(-sum); // 直接取补码
            return lrc.ToString("X2");
        }

// 辅助方法：验证是否为合法十六进制字符
        private static bool IsValidHex(string hex)
        {
            return hex.Length == 2 &&
                   Uri.IsHexDigit(hex[0]) &&
                   Uri.IsHexDigit(hex[1]);
        }
    }
}