using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Models
{
    public class DevicePropOption
    {
        public string PropHeader { get; set; }
        public string PropName { get; set; }

        /// <summary>
        /// 0：文本框；1：下拉框
        /// </summary>
        public string PropType { get; set; }

        /// <summary>
        /// 默认选中项的索引
        /// </summary>
        public int DefaultSelectedIndex { get; set; }

        public List<string> PropValueOptions { get; set; }
    }
}