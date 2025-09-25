using Nobody.MTHModels;
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
    public partial class FrmModify : Form
    {
        private string bindVarName;
        public FrmModify(string titleName,string curentValue,string bindVarName)
        {
            InitializeComponent();
            this.lbl_titleName.Text = titleName;
            this.lbl_currentVal.Text = curentValue;
            this.bindVarName = bindVarName;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_cancel_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                Confirm();
        }

        private void Confirm()
        {
            var result = CommonMethods.CommonWrite(bindVarName, this.txt_modifyVal.Text);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                new FrmMsgBoxWithoutAck("参数设置", "参数设置失败，请检查参数");
            }
        }
    }
}
