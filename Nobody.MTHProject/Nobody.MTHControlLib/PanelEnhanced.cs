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
    public partial class PanelEnhanced : Panel
    {
        public PanelEnhanced()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 重载基类的背景擦除方法
            // 解决窗体刷新，放大和闪烁
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            if(this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                e.Graphics.DrawImage(this.BackgroundImage, new Rectangle(0, 0, this.Width,this.Height), new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height), GraphicsUnit.Pixel);
            }
            base.OnPaint(e);
        }
    }
}
