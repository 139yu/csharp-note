using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Omron.Communication
{
    class Program
    {
        private static ManualResetEvent _timeoutObject = new ManualResetEvent(false);
        private static bool _connectState = false;
        private static Socket _socket;
        private static IPEndPoint _ipEndPoint;
        
        static void Main(string[] args)
        {
            Connect("192.168.1.3", 9600);
            CpuInfo();
        }

        public static void CpuInfo()
        {
            List<byte> bytes = new List<byte>();
            List<byte> finsTCPHeader = new List<byte>()
            {
                // header
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00, 0x00, 0x00, 0x0c,
                //Command
                0x00, 0x00, 0x00, 0x02,
                //Error code
                0x00, 0x00, 0x00, 0x00,
                /*//Client Address
                0x00, 0x00, 0x00, 0x01*/
            };
            List<byte> finsHeader = new List<byte>()
            {
                0x80,
                0x00, // 预留
                0x02, //网关数量
                0x00, //目标网络地址
                0x01, //目标IP末位
                0x00, // 目标单位地址
                0x00,
                0x01, //源ip末位
                0x00,
                0x01, //服务ID，00-ff任意数字
            };
            List<byte> commandBytes = new List<byte>()
            {
                0x06,0x01, // Command
                
                
            };
            int reqLne = 8 + finsHeader.Count + commandBytes.Count;
            var lenBytes = BitConverter.GetBytes(reqLne);
            for (var i = 0; i < lenBytes.Length; i++)
            {
                finsTCPHeader[7 - i] = lenBytes[i];
            }
            bytes.AddRange(finsTCPHeader);
            bytes.AddRange(finsHeader);
            bytes.AddRange(commandBytes); 
            _socket.Send(bytes.ToArray());
            var resH = finsTCPHeader.ToArray();
            _socket.Receive(resH);
            var resLenBytes = resH.ToList().GetRange(4,4);
            resLenBytes.Reverse();
            var resLen = BitConverter.ToInt32(resLenBytes.ToArray());
            var resByes = new byte[resLen];
            _socket.Receive(resByes);
        }
        public static void WritePLCTime()
        {
            List<byte> bytes = new List<byte>();
            List<byte> finsTCPHeader = new List<byte>()
            {
                // header
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00, 0x00, 0x00, 0x0c,
                //Command
                0x00, 0x00, 0x00, 0x02,
                //Error code
                0x00, 0x00, 0x00, 0x00,
                /*//Client Address
                0x00, 0x00, 0x00, 0x01*/
            };
            List<byte> finsHeader = new List<byte>()
            {
                0x80,
                0x00, // 预留
                0x02, //网关数量
                0x00, //目标网络地址
                0x01, //目标IP末位
                0x00, // 目标单位地址
                0x00,
                0x01, //源ip末位
                0x00,
                0x01, //服务ID，00-ff任意数字
            };
            List<byte> commandBytes = new List<byte>()
            {
                0x07,0x02, // Command
                0x25,
                0x06,
                0x08,
                0x15,
                0x52,
                0x00,0x01
                
            };
            int reqLne = 8 + finsHeader.Count + commandBytes.Count;
            var lenBytes = BitConverter.GetBytes(reqLne);
            for (var i = 0; i < lenBytes.Length; i++)
            {
                finsTCPHeader[7 - i] = lenBytes[i];
            }
            bytes.AddRange(finsTCPHeader);
            bytes.AddRange(finsHeader);
            bytes.AddRange(commandBytes); 
            _socket.Send(bytes.ToArray());
            var resH = finsTCPHeader.ToArray();
            _socket.Receive(resH);
            var resLenBytes = resH.ToList().GetRange(4,4);
            resLenBytes.Reverse();
            var resLen = BitConverter.ToInt32(resLenBytes.ToArray());
            var resByes = new byte[resLen];
            _socket.Receive(resByes);
        }
        public static void GetPLCTime()
        {
            List<byte> bytes = new List<byte>();
            List<byte> finsTCPHeader = new List<byte>()
            {
                // header
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00, 0x00, 0x00, 0x0c,
                //Command
                0x00, 0x00, 0x00, 0x02,
                //Error code
                0x00, 0x00, 0x00, 0x00,
                /*//Client Address
                0x00, 0x00, 0x00, 0x01*/
            };
            List<byte> finsHeader = new List<byte>()
            {
                0x80,
                0x00, // 预留
                0x02, //网关数量
                0x00, //目标网络地址
                0x01, //目标IP末位
                0x00, // 目标单位地址
                0x00,
                0x01, //源ip末位
                0x00,
                0x01, //服务ID，00-ff任意数字
            };
            List<byte> commandBytes = new List<byte>()
            {
                0x07,0x01, // Command
            };
            int reqLne = 8 + finsHeader.Count + commandBytes.Count;
            var lenBytes = BitConverter.GetBytes(reqLne);
            for (var i = 0; i < lenBytes.Length; i++)
            {
                finsTCPHeader[7 - i] = lenBytes[i];
            }
            bytes.AddRange(finsTCPHeader);
            bytes.AddRange(finsHeader);
            bytes.AddRange(commandBytes); 
            _socket.Send(bytes.ToArray());
            var resH = finsTCPHeader.ToArray();
            _socket.Receive(resH);
            var resLenBytes = resH.ToList().GetRange(4,4);
            resLenBytes.Reverse();
            var resLen = BitConverter.ToInt32(resLenBytes.ToArray());
            var resByes = new byte[resLen];
            _socket.Receive(resByes);
        }
        public static void Transform()
        {
            List<byte> bytes = new List<byte>();
            List<byte> finsTCPHeader = new List<byte>()
            {
                // header
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00, 0x00, 0x00, 0x0c,
                //Command
                0x00, 0x00, 0x00, 0x02,
                //Error code
                0x00, 0x00, 0x00, 0x00,
                /*//Client Address
                0x00, 0x00, 0x00, 0x01*/
            };
            List<byte> finsHeader = new List<byte>()
            {
                0x80,
                0x00, // 预留
                0x02, //网关数量
                0x00, //目标网络地址
                0x01, //目标IP末位
                0x00, // 目标单位地址
                0x00,
                0x01, //源ip末位
                0x00,
                0x01, //服务ID，00-ff任意数字
            };
            List<byte> commandBytes = new List<byte>()
            {
                0x01,0x05, // Command
                
                // source
                0xb0, // 储存区
                0x00,0x00, //起始地址
                0x00, //位地址
                
                // dest
                0xb0, //目标内存区
                0x00,0x10, //目标起始地址
                0x00, // 位
                0x00,0x05 // 需要转移多少个
            };
            int reqLne = 8 + finsHeader.Count + commandBytes.Count;
            var lenBytes = BitConverter.GetBytes(reqLne);
            for (var i = 0; i < lenBytes.Length; i++)
            {
                finsTCPHeader[7 - i] = lenBytes[i];
            }
            bytes.AddRange(finsTCPHeader);
            bytes.AddRange(finsHeader);
            bytes.AddRange(commandBytes); 
            _socket.Send(bytes.ToArray());
            var resH = finsTCPHeader.ToArray();
            _socket.Receive(resH);
            var resLenBytes = resH.ToList().GetRange(4,4);
            resLenBytes.Reverse();
            var resLen = BitConverter.ToInt32(resLenBytes.ToArray());
            var resByes = new byte[resLen];
            _socket.Receive(resByes);
        }
        
        public static void Connect(string ip,int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            /*_socket.BeginConnect(_ipEndPoint, ar =>
            {
                _timeoutObject.Set();
                try
                {
                    Socket socket = ar.AsyncState as Socket;
                    if (socket != null)
                    {
                        socket.EndConnect(ar);
                        _connectState = socket.Connected;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }, _socket);
            _timeoutObject.WaitOne(100);*/
            _socket.Connect(_ipEndPoint);
            /*if (!_connectState)
            {
                throw new Exception("网络请求失败");
            }*/
            byte[] bytes = new byte[]
            {
                //Header FINS 16进制ASCII
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00,0x00,0x00,0x0c,
                //Command
                0x00,0x00,0x00,0x00,
                //Error code
                0x00,0x00,0x00,0x00,
                //Client Address
                0x00,0x00,0x00,0x01
            };
            _socket.Send(bytes);
            byte[] resHeaderBytes = new byte[8];
            _socket.Receive(resHeaderBytes);
            var list = resHeaderBytes.ToList();
            var lenBytes = list.GetRange(4,4);
            lenBytes.Reverse();
            var len = BitConverter.ToInt32(lenBytes.ToArray()) - 8; 
            byte[] resBytes = new byte[len];
            _socket.Receive(resBytes);
            Console.WriteLine(1);
        }

        public static void Read()
        {
            List<byte> bytes = new List<byte>();
            List<byte> finsTCPHeader = new List<byte>()
            {
                // header
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00, 0x00, 0x00, 0x0c,
                //Command
                0x00, 0x00, 0x00, 0x02,
                //Error code
                0x00, 0x00, 0x00, 0x00,
                /*//Client Address
                0x00, 0x00, 0x00, 0x01*/
            };
            List<byte> finsHeader = new List<byte>()
            {
                0x80,
                0x00, // 预留
                0x02, //网关数量
                0x00, //目标网络地址
                0x01, //目标IP末位
                0x00, // 目标单位地址
                0x00,
                0x01, //源ip末位
                0x00,
                0x01, //服务ID，00-ff任意数字
            };
            List<byte> commandBytes = new List<byte>()
            {
                0x01,0x01, // Command
                0x82, // 储存区
                0x00,0x00, //读取地址
                0x00, //位地址
                0x00,0x01 //读取个数
            };
            int reqLne = 8 + finsHeader.Count + commandBytes.Count;
            var lenBytes = BitConverter.GetBytes(reqLne);
            for (var i = 0; i < lenBytes.Length; i++)
            {
                finsTCPHeader[7 - i] = lenBytes[i];
            }
            bytes.AddRange(finsTCPHeader);
            bytes.AddRange(finsHeader);
            bytes.AddRange(commandBytes); 
            _socket.Send(bytes.ToArray());
            var resH = finsTCPHeader.ToArray();
            _socket.Receive(resH);
            var resLenBytes = resH.ToList().GetRange(4,4);
            resLenBytes.Reverse();
            var resLen = BitConverter.ToInt32(resLenBytes.ToArray());
            var resByes = new byte[resLen];
            _socket.Receive(resByes);
            
        }

        public static void ReadBit()
        {
            List<byte> bytes = new List<byte>();
            List<byte> finsTCPHeader = new List<byte>()
            {
                // header
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00, 0x00, 0x00, 0x0c,
                //Command
                0x00, 0x00, 0x00, 0x02,
                //Error code
                0x00, 0x00, 0x00, 0x00,
                /*//Client Address
                0x00, 0x00, 0x00, 0x01*/
            };
            List<byte> finsHeader = new List<byte>()
            {
                0x80,
                0x00, // 预留
                0x02, //网关数量
                0x00, //目标网络地址
                0x01, //目标IP末位
                0x00, // 目标单位地址
                0x00,
                0x01, //源ip末位
                0x00,
                0x01, //服务ID，00-ff任意数字
            };
            List<byte> commandBytes = new List<byte>()
            {
                0x01,0x01, // Command
                0x30, // 储存区
                0x00,0x00, //读取地址
                0x00, //位地址
                0x00,0x03 //读取个数
            };
            int reqLne = 8 + finsHeader.Count + commandBytes.Count;
            var lenBytes = BitConverter.GetBytes(reqLne);
            for (var i = 0; i < lenBytes.Length; i++)
            {
                finsTCPHeader[7 - i] = lenBytes[i];
            }
            bytes.AddRange(finsTCPHeader);
            bytes.AddRange(finsHeader);
            bytes.AddRange(commandBytes); 
            _socket.Send(bytes.ToArray());
            var resH = finsTCPHeader.ToArray();
            _socket.Receive(resH);
            var resLenBytes = resH.ToList().GetRange(4,4);
            resLenBytes.Reverse();
            var resLen = BitConverter.ToInt32(resLenBytes.ToArray());
            var resByes = new byte[resLen];
            _socket.Receive(resByes);
        }
        
        public static void Write()
        {
            List<byte> bytes = new List<byte>();
            List<byte> finsTCPHeader = new List<byte>()
            {
                // header
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00, 0x00, 0x00, 0x0c,
                //Command
                0x00, 0x00, 0x00, 0x02,
                //Error code
                0x00, 0x00, 0x00, 0x00,
                /*//Client Address
                0x00, 0x00, 0x00, 0x01*/
            };
            List<byte> finsHeader = new List<byte>()
            {
                0x80,
                0x00, // 预留
                0x02, //网关数量
                0x00, //目标网络地址
                0x01, //目标IP末位
                0x00, // 目标单位地址
                0x00,
                0x01, //源ip末位
                0x00,
                0x01, //服务ID，00-ff任意数字
            };
            List<byte> commandBytes = new List<byte>()
            {
                0x01,0x02, // Command
                0xb0, // 储存区
                0x00,0x00, //起始地址
                0x00, //位地址
                0x00,0x01, //读取个数
                0x12,0x12, //写入数据
            };
            int reqLne = 8 + finsHeader.Count + commandBytes.Count;
            var lenBytes = BitConverter.GetBytes(reqLne);
            for (var i = 0; i < lenBytes.Length; i++)
            {
                finsTCPHeader[7 - i] = lenBytes[i];
            }
            bytes.AddRange(finsTCPHeader);
            bytes.AddRange(finsHeader);
            bytes.AddRange(commandBytes); 
            _socket.Send(bytes.ToArray());
            var resH = finsTCPHeader.ToArray();
            _socket.Receive(resH);
            var resLenBytes = resH.ToList().GetRange(4,4);
            resLenBytes.Reverse();
            var resLen = BitConverter.ToInt32(resLenBytes.ToArray());
            var resByes = new byte[resLen];
            _socket.Receive(resByes);
        }

        public static void Fill()
        {
            List<byte> bytes = new List<byte>();
            List<byte> finsTCPHeader = new List<byte>()
            {
                // header
                0x46, 0x49, 0x4e, 0x53,
                //length
                0x00, 0x00, 0x00, 0x0c,
                //Command
                0x00, 0x00, 0x00, 0x02,
                //Error code
                0x00, 0x00, 0x00, 0x00,
                /*//Client Address
                0x00, 0x00, 0x00, 0x01*/
            };
            List<byte> finsHeader = new List<byte>()
            {
                0x80,
                0x00, // 预留
                0x02, //网关数量
                0x00, //目标网络地址
                0x01, //目标IP末位
                0x00, // 目标单位地址
                0x00,
                0x01, //源ip末位
                0x00,
                0x01, //服务ID，00-ff任意数字
            };
            List<byte> commandBytes = new List<byte>()
            {
                0x01,0x03, // Command
                0xb0, // 储存区
                0x00,0x00, //起始地址
                0x00, //位地址
                0x00,0x0a, //填充个数
                0x12,0x12, //要填充数据
            };
            int reqLne = 8 + finsHeader.Count + commandBytes.Count;
            var lenBytes = BitConverter.GetBytes(reqLne);
            for (var i = 0; i < lenBytes.Length; i++)
            {
                finsTCPHeader[7 - i] = lenBytes[i];
            }
            bytes.AddRange(finsTCPHeader);
            bytes.AddRange(finsHeader);
            bytes.AddRange(commandBytes); 
            _socket.Send(bytes.ToArray());
            var resH = finsTCPHeader.ToArray();
            _socket.Receive(resH);
            var resLenBytes = resH.ToList().GetRange(4,4);
            resLenBytes.Reverse();
            var resLen = BitConverter.ToInt32(resLenBytes.ToArray());
            var resByes = new byte[resLen];
            _socket.Receive(resByes);
        }
    }
}    