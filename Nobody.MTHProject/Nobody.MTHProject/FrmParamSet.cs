using Nobody.MTHControlLib;
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
            devPath = path;
            InitParams();
            updateTimer = new Timer();
            updateTimer.Interval = 500;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
            this.FormClosed += FrmParamSet_FormClosed;
            ControlEventBind();
        }
        private void ControlEventBind()
        {
            foreach (var item in panel_main.Controls.OfType<CheckBoxEx>())
            {
                item.CheckedChanged += Common_CheckedChanged;
            }
            foreach (var item in panel_main.Controls.OfType<TextSet>())
            {
                item.ControlDoubleClick += Common_ControlDoubleClick;
            }
        }
        private void FrmParamSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateTimer.Stop();
            updateTimer.Dispose();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            GetLimitParam();
        }

        private void GetLimitParam()
        {
            var device = CommonMethods.Device;
            if (!device.IsConnected) return;
            foreach (var item in panel_main.Controls.OfType<TextSet>())
            {
                if (device.CurrentValue.ContainsKey(item.BindName))
                {
                    item.CurrentValue = device[item.BindName].ToString();
                }
                if (device.CurrentValue.ContainsKey(item.AlarmVarName))
                {
                    item.IsAlarm = device[item.AlarmVarName].ToString() == "True";
                }

            }
        }


        private void GetAlarmParam()
        {

            var device = CommonMethods.Device;
            if (!device.IsConnected) return;
            foreach (var item in panel_main.Controls.OfType<CheckBoxEx>())
            {
                if(item.Tag != null && item.Tag.ToString().Length> 0)
                {
                    string varName = item.Tag.ToString();
                    if (device.CurrentValue.ContainsKey(varName))
                    {
                        item.Checked = device[item.Tag.ToString()].ToString() == "1";
                    }
                }
            }
        }

        private Timer updateTimer;
        private void InitParams()
        {

            this.txt_ip.Text = CommonMethods.Device.IPAddress;
            this.txt_port.Text = CommonMethods.Device.Port.ToString();
            GetLimitParam();
            GetAlarmParam();
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
                new FrmMsgBoxWithoutAck("参数配置", "请填写IP或端口号").Show();
                return;
            }
            bool result = IniConfigHelper.WriteIniData("deviceParams", "IPAddress", ip, devPath);
            result &= IniConfigHelper.WriteIniData("deviceParams", "Port",port, devPath);
            if (result)
            {
                CommonMethods.Device.IPAddress = ip;
                CommonMethods.Device.Port = int.Parse(port);
                DialogResult dialogResult = new FrmMsgBoxWithAck("参数配置", "参数配置成功，是否立即重连").ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    CommonMethods.Device.IsConnected = false;
                }
            }
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            InitParams();
        }

        private void Common_ControlDoubleClick(object sender, EventArgs e)
        {
            if(sender is TextSet textSet)
            {
                if (textSet.BindName != null && textSet.BindName.Length > 0)
                {
                    new FrmModify(textSet.TitleName, textSet.CurrentValue,textSet.BindName)
                        .ShowDialog();
                }
            }
            
        }

        private void Common_CheckedChanged(object sender, EventArgs e)
        {
            if(sender is CheckBoxEx chk && chk.Tag != null && chk.Tag.ToString().Length > 0)
            {
                bool checkFlag = chk.Checked;
                var result = CommonMethods.CommonWrite(chk.Tag.ToString(), checkFlag ? "1" : "0");
                if (!result)
                {
                    new FrmMsgBoxWithoutAck("修改变量", "修改变量失败，请检查变量！  ").Show();
                }
            }
        }
    }
}
