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
    [DefaultEvent("ControlDoubleClick")]
    public partial class TextSet : UserControl
    {
        public TextSet()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //通过双缓冲技术消除绘制过程中的闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //调整控件大小时自动触发重绘，保持视觉一致性
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string titleName = "1#站点温度限高";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置显示标题")]
        public string TitleName
        {
            get { return titleName; }
            set
            {
                titleName = value;
                this.lbl_title.Text = value;
            }
        }
        private string currentValue = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("当前值")]
        public string CurrentValue
        {
            get { return currentValue; }
            set
            {
                currentValue = value;
                this.lbl_value.Text = value;
            }
        }
        private string unit = "°C";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("显示单位")]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                this.lbl_unit.Text = value;
            }
        }
        private string bindName = "模块1温度限高";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("绑定变量名称")]
        public string BindName
        {
            get { return bindName; }
            set
            {
                bindName = value;
            }
        }

        private string alarmVarName = "模块1温度限高";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("报警变量名称")]
        public string AlarmVarName
        {
            get { return alarmVarName; }
            set
            {
                alarmVarName = value;
            }
        }

        private bool isAlarm = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("是否报警")]
        public bool IsAlarm
        {
            get { return isAlarm; }
            set
            {
                if(isAlarm != value)
                {
                    isAlarm = value;
                    this.led_alarm.Value = isAlarm;
                }
            }
        }

        public event EventHandler ControlDoubleClick;

        private void lbl_Value_DoubleClick(object sender,EventArgs e)
        {
            ControlDoubleClick?.Invoke(this, e);
        }
    }
}
