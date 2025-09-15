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
    public partial class PanelEx : Panel
    {
        public PanelEx()
        {
            InitializeComponent();
            //减少闪烁，提升绘制效率
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //通过双缓冲技术消除绘制过程中的闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //调整控件大小时自动触发重绘，保持视觉一致性
            this.SetStyle(ControlStyles.ResizeRedraw,true);
            this.SetStyle(ControlStyles.Selectable,true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor,true);
        }

        private int topGrap;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("上边间隙")]
        public int TopGrap
        {
            get { return topGrap; }
            set { topGrap = value; }
        }
        private int bottomGrap;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("下边间隙")]
        public int BottomGrap
        {
            get { return bottomGrap; }
            set { bottomGrap = value; }
        }
        private int leftGrap;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("左边间隙")]
        public int LeftGrap
        {
            get { return leftGrap; }
            set { leftGrap = value; }
        }
        private int rightGrap;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("右边间隙")]
        public int RightGrap
        {
            get { return rightGrap; }
            set { rightGrap = value; }
        }

        private float borderWidth;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("边框宽度")]
        public float BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        private Color borderColor = Color.FromArgb(35,255,253);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor  = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            Pen pen = new Pen(borderColor,borderWidth);
            float x = leftGrap + borderWidth * 0.5f;
            float y = TopGrap + borderWidth * 0.5f;
            float width = this.Width - leftGrap - rightGrap - borderWidth;
            float height = this.Height - TopGrap - BottomGrap - borderWidth;
            g.DrawRectangle(pen, x, y, width, height);
        }
    }
}
