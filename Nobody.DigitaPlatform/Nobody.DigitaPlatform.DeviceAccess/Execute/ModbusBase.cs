using Nobody.DigitaPlatform.Common.Enum;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Nobody.DigitaPlatform.DeviceAccess.Transfer;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DeviceAccess.Execute
{
    public abstract class ModbusBase : ExecuteObject
    {
        protected static Dictionary<int, string> Errors = new Dictionary<int, string>
        {
            { 0x01, "非法功能码" },
            { 0x02, "非法数据地址" },
            { 0x03, "非法数据值" },
            { 0x04, "从站设备故障" },
            { 0x05, "确认，从站需要一个耗时操作" },
            { 0x06, "从站忙" },
            { 0x08, "存储奇偶性差错" },
            { 0x0A, "不可用网关路径" },
            { 0x0B, "网关目标设备响应失败" },
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mas">分组后的地址</param>
        /// <returns></returns>
        public override Result Read(List<CommAddress> mas)
        {
            var result = new Result();
            try
            {
                var prop = Props.FirstOrDefault(p => p.PropName.Equals("SlaveId"));
                if (prop == null || string.IsNullOrEmpty(prop.PropValue))
                {
                    throw new Exception("从站ID未配置");
                }

                byte slaveId = 0x01;
                byte.TryParse(prop.PropValue, out slaveId);
                foreach (ModbusAddress ma in mas)
                {
                    // 一次请求最多120个寄存器
                    int max = 120;
                    int reqTotalCount = ma.Length;
                    // 将一组数据打包成一个请求
                    int resLen = (ushort)(ma.Length * 2);
                    if (ma.FuncCode == 1 || ma.FuncCode == 2)
                    {
                        resLen = int.Parse(Math.Ceiling(ma.Length / 8.0).ToString());
                        max = 240 * 8;
                    }

                    List<byte> valueBytes = new List<byte>();
                    for (int i = 0; i < reqTotalCount; i += max)
                    {
                        ushort len = (ushort)Math.Min(ma.Length - i, max);
                        var readResult = Read(slaveId,
                            (byte)ma.FuncCode,
                            (ushort)ma.StartAddress,
                            len,
                            resLen);
                        if (!readResult.Status)
                        {
                            result.Status =false;
                            result.Message = readResult.Message;
                            return result;
                        }
                        valueBytes.AddRange(readResult.Data);
                    }

                    if (ma.FuncCode == 3 || ma.FuncCode == 4)
                    {
                        foreach (ModbusAddress address in ma.Variables)
                        {
                            int index = (address.StartAddress - ma.StartAddress) * 2;

                            address.valueBytes = this.SwitchEndianType(valueBytes
                                .GetRange(index, address.Length * 2));
                        }
                    }
                    else
                    {
                        // 读线圈
                        // 读取结果
                        List<byte> resultState = new List<byte>();
                        // 使用一个字节保存一个线圈状态
                        foreach (var valueByte in valueBytes)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                // 0x01表示线圈ON，0x00表示线圈OFF
                                resultState.Add((byte)(valueByte & (1 << i) >> i));
                            }
                        }

                        foreach (ModbusAddress address in ma.Variables)
                        {
                            var start = address.StartAddress - ma.StartAddress;
                            address.valueBytes = resultState.GetRange(start, address.Length);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        protected virtual Result<List<byte>> Read(byte slaveId, byte funcCode, ushort start, ushort count, int resLen)
        {
            return null;
        }
       
        /// <summary>
        /// 将地址分组，一次性读出一组数据
        /// </summary>
        /// <param name="variables"></param>
        /// <returns></returns>
        public override Result<List<CommAddress>> GroupAddress(List<VariableProperty> variables)
        {
            Result<List<CommAddress>> result = new Result<List<CommAddress>>();
            result.Data = new List<CommAddress>();
            List<ModbusAddress> mas = new List<ModbusAddress>();
            foreach (var item in variables)
            {
                ModbusAddress currentAddr = AnalyzeAddress(item);
                ModbusAddress firstAddr = mas
                    .FirstOrDefault(m => m.FuncCode == currentAddr.FuncCode);
                if (firstAddr == null)
                {
                    var addr = new ModbusAddress(currentAddr);
                    currentAddr.Variables.Add(addr);
                    mas.Add(currentAddr);
                }
                else
                {

                    firstAddr.Variables.Add(currentAddr);
                    if (firstAddr.StartAddress > currentAddr.StartAddress)
                    {
                        if ((firstAddr.StartAddress + firstAddr.Length) > (currentAddr.StartAddress + currentAddr.Length))
                        {
                            var count = (firstAddr.StartAddress - currentAddr.StartAddress) + firstAddr.Length;
                            firstAddr.StartAddress = currentAddr.StartAddress;
                            firstAddr.Length = count;
                        }
                    }
                    else
                    {
                        firstAddr.Length = (currentAddr.StartAddress - firstAddr.StartAddress) + currentAddr.Length;
                    }

                }
            }
            result.Data.AddRange(mas);
            return result;
        }
        protected override ModbusAddress AnalyzeAddress(VariableProperty item)
        {
            // 计算寄存器数量
            ModbusAddress ma = new ModbusAddress();
            var valueType = item.ValueType;
            var count = Marshal.SizeOf(valueType) / 2;
            ma.Length = count;
            // 输出线圈
            if (item.VarAddr.StartsWith("0"))
            {
                ma.FuncCode = 01;
                ma.Length = 1;
            }
            // 输入线圈
            else if (item.VarAddr.StartsWith("1"))
            {
                ma.FuncCode = 02;
                ma.Length = 1;
            }
            // 输出寄存器
            else if (item.VarAddr.StartsWith("3"))
                ma.FuncCode = 04;
            // 输入寄存器
            else if (item.VarAddr.StartsWith("4"))
                ma.FuncCode = 03;

            // 40001 ---> 0地址
            ma.StartAddress = int.Parse(item.VarAddr.Substring(1)) - 1;
            ma.VarNum = item.VarNum;
            return ma;
        }
        protected List<byte> CreateReadPDU(byte slaveId, byte funcCode, ushort start, ushort count)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(slaveId);
            bytes.Add(funcCode);
            var startBytes = BitConverter.GetBytes(start);
            bytes.Add(startBytes[1]);
            bytes.Add(startBytes[0]);
            bytes.Add((byte)(count / 256));
            bytes.Add((byte)(count % 256));

            return bytes;
        }

        
    }
}