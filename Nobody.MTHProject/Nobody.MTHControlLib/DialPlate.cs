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
    public partial class DialPlate : UserControl
    {
        public DialPlate()
        {
            InitializeComponent();
            //减少闪烁，提升绘制效率
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //通过双缓冲技术消除绘制过程中的闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //调整控件大小时自动触发重绘，保持视觉一致性
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
        }
       
        private StringFormat stringFormat = new StringFormat();
        #region 外环属性
        private float textScale = 0.85f;
        [Browsable(true)]
        [Category("自定义属性-外环属性")]
        [Description("刻度盘比例")]
        public float TextScale
        {
            get { return textScale; }
            set 
            { 
                if(value > 1 || value < 0)
                {
                    return;
                }
                textScale = value;
            }
        }
        private float minValue = 0;
        [Browsable(true)]
        [Category("自定义属性-外环属性")]
        [Description("最小刻度值")]
        public float MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        private float maxValue = 90;
        [Browsable(true)]
        [Category("自定义属性-外环属性")]
        [Description("最大刻度值")]
        public float MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        private int step =15;
        [Browsable(true)]
        [Category("自定义属性-外环属性")]
        [Description("刻度间隔值")]
        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        private int outThickness = 10;
        [Browsable(true)]
        [Category("自定义属性-外环属性")]
        [Description("外环线条宽度")]
        public int OutThickness
        {
            get { return outThickness; }
            set { outThickness = value; }
        }


        private float alarmAngel = 120;
        [Browsable(true)]
        [Category("自定义属性-外环属性")]
        [Description("报警角度")]
        public float AlarmAngel
        {
            get { return alarmAngel; }
            set { alarmAngel = value; }
        }
        private Color alarmColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性-外环属性")]
        [Description("报警颜色")]
        public Color AlarmColor
        {
            get { return alarmColor; }
            set { alarmColor = value; }
        }
        private Color ringColor = Color.FromArgb(184, 184, 184);
        [Browsable(true)]
        [Category("自定义属性-外环属性")]
        [Description("外环颜色")]
        public Color RingColor
        {
            get { return ringColor; }
            set { ringColor = value; }
        }


        #endregion
        #region 内环属性
        private float tempValue = 90;
        [Browsable(true)]
        [Category("自定义属性-内环属性")]
        [Description("温度值")]
        public float TempValue
        {
            get { return tempValue; }
            set 
            {
                if (value >= minValue && value <= maxValue)
                {
                    tempValue = value;
                    this.Invalidate();
                }
            }
        }
        private float humidityValue = 20;
        [Browsable(true)]
        [Category("自定义属性-内环属性")]
        [Description("湿度值")]
        public float HumidityValue
        {
            get { return humidityValue; }
            set
            {
                if (value >= minValue && value <= maxValue)
                {
                    humidityValue = value;
                    this.Invalidate();
                }
            }
        }

        private int inThickness = 15;

        [Browsable(true)]
        [Category("自定义属性-内环属性")]
        [Description("内环线条宽度")]
        public int InThickness
        {
            get { return inThickness; }
            set { inThickness = value; }
        }

        private Color humidityColor = Color.FromArgb(34, 162, 188);
        [Browsable(true)]
        [Category("自定义属性-内环属性")]
        [Description("湿度环颜色")]
        public Color HumidityColor
        {
            get { return humidityColor; }
            set { humidityColor = value; }
        }
        private Color tempColor = Color.FromArgb(34, 162, 188);
        [Browsable(true)]
        [Category("自定义属性-内环属性")]
        [Description("温度环颜色")]
        public Color TempColor
        {
            get { return tempColor; }
            set { tempColor = value; }
        }

        private float tempScale = 0.65f;
        [Browsable(true)]
        [Category("自定义属性-内环属性")]
        [Description("温度环比例")]
        public float TempScale
        {
            get { return tempScale; }
            set
            {
                if (value > 1 || value < 0)
                {
                    return;
                }
                tempScale = value;
            }
        }

        private float humidityScale = 0.85f;
        [Browsable(true)]
        [Category("自定义属性-内环属性")]
        [Description("湿度环比例")]
        public float HumidityScale
        {
            get { return humidityScale; }
            set
            {
                if (value > 1 || value < 0)
                {
                    return;
                }
                humidityScale = value;
            }
        }
        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // 绘制图形上下左右间隔为10，所以宽高必须大于20
            if (maxValue <= minValue || Width <= Height || AlarmAngel > 180 || Width <= 20 || Height <= 20)
            {
                return;
            }

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            // 绘制外圆弧
            var pen = new Pen(AlarmColor, outThickness);
            g.DrawArc(pen, 10, 10, this.Width - 20, this.Width - 20, 180, alarmAngel);
            pen.Color = ringColor;
            pen.Width = OutThickness;
            g.DrawArc(pen, 10, 10, this.Width - 20, this.Width - 20, 180 + alarmAngel, 180 - alarmAngel);


            // 绘制刻度
            float disVal = this.maxValue - this.minValue;
            // 刻度数量
            int stepCount = (int)(disVal / step);
            // 一个刻度度数
            float stepAngle = 180 / stepCount;
            g.TranslateTransform(this.Width * 0.5f, this.Width * 0.5f);
            g.RotateTransform(-180);
            pen.Color = alarmColor;
            pen.Width = 6;
            float radio = (Width - OutThickness) * 0.5f - 10;
            g.DrawLine(pen, radio + OutThickness + 3, 3, radio - 3, 3);
            for (int i = 0; i < stepCount - 1; i++)
            {
                g.RotateTransform(stepAngle);
                g.DrawLine(pen, radio + OutThickness + 3, 3, radio - 3, 3);
            }
            g.RotateTransform(stepAngle);
            g.DrawLine(pen, radio + OutThickness + 3, -3, radio - 3, -3);
            //绘制刻度数值
            var brush = new SolidBrush(this.ForeColor);
            var fontRadio = Width * 0.5f * textScale;

            for (int i = 0; i < stepCount + 1; i++)
            {
                float angle = -180 + (i * stepAngle);
                string txt = (i * step).ToString();
                SizeF size = g.MeasureString(txt, this.Font);
                float x = Convert.ToSingle(fontRadio * Math.Cos(angle * Math.PI / 180.0f));
                float y = Convert.ToSingle(fontRadio * Math.Sin(angle * Math.PI / 180.0f));
                var rect = new RectangleF(x - size.Width * 0.5f, y - size.Height * 0.5f, size.Width, size.Height);
                g.DrawString(txt, this.Font, brush, rect, stringFormat);
            }

            // 绘制温度环
            pen.Color = TempColor;
            pen.Width = InThickness;
            g.TranslateTransform(-this.Width * 0.5f, -this.Width * 0.5f);
            radio = (float)(Width * 0.5 - 10) * tempScale;
            var angleValue = tempValue * (180 / maxValue);
            float x1 = (Width * 0.5f - radio);
            float y1 = Convert.ToSingle((Width * 0.5f - Math.Tan(45 * Math.PI / 180) * radio));
            g.DrawArc(pen, x1, y1, radio * 2, radio * 2, 180, angleValue);
            // 绘制湿度环
            pen.Color = HumidityColor;
            pen.Width = InThickness;
            angleValue = humidityValue  * (180 / maxValue);
            radio = (float)(Width * 0.5 - 10) * humidityScale;
            x1 = (Width * 0.5f - radio);
            y1 = Convert.ToSingle((Width * 0.5f - Math.Tan(45 * Math.PI / 180) * radio));
            g.DrawArc(pen, x1, y1, radio * 2, radio * 2, 180, angleValue);
        }   
    }
}
