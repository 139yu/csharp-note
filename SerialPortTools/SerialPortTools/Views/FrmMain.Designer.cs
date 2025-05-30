namespace SerialPortTools.Views
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.group2 = new DevExpress.XtraEditors.GroupControl();
            this.checkEdit7 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit6 = new DevExpress.XtraEditors.CheckEdit();
            this.group3 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit5 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.showLogState = new DevExpress.XtraEditors.CheckEdit();
            this.parseHex = new DevExpress.XtraEditors.CheckEdit();
            this.parseAscii = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.openBtn = new DevExpress.XtraEditors.SimpleButton();
            this.stopBit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dataBit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkBit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.baudRate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.portName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.sendBtn = new DevExpress.XtraEditors.SimpleButton();
            this.sendMessage = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.dataLog = new DevExpress.XtraEditors.MemoEdit();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group2)).BeginInit();
            this.group2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group3)).BeginInit();
            this.group3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showLogState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseHex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseAscii.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baudRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sendMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLog.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.group2);
            this.panelControl1.Controls.Add(this.group3);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(254, 624);
            this.panelControl1.TabIndex = 0;
            // 
            // group2
            // 
            this.group2.Controls.Add(this.checkEdit7);
            this.group2.Controls.Add(this.checkEdit6);
            this.group2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.group2.Location = new System.Drawing.Point(3, 479);
            this.group2.Name = "group2";
            this.group2.Size = new System.Drawing.Size(248, 142);
            this.group2.TabIndex = 3;
            this.group2.Text = "发送设置";
            // 
            // checkEdit7
            // 
            this.checkEdit7.Location = new System.Drawing.Point(130, 48);
            this.checkEdit7.Name = "checkEdit7";
            this.checkEdit7.Properties.Caption = "HEX";
            this.checkEdit7.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.checkEdit7.Properties.RadioGroupIndex = 2;
            this.checkEdit7.Size = new System.Drawing.Size(75, 19);
            this.checkEdit7.TabIndex = 0;
            this.checkEdit7.TabStop = false;
            // 
            // checkEdit6
            // 
            this.checkEdit6.EditValue = true;
            this.checkEdit6.Location = new System.Drawing.Point(31, 48);
            this.checkEdit6.Name = "checkEdit6";
            this.checkEdit6.Properties.Caption = "ASCII";
            this.checkEdit6.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.checkEdit6.Properties.RadioGroupIndex = 2;
            this.checkEdit6.Size = new System.Drawing.Size(75, 19);
            this.checkEdit6.TabIndex = 0;
            // 
            // group3
            // 
            this.group3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group3.Controls.Add(this.simpleButton3);
            this.group3.Controls.Add(this.checkEdit5);
            this.group3.Controls.Add(this.checkEdit4);
            this.group3.Controls.Add(this.showLogState);
            this.group3.Controls.Add(this.parseHex);
            this.group3.Controls.Add(this.parseAscii);
            this.group3.Location = new System.Drawing.Point(0, 227);
            this.group3.Name = "group3";
            this.group3.Size = new System.Drawing.Size(253, 249);
            this.group3.TabIndex = 2;
            this.group3.Text = "接收设置";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(34, 196);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(150, 36);
            this.simpleButton3.TabIndex = 2;
            this.simpleButton3.Text = "清除数据";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // checkEdit5
            // 
            this.checkEdit5.Location = new System.Drawing.Point(34, 155);
            this.checkEdit5.Name = "checkEdit5";
            this.checkEdit5.Properties.Caption = "自动滚屏";
            this.checkEdit5.Size = new System.Drawing.Size(113, 19);
            this.checkEdit5.TabIndex = 1;
            // 
            // checkEdit4
            // 
            this.checkEdit4.Location = new System.Drawing.Point(34, 118);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.Caption = "接收保存到文件";
            this.checkEdit4.Size = new System.Drawing.Size(113, 19);
            this.checkEdit4.TabIndex = 1;
            // 
            // showLogState
            // 
            this.showLogState.Location = new System.Drawing.Point(34, 79);
            this.showLogState.Name = "showLogState";
            this.showLogState.Properties.Caption = "按日志模式显示";
            this.showLogState.Size = new System.Drawing.Size(113, 19);
            this.showLogState.TabIndex = 1;
            this.showLogState.CheckedChanged += new System.EventHandler(this.checkEdit3_CheckedChanged);
            // 
            // parseHex
            // 
            this.parseHex.Location = new System.Drawing.Point(133, 44);
            this.parseHex.Name = "parseHex";
            this.parseHex.Properties.Caption = "HEX";
            this.parseHex.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.parseHex.Properties.RadioGroupIndex = 1;
            this.parseHex.Size = new System.Drawing.Size(75, 19);
            this.parseHex.TabIndex = 0;
            this.parseHex.TabStop = false;
            // 
            // parseAscii
            // 
            this.parseAscii.EditValue = true;
            this.parseAscii.Location = new System.Drawing.Point(34, 44);
            this.parseAscii.Name = "parseAscii";
            this.parseAscii.Properties.Caption = "ASCII";
            this.parseAscii.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.parseAscii.Properties.RadioGroupIndex = 1;
            this.parseAscii.Size = new System.Drawing.Size(75, 19);
            this.parseAscii.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.openBtn);
            this.groupControl1.Controls.Add(this.stopBit);
            this.groupControl1.Controls.Add(this.dataBit);
            this.groupControl1.Controls.Add(this.checkBit);
            this.groupControl1.Controls.Add(this.baudRate);
            this.groupControl1.Controls.Add(this.portName);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(248, 223);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "串口设置";
            // 
            // openBtn
            // 
            this.openBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.openBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.openBtn.ImageOptions.ImageToTextIndent = 5;
            this.openBtn.Location = new System.Drawing.Point(31, 183);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(174, 35);
            this.openBtn.TabIndex = 2;
            this.openBtn.Text = "打开";
            this.openBtn.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // stopBit
            // 
            this.stopBit.Location = new System.Drawing.Point(87, 152);
            this.stopBit.Name = "stopBit";
            this.stopBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.stopBit.Size = new System.Drawing.Size(118, 20);
            this.stopBit.TabIndex = 1;
            // 
            // dataBit
            // 
            this.dataBit.Location = new System.Drawing.Point(87, 122);
            this.dataBit.Name = "dataBit";
            this.dataBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataBit.Size = new System.Drawing.Size(118, 20);
            this.dataBit.TabIndex = 1;
            // 
            // checkBit
            // 
            this.checkBit.Location = new System.Drawing.Point(87, 92);
            this.checkBit.Name = "checkBit";
            this.checkBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkBit.Size = new System.Drawing.Size(118, 20);
            this.checkBit.TabIndex = 1;
            // 
            // baudRate
            // 
            this.baudRate.Location = new System.Drawing.Point(87, 62);
            this.baudRate.Name = "baudRate";
            this.baudRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.baudRate.Size = new System.Drawing.Size(118, 20);
            this.baudRate.TabIndex = 1;
            // 
            // portName
            // 
            this.portName.Location = new System.Drawing.Point(87, 32);
            this.portName.Name = "portName";
            this.portName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.portName.Properties.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5"});
            this.portName.Size = new System.Drawing.Size(118, 20);
            this.portName.TabIndex = 1;
            this.portName.SelectedIndexChanged += new System.EventHandler(this.portName_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(31, 125);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "数据位";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(31, 155);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "停止位";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 95);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "校验位";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "波特率";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "串口号";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.groupControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(254, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(647, 624);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.sendBtn);
            this.panelControl3.Controls.Add(this.sendMessage);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 476);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(641, 145);
            this.panelControl3.TabIndex = 1;
            // 
            // sendBtn
            // 
            this.sendBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendBtn.Location = new System.Drawing.Point(502, 3);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(136, 139);
            this.sendBtn.TabIndex = 1;
            this.sendBtn.Text = "发送";
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // sendMessage
            // 
            this.sendMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.sendMessage.Location = new System.Drawing.Point(3, 3);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(499, 139);
            this.sendMessage.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.dataLog);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl4.Location = new System.Drawing.Point(3, 3);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(641, 473);
            this.groupControl4.TabIndex = 0;
            this.groupControl4.Text = "数据日志";
            // 
            // dataLog
            // 
            this.dataLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLog.Location = new System.Drawing.Point(2, 22);
            this.dataLog.Name = "dataLog";
            this.dataLog.Size = new System.Drawing.Size(637, 449);
            this.dataLog.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 624);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Money Twins";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group2)).EndInit();
            this.group2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group3)).EndInit();
            this.group3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showLogState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseHex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseAscii.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baudRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sendMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLog.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.MemoEdit dataLog;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sendBtn;
        private DevExpress.XtraEditors.MemoEdit sendMessage;
        private DevExpress.XtraEditors.SimpleButton openBtn;
        private DevExpress.XtraEditors.ComboBoxEdit stopBit;
        private DevExpress.XtraEditors.ComboBoxEdit dataBit;
        private DevExpress.XtraEditors.ComboBoxEdit checkBit;
        private DevExpress.XtraEditors.ComboBoxEdit baudRate;
        private DevExpress.XtraEditors.ComboBoxEdit portName;
        private DevExpress.XtraEditors.GroupControl group3;
        private DevExpress.XtraEditors.GroupControl group2;
        private DevExpress.XtraEditors.CheckEdit parseHex;
        private DevExpress.XtraEditors.CheckEdit parseAscii;
        private DevExpress.XtraEditors.CheckEdit checkEdit7;
        private DevExpress.XtraEditors.CheckEdit checkEdit6;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.CheckEdit checkEdit5;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraEditors.CheckEdit showLogState;
        private System.IO.Ports.SerialPort serialPort1;
    }
}