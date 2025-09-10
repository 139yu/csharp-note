using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.DeviceAccess.Transfer;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DeviceAccess.Execute
{
    public class ModbusASCII : ModbusBase
    {
        internal override Result Match(List<DevicePropEntity> props, List<TransferObject> transfers)
        {

            var propVars = props
                .Where(p => p.PropName.Equals("PortName"))
                .Select(p => p.PropValue)
                .ToList();
            return this.Match(propVars, props, transfers, "SerialUnit");
        }

        protected override Result<List<byte>> Read(byte slaveId, byte funcCode, ushort start, ushort count, int resLen)
        {
            var receiveResult = new Result<List<byte>>();
            var readPdu = CreateReadPDU(slaveId, funcCode, start, count);
            LRC(readPdu);
            var reqBytes = ByteArrayToAsciiArray(readPdu);
            int tryCount = 30;
            var tryCountProp = Props.FirstOrDefault(p => p.PropName.Equals("TryCount"));
            if (tryCountProp != null && tryCountProp.PropValue != null)
            {
                int.TryParse(tryCountProp.PropValue,out tryCount);
            }

            this.TransferObject.Connect(tryCount);
            var timeoutProp = Props.FirstOrDefault(p => p.PropName.Equals("Timeout"));
            int timeout = 100;
            if (timeoutProp != null && timeoutProp.PropValue != null)
            {
                int.TryParse(timeoutProp.PropValue, out timeout);
            }
            var result = this.TransferObject.SendAndReceive(reqBytes, (resLen + 4) * 2 + 3, 5, timeout);
            if (!result.Status)
            {
                receiveResult.Status = false;
                receiveResult.Message = result.Message;
                return receiveResult;
            }
            receiveResult.Data = result.Data;
            return receiveResult;
        }

        private void LRC(List<byte> value)
        {
            if (value == null || value.Count == 0) return;

            int sum = 0;
            for (int i = 0; i < value.Count; i++)
            {
                sum += value[i];
            }

            sum = sum % 256;
            sum = 256 - sum;

            value.Add((byte)sum);
        }
        /// <summary>
        /// 将字节数组转换为ASCII格式的字节数组
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private List<byte> ByteArrayToAsciiArray(List<byte> bytes)
        {
            // 转成16进制字符串
            var hex = bytes.Select(b => b.ToString("X2"));
            var hexStr = ":" + string.Join("",hex) + "\r\n";
            return new List<byte>(Encoding.ASCII.GetBytes(hexStr).ToList());
        }

        private List<byte> AsciiArrayToByteArray(List<byte> bytes)
        {
            List<byte> result = new List<byte>();
            // 将ASCII字节转换为字符串列表，如 ["3A", "30", "31", ...]
            var asciiList = bytes.Select(b => ((char)b).ToString()).ToList();
            for (var i = 0; i < asciiList.Count; i+=2)
            {
                string hex = asciiList[i] + asciiList[i + 1];
                result.Add(Convert.ToByte(hex,16));
            }
            return result;
        }
    }
}
