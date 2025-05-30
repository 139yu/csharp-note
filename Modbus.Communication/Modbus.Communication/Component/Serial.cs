using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using Modbus.Communication.Common;

namespace Modbus.Communication.Component
{
    public class Serial : ICommunicationUnit
    {
        private SerialPort _serialPort = null;

        public Serial(string portName, int baudRate, int dataBit, Parity parity, StopBits stopBits, int readTimeout)
        {
            _serialPort = new SerialPort(portName, baudRate, parity, dataBit, stopBits);
            _serialPort.ReadTimeout = readTimeout;
        }

        public int ConnectTimeout { get; set; } = 50;

        public Result Open(int timeout)
        {
            try
            {
                if (_serialPort == null)
                {
                    throw new Exception("串口对象未初始化");
                }

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while (stopwatch.ElapsedMilliseconds < timeout)
                {
                    if (_serialPort.IsOpen)
                    {
                        break;
                    }

                    try
                    {
                        _serialPort.Open();
                        break;
                    }
                    catch (IOException e)
                    {
                        Task.Delay(1).GetAwaiter().GetResult();
                    }
                }

                stopwatch.Stop();
                if (_serialPort == null || !_serialPort.IsOpen)
                {
                    throw new Exception("串口打开失败");
                }
            }
            catch (Exception e)
            {
                return Result.Failed(e.Message);
            }

            return Result.Success();
        }

        public void Close()
        {
        }

        public Result<byte> SendAndReceive(List<byte> requestBytes, int receiveLen, int errorLen)
        {
            _serialPort.Write(requestBytes.ToArray(), 0, requestBytes.Count);
            List<byte> response = new List<byte>();
            try
            {
                while (response.Count < receiveLen)
                {
                    response.Add((byte)_serialPort.ReadByte());
                }
            }
            catch (TimeoutException e)
            {
                if (response.Count != errorLen)
                {
                    return Result<byte>.Failed("接收报文超时", response);
                }
            }
            catch (Exception e)
            {
                return Result<byte>.Failed(e.Message, response);
            }

            return Result<byte>.Success(response);
        }
    }
}