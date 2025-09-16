using Nobody.MTHHelper;
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
    public partial class FrmParamSet : Form
    {
        public FrmParamSet(string path)
        {
            InitializeComponent();
            InitParams();
            CommonMethods.AddLogAction?.Invoke(0, "参数设置页面");
        }
        private void InitParams()
        {

            this.txt_ip.Text = CommonMethods.Device.IPAddress;
            this.txt_port.Text = CommonMethods.Device.Port.ToString();
        }
        private string devPath = string.Empty;
        private void btn_groupConfig_Click(object sender, EventArgs e)
        {
            new FrmGroupConfig().ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            new FrmVariableConfig().ShowDialog();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            var ip = this.txt_ip.Text;
            var port = this.txt_port.Text;
            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port))
            {
                new FrmMsgBoxWithoutAck("设备配置", "请填写IP或端口号").Show();
                return;
            }
            IniConfigHelper.WriteIniData("deviceParams", "IPAddress", ip, devPath);
            IniConfigHelper.WriteIniData("deviceParams", "Port",port, devPath);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            InitParams();
        }
    }
}
