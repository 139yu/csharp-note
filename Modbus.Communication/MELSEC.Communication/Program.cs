using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using MCProtocol;

namespace MELSEC.Communication
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.45.130"), 6000);
            _socket.Connect(ipEndPoint);
            
            WriteRandom();
        }

        static void TestMcProtocolTcp()
        {
            Mitsubishi.McProtocolTcp mcProtocolTcp = new Mitsubishi.McProtocolTcp("192.168.45.130",6000,Mitsubishi.McFrame.MC3E);
            mcProtocolTcp.Open().GetAwaiter().GetResult();
            int[] data = new int[2];
            mcProtocolTcp.ReadDeviceBlock(Mitsubishi.PlcDeviceType.D, 0, 2,data);
            for (var i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }

            /*data[0] = 1;
            data[1] = 4;
            mcProtocolTcp.WriteDeviceBlock(Mitsubishi.PlcDeviceType.D, 0, 2, data);*/
        }
        static Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        
        static void Write()
        {
            var bytesHeader = new List<byte>()
            {
                0x50,0x00,0x00,0xff,0xff,0x03,0x00,
                0x0c,0x00, //数据长度，当前字节往后
                
            };
            var bytesCommand = new List<byte>()
            {
                0x10,0x00, //PLC响应超时时间，以250ms为单位计算
                0x01, 0x14, //操作指令
                0x01, 0x00, // 子命令

                0x00, 0x00, 0x00, //起始地址
                0x9c, //储存区
                0x02, 0x00, //写入点数
                0x10 //0x00, //数据
                // 0x00, 0x00, //数据
            };
            ushort len = (ushort)bytesCommand.Count;
            var bytesLen = BitConverter.GetBytes(len);
            bytesHeader[6] = bytesLen[0];
            bytesHeader[7] = bytesLen[0];
            bytesHeader.AddRange(bytesCommand);
            _socket.Send(bytesHeader.ToArray());
        }

        static void WriteRandom()
        {
            var bytes = new List<byte>()
            {
                0x50,0x00,0x00,0xff,0xff,0x03,0x00,
                0x0c,0x00, //数据长度，当前字节往后
            };
            var bytesCommand = new List<byte>()
            {
                0x10,0x00, //PLC响应超时时间，以250ms为单位计算
                0x02, 0x14, //操作指令
                0x01, 0x00, // 子命令

                0x01,  // 操作点数
                0x01,0x00,0x00, // 起始地址
                0x90, // 储存区
                0x10,//写入值
            };
            ushort len = (ushort)(bytesCommand.Count);
            var bytesLen = BitConverter.GetBytes(len);
            bytes[6] = bytesLen[0];
            bytes[7] = bytesLen[0];
            
            bytes.AddRange(bytesCommand);
            _socket.Send(bytes.ToArray());
        }
    }
}