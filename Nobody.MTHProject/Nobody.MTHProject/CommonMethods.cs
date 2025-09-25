using Nobody.MTHHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace Nobody.MTHModels
{
    public class CommonMethods
    {
        public static Device Device { get; set; }
        public static DataFormat DataFormat { get; set; } = DataFormat.ABCD;
        public static Action<int,string> AddLogAction { get; set; }
        public static SysAdmin CurrentUser { get; set; }
        public static ModbusTCP Modbus { get; set; }

        public static RecipeInfo CurrentRecipe { get; set; }
        private static Variable FindVariable(string varName)
        {
            foreach (var group in Device.GroupList)
            {
                var variable = group.VarList.Find(v => v.VarName.Equals(varName));
                if (variable != null) return variable;
            }
            return null;
        }

        public static bool CommonWrite(string varName,string value)
        {
            var variable = FindVariable(varName);
            if (variable == null) return false;
            DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType);
            var result = MigrationLib.SetMigrationValue(value, dataType, variable.Scale.ToString(), variable.Offset.ToString());
            if(!result.IsSuccess) return false;
            var targetVal = result.Content;
            try
            {
                switch (dataType)
                {
                    case DataType.Bool:
                        return Modbus.PreSetSingleCoil(variable.Start, Convert.ToBoolean(targetVal));
                    case DataType.Short:
                        return Modbus.PreSetSingleRegister(variable.Start, Convert.ToInt16(targetVal));
                    case DataType.UShort:
                        return Modbus.PreSetSingleRegister(variable.Start, Convert.ToUInt16(targetVal));
                    case DataType.Int:
                        return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromInt(Convert.ToInt32(targetVal), DataFormat));
                    case DataType.UInt:
                        return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromUInt(Convert.ToUInt32(targetVal), DataFormat));
                    case DataType.Float:
                        return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromFloat(Convert.ToSingle(targetVal), DataFormat));
                    case DataType.Double:
                        return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromDouble(Convert.ToDouble(targetVal), DataFormat));
                    case DataType.Long:
                        return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromLong(Convert.ToInt64(targetVal), DataFormat));
                    case DataType.ULong:
                        return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromULong(Convert.ToUInt64(targetVal), DataFormat));
                    case DataType.String:
                        return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromString(targetVal, Encoding.ASCII));
                    case DataType.HexString:
                        return Modbus.PreSetMultiRegisters(variable.Start, ByteArrayLib.GetByteArrayFromHexString(targetVal));
                    default: return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
