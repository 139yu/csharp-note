using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHControlLib
{
    public partial class TextSetEx : UserControl
    {
        public TextSetEx()
        {
            InitializeComponent();
        }
        private string titleName = "1#站点温度高限";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("标题名称")]
        public string TitleName
        {
            get { return titleName; }
            set
            {
                titleName = value;
                this.lbl_titleName.Text = value;
                this.Invalidate();
            }
        }
        private string unit;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("单位")]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                this.lbl_unit.Text = value;
            }
        }
        private float currentValue = 0.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("单位")]
        public float CurrentValue
        {
            get 
            { 
                return Convert.ToSingle(this.txt_value.Value);
            }
            set
            {
                currentValue = value;
                this.txt_value.Value = Convert.ToDecimal(currentValue);
            }
        }

    }
}
