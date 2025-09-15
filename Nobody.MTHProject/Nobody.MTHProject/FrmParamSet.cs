using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHProject
{
    public partial class FrmParamSet : Form
    {
        public FrmParamSet()
        {
            InitializeComponent();
        }

        private void btn_groupConfig_Click(object sender, EventArgs e)
        {
            new FrmGroupConfig().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FrmVariableConfig().ShowDialog();
        }
    }
}
