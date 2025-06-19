using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Modbus.Communication.Common;
using Modbus.Communication.Component;

namespace Modbus.Communication.Modbus
{
    public abstract class ModbusBase
    {
        public EndianType EndianType { get; set; } = EndianType.BA;
        public ICommunicationUnit CommunicationUnit { get; set; }

        protected static Dictionary<int, string> Errors = new Dictionary<int, string>
        {
            { 0x01, "非法功能码" },
            { 0x02, "非法数据地址" },
            { 0x03, "非法数据值" },
            { 0x04, "从站设备故障" },
            { 0x05, "确认，从站需要一个耗时操作" },
            { 0x06, "从站忙" },
            { 0x08, "存储奇偶性差错" },
            { 0x0A, "不可用网关路径" },
            { 0x0B, "网关目标设备响应失败" },
        };

        #region 基方法

        /// <summary>
        /// 创建读取报文
        /// </summary>
        /// <param name="slave"></param>
        /// <param name="funcCode"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<byte> CreateReadPUD(byte slave, byte funcCode, ushort start, ushort count)
        {
            List<byte> data = new List<byte>();
            data.Add(slave);
            data.Add(funcCode);
            var startBytes = BitConverter.GetBytes(start);
            data.Add(startBytes[1]);
            data.Add(startBytes[0]);
            var countBytes = BitConverter.GetBytes(count);
            data.Add(countBytes[1]);
            data.Add(countBytes[0]);
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slave">从站地址</param>
        /// <param name="funcCode">功能码</param>
        /// <param name="start">起始地址</param>
        /// <param name="count">写入数量</param>
        /// <param name="bytesCount">后续字节总数，不包含CRC</param>
        /// <returns></returns>
        public List<byte> CreateWritePUD(byte slave, byte funcCode, ushort start, ushort count, byte bytesCount)
        {
            List<byte> data = new List<byte>();
            data.Add(slave);
            data.Add(funcCode);
            byte startHi = (byte)(start / 255);
            var startLo = (byte)(start % 255);
            data.Add(startHi);
            data.Add(startLo);
            var countHi = (byte)(count / 255);
            var countLo = (byte)(count % 255);
            data.Add(countHi);
            data.Add(countLo);
            data.Add(bytesCount);
            return data;
        }

        #endregion

        #region 虚方法

        /// <summary>
        /// 读线圈状态（输入线圈、输出线圈）
        /// </summary>
        /// <param name="slave">从站设备</param>
        /// <param name="funcCode">功能码</param>
        /// <param name="start">起始地址</param>
        /// <param name="count">读寄存器数量</param>
        /// <returns></returns>
        public virtual ModBudResult<bool> ReadCoils(byte slave, byte funcCode, ushort start, ushort count)
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
                return ModBudResult<bool>.Failed(e.Message);
            }

            return ModBudResult<bool>.Success(data);
        }

        /// <summary>
        /// 读寄存器（输入寄存器、保持寄存器）
        /// </summary>
        /// <param name="slave">从站设备</param>
        /// <param name="funcCode">功能码</param>
        /// <param name="start">起始地址</param>
        /// <param name="count">读寄存器数量</param>
        /// <returns></returns>
        public virtual ModBudResult<T> ReadRegisters<T>(byte slave, byte funcCode, ushort start, ushort count)
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
                    // 寄存器数量
                    var realCount = (ushort)Math.Min(registerCount - i, 120);
                    var bytes = this.Read(slave, funcCode, start, realCount, (ushort)(realCount * 2 + 5));
                    data.AddRange(BytesToTargetValue<T>(bytes));
                }
            }
            catch (Exception e)
            {
                return ModBudResult<T>.Failed(e.Message);
            }

            return ModBudResult<T>.Success(data);
        }

        /// <summary>
        /// 写多个线圈状态
        /// </summary>
        /// <param name="slave">从站设备</param>
        /// <param name="start">起始地址</param>
        /// <param name="data">写入数据</param>
        /// <returns></returns>
        public virtual ModBudResult<bool> WriteCoils(byte slave, ushort start, List<bool> data)
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
                return ModBudResult<bool>.Failed(e.Message);
            }
            return ModBudResult<bool>.Success();
        }

        public virtual ModBudResult<bool> WriteRegisters<T>(byte slave, ushort start, List<T> data)
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
                ModBudResult<bool>.Failed(e.Message);
            }
            return ModBudResult<bool>.Success();
        }

        protected virtual List<byte> Read(byte slave, byte funcCode, ushort start, ushort count, ushort respLen)
        {
            return null;
        }

        protected virtual void Write(List<byte> writePud)
        {
        }

        #endregion

        /// <summary>
        /// 将字节序转化成大端序
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        protected List<byte> SwitchEndianType(List<byte> bytes)
        {
            List<byte> temp = new List<byte>();
            switch (this.EndianType)
            {
                case EndianType.AB:
                case EndianType.ABCD:
                case EndianType.ABCDEFGH:
                    temp = bytes;
                    break;
                case EndianType.BA:
                case EndianType.DCBA:
                case EndianType.HGFEDCBA:
                    for (int i = bytes.Count; i > 0; i--)
                    {
                        temp.Add(bytes[i - 1]);
                    }

                    break;
                case EndianType.CDAB:
                    temp.Add(bytes[2]);
                    temp.Add(bytes[3]);
                    temp.Add(bytes[0]);
                    temp.Add(bytes[1]);
                    break;
                case EndianType.BADC:
                    temp.Add(bytes[1]);
                    temp.Add(bytes[0]);
                    temp.Add(bytes[3]);
                    temp.Add(bytes[2]);
                    break;
                case EndianType.BADCFEHG:
                    temp.Add(bytes[1]);
                    temp.Add(bytes[0]);
                    temp.Add(bytes[3]);
                    temp.Add(bytes[2]);

                    temp.Add(bytes[1 + 4]);
                    temp.Add(bytes[0 + 4]);
                    temp.Add(bytes[3 + 4]);
                    temp.Add(bytes[2 + 4]);
                    break;
                case EndianType.GHEFCDAB:
                    temp.Add(bytes[6]);
                    temp.Add(bytes[7]);
                    temp.Add(bytes[4]);
                    temp.Add(bytes[6]);

                    temp.Add(bytes[6 - 4]);
                    temp.Add(bytes[7 - 4]);
                    temp.Add(bytes[4 - 4]);
                    temp.Add(bytes[6 - 4]);
                    break;
            }

            return temp;
        }


        protected List<T> BytesToTargetValue<T>(List<byte> dataBytes)
        {
            List<T> result = new List<T>();
            //当前类型字节数
            Type type = typeof(T);
            // 字节数
            int len = Marshal.SizeOf(type);
            Type tBitConverter = typeof(BitConverter);

            MethodInfo[] mis = tBitConverter.GetMethods(
                BindingFlags.Public | BindingFlags.Static);
            MethodInfo method = mis.FirstOrDefault(
                mi => mi.ReturnType == typeof(T)
                      && mi.GetParameters().Length == 2) as MethodInfo;
            if (method == null)
                throw new Exception("转换数据类型出错：未找到匹配的数据类型转换方法");

            for (int k = 0; k < dataBytes.Count; k += len)
            {
                List<byte> dataTemp = dataBytes.GetRange(k, len);
                dataTemp = this.SwitchEndianType(dataTemp);
                result.Add((T)method.Invoke(tBitConverter, new object[] { dataTemp.ToArray(), 0 }));
            }

            return result;
        }
    }
}