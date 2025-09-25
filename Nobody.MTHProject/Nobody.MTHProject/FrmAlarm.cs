using MiniExcelLibs;
using Nobody.MTHBLL;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHProject
{
    public partial class FrmAlarm : Form
    {
        private LogManager logManager;
        public FrmAlarm()
        {
            InitializeComponent();
            logManager = new LogManager();
            this.selector_alarmType.DataSource = new string[]
            {
                "查询所有",
                "触发",
                "消除",
            };
            this.selector_alarmType.SelectedIndex = 0;
            this.time_startTime.Value = DateTime.Now.AddDays(-1);
            this.time_endTime.Value = DateTime.Now;
            QueryData();
        }
        private List<SysLog> sysLogs = null;
        private void QueryData()
        {
            string alarmType = this.selector_alarmType.SelectedItem.ToString().Equals("查询所有") ? string.Empty : this.selector_alarmType.SelectedItem.ToString();
            string startTime = this.time_startTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = this.time_endTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            sysLogs = logManager.GetLogList(alarmType, startTime, endTime);
            this.dvg_main.DataSource = null;
            this.dvg_main.DataSource = sysLogs;
            this.dvg_main.AutoGenerateColumns = false;
        }

        private void btn_timeQuery_Click(object sender, EventArgs e)
        {
            QueryData();
        }

        private void selector_alarmType_SelectedValueChanged(object sender, EventArgs e)
        {
            QueryData();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "xlsx文件(*.xlsx)|*.xlsx|所有文件|*.*";
            fileDialog.Title = "导出历史报警";
            fileDialog.FileName = "历史报警" + DateTime.Now.ToString("yyyyMMddHHmmss");
            fileDialog.DefaultExt = "xlsx";
            fileDialog.AddExtension = true;
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                MiniExcel.SaveAs(fileDialog.FileName, this.dvg_main.DataSource);
                if(new FrmMsgBoxWithAck("导出历史报警", "导出历史报警成功，是否打开").ShowDialog() == DialogResult.OK){
                    Process.Start(fileDialog.FileName);
                }
            }
        }
    }
}
