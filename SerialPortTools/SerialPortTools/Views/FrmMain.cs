using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialPortTools.Helper;

namespace SerialPortTools.Views
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        private bool isOpen = false;
        public FrmMain()
        {
            InitializeComponent();
            InitUI();
        }

        private string selectPortName;

        private void InitUI()
        {
            this.portName.Properties.Items.AddRange(Faker.PortNames());
            this.baudRate.Properties.Items.AddRange(Faker.BaudRates());
            this.checkBit.Properties.Items.AddRange(Enum.GetValues(typeof(Parity)));
            this.dataBit.Properties.Items.AddRange(Faker.DataBits());
            this.stopBit.Properties.Items.AddRange(Enum.GetValues(typeof(StopBits)));


            this.portName.SelectedIndex = 0;
            this.baudRate.SelectedIndex = 6;
            this.checkBit.SelectedIndex = 0;
            this.dataBit.SelectedIndex = 7;
            this.stopBit.SelectedIndex = 1;

            this.parseAscii.Checked = true;

            this.serialPort1.DataReceived += SerialPort1OnDataReceived;
        }

        private void SerialPort1OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var bytesToRead = this.serialPort1.BytesToRead;
            var buffer = new byte[bytesToRead];
            this.serialPort1.Read(buffer, 0, bytesToRead);
            Invoke(new Action(() =>
            {
                if (this.parseAscii.Checked)
                {
                    this.dataLog.AppendLine(("接收消息：" + Encoding.UTF8.GetString(buffer)).FormatMessage());
                }
                else
                {
                    StringBuilder sb = new StringBuilder("接收消息：");
                    string msg = string.Join(" ", buffer.Select(b => b.ToString("X2")).ToArray());
                    sb.Append(msg);
                    this.dataLog.AppendLine(sb.ToString().FormatMessage());
                }
            }));
            

        } 

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (isOpen )
                {
                    this.serialPort1.Close();
                    this.openBtn.Text = "打开";
                    ChangeUIState(true);
                    isOpen = false;
                    this.dataLog.AppendLine("连接关闭".FormatMessage());
                }
                else
                {
                    this.serialPort1.PortName = this.portName.Text;
                    this.serialPort1.BaudRate = int.Parse(this.baudRate.Text);

                    if (Enum.TryParse(this.checkBit.Text, out Parity parity))
                    {
                        this.serialPort1.Parity = parity;
                    }

                    this.serialPort1.DataBits = int.Parse(this.dataBit.Text);
                    if (Enum.TryParse(this.stopBit.Text, out StopBits stopBits))
                    {
                        this.serialPort1.StopBits = stopBits;
                    }
                    this.serialPort1.Open();
                    isOpen = true;
                    this.openBtn.Text = "关闭";
                    this.dataLog.AppendLine("连接打开".FormatMessage());
                    ChangeUIState(false);
                }
            }
            catch (Exception exception)
            {
                this.openBtn.Text = "打开";
                this.dataLog.AppendLine("[Error]: "+ exception.Message.FormatMessage());
            }
        }

        private void ChangeUIState(bool enable)
        {
            this.portName.Enabled = enable;
            this.baudRate.Enabled = enable;
            this.checkBit.Enabled = enable;
            this.dataBit.Enabled = enable;
            this.stopBit.Enabled = enable;
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            MessageHelper.showLogFormat = this.showLogState.Checked;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.dataLog.Clear();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                MessageBox.Show("请打开串口！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            var message = this.sendMessage.Text;
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("请输入信息", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            var buffer = Encoding.UTF8.GetBytes(message);
            this.serialPort1.Write(buffer,0,buffer.Length);
            this.dataLog.AppendLine(("发送消息：" + message).FormatMessage());
        }

        protected override void WndProc(ref Message msg)
        {
            //设备改变
            if (msg.Msg == 0x0219)
            {
                List<string> portNames = null;
                // 设备拔出
                if (msg.WParam.ToInt32() == 0x8004)
                {
                    dataLog.AppendLine("设备已拔出！".FormatMessage());
                    this.portName.Properties.Items.Clear();
                    portNames = Faker.PortNames();
                    this.portName.Properties.Items.AddRange(portNames);
                }
                // 设备已连接
                else if (msg.WParam.ToInt32() == 0x8000)
                {
                    dataLog.AppendLine("设备已连接！".FormatMessage());
                    this.portName.Properties.Items.Clear();
                    portNames = Faker.PortNames();
                    this.portName.Properties.Items.AddRange(portNames);
                }

                // 如果之前串口已打开，那就释放掉资源
                if (isOpen)
                {
                    if (!portNames.Contains(selectPortName))
                    {
                        serialPort1.Close();
                        serialPort1.Dispose();
                        openBtn.Text = "打开";
                        ChangeUIState(true);
                        this.portName.SelectedIndex = portNames.Count > 0 ? 0 : -1;

                    }
                    else
                    {
                        this.portName.SelectedIndex = this.portName.Properties.Items.IndexOf(selectPortName);
                    }
                }
            }
        }

        private void portName_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectPortName = this.portName.Text.ToString();
        }
    }
}