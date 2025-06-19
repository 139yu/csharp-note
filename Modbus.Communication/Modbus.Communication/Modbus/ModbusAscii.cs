using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using Modbus.Communication.Common;
using Modbus.Communication.Component;

namespace Modbus.Communication.Modbus
{
    public class ModbusAscii : ModbusBase
    {
        public ModbusAscii(string portName, int baudRate, int dataBit, Parity parity, StopBits stopBits,
            int readTimeout = 50)
        {
            this.CommunicationUnit = new Serial(portName, baudRate, dataBit, parity, stopBits, readTimeout);
        }
        //30 31 30 33 30 36 30 30 30 31 30 30 30 32 30 30 30 33 46 30 0D 0A

        protected override List<byte> Read(byte slave, byte funcCode, ushort start, ushort count, ushort respLen)
        {
            var readPud = this.CreateReadPUD(slave, funcCode, start, count);
            var lrc = LRC(readPud);
            readPud.Add(lrc);
            var asciiPud = string.Join("", readPud.Select(b => b.ToString("X2")).ToList());
            StringBuilder sb = new StringBuilder();
            sb.Append(":");
            sb.Append(asciiPud);
            sb.Append("\r\n");
            var asciiBytes = Encoding.ASCII.GetBytes(sb.ToString());

            var openResult = this.CommunicationUnit.Open(100);
            if (!openResult.Status)
            {
                throw new Exception(openResult.Message);
            }

            // resLen：RTU长度 从站地址 1 + 功能码 1 + 字节数 1 + CRC16 2
            // ascii：从站地址 1 + 功能码 1 + LRC 1
            var receive = this.CommunicationUnit.SendAndReceive(asciiBytes.ToList(), (respLen - 1) * 2 + 3, 6);
            if (!receive.Status)
            {
                throw new Exception(receive.Message);
            }

            var receiveData = receive.Data;
            var asciiStr = Encoding.ASCII.GetString(receiveData.ToArray(), 0, receiveData.Count);
            List<byte> bytes = new List<byte>();
            for (var i = 1; i < asciiStr.Length - 2; i += 2)
            {
                string temp = asciiStr[i].ToString() + asciiStr[i + 1].ToString();
                bytes.Add(Convert.ToByte(temp, 16));
            }

            List<byte> lrcValidation = new List<byte>(bytes.GetRange(0, bytes.Count - 1));
            lrcValidation.Add(LRC(lrcValidation));
            if (!lrcValidation.SequenceEqual(bytes))
            {
                throw new Exception("LRC校验失败");
            }

            if (bytes[1] > 0x80)
            {
                var errorCode = bytes[2];
                throw new Exception(Errors[errorCode]);
            }

            return bytes.GetRange(3, bytes.Count - 4);
        }

        protected override void Write(List<byte> writePud)
        {
            var lrc = LRC(writePud);
            writePud.Add(lrc);
            var pduStr = string.Join("", writePud.Select(b => b.ToString("X2")).ToList());
            StringBuilder sb = new StringBuilder();
            sb.Append(":");
            sb.Append(pduStr);
            sb.Append("\r\n");
            var openResult = this.CommunicationUnit.Open(100);
            if (!openResult.Status)
            {
                throw new Exception(openResult.Message);
            }

            var asciiPdw = Encoding.ASCII.GetBytes(sb.ToString());
            var receive = this.CommunicationUnit.SendAndReceive(asciiPdw.ToList(), 7 * 2 + 3,4 * 2 + 3);
            if (!receive.Status)
            {
                throw new Exception(receive.Message);
            }

            List<byte> dataBytes = new List<byte>();
            var asciiStr = Encoding.ASCII.GetString(receive.Data.ToArray());
            for (var i = 1; i < asciiStr.Length - 2; i += 2)
            {
                var temp = asciiStr[i].ToString() + asciiStr[i + 1].ToString();
                dataBytes.Add(Convert.ToByte(temp,16));
            }

            var lrcValidation = dataBytes.GetRange(0, dataBytes.Count - 1);
            this.LRC(lrcValidation);
            if (!lrcValidation.SequenceEqual(dataBytes))
            {
                throw new Exception("LRC校验检查不匹配");
            }
            if (dataBytes[1] > 0x80)
            {
                byte errorCode = dataBytes[2];
                throw new Exception(Errors[errorCode]);
            }
        }

        private byte LRC(List<byte> data)
        {
            byte lrc = 0;
            foreach (byte b in data)
            {
                lrc += b;
            }

            return (byte)((lrc ^ 0xFF) + 1);
        }
    }
}