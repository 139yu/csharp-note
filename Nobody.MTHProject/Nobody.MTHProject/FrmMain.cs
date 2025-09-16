using MiniExcelLibs;
using Nobody.MTHControlLib;
using Nobody.MTHHelper;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHProject
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CommonMethods.Device = LoadDevice(devPath);
            CommNaviBtn_Click(navi_monitor, e);
            CommonMethods.AddLogAction?.Invoke(0, "主页面");
        }
        private string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";
        private string variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";
        private Device LoadDevice(string path)
        {
            var ip = IniConfigHelper.ReadIniData("deviceParams", "IPAddress", "127.0.0.1", devPath);
            try
            {
                var device = new Device()
                {
                    IPAddress = IniConfigHelper.ReadIniData("deviceParams", "IPAddress", "127.0.0.1", devPath),
                    Port = Convert.ToInt32(IniConfigHelper.ReadIniData("deviceParams", "Port", "502", devPath))
                };
                var groups = LoadGroup();
                var variables = LoadVariable();
                foreach (var item in groups)
                {
                    item.VarList = variables.Where(v => v.GroupName.Equals(item.GroupName)).ToList();
                }
                device.GroupList = groups;
                return device;
            }
            catch (Exception ex)
            {
                CommonMethods.AddLogAction(2, "加载设备信息失败：" + ex);
                return null;
            }
        }
        public List<Group> LoadGroup()
        {
            try
            {
                return MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLogAction(2, "加载通信组信息失败：" + ex);
                return new List<Group>();
            }
        }
        public List<Variable> LoadVariable()
        {
            try
            {
                return MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLogAction(2, "加载变量信息失败：" + ex);
                return new List<Variable>();
            }
        }
        private string devPath = Application.StartupPath + "\\Config\\Conf.ini";
        public void CommNaviBtn_Click(object sender,EventArgs e)
        {
            if(sender is NaviButton btn)
            {
                var titleName = btn.TitleName;
                if(Enum.TryParse(titleName, out FormNames formName))
                {
                    OpenForm(mainPanel, formName);
                    center_title.Text = titleName;
                    btn.IsSelected = true;
                }
            }
        }

        private void OpenForm(Panel mainPanel,FormNames formNames)
        {
            int total = mainPanel.Controls.Count;
            int closeCount = 0;
            bool isFind = false;
            for (int i = 0; i < total; i++) 
            {
                var control = mainPanel.Controls[i - closeCount];
                if(control is Form frm)
                {
                    if (frm.Text == formNames.ToString())
                    {
                        // 将当前窗体放到最上面
                        frm.BringToFront();
                        isFind = true;
                    }
                    // 如果不是临界窗体，关闭
                    else if (Enum.TryParse(frm.Text,true,out FormNames name) && name >= FormNames.临界窗体)
                    {
                        frm.Close();
                        closeCount++;
                    }
                   
                }
                
            }
            if (!isFind)
            {
                Form frm = null;
                switch (formNames)
                {
                    case FormNames.集中监控:
                        frm = new FrmMonitor();
                        CommonMethods.AddLogAction = ((FrmMonitor)frm).AddLog;
                        break;
                    case FormNames.参数设置:
                        frm = new FrmParamSet(devPath);
                        break;
                    case FormNames.配方管理:
                        frm = new FrmRecipe();
                        break;
                    case FormNames.历史趋势:
                        frm = new FrmHistory();
                        break;
                    case FormNames.用户管理:
                        frm = new FrmUserManager();
                        break;
                    case FormNames.报警追溯:
                        frm = new FrmAlarm();
                        break;
                    default: break;
                }
                if(frm != null)
                {
                    // 窗体不再是独立的窗口，它可以被嵌入到其他容器控件中，作为复杂界面的一部分。
                    frm.TopLevel = false;
                    frm.Dock = DockStyle.Fill;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Parent = mainPanel;
                    frm.BringToFront();
                    frm.Show();
                }
            }
        }


        #region 无边框拖动

        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion
    }
}
