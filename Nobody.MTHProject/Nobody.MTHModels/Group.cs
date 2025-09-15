using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    public class Group
    {
        /// <summary>
        /// 组名
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 起始地址
        /// </summary>
        public ushort Start { get; set; }
        /// <summary>
        /// 字节长度
        /// </summary>
        public ushort Length { get; set; }
        /// <summary>
        /// 储存区
        /// </summary>
        public string StoreArea { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        [ExcelIgnore]
        public List<Variable> VarList { get; set; }
    }
}
