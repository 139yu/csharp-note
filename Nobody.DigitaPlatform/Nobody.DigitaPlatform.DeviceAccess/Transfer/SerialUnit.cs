using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Printing;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DeviceAccess.Transfer
{
    internal class SerialUnit : TransferObject
    {
        private SerialPort _serialPort = new SerialPort();

        internal override Result Config(List<DevicePropEntity> props)
        {
            try
            {
                var serialProps = _serialPort.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var item in props)
                {
                    var targetProp = serialProps.FirstOrDefault(p => p.Name.Trim().Equals(item.PropName));
                    if (targetProp == null)
                    {
                        continue;
                    }

                    object v = null;
                    var propType = targetProp.PropertyType;
                    if (propType.IsEnum)
                    {
                        v = Enum.Parse(propType, item.PropValue);
                    }
                    else
                    {
                        v = Convert.ChangeType(item.PropValue.Trim(), propType);
                    }

                    targetProp.SetValue(_serialPort, v);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Result.Success();
        }

        public override Result Connect(int tryCount)
        {
            try
            {
                while (tryCount > 0)
                {
                    if (_serialPort.IsOpen)
                    {
                        break;
                    }

                    // 尝试打开串口
                    try
                    {
                        _serialPort.Open();
                    }
                    catch (Exception e)
                    {
                        Task.Delay(1).GetAwaiter().GetResult();
                        tryCount--;
                    }
                }

                if (_serialPort.IsOpen)
                {
                    this.ConnectState = true;
                    return Result.Success();
                }
                else
                {
                    return Result.Failed("串口连接失败，尝试次数已用完");
                }
            }
            catch (Exception e)
            {
                Result.Failed("串口连接失败：" + e.Message);
            }

            return Result.Success();
        }

        public override Result<List<byte>> SendAndReceive(List<byte> readPdu, int resLen, int errorLen, int timeout)
        {
            Result<List<byte>> result = new Result<List<byte>>();
            List<byte> data = new List<byte>();
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                _serialPort.Write(readPdu.ToArray(), 0, readPdu.Count);
                _serialPort.ReadTimeout = timeout;
                stopwatch.Start();
                while (data.Count < resLen)
                {
                    byte readByte = (byte)_serialPort.ReadByte();
                    data.Add(readByte);

                    if (data.Count > 1 && data[1] > 0x80)
                    {
                        resLen = errorLen; // 如果是错误响应，设置预期长度为错误长度
                    }
                }


            }
            catch (TimeoutException e)
            {
                if (data.Count != errorLen && data.Count != resLen)
                {
                    result.Status = false;
                    result.Message = "接收报文超时";
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            finally
            {
                result.Data = data;
            }

            return result;
        }

        public override void Close()
        {
            if (_serialPort != null)
            {
                _serialPort.Close();
            }

            base.Close();
        }
    }
}