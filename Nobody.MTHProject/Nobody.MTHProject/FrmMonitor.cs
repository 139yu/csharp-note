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
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();
            CommonMethods.AddLogAction?.Invoke(0, "监控页面");
        }
        public string CurrentTime { get => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        public void AddLog(int level,string message)
        {
            if(level> 2)
            {
                level = 2;
            }else if (level < 0)
            {
                level = 0;
            }

            if (this.lv_log.InvokeRequired)
            {
                this.lv_log.Invoke(new Action<int,string>(AddLog),level,message);
            }
            else
            {
                var item = new ListViewItem(" " + CurrentTime, level);
                item.SubItems.Add(message);
                this.lv_log.Items.Add(item);
                this.lv_log.Items[this.lv_log.Items.Count - 1].EnsureVisible();
            }
        }
    }
}
