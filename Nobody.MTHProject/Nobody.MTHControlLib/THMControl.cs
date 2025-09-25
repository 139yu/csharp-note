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
    public partial class THMControl : UserControl
    {
        public THMControl()
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

        private string title = "1#站点";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("标题")]
        public string Title
        {
            get { return title; }
            set 
            {
                title = value;
                this.lbl_title.Text = title;
            }
        }


        private string tempValue;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("温度")]
        public string TempValue
        {
            get { return tempValue; }
            set
            {
                if (tempValue != value)
                {
                    tempValue = value;
                    this.lbl_temp.Text = tempValue.ToString();
                    dialPlate.TempValue = Convert.ToSingle(tempValue); 
                }
            }
        }

        private string humidityValue;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("湿度")]
        public string HumidityValue
        {
            get { return humidityValue; }
            set
            {
                if (humidityValue != value)
                {
                    humidityValue = value;
                    this.lbl_humidity.Text = humidityValue.ToString();
                    dialPlate.HumidityValue = Convert.ToSingle(humidityValue);
                }
            }
        }

        private bool errorState;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("错误状态")]
        public bool ErrorState
        {
            get { return errorState; }
            set
            {
                errorState = value;
                lbl_title.BackColor = errorState ? Color.Red : Color.FromArgb(38, 163, 186);
            }
        }

        private string tempVarName;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("温度绑定名称")]
        public string TempVarName
        {
            get { return tempVarName; }
            set { tempVarName = value; }
        }
        private string humidityVarName;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("湿度绑定名称")]
        public string HumidityVarName
        {
            get { return humidityVarName; }
            set { humidityVarName = value; }
        }

        private string stateVarName;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("湿度绑定名称")]
        public string StateVarName
        {
            get { return stateVarName; }
            set { stateVarName = value; }
        }

    }
}
