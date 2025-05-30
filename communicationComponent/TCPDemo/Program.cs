using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 10086));
            socket.Listen();
            Socket client = socket.Accept();
            var buff = new byte[1024];
            var len = 0;
            var receive = client.Receive(buff);
            var s = Encoding.UTF8.GetString(buff);
            Console.WriteLine($"接收到数据：{s}");
            client.Send(Encoding.UTF8.GetBytes("你好"));
        }
    }
}