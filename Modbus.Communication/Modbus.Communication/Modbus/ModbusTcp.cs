using System.Collections.Generic;
using Modbus.Communication.Common;

namespace Modbus.Communication.Modbus
{
    public class ModbusTcp: ModbusBase
    {
        #region 读操作

        public override Result<bool> ReadCoils(byte slave, byte funcCode, ushort start, ushort count)
        {
            return base.ReadCoils(slave, funcCode, start, count);
        }

        public override Result<T> ReadRegisters<T>(byte slave, byte funcCode, ushort start, ushort count)
        {
            return base.ReadRegisters<T>(slave, funcCode, start, count);
        }
        protected override void Write(List<byte> writePud)
        {
            base.Write(writePud);
        }
        #endregion


        #region 写操作

        public override Result<bool> WriteCoils(byte slave, ushort start, List<bool> data)
        {
            return base.WriteCoils(slave, start, data);
        }

        public override Result<bool> WriteRegisters<T>(byte slave, ushort start, List<T> data)
        {
            return base.WriteRegisters(slave, start, data);
        }

        protected override List<byte> Read(byte slave, byte funcCode, ushort start, ushort count, ushort respLen)
        {
            return base.Read(slave, funcCode, start, count, respLen);
        }

        #endregion

       
    }
}