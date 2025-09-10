using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.DeviceAccess.Transfer;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DeviceAccess.Execute
{
    public class ModbusRTU : ModbusBase
    {
        internal override Result Match(List<DevicePropEntity> props, List<TransferObject> transfers)
        {
            // 取出所有的端口名称
            var propVars = props
                .Where(p => p.PropName.Equals("PortName"))
                .Select(p => p.PropValue)
                .ToList();
            return this.Match(propVars, props, transfers, "SerialUnit");
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveId"></param>
        /// <param name="funcCode"></param>
        /// <param name="start"></param>
        /// <param name="count">寄存器数量或线圈数量</param>
        /// <param name="resLen">响应数据字节数，不包含头和CRC</param>
        /// <returns></returns>
        protected override Result<List<byte>> Read(byte slaveId, byte funcCode, ushort start, ushort count, int resLen)
        {
            Result<List<byte>> result = new Result<List<byte>>();
            try
            {
                var readPdu = CreateReadPDU(slaveId, funcCode, start, count);
                CRC16(readPdu);
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

                var receiveResult = this.TransferObject.SendAndReceive(readPdu, resLen + 5, 5, timeout);
                if (!receiveResult.Status)
                {
                    throw new Exception(receiveResult.Message);
                }

                // 读取成功，进行CRC校验
                var crcBytes = receiveResult.Data.GetRange(0, receiveResult.Data.Count - 2);
                CRC16(crcBytes);
                if (!crcBytes.SequenceEqual(receiveResult.Data))
                {
                    throw new Exception("CRC校验失败");
                }

                if (receiveResult.Data[1] > 0x80)
                {
                    // 
                    byte errorCode = receiveResult.Data[2];
                    throw new Exception(Errors[errorCode]);
                }

                result.Data = receiveResult.Data.GetRange(3, receiveResult.Data.Count - 5);
                
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            return result;
        }

        public override void Write(byte slaveNum, byte funcCode, ushort startAddr, byte[] data, ushort respLen)
        {
            var dataBytes = this.CreateWritePDU(slaveNum, funcCode, startAddr, data);
            this.CRC16(dataBytes);
            var tryCountProp = this.Props.FirstOrDefault(p => p.PropName.Equals("TryCount"));
            int tryCount = 30;
            if (tryCountProp != null)
            {
                int.TryParse(tryCountProp.PropValue, out tryCount);
            }

            var connectResult = this.TransferObject.Connect(tryCount);
            if (!connectResult.Status)
            {
                throw new Exception(connectResult.Message);
            }
            int timeout = 5000;
            var timeoutProp = this.Props.FirstOrDefault(p => p.PropName.Equals("Timeout"));
            if (tryCountProp != null)
            {
                int.TryParse(tryCountProp.PropValue, out timeout);
            }
            var receiveResult = this.TransferObject.SendAndReceive(dataBytes, respLen, 5, timeout);
            if (!receiveResult.Status)
            {
                throw new Exception(receiveResult.Message);
            }
            List<byte> crcValidation = receiveResult.Data.GetRange(0, receiveResult.Data.Count - 2);
            this.CRC16(crcValidation);
            if (!crcValidation.SequenceEqual(receiveResult.Data))
            {
                throw new Exception("CRC校验检查不匹配");
                // CRC 校验失败
            }

            // 六、检查异常报文
            if (receiveResult.Data[1] > 0x80)
            {
                byte errorCode = receiveResult.Data[2];
                throw new Exception(Errors.ContainsKey(errorCode) ? Errors[errorCode] : "自定义异常");
            }
        }


        private void CRC16(List<byte> value, ushort poly = 0xA001, ushort crcInit = 0xFFFF)
        {
            if (value == null || !value.Any())
                throw new ArgumentException("");

            //运算
            ushort crc = crcInit;
            for (int i = 0; i < value.Count; i++)
            {
                crc = (ushort)(crc ^ (value[i]));
                for (int j = 0; j < 8; j++)
                {
                    crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ poly) : (ushort)(crc >> 1);
                }
            }

            byte hi = (byte)((crc & 0xFF00) >> 8); //高位置
            byte lo = (byte)(crc & 0x00FF); //低位置

            value.Add(lo);
            value.Add(hi);
        }
    }
}