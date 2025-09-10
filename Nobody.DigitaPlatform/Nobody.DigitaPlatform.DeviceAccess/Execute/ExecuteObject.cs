using Nobody.DigitaPlatform.Common.Enum;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.DeviceAccess.Transfer;
using Nobody.DigitaPlatform.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.DeviceAccess.Execute
{
    public abstract class ExecuteObject
    {
        // 动态配置字节
        public EndianType EndianType { get; set; } = EndianType.ABCD;
        internal TransferObject TransferObject { get; set; }
        internal List<DevicePropEntity> Props { get; set; }
        internal virtual Result Match(List<DevicePropEntity> props, List<TransferObject> transfers)
        {
            return Result.Failed();
        }
        internal Result Match(List<string> propVars, List<DevicePropEntity> props, List<TransferObject> transfers, string unit)
        {
            this.Props = props;
            var result = new Result();
            this.TransferObject = transfers.FirstOrDefault(t =>
                t.GetType().Name.Equals(unit) &&
                propVars.All(p => t.Conditions.Any(c => c.Equals(p)))
            );
            if (this.TransferObject == null)
            {
                var type = Assembly.Load("Nobody.DigitaPlatform.DeviceAccess")
                    .GetType("Nobody.DigitaPlatform.DeviceAccess.Transfer." + unit);
                if (type == null)
                {
                    result.Status = false;
                    result.Message = $"未找到通信单元：{unit}";
                    return result;
                }

                this.TransferObject = Activator.CreateInstance(type) as TransferObject;
                this.TransferObject.Conditions = propVars;
                transfers.Add(this.TransferObject);
                // 配置通信参数，如波特率、数据位、停止位等
                var configResult = this.TransferObject.Config(this.Props);
                if (!configResult.Status)
                {
                    return configResult;
                }
            }

            return result;
        }
        public virtual Result Connect()
        {
            return new Result();
        }

        public virtual Result Read(List<CommAddress> mas) => new Result();

        public virtual void ReadAsync()
        {
        }

        public virtual void Write()
        {
        }

        public virtual void WriteAsync()
        {
        }

        public virtual void Dispose()
        {
        }

        /// <summary>
        /// 将字节序转换为大端序（高位在前，低位在后）
        /// </summary>
        /// <returns></returns>
        protected List<byte> SwitchEndianType(List<byte> bytes)
        {
            // 不管是什么字节序，这个Switch里返回的是ABCD这个顺序
            List<byte> temp = new List<byte>();
            switch (EndianType)  // alt+enter
            {
                case EndianType.ABCD:
                    temp = bytes;
                    break;
                case EndianType.DCBA:
                    for (int i = bytes.Count - 1; i >= 0; i--)
                    {
                        temp.Add(bytes[i]);
                    }
                    break;
                case EndianType.CDAB:
                    temp = new List<byte> { bytes[2], bytes[3], bytes[0], bytes[1] };
                    break;
                case EndianType.BADC:
                    temp = new List<byte> { bytes[1], bytes[0], bytes[3], bytes[2] };
                    break;
            }
            if (BitConverter.IsLittleEndian)
                temp.Reverse();

            return temp;
        }

        public virtual Result<List<CommAddress>> GroupAddress(List<VariableProperty> variables)
        {
            return null;
        }

        protected virtual CommAddress AnalyzeAddress(VariableProperty item)
        {
            return null;
        }
    }
}