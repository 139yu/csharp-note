using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10010);
            //
            // #region connect
            //
            // // {
            // //     Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // //     var endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.7"), 10010);
            // //     socket.Connect(endPoint);
            // //     var readPoll = socket.Poll(1000,SelectMode.SelectRead);
            // //     var writePoll = socket.Poll(1000,SelectMode.SelectWrite);
            // //     Console.WriteLine($"connection state: {socket.Connected}");
            // //     Console.WriteLine($"read poll state: {readPoll}");
            // //     Console.WriteLine($"read poll state: {writePoll}");
            // //     Console.WriteLine($"socket available: {socket.Available}");
            // //     Thread.Sleep(5000);
            // //     Console.WriteLine("----------after 5 seconds----------");
            // //     Console.WriteLine($"connection state: {socket.Connected}");
            // //     Console.WriteLine($"read poll state: {readPoll}");
            // //     Console.WriteLine($"write poll state: {writePoll}");
            // //     Console.WriteLine($"socket available: {socket.Available}");
            // // }
            //
            // #endregion
            //
            // #region begin connect
            // Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // var result = socket.BeginConnect(endPoint, res =>
            // {
            //     var resIsCompleted = res.IsCompleted;
            //     Console.WriteLine(resIsCompleted);
            // }, null);
            // // result.AsyncWaitHandle.WaitOne(1000);
            // try
            // {
            //     if (result.IsCompleted)
            //     {
            //         Console.WriteLine("连接成功");
            //     }
            //     socket.EndConnect(result);
            //     var data = Encoding.UTF8.GetBytes("hello");
            //     socket.Send(data);
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     throw;
            // }
            // #endregion
            TcpClient client = null;
            NetworkStream networkStream = null;
            try
            {
                client = new TcpClient(AddressFamily.InterNetwork);
                client.Connect(IPAddress.Parse("127.0.0.1"), 10010);
                networkStream = client.GetStream();
                if (networkStream.CanWrite)
                {
                    networkStream.Write(Encoding.UTF8.GetBytes("I am going!"));
                }

                Task.Run(async () =>
                {
                    while (networkStream.CanRead)
                    {
                        var buffer = new byte[1024 * 1024];
                        var readBytes = networkStream.Read(buffer);
                        if (readBytes == 0)
                        {
                            Console.WriteLine("读取失败");
                            networkStream.Close();
                        }

                        Console.WriteLine(Encoding.UTF8.GetString(buffer));
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                networkStream?.Dispose();
                client?.Dispose();
                throw;
            }

            Console.ReadKey();
        }
    }
}