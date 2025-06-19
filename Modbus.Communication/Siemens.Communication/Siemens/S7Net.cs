using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using Siemens.Communication.Common;

namespace Siemens.Communication.Siemens
{
    public class S7Net
    {
        private string _ip;
        private int _port;
        private ushort _rack;
        private ushort _slot;
        private int _pudSize;

        private bool _connectState = false;

        private Socket _socket;

        private ManualResetEvent _timeoutObject = new ManualResetEvent(false);

        public S7Net(string ip, int port, ushort rack, ushort slot)
        {
            _ip = ip;
            _port = port;
            _rack = rack;
            _slot = slot;
        }

        private Dictionary<int, string> ErrorClass = new Dictionary<int, string>()
        {
            { 0x81, "应用程序关系错误" },
            { 0x82, "对象定义错误" },
            { 0x83, "无资源可用错误" },
            { 0x84, "服务处理错误" },
            { 0x85, "请求错误" },
            { 0x87, "访问错误" },
        };
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public SiemensResult Connect(int timeout = 50)
        {
            _timeoutObject.Reset();
            try
            {
                var stopwatch = Stopwatch.StartNew();
                
                while (stopwatch.ElapsedMilliseconds < timeout)
                {
                    if (_socket != null)
                    {
                        var pollRead = _socket.Poll(1000, SelectMode.SelectRead);
                        var zeroData = _socket.Available == 0;
                        if (_socket.Connected && !(pollRead && zeroData))
                        {
                            return SiemensResult.Success();
                        }
                    }

                    try
                    {
                        _socket?.Close();
                        _socket?.Dispose();
                        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        _socket.BeginConnect(_ip, _port, req =>
                        {
                            var socket = req.AsyncState as Socket;
                            if (socket != null)
                            {
                                socket.EndConnect(req);
                                _connectState = socket.Connected;
                            }

                            _timeoutObject.Set();
                        }, _socket);
                        _timeoutObject.WaitOne(100);
                        if (_connectState)
                        {
                            break;
                        }

                        throw new Exception("网络连接失败");
                    }
                    // 不处理异常，继续尝试连接
                    catch (Exception e){}
                }

                if (_socket == null || !_connectState)
                {
                    throw new Exception("网络连接失败");
                }

                if (_socket.Poll(1000, SelectMode.SelectRead) && _socket.Available == 0)
                {
                    throw new Exception("网络连接失败");
                }

                var cotpResutl = COTPConnect();
                if (!cotpResutl.Status)
                {
                    return SiemensResult.Failed(cotpResutl.Message);
                }

                var result = SetupCommunication();
                if (!result.Status)
                {
                    return SiemensResult.Failed(result.Message);
                }
            }
            catch (Exception e)
            {
                return SiemensResult.Failed(e.Message);
            }

            return SiemensResult.Success();
        }

        private SiemensResult COTPConnect()
        {
            var cotpBytes = new List<byte>()
            {
                // TPKT
                0x03, 0x00, 0x00, 0x16,
                // COTP
                0x11, 0xe0,
                0x00, 0x00, 0x00, 0x00, 0x00,

                // Parameter-code  tpdu-size
                0xc0, 0x01, 0x0a,
                // Parameter-code  src-tsap
                0xc1, 0x02, 0x10, 0x00,
                // Parameter-code  dst-tsap
                0xc2, 0x02
            };
            var dst = BitConverter.GetBytes((ushort)((_rack << 8) + _slot));
            cotpBytes.Add(dst[1]);
            cotpBytes.Add(dst[0]);
            try
            {
                _socket.Send(cotpBytes.ToArray());
                var resBytes = new byte[22];
                _socket.Receive(resBytes, 0, 22, SocketFlags.None);
                if (resBytes[5] != (byte)PudType.ConnectionConfirm)
                {
                    throw new Exception("COTP连接响应异常");
                }
            }
            catch (Exception e)
            {
                return SiemensResult.Failed("COTP连接未建立！" + e.Message);
            }

            return SiemensResult.Success();
        }

        private SiemensResult SetupCommunication()
        {
            byte[] setupBytes = new byte[]
            {
                // TPKT
                0x03, 0x00, 0x00, 0x19,
                // COTP
                0x02, 0xf0, 0x80,
                // Header
                0x32, 0x01,
                0x00, 0x00, 0x00, 0x00,
                // PL
                0x00, 0x08,
                // DL
                0x00, 0x00,
                // Parameter
                0xf0,
                0x00,
                0x00, 0x03, 0x00, 0x03, 0x03, 0xc0
            };
            try
            {
                _socket.Send(setupBytes);
                var cotpHeader = new byte[4];
                _socket.Receive(cotpHeader);
                var resLen = BitConverter.ToUInt16(new[] { cotpHeader[3], cotpHeader[2] });
                var bytes = new byte[resLen - 4];
                _socket.Receive(bytes);
                if (bytes[13] != 0x00)
                {
                    throw new Exception(ErrorClass[bytes[13]]);
                }

                _pudSize = BitConverter.ToUInt16(new[] { bytes[bytes.Length - 2], bytes[bytes.Length - 1] });
            }
            catch (Exception e)
            {
                return SiemensResult.Failed("Setup Communication建立连接失败！" + e.Message);
            }

            return SiemensResult.Success();
        }

        public int ReadArea(AreaType areaType,int dbNum,int startAddress)
        {
            return 0;
        }
    }
}