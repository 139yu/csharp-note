using System;
using System.Collections.Generic;

namespace ModbusDemo
{
    public class Crc16
    {
        // CRC-16 预计算表（Modbus 多项式 0xA001）
        private static readonly ushort[] CrcTable = new ushort[256];

        // 静态构造函数：初始化 CRC 表
        static Crc16()
        {
            const ushort polynomial = 0xA001; // Modbus 多项式（反向）
            for (ushort i = 0; i < 256; i++)
            {
                ushort value = i;
                for (int j = 0; j < 8; j++)
                {
                    if ((value & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                }

                CrcTable[i] = value;
            }
        }

        /// <summary>
        /// 计算字节数组的 CRC-16 校验值（Modbus RTU 标准）
        /// </summary>
        /// <param name="data">输入数据</param>
        /// <param name="offset">起始偏移</param>
        /// <param name="length">数据长度</param>
        /// <returns>CRC 值（小端序字节数组）</returns>
        public static byte[] ComputeChecksum(List<byte> data, int offset = 0, int length = -1)
        {
            if (data == null || data.Count == 0)
                throw new ArgumentException("数据不能为空");

            if (length < 0)
                length = data.Count - offset;

            ushort crc = 0xFFFF; // 初始值

            // 查表法快速计算
            for (int i = offset; i < offset + length; i++)
            {
                byte index = (byte)(crc ^ data[i]);
                crc = (ushort)((crc >> 8) ^ CrcTable[index]);
            }

            // 转换为小端序字节数组
            byte[] result = BitConverter.GetBytes(crc);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(result); // 系统为小端序时，直接 GetBytes 会反转，需还原

            return result; // 返回低字节在前的结果（如 0xABCD → [0xCD, 0xAB]）
        }

        /// <summary>
        /// 直接计算法（无需预计算表，适合低频使用）
        /// </summary>
        public static ushort ComputeChecksumDirect(byte[] data, int offset = 0, int length = -1)
        {
            if (length < 0)
                length = data.Length - offset;

            ushort crc = 0xFFFF;
            for (int i = offset; i < offset + length; i++)
            {
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc = (ushort)((crc >> 1) ^ 0xA001);
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }

            return crc;
        }
    }
}