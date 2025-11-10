using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm01
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form01 form01 = new Form01();
            form01.MdiParent = this;
            form01.Show();
        }

        private void form02ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form02 form02 = new Form02();
            form02.MdiParent = this;
            form02.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right) 
                contextMenuStrip.Show(this,e.X,e.Y);
        }

        private void txt_num_TextChanged(object sender, EventArgs e)
        {
            var result = double.TryParse(txt_num.Text, out double num);
            if (!result)
            {
                errorProvider.SetError(txt_num, "只能输入数字");
            }
            else
            {
                errorProvider.SetError(txt_num, "");
            }
        }
    }
}
