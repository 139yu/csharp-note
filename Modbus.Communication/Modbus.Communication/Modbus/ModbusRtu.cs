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

        public override Result<bool> ReadCoils(byte slave, byte funcCode, ushort start, ushort count)
        {
            ushort resLen = (ushort)(Math.Ceiling(count * 1.0 / 8) + 5);
            List<bool> data = new List<bool>();
            try
            {
                List<byte> bytes = this.Read(slave, funcCode, start, count, resLen);
                int sum = 0;
                for (var i = 0; i < bytes.Count; i++)
                {
                    var temp = bytes[i];
                    for (int j = 0; j < 8; j++)
                    {
                        data.Add((temp & (1 << j)) == 0);
                        sum++;
                        if (sum == count)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return Result<bool>.Failed(e.Message);
            }

            return Result<bool>.Success(data);
        }

        public override Result<T> ReadRegisters<T>(byte slave, byte funcCode, ushort start, ushort count)
        {
            //当前类型字节数
            Type type = typeof(T);
            // 字节数
            int len = Marshal.SizeOf(type);
            //寄存器个数
            int registerCount = count * len / 2;

            List<T> data = new List<T>();
            try
            {
                //120:当前通信库中规定的一个一次性请求数量，这个值只要小于125就行
                for (ushort i = 0; i < registerCount; i += 120)
                {
                    start += i;
                    var realCount = (ushort)Math.Min(registerCount - i, 120);
                    var bytes = this.Read(slave, funcCode, start, realCount, (ushort)(realCount * 2 + 5));
                    Type targetType = typeof(T);
                    Type tBitConverter = typeof(BitConverter);
                    var method = tBitConverter.GetMethods()
                        .FirstOrDefault(m => m.ReturnType == targetType && m.GetParameters().Length == 2);
                    if (method == null)
                    {
                        return Result<T>.Failed("转换数据类型出错：未找到匹配的数据类型转换方法");
                    }

                    for (var j = 0; j < bytes.Count; j += len)
                    {
                        List<byte> temp = new List<byte>(bytes.GetRange(j, len));
                        var realBytes = this.SwitchEndianType(temp);
                        data.Add((T)(method.Invoke(tBitConverter, new object[] { realBytes.ToArray(), 0 })));
                    }
                }
            }
            catch (Exception e)
            {
                return Result<T>.Failed(e.Message);
            }

            return Result<T>.Success(data);
        }
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
                if (!crcValidation.SequenceEqual(dataBytes))
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

        public override Result<bool> WriteCoils(byte slave, ushort start, List<bool> data)
        {
            try
            {
                var writePud = this.CreateWritePUD(slave, (byte)FuncEnum.WriteMultiCoil, start, (ushort)data.Count,
                    (byte)Math.Ceiling(data.Count * 1.0 / 8));
                var valueBytes = new List<byte>();
                int index = 0;
                for (var i = 0; i < data.Count; i++)
                {
                    // 8位为一个字节，设置初始值
                    if (i % 8 == 0)
                    {
                        valueBytes.Add(0x00);
                    }

                    index = valueBytes.Count - 1;
                    if (data[i])
                    {
                        var temp = (byte)(1 << (i % 8));
                        // 异或操作，有一个为1，则返回1
                        valueBytes[index] |= temp;
                    }
                }
                writePud.AddRange(valueBytes);
                Write(writePud);
            }
            catch (Exception e)
            {
                return Result<bool>.Failed(e.Message);
            }
            return Result<bool>.Success();
        }

        public override Result<bool> WriteRegisters<T>(byte slave, ushort start, List<T> data)
        {
            try
            {
                Type targetType = typeof(T);
                var len = Marshal.SizeOf(targetType);
                // len / 2 一个寄存器两个字节
                var writePud = this.CreateWritePUD(slave, (byte)FuncEnum.WriteMultiHoldingRegister, start, (ushort)(data.Count * len / 2), (byte)(len * data.Count));
                for (var i = 0; i < data.Count; i++)
                {
                    dynamic item = data[i];
                    List<byte> valueTemp = new List<byte>(BitConverter.GetBytes(item));
                    var realBytes = this.SwitchEndianType(valueTemp);
                    writePud.AddRange(realBytes);
                }

                Write(writePud);
            }
            catch (Exception e)
            {
                Result<bool>.Failed(e.Message);
            }
            return Result<bool>.Success();
        }
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