using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.DeviceAccess.Transfer;
using Nobody.DigitaPlatform.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.DeviceAccess.Execute
{
    public class ModbusTCP : ModbusBase
    {
        private static ushort tx_id = 1;

        internal override Result Match(List<DevicePropEntity> props, List<TransferObject> transfers)
        {
            var propVars = props
                .Where(p => p.PropName.Equals("IP") || p.PropName.Equals("Port"))
                .Select(p => p.PropValue)
                .ToList();
            return this.Match(propVars, props, transfers, "SocketTcpUnit");
        }

        protected override Result<List<byte>> Read(byte slaveId, byte funcCode, ushort start, ushort count, int resLen)
        {
            Result<List<byte>> result = new Result<List<byte>>();
            var readPdu = CreateReadPDU(slaveId, funcCode, start, count);
            var tcpHeaderLen = readPdu.Count;
            AddTcpHeader(readPdu);
            tcpHeaderLen = Math.Abs(tcpHeaderLen - readPdu.Count);
            try
            {
                var tryCountProp = Props.FirstOrDefault(p => p.PropName.Equals("TryCount"));
                int tryCount = 30;
                if (tryCountProp != null && tryCountProp.PropValue != null)
                {
                    int.TryParse(tryCountProp.PropValue, out tryCount);
                }

                var connectResult = this.TransferObject.Connect(tryCount);
                if (!connectResult.Status)
                {
                    throw new Exception(connectResult.Message);
                }

                var timeoutProp = Props.FirstOrDefault(p => p.PropName.Equals("Timeout"));
                int timeout = 100;
                if (timeoutProp != null && timeoutProp.PropValue != null)
                {
                    int.TryParse(timeoutProp.PropValue, out timeout);
                }

                var receiveResult = this.TransferObject.SendAndReceive(readPdu, tcpHeaderLen, 5, timeout, CalLen);
                if (!receiveResult.Status)
                {
                    throw new Exception(receiveResult.Message);
                }

                var data = receiveResult.Data;
                // 移除tcp和数据域头部
                data.RemoveRange(0, 9);
                if (data[1] > 0x80)
                {
                    byte errorCode = data[2];
                    throw new Exception(Errors.ContainsKey(errorCode) ? Errors[errorCode] : "自定义异常");
                }

                result.Data = data;
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        private int CalLen(byte[] headerBytes)
        {
            int len = 0;
            var lenBytes = headerBytes.ToList().GetRange(4,2);
            if (lenBytes.Count == 2)
            {
                len = lenBytes[0] * 256 + lenBytes[1];
            }
            return len;
        }

        private void AddTcpHeader(List<byte> bytes)
        {
            List<byte> tcpHeader = new List<byte>();
            ushort txId = (ushort)(tx_id++ % ushort.MaxValue);
            tcpHeader.Add((byte)(txId / 256));
            tcpHeader.Add((byte)(txId % 256));
            tcpHeader.Add(0x00);
            tcpHeader.Add(0x00);
            tcpHeader.Add((byte)(bytes.Count / 256));
            tcpHeader.Add((byte)(bytes.Count % 256));
            bytes.InsertRange(0, tcpHeader);
        }
    }
}