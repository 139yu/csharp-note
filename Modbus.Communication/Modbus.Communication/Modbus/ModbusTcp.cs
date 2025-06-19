using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Modbus.Communication.Common;
using Modbus.Communication.Component;

namespace Modbus.Communication.Modbus
{
    public class ModbusTcp : ModbusBase
    {
        public ModbusTcp(string ip, int port = 502, int readTimeout = 50)
        {
            this.CommunicationUnit = new Ethernet(ip, port, readTimeout);
        }

        private int txId = 0;

        #region 读操作

        protected override List<byte> Read(byte slave, byte funcCode, ushort start, ushort count, ushort respLen)
        {
            var dataBytes = this.CreateReadPUD(slave, funcCode, start, count);
            var tcpBytes = new List<byte>();
            txId++;
            txId %= 65535;
            tcpBytes.Add((byte)(txId / 255)); //事务标识符
            tcpBytes.Add((byte)(txId % 255));
            tcpBytes.Add(0x00); //协议标识符
            tcpBytes.Add(0x00);
            tcpBytes.Add((byte)(dataBytes.Count / 255)); //后续字节数
            tcpBytes.Add((byte)(dataBytes.Count % 255));
            tcpBytes.AddRange(dataBytes);
            var result = this.CommunicationUnit.Open(100);
            if (!result.Status)
            {
                throw new Exception(result.Message);
            }

            var receive = this.CommunicationUnit.SendAndReceive(tcpBytes, 0, 0);
            if (!receive.Status)
            {
                throw new Exception(receive.Message);
            }

            // 移除tcp头
            var receiveData = receive.Data;
            receiveData.RemoveRange(0, 6);
            if (receiveData[1] > 0x80)
            {
                byte errorCode = receiveData[2];
                throw new Exception(Errors[errorCode]);
            }

            return receiveData.GetRange(3, receiveData.Count - 3);
        }

        #endregion

        #region 写操作

        protected override void Write(List<byte> writePud)
        {
            List<byte> tcpBytes = new List<byte>();
            txId++;
            txId %= 65536;
            //事务标识符
            tcpBytes.Add((byte)(txId / 256));
            tcpBytes.Add((byte)(txId % 256));
            //协议标识符
            tcpBytes.Add(0x00);
            tcpBytes.Add(0x00);
            //长度字段
            tcpBytes.Add((byte)(writePud.Count / 256));
            tcpBytes.Add((byte)(writePud.Count % 256));

            tcpBytes.AddRange(writePud);
            var openResult = this.CommunicationUnit.Open(100);
            if (!openResult.Status)
            {
                throw new Exception(openResult.Message);
            }

            var receive = this.CommunicationUnit.SendAndReceive(tcpBytes, 0, 0);
            if (!receive.Status)
            {
                throw new Exception(receive.Message);
            }

            //去除tcp头
            receive.Data.RemoveRange(0, 6);
            var receiveData = receive.Data;
            if (receiveData[1] > 0x80)
            {
                byte errorCode = receiveData[2];
                throw new Exception(Errors[errorCode]);
            }
        }

        #endregion
    }
}