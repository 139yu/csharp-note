using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.DeviceAccess.Transfer;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DeviceAccess.Execute
{
    public class S7COMM : ExecuteObject
    {
        private static int serialId = 0;
        private int _pduSize = 240; // PDU大小

        Dictionary<byte, string> HeaderErrors = new Dictionary<byte, string>()
        {
            { 0x00, "无错误" },
            { 0x81, "应用程序关系错误" },
            { 0x82, "对象定义错误" },
            { 0x83, "无资源可用错误" },
            { 0x84, "服务处理错误" },
            { 0x85, "请求错误" },
            { 0x87, "访问错误" }
        };

        Dictionary<byte, string> DataItemReturnCodes = new Dictionary<byte, string>()
        {
            { 0xff, "请求成功" },
            { 0x01, "硬件错误" },
            { 0x03, "对象不允许访问" },
            { 0x05, "地址越界，所需的地址超出此PLC的极限" },
            { 0x06, "请求的数据类型与存储类型不一致" },
            { 0x07, "日期类型不一致" },
            { 0x0a, "对象不存在" }
        };

        Dictionary<string, SiemensAreaTypes> AreaTypeDic = new Dictionary<string, SiemensAreaTypes>()
        {
            { "I", SiemensAreaTypes.INPUT },
            { "Q", SiemensAreaTypes.OUTPUT },
            { "M", SiemensAreaTypes.MERKER },
            { "V", SiemensAreaTypes.DATABLOCK }
        };

        internal override Result Match(List<DevicePropEntity> props, List<TransferObject> transfers)
        {
            var ps = props
                .Where(p => p.PropName.Equals("IP") || p.PropName.Equals("Port"))
                .Select(p => p.PropValue)
                .ToList();
            return this.Match(ps, props, transfers, "SocketTcpUnit");
        }

        public override Result<List<CommAddress>> GroupAddress(List<VariableProperty> variables)
        {
            Result<List<CommAddress>> result = new Result<List<CommAddress>>();
            List<SiemensAddress> addressList = new List<SiemensAddress>();
            SiemensAddress address = new SiemensAddress();
            SiemensAddress last = null;
            foreach (var point in variables)
            {
                var current = AnalysisAddress(point);
                if (current.AreaType != address.AreaType)
                {
                    last = current;
                    address = new SiemensAddress(current);
                    addressList.Add(address);
                }
                else
                {
                    if (Math.Abs(current.ByteAddress - address.ByteAddress + current.ByteCount - address.ByteCount) >
                        32)
                    {
                        last = current;
                        address = new SiemensAddress(current);
                        addressList.Add(address);
                    }
                    else
                    {
                        address.ByteCount +=
                            Math.Abs(current.ByteAddress - last.ByteAddress + current.ByteCount - last.ByteCount);
                    }
                }

                address.Variables.Add(current);
            }

            result.Data = new List<CommAddress>(addressList);
            return result;
        }

        private int CalLen(byte[] headerBytes)
        {
            var lenBytes = headerBytes.ToList().GetRange(2, 2);
            int len = lenBytes[0] * 256 + lenBytes[1];
            return len;
        }

        private SiemensAddress AnalysisAddress(VariableProperty point)
        {
            var address = new SiemensAddress();
            address.DBNumber = 0;
            var varAddr = point.VarAddr.ToUpper();
            var blockName = varAddr.Substring(0, 2);
            var strArr = varAddr.Split(".");
            if (blockName.Equals("DB"))
            {
                address.AreaType = SiemensAreaTypes.DATABLOCK;
                address.DBNumber = int.Parse(strArr[0].Substring(2));
                address.ByteAddress = int.Parse(strArr[1]);
                address.ByteCount = Marshal.SizeOf(point.ValueType);
                int bitAddress;
                if (strArr.Length == 3 && int.TryParse(strArr[2], out bitAddress))
                {
                    if (bitAddress > 7)
                    {
                        throw new Exception("Bit地址设置错误，只允许在0-7范围内");
                    }

                    address.BitAddress = (byte)bitAddress;
                    address.ByteCount = 1; // 如果有Bit地址，字节数为1
                }
            }
            else if (new string[] { "I", "Q", "M", "V" }.Contains(varAddr[0].ToString()))
            {
                var areaName = blockName[0].ToString();
                if (areaName.Equals("V"))
                {
                    address.DBNumber = 1;
                }

                if (AreaTypeDic.ContainsKey(areaName))
                {
                    address.AreaType = AreaTypeDic[areaName];
                }

                address.ByteCount = Marshal.SizeOf(point.ValueType);
                address.ByteAddress = int.Parse(varAddr.Substring(1));
                int bitAddress;
                if (strArr.Length == 3 && int.TryParse(strArr[2], out bitAddress))
                {
                    if (bitAddress > 7)
                    {
                        throw new Exception("Bit地址设置错误，只允许在0-7范围内");
                    }

                    address.BitAddress = (byte)bitAddress;
                    address.ByteCount = 1; // 如果有Bit地址，字节数为1
                }
            }
            else if (point.ValueType == typeof(bool))
            {
                address.ByteCount = 1;
            }

            return address;
        }

        public override Result Read(List<CommAddress> mas)
        {
            var prop = this.Props.FirstOrDefault(p => p.PropName == "Timeout");
            int timeout = 5000;
            if (prop != null)
                int.TryParse(prop.PropValue, out timeout);

            foreach (var address in mas)
            {
                if (!this.TransferObject.ConnectState)
                {
                    var connectResult = this.Connect();
                    if (!connectResult.Status)
                    {
                        return connectResult;
                    }
                }

                var readBytes = GetReadCommand(address.Variables);
                var receiveResult = this.TransferObject.SendAndReceive(readBytes, 4, 0, timeout, CalLen);
                if (!receiveResult.Status)
                {
                    throw new Exception(receiveResult.Message);
                }

                var resultData = receiveResult.Data;
                if (resultData[17] != 0x00)
                {
                    throw new Exception($"{resultData[17]}:{HeaderErrors[resultData[17]]}");
                }

                for (int i = 20; i < resultData.Count; i++)
                {
                    
                }
            }

            return null;
        }

        private List<byte> GetReadCommand(List<CommAddress> addressList)
        {
            // 每个 address都是一个item
            List<byte> itemBytes = new List<byte>();
            foreach (var address in addressList)
            {
                var item = address as SiemensAddress;
                itemBytes.AddRange(GetParamItemBytes(item));
            }

            return GetRequestCommands(itemBytes);
        }

        public List<byte> GetRequestCommands(List<byte> itemBytes, List<byte> dataBytes = null)
        {
            // TPKT
            List<byte> tpktBytes = new List<byte>();
            tpktBytes.Add(0x03);
            tpktBytes.Add(0x00);
            // --------整个字节数组的长度

            // COTP
            List<byte> cotpBytes = new List<byte>();
            cotpBytes.Add(0x02);
            cotpBytes.Add(0xf0);
            cotpBytes.Add(0x80);

            // Header
            List<byte> headerBytes = new List<byte>();
            headerBytes.Add(0x32);
            headerBytes.Add(0x01);
            headerBytes.Add(0x00);
            headerBytes.Add(0x00);
            headerBytes.Add(0x00);
            headerBytes.Add(0x00);
            // 添加Parameter字节数组的长度
            // 添加Data字节数组的长度


            // 开始组装paramBytes
            // 开始组装 dataBytes
            if (itemBytes != null)
            {
                // 拼装Header&Parameter
                headerBytes.Add((byte)(itemBytes.Count / 256 % 256));
                headerBytes.Add((byte)(itemBytes.Count % 256));
            }

            if (dataBytes != null)
            {
                headerBytes.Add((byte)(dataBytes.Count / 256 % 256));
                headerBytes.Add((byte)(dataBytes.Count % 256));
            }
            else
            {
                headerBytes.Add(0x00);
                headerBytes.Add(0x00);
            }

            if (itemBytes != null)
                headerBytes.AddRange(itemBytes);
            if (dataBytes != null)
                headerBytes.AddRange(dataBytes);
            // 拼装COTP&Header
            cotpBytes.AddRange(headerBytes);
            //拼装 TPKT&COTP
            // tpkt现有长度+报文总长度2个字节+COTP长度
            int count = tpktBytes.Count + 2 + cotpBytes.Count;
            tpktBytes.Add((byte)(count / 256 % 256));
            tpktBytes.Add((byte)(count % 256));
            tpktBytes.AddRange(cotpBytes);

            // 检查请求报文长度是否超过PDU Size
            if (tpktBytes.Count > _pduSize)
                throw new Exception("请求报文长度超过PLC的PDU最大值");


            return tpktBytes;
        }

        private List<byte> GetParamItemBytes(SiemensAddress sa)
        {
            List<byte> paramBytes = new List<byte>();
            // 组装Parameter Item
            paramBytes.Add(0x12);
            paramBytes.Add(0x0a);
            paramBytes.Add(0x10);
            paramBytes.Add(0x02); // 读取类型  Bit  02Byte  03Char  04Word
            // 写入长度
            paramBytes.Add((byte)(sa.ByteCount / 256 % 256));
            paramBytes.Add((byte)(sa.ByteCount % 256));
            // DB块编号   200Smart V区  DB1
            paramBytes.Add((byte)(sa.DBNumber / 256 % 256));
            paramBytes.Add((byte)(sa.DBNumber % 256));
            // 数据区域
            paramBytes.Add((byte)sa.AreaType); //81 I   82  Q   83  M   84DB
            // 地址
            // Byte:100   Bit:0

            //int address = startAddr * 8 + bitAddr;
            int addr = (sa.ByteAddress << 3);
            paramBytes.Add((byte)(addr / 256 / 256 % 256));
            paramBytes.Add((byte)(addr / 256 % 256));
            paramBytes.Add((byte)(addr % 256));

            return paramBytes;
        }

        public override Result Connect()
        {
            var result = new Result();

            try
            {
                var tcpConnectRes = this.TransferObject.Connect();
                if (!tcpConnectRes.Status)
                {
                    throw new Exception(tcpConnectRes.Message);
                }

                int slot = 0;
                var slotProp = this.Props.FirstOrDefault(p => p.PropName == "Slot");
                if (slotProp == null || slotProp.PropValue == null)
                {
                    throw new Exception("请填写s7 COMM 插槽号");
                    int.TryParse(slotProp.PropValue, out slot);
                }

                int rack = 0;
                var rackProp = this.Props.FirstOrDefault(p => p.PropName == "Rack");
                if (rackProp == null || rackProp.PropValue == null)
                {
                    throw new Exception("请填写s7 COMM 机架号");
                }

                int.TryParse(rackProp.PropValue, out rack);
                var cotpResult = COTPConnect(slot, rack);
                if (!cotpResult.Status)
                {
                    throw new Exception(cotpResult.Message);
                }

                var setupCommunication = SetupCommunication();
                if (!setupCommunication.Status)
                {
                    throw new Exception(cotpResult.Message);
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot">插槽号</param>
        /// <param name="rack">机架号</param>
        /// <returns></returns>
        private Result COTPConnect(int slot, int rack)
        {
            Result result = new Result();
            List<byte> bytes = new List<byte>();
            var tpkt = new List<byte>()
            {
                0x03, 0x00,
                0x00, 0x16
            };
            var cotp = new List<byte>()
            {
                0x11, 0xe0, // 后续字节数和PDU Type
                0x00, 0x00, 0x00, 0x01, // dst、src
                0x00,

                0xc1, // src-tsap
                0x02, // parameter length
                0x10, 0x00, // source tsap

                0xc2, // dst-tsap PLC
                0x02, // parameter length
                (byte)(rack % 255), (byte)(slot % 255), // destination tsap，机架号，插槽号

                0xc0, // tpdu-size
                0x01, 0x0a // parameter length，tpdu size
            };
            bytes.AddRange(tpkt);
            bytes.AddRange(cotp);
            // 返回的是4字节以后的数据
            var prop = this.Props.FirstOrDefault(p => p.PropName == "Timeout");
            int timeout = 5000;
            if (prop != null)
                int.TryParse(prop.PropValue, out timeout);
            var receiveResult = this.TransferObject.SendAndReceive(bytes, 4, 0, timeout, CalLen);
            if (!receiveResult.Status)
            {
                result.Status = false;
                result.Message = receiveResult.Message;
            }

            if (receiveResult.Data[5] != 0xd0)
            {
                throw new Exception("COTP连接响应异常");
            }

            var receiveBytes = receiveResult.Data;
            return result;
        }

        private Result SetupCommunication()
        {
            serialId++;
            var tpkt = new List<byte>()
            {
                0x03, 0x00,
                0x00, 0x19 // total length
            };
            var cotp = new List<byte>()
            {
                0x02, //current length
                0xf0, // PDU Type
                0x80
            };
            var s7Header = new List<byte>()
            {
                0x32, 0x01,
                0x00, 0x00,
                (byte)(serialId % 256), (byte)(serialId / 256), // serial number
                0x00, 0x08, // parameter length
                0x00, 0x00, // data length
            };
            var s7Parameter = new List<byte>()
            {
                0xf0, //设置通信参数
                0x00, 0x03, 0x00, 0x03,
                0x03, 0xc0, // PDU size
            };
            var bytes = new List<byte>();
            bytes.AddRange(tpkt);
            bytes.AddRange(cotp);
            bytes.AddRange(s7Header);
            bytes.AddRange(s7Parameter);
            Result result = new Result();
            int timeout = 5000;
            var timeoutVar = Props
                .Where(p => p.PropName.Equals("Timeout"))
                .Select(p => p.PropValue)
                .FirstOrDefault();
            if (timeoutVar != null && int.TryParse(timeoutVar, out int t))
            {
                timeout = t;
            }

            var receiveResult = this.TransferObject.SendAndReceive(bytes, 4, 0, timeout, CalLen);
            if (!receiveResult.Status)
            {
                throw new Exception(receiveResult.Message);
            }

            var resultData = receiveResult.Data;
            this._pduSize = resultData[resultData.Count - 2] * 256 + resultData[resultData.Count - 1];
            return result;
        }
    }
}