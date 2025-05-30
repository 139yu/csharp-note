using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // var endPoint = new IPEndPoint(IPAddress.Any, 10011);
            // socket.Bind(endPoint);
            // socket.Listen();
            // var client = socket.Accept();
            // var buffer = new byte[1024];
            // // 会阻塞，直到接收到消息
            // var receive = client.Receive(buffer);   
            // Console.WriteLine($"接收成功: {Encoding.UTF8.GetString(buffer)}");
            // Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10010);
            // var connectResult = socket.BeginConnect(endPoint, res =>
            // {
            //     if (res.IsCompleted)
            //     {
            //         Console.WriteLine("连接成功,当前线程：" + Thread.CurrentThread.ManagedThreadId);
            //         // socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None);
            //     }
            // }, socket);
            //
            // socket.EndConnect(connectResult);
            // if (connectResult.IsCompleted)
            // {
            //     Console.WriteLine("当前线程：" + Thread.CurrentThread.ManagedThreadId);
            // }
            //
            // var buff = Encoding.UTF8.GetBytes("hello");
            // var result = socket.BeginSend(buff, 0, buff.Length, SocketFlags.None, res =>
            // {
            //     if (res.IsCompleted)
            //     {
            //         Console.WriteLine("helo发送完成，thread-" + Thread.CurrentThread.ManagedThreadId);
            //     }
            // }, socket);
            // socket.EndSend(result);
            //
            // var bigBuff = new byte[10_000_000];
            //
            // socket.BeginSend(bigBuff, 0, bigBuff.Length, SocketFlags.None, res =>
            // {
            //     socket.EndSend(res);
            //     if (res.IsCompleted)
            //     {
            //         Console.WriteLine("big buff 发送完成，thread-" + Thread.CurrentThread.ManagedThreadId);
            //         var receiveBuff = new byte[1024];
            //         var beginReceive = socket.BeginReceive(receiveBuff, 0, receiveBuff.Length, SocketFlags.None, receive =>
            //         {
            //             
            //             Console.WriteLine("接收到数据:" + Encoding.UTF8.GetString(receiveBuff));
            //         }, null);
            //         // 
            //         if (beginReceive.AsyncWaitHandle.WaitOne(500))
            //         {
            //             socket.EndReceive(beginReceive);
            //         }
            //         else
            //         {
            //             Console.WriteLine("接收失败");
            //         }
            //     }
            //     
            // }, socket);
            // Console.WriteLine("1123");
          
            /*Task.Run(() =>
            {
                try
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    socket.Bind(new IPEndPoint(IPAddress.Any, 10010));
                    var buff = new byte[1024];
                    EndPoint sendPoint = new IPEndPoint(IPAddress.Any, 0);
                    socket.ReceiveFrom(buff, ref sendPoint);
                    Console.WriteLine("接收到消息：" + Encoding.UTF8.GetString(buff));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });
            
            Socket broadcastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            broadcastSocket.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 10010);
            var message = Encoding.UTF8.GetBytes("helloooooo");
            broadcastSocket.SendTo(message, endPoint);
            Console.ReadKey();*/
            Test01();
        }

        public static void Test01()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.45.44"), 502);
            client.Connect(endPoint);
            Console.WriteLine("已连接到");
            var tcp = new List<byte>();
            tcp.Add(0x00);
            tcp.Add(0x01);
            tcp.AddRange(new byte[2]{0x00,0x00});//协议标识符
            tcp.AddRange(new byte[2]{0x00,0x06});//长度字段
            tcp.Add(0x05);//从站地址
            tcp.Add(0x03);//功能码
            tcp.Add(0x00);
            tcp.Add(0x00);
            tcp.Add(0x00);
            tcp.Add(0x01);
            client.Send(tcp.ToArray(), SocketFlags.None);
            var tcpHeader = new byte[6];
            // var res = new byte[2 + 2 + 2+ 1 +1 + 1 + 2];
            client.Receive(tcpHeader, 0, 6, SocketFlags.None);
            var len = BitConverter.ToInt16(new []{tcpHeader[5],tcpHeader[4]});
            Console.WriteLine(len);
            var data = new byte[len];
            client.Receive(data, 0, len, SocketFlags.None);
            // var addr = BitConverter.ToInt16(new []{data[0]});
            // var code = BitConverter.ToInt16(new[] { data[1] });
            // var l = BitConverter.ToInt16(new[] { data[2] });
            var val = BitConverter.ToInt16(new[] { data[4],data[3] });
            Console.WriteLine($" value: {val}");
        }

        public static void Test02()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.45.44"), 502);
            client.Connect(endPoint);
            var tcp = new List<byte>();
            tcp.Add(0x00);
            tcp.Add(0x01);
            tcp.AddRange(new byte[2]{0x00,0x00});//协议标识符
            tcp.AddRange(new byte[2]{0x00,0x06});//长度字段
            tcp.Add(0x05);//从站地址
            tcp.Add(0x06);//功能码
            tcp.Add(0x00);
            tcp.Add(0x00);
            tcp.Add(0x00);
            tcp.Add(0x11);
            client.Send(tcp.ToArray(), 0, tcp.Count, SocketFlags.None);
        }
    }
}