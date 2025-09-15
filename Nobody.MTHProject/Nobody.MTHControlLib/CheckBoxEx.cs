using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHControlLib
{
    public partial class CheckBoxEx : CheckBox
    {
        public CheckBoxEx()
        {
            InitializeComponent();
            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center; ;
        }

        private StringFormat stringFormat;
        private int checkButtonWidth = 20;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("勾选框长宽")]
        public int CheckButtonWidth
        {
            get { return checkButtonWidth; }
            set 
            { 
                checkButtonWidth = value;
                this.Invalidate();
            }
        }

        private Color checkBackColor = Color.FromArgb(255,255,255);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("勾选框背景颜色")]
        public Color CheckBackColor
        {
            get { return checkBackColor; }
            set { checkBackColor = value;
                this.Invalidate();
            }
        }
        private Color checkedColor = Color.FromArgb(3, 25, 66);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("选中颜色")]
        public Color CheckedColor
        {
            get { return checkedColor; }
            set { checkedColor = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);

            var g = e.Graphics;
            // 消除锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            Rectangle checkRect;
            Rectangle textRect;
            CalculatorRect(out checkRect,out textRect);
            var brush = new SolidBrush(this.CheckBackColor);
            Pen pen = new Pen(brush);
            g.FillRectangle(brush, checkRect);
            pen.Color = Color.LightGray;
            g.DrawRectangle(pen, checkRect);

            if (this.CheckState == CheckState.Checked)
            {
                // 绘制勾选
                CalculatorChecked(g,checkRect,CheckedColor);
            }
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect, stringFormat);
        }
        /// <summary>
        /// 计算矩形
        /// </summary>
        /// <param name="checkRect"></param>
        /// <param name="textRect"></param>
        private void CalculatorRect(out Rectangle checkRect,out Rectangle textRect)
        {
            checkRect = new Rectangle(3,(this.Height - checkButtonWidth) / 2, checkButtonWidth, checkButtonWidth);
            textRect = new Rectangle(checkRect.Right + 3,0,this.Width - checkRect.Right - 6,this.Height);
        }

        private void CalculatorChecked(Graphics g, Rectangle rect, Color color)
        {
            PointF[] points = new PointF[3];
            points[0] = new PointF(rect.X + rect.Width * 0.25f,rect.Y + rect.Height * 0.45f);
            points[1] = new PointF(rect.X + rect.Width * 0.45f, rect.Y + rect.Height * 0.75f);
            points[2] = new PointF(rect.X + rect.Width * 0.75f, rect.Y + rect.Height * 0.25f);
            g.DrawLines(new Pen(color,2.0f), points);
        }
    }
}
