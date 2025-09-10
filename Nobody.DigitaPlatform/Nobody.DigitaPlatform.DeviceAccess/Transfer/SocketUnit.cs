using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.DeviceAccess.Transfer
{
    internal class SocketTcpUnit : TransferObject
    {
        private string ip;
        private int port;
        private Socket socket;
        readonly object lockObj = new object();
        private ManualResetEvent TimeoutObject = new ManualResetEvent(false);


        internal override Result Config(List<DevicePropEntity> props)
        {
            Result result = new Result();
            try
            {
                var ipProp = props.FirstOrDefault(p => p.PropName.Equals("IP"));
                if (ipProp == null || string.IsNullOrEmpty(ipProp.PropValue))
                {
                    throw new Exception("IP address is not configured.");
                }

                ip = ipProp.PropValue.Trim();
                var portProp = props.FirstOrDefault(p => p.PropName.Equals("Port"));
                if (portProp == null || string.IsNullOrEmpty(portProp.PropValue) ||
                    !int.TryParse(portProp.PropValue, out port))
                {
                    throw new Exception("Port is not configured or invalid.");
                }

                int.TryParse(portProp.PropValue, out port);
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        public override Result Connect(int tryCount = 30)
        {
            lock (lockObj)
            {
                bool connectState = false;
                Result result = new Result();
                try
                {
                    int count = 0;
                    TimeoutObject.Reset();
                    while (count++ < tryCount)
                    {
                        // socket.Poll(2000, SelectMode.SelectRead)：检查socket是否有数据可读
                        // socket.Available != 0：检查socket是否接收到数据
                        if (socket != null && socket.Connected && 
                            socket.Poll(2000, SelectMode.SelectRead) &&
                            socket.Available != 0)
                        {
                            return result;
                        }
                        socket?.Close();
                        socket?.Dispose();
                        socket = null;
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        try
                        {
                            var asyncResult = socket.BeginConnect(ip,port,null,null);
                            var connected = asyncResult.AsyncWaitHandle.WaitOne(2000);
                            if (connected)
                            {
                                socket.EndConnect(asyncResult);
                                if (socket.Connected)
                                {
                                    break;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }

                    if (socket != null && socket.Connected &&
                        socket.Poll(2000, SelectMode.SelectRead) &&
                        socket.Available != 0)
                    {
                        throw new Exception("网络连接失败");
                    }

                    ConnectState = true;
                }
                catch (Exception e)
                {
                    result.Status = false;
                    result.Message = "Socket connection failed: " + e.Message;
                }

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readPdu"></param>
        /// <param name="headerLen">tcp头长度</param>
        /// <param name="len2"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>

        public override Result<List<byte>> SendAndReceive(List<byte> readPdu, int headerLen, int len2, int timeout, Func<byte[], int> calLen)
        {
            lock (lockObj)
            {
                Result<List<byte>> result = new Result<List<byte>>();
                try
                {
                    socket.ReceiveTimeout = timeout;
                    socket.Send(readPdu.ToArray(), 0, readPdu.Count, SocketFlags.None);
                    byte[] tcpHeader = new byte[headerLen];
                    socket.Receive(tcpHeader);
                    result.Data = new List<byte>(tcpHeader);
                    var bytesLen = calLen(tcpHeader);
                    
                    var dataBytes = new byte[bytesLen];
                    socket.Receive(dataBytes, 0, bytesLen, SocketFlags.None);
                    result.Data.AddRange(dataBytes);
                }
                catch (SocketException se)
                {
                    result.Status = false;
                    if (se.SocketErrorCode == SocketError.TimedOut)
                    {
                        result.Message = "未获取到响应数据，接收超时";
                    }
                }
                catch (Exception e)
                {
                    result.Status = false;
                    result.Message = e.Message;
                }

                return result;
            }
        }
    }

    internal class SocketUdpUnit : TransferObject
    {
    }
}