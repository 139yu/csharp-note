using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Sharp7;
using Siemens.Communication.Siemens;

namespace S7COMM.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestConnect();
            // // TestRead();
            // TestWrite();
            // // TestS7Sharp();
            S7Net s7Net = new S7Net("192.168.45.112", 102, 3, 1);
            var siemensResult = s7Net.Connect(100);
            if (!siemensResult.Status)
            {
                Console.WriteLine(siemensResult.Message);
            }
        }

        public static void Test01()
        {
            // Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.45.112"), 102);
            // socket.Connect(ipEndPoint);
            // var bytes = new byte[]
            // {
            //     //TPKT 头
            //     0x03,
            //     0x00,
            //     0x00, 0x16,
            //     //COTP头
            //     0x11,
            //     0xe0,
            //     0x00, 0x00,
            //     0x00, 0x01,
            //     0x00,
            //     //参数列表
            //     0xc0, 0x01, 0x0a,
            //     0xc1, 0x02, 0x02, 0x00,
            //     0xc2, 0x02, 0x03, 0x01
            // };
            // socket.Send(bytes);
            // var receiveBytes = new byte[22];
            // socket.Receive(receiveBytes, 0, receiveBytes.Length, SocketFlags.None);
            // Console.WriteLine(111);
            
        }

        public static void TestS7Sharp()
        {
            S7Client client = new S7Client();
            client.ConnectTo("192.168.45.112", 3, 1);
            byte[] data = new byte[2];
            var readArea = client.DBRead(1, 0, 2, data);
            data.Reverse();
            var int16 = BitConverter.ToInt16(data);
            Console.WriteLine($"S7Sharp read value: {int16}");
            // var writeVal = new List<byte>();
            // writeVal.Add(0x02);
            // writeVal.Add(0x02);
            // client.WriteArea(S7Area.DB, 2, 0, 2, S7WordLength.Byte, writeVal.ToArray());
            // client.DBWrite(2, 0, 2, new byte[] { 0x00, 0x12 });
        }

        private static Socket _socket;
        public static void TestConnect()
        {
            // cotp连接
            List<byte> cotpBytes = new List<byte>()
            {
                //TPKT 头
                0x03, //版本
                0x00, //保留字段
                0x00, 0x16, //整个请求字节数
                //COTP头
                0x11, //COTP报文字节数
                0xe0, //pdu type
                0x00, 0x00, // dst reference
                0x00, 0x01, // src reference
                0x00, //class
                //参数列表
                0xc0, 0x01, 0x0a,
                0xc1, 0x02, 0x02, 0x00,
                0xc2, 0x02, 0x03, 0x01
            };
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.45.112"), 102);
            _socket.Connect(ipEndPoint);
            _socket.Send(cotpBytes.ToArray());
            var tpktBytes = new byte[4];
            _socket.Receive(tpktBytes, 0, 4, SocketFlags.None);
            var totalLen = BitConverter.ToInt16(new[] { tpktBytes[3], tpktBytes[2] }) - 4;
            Console.WriteLine($"totalLen：{totalLen}");
            var resBytes = new byte[totalLen];
            _socket.Receive(resBytes, 0, totalLen, SocketFlags.None);
            var cotpLen = Convert.ToInt16(resBytes[0]);
            Console.WriteLine($"cotpLen: {cotpLen}");
            List<byte> setupBytes = new List<byte>()
            {
//TPKT 头
                0x03, //版本
                0x00, //保留字段
                0x00, 0x19, //整个请求字节数
                //COTP
                0x02,
                0xf0,
                0x80,
                //S7-Header
                0x32,
                0x01,
                0x00, 0x00,
                0x00, 0x00,
                0x00, 0x08,
                0x00, 0x00,
                0xf0,
                0x00,
                0x00, 0x03,
                0x00, 0x03,
                0x03, 0xc0
            };
            var send = _socket.Send(setupBytes.ToArray());
            var setupTpktHeader = new byte[4];
            _socket.Receive(setupTpktHeader);
            var totalSetupLen = BitConverter.ToInt16(new[] { setupTpktHeader[3], setupTpktHeader[2] }) - 4;
            var setupResBytes = new byte[totalSetupLen];
            _socket.Receive(setupResBytes);
            var pduLength = BitConverter.ToInt16(new []{setupResBytes[setupResBytes.Length - 1],setupResBytes[setupResBytes.Length - 2]});
            Console.WriteLine($"pduLength: {pduLength}");
        }

        public static void TestRead()
        {
            
            var readBytes = new List<byte>()
            {
                0x03,
                0x00,
                0x00,0x1f,
                
                0x02,0xf0,0x80,
                
                0x32,
                0x01,
                0x00,0x00,
                0x00,0x00,
                0x00,0x0e,
                0x00,0x00,
                
                0x04,
                0x01,
                
                0x12,
                0x0a,
                0x10,//Syntax Id：S7ANY
                0x02,//Transport Size
                0x00,0x01,//数据长度，指传输数据单位为多少字节
                0x00,0x02,//数据块编号
                0x84,//读取数据区域
                // 0x00,0x00,0x00 //18-3位表示Byte Address，读取数据地址；2-0位表示Bit Address，读取哪个位，如果读取的是byte，则为0
            };
            var addr = 0 << 3;
            readBytes.Add((byte)(addr / 256 / 256 % 256));
            readBytes.Add((byte)(addr / 256 % 256));
            readBytes.Add((byte)(addr % 256));
            _socket.Send(readBytes.ToArray());
        }

        public static void TestWrite()
        {
            List<byte> tpktBytes = new List<byte>()
            {
                0x03,
                0x00,
                // req len
                0x00, 0x00
            };
            var cotpBytes = new List<byte>()
            {
                //cotp len
                0x02,
                // pdu type
                0xf0,
                0x80
            };
            var headerBytes = new List<byte>()
            {
                0x32,
                0x01,
                0x00,0x00,
                0x00,0x00,
                // parameter len
                0x00,0x0e,
                // data len
                0x00,0x05
            };
            var parameterBytes = new List<byte>()
            {
                // write func
                0x05,
                // item count,
                0x01
            };
            
            var itemBytes = new List<byte>()
            {
                0x12,
                // item len
                0x0a,
                // syntax id
                0x10,
                // transport size, byte(2)
                0x02,
                // data bytes
                0x00,0x01,
                // 数据块
                0x00,0x02,
                // area
                0x84,
                // 18-3 byte address,2-0 bit address
                0x00,0x00,0x00
            };
            var dataBytes = new List<byte>()
            {
                // return code
                0x00,
                0x04,
                // 剩余数据长度
                0x00,0x08,
                0x16
            };
            
            var itemLen = (ushort)(itemBytes.Count - 2);
            itemBytes[1] = (byte)(itemLen % 256);

            var parameterLen = (ushort)(parameterBytes.Count + itemBytes.Count);
            headerBytes[6] = (byte)(parameterLen / 256);
            headerBytes[7] = (byte)(parameterLen % 256);
            
            var dataLen = (ushort)(dataBytes.Count);
            headerBytes[8] = (byte)(dataLen / 256);
            headerBytes[9] = (byte)(dataLen % 256);
            
            
            List<byte> writeBytes = new List<byte>();
            writeBytes.AddRange(tpktBytes);
            writeBytes.AddRange(cotpBytes);
            writeBytes.AddRange(headerBytes);
            writeBytes.AddRange(parameterBytes);
            writeBytes.AddRange(itemBytes);
            writeBytes.AddRange(dataBytes);
            
            ushort totalLen = (ushort)writeBytes.Count;
            var bytes = BitConverter.GetBytes(totalLen);
            writeBytes[2] = (byte)(totalLen / 256);
            writeBytes[3] = (byte)(totalLen % 256);
            _socket.Send(writeBytes.ToArray());
        }
    }
}