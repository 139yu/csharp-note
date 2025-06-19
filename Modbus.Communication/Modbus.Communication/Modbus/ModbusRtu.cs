using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Modbus.Communication.Common;
using Modbus.Communication.Component;

namespace Modbus.Communication.Modbus
{
    public class ModbusRtu : ModbusBase
    {
        public EndianType EndianType { get; set; } = EndianType.AB;

        public ModbusRtu(string portName, int baudRate, int dataBit, Parity parity, StopBits stopBits,
            int readTimeout = 50)
        {
            this.CommunicationUnit = new Serial(portName, baudRate, dataBit, parity, stopBits, readTimeout);
        }

        #region 读操作

        protected override List<byte> Read(byte slave, byte funcCode, ushort start, ushort count, ushort respLen)
        {
            List<byte> dataBytes = CreateReadPUD(slave, funcCode, start, count);
            CRC16(dataBytes);
            var result = this.CommunicationUnit.Open(100);
            if (result.Status)
            {
                var receiveResult = this.CommunicationUnit.SendAndReceive(dataBytes, respLen, 5);
                if (!receiveResult.Status)
                {
                    throw new Exception(receiveResult.Message);
                }

                var crcValidation = receiveResult.Data.GetRange(0, receiveResult.Data.Count - 2);
                CRC16(crcValidation);
                if (!crcValidation.SequenceEqual(receiveResult.Data))
                {
                    throw new Exception("crc校验失败！");
                }

                if (receiveResult.Data[1] > 0x80)
                {
                    byte errorCode = receiveResult.Data[2];
                    throw new Exception(Errors[errorCode]);
                }

                List<byte> datas = receiveResult.Data.GetRange(3, receiveResult.Data.Count - 5);
                return datas;
            }

            throw new Exception(result.Message);
        }

        #endregion

        #region 写操作

       
        protected override void Write(List<byte> writePud)
        {
            CRC16(writePud);
            var openResult = this.CommunicationUnit.Open(100);
            if (!openResult.Status)
            {
                throw new Exception(openResult.Message);
            }

            var receive = this.CommunicationUnit.SendAndReceive(writePud, 8, 5);
            if (!receive.Status)
            {
                throw new Exception(receive.Message);
            }

            var crcValidation = receive.Data.GetRange(0, receive.Data.Count - 2);
            CRC16(crcValidation);
            if (!receive.Data.SequenceEqual(crcValidation))
            {
                throw new Exception("CRC校验检查不匹配");
            }

            if (receive.Data[1] > 0x80)
            {
                byte errorCode = receive.Data[2];
                throw new Exception(Errors[errorCode]);
            }
        }

        #endregion
        

        
        void CRC16(List<byte> value, ushort poly = 0xA001, ushort crcInit = 0xFFFF)
        {
            if (value == null || !value.Any())
                throw new ArgumentException("");

            //运算
            ushort crc = crcInit;
            for (int i = 0; i < value.Count; i++)
            {
                crc = (ushort)(crc ^ (value[i]));
                for (int j = 0; j < 8; j++)
                {
                    crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ poly) : (ushort)(crc >> 1);
                }
            }

            byte hi = (byte)((crc & 0xFF00) >> 8); //高位置
            byte lo = (byte)(crc & 0x00FF); //低位置

            value.Add(lo);
            value.Add(hi);
        }
    }
}