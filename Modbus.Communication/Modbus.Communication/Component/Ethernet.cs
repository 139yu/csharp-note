using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Modbus.Communication.Common;

namespace Modbus.Communication.Component
{
    public class Ethernet : ICommunicationUnit
    {
        public int ConnectTimeout { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public int ReadTimeout { get; set; }
        private Socket _socket;
        private bool connectState = false;

        private readonly ManualResetEvent _timeoutObject = new(false);

        public Ethernet(string ip, int port, int readTimeout)
        {
            ReadTimeout = readTimeout;
            IP = ip;
            Port = port;
        }

        public Result Open(int timeout)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                if (_socket != null)
                {
                    bool poolRead = _socket.Poll(1000, SelectMode.SelectRead);
                    bool zeroData = _socket.Available == 0;
                    if (_socket.Connected && !(poolRead && zeroData))
                    {
                        return Result.Success();
                    }
                }

                try
                {
                    connectState = false;
                    _socket?.Dispose();
                    _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _socket.ReceiveTimeout = ReadTimeout;
                    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
                    _timeoutObject.Set();
                    _socket.BeginConnect(ipEndPoint, ar =>
                    {
                        var socket = ar.AsyncState as Socket;
                        if (socket != null)
                        {
                            socket.EndConnect(ar);
                            connectState = socket.Connected;
                        }
                    }, _socket);
                    _timeoutObject.WaitOne(timeout, false);
                    if (connectState)
                    {
                        break;
                    }
                }
                catch (SocketException e)
                {
                    //连接尝试超时，或者连接的主机未能响应。
                    if (e.SocketErrorCode == SocketError.TimedOut)
                        throw new Exception(e.Message);
                }
                catch (Exception e)
                {
                }
            }

            if (!connectState)
            {
                _socket?.Dispose();
                throw new Exception("网络连接失败");
            }

            return Result.Success();
        }

        public void Close()
        {
            _socket?.Shutdown(SocketShutdown.Both);
            _socket?.Dispose();
        }

        public Result<byte> SendAndReceive(List<byte> requestBytes, int receiveLen, int errorLen)
        {
            
            return null;
        }
    }
}