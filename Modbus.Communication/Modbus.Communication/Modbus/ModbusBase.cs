using System;
using System.Collections.Generic;
using Modbus.Communication.Common;
using Modbus.Communication.Component;

namespace Modbus.Communication.Modbus
{
    public abstract class ModbusBase
    {
        public EndianType EndianType { get; set; }
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
        public virtual Result<bool> ReadCoils(byte slave, byte funcCode, ushort start, ushort count)
        {
            return null;
        }

        /// <summary>
        /// 读寄存器（输入寄存器、保持寄存器）
        /// </summary>
        /// <param name="slave">从站设备</param>
        /// <param name="funcCode">功能码</param>
        /// <param name="start">起始地址</param>
        /// <param name="count">读寄存器数量</param>
        /// <returns></returns>
        public virtual Result<T> ReadRegisters<T>(byte slave, byte funcCode, ushort start, ushort count)
        {
            return null;
        }

        /// <summary>
        /// 写多个线圈状态
        /// </summary>
        /// <param name="slave">从站设备</param>
        /// <param name="start">起始地址</param>
        /// <param name="data">写入数据</param>
        /// <returns></returns>
        public virtual Result<bool> WriteCoils(byte slave, ushort start, List<bool> data)
        {
            return null;
        }

        public virtual Result<bool> WriteRegisters<T>(byte slave,ushort start,List<T> data)
        {
            return null;
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
                        temp.Add(bytes[i]);
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
    }
}