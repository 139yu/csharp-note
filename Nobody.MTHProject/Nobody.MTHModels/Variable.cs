using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    public class Variable
    {
        /// <summary>
        /// 所属组名
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 变量名
        /// </summary>
        public string VarName { get; set; }
        /// <summary>
        /// 起始地址
        /// </summary>
        public ushort Start { get; set; }
        /// <summary>
        /// 寄存器数量或位偏移量
        /// </summary>
        public ushort Length { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 系数
        /// </summary>
        public float Scale { get; set; } = 1.0f;
        /// <summary>
        /// 偏移量
        /// </summary>
        public float Offset { get; set; } = 0.0f;
        /// <summary>
        /// 是否上升沿报警
        /// </summary>
        public bool PosAlarm { get; set; }
        /// <summary>
        /// 是否下降沿报警
        /// </summary>
        public bool NegAlarm { get; set; }

        [ExcelIgnore]
        public object VarValue { get; set; }
        [ExcelIgnore]
        public bool PosAlarmCache { get; set; } = false;
        [ExcelIgnore]
        public bool NegAlarmCache { get; set; } = true;
    }
}
