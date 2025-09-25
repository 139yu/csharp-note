using MiniExcelLibs;
using Nobody.MTHBLL;
using Nobody.MTHControlLib;
using Nobody.MTHHelper;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace Nobody.MTHProject
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.Closed += FrmMain_Closed;
            logManager = new LogManager();
            storeTimer = new System.Timers.Timer();
            storeTimer.Interval = 1000;
            storeTimer.AutoReset = true;
            storeTimer.Elapsed += StoreTimer_Elapsed;
            storeTimer.Start();
        }
        private ActualDataManager acutalDataManager = new ActualDataManager();
        private void StoreTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (CommonMethods.Device.IsConnected)
            {
                var device = CommonMethods.Device;
                var result = device["模块1温度"] != null;
                result = device["模块1湿度"] != null;
                result = device["模块2温度"] != null;
                result = device["模块2湿度"] != null;
                result = device["模块3温度"] != null;
                result = device["模块3湿度"] != null;
                result = device["模块4温度"] != null;
                result = device["模块4湿度"] != null;
                result = device["模块5温度"] != null;
                result = device["模块5湿度"] != null;
                result = device["模块6温度"] != null;
                result = device["模块6湿度"] != null;
                if (result)
                {
                    var actualData = new ActualData()
                    {
                        InsertTime = DateTime.Now,
                        Station1Temp = device["模块1温度"].ToString(),
                        Station1Humidity = device["模块1湿度"].ToString(),
                        Station2Temp = device["模块2温度"].ToString(),
                        Station2Humidity = device["模块2湿度"].ToString(),
                        Station3Temp = device["模块3温度"].ToString(),
                        Station3Humidity = device["模块3湿度"].ToString(),
                        Station4Temp = device["模块4温度"].ToString(),
                        Station4Humidity = device["模块4湿度"].ToString(),
                        Station5Temp = device["模块5温度"].ToString(),
                        Station5Humidity = device["模块5湿度"].ToString(),
                        Station6Temp = device["模块6温度"].ToString(),
                        Station6Humidity = device["模块6湿度"].ToString(),
                    };
                    acutalDataManager.AddActualData(actualData);
                }
            }
        }

        private System.Timers.Timer storeTimer;
        private void FrmMain_Closed(object sender, EventArgs e)
        {
            cts?.Cancel();
            storeTimer?.Stop();
        }

        private LogManager logManager;
        private DataFormat dataFormat = DataFormat.ABCD;
        private ObservableCollection<string> alarmMessages = new ObservableCollection<string>();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private void FrmMain_Load(object sender, EventArgs e)
        {
            CommNaviBtn_Click(navi_monitor, e);
            CommonMethods.AddLogAction?.Invoke(0, "主页面");
            CommonMethods.Device = LoadDevice(devPath);
            if (CommonMethods.Device != null) 
            {
                CommonMethods.Device.AlarmTriggerEvent += Device_AlarmTriggerEvent;
                Task.Run(async () =>
                {
                    await DeviceCommunication(CommonMethods.Device);
                },cts.Token);
            }
            alarmMessages.CollectionChanged += AlarmMessages_CollectionChanged;
        }

        private void AlarmMessages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (alarmMessages.Count)
            {
                case 0:
                    this.scroll_warning.Text = "当前系统无报警";
                    break;
                default:
                    this.scroll_warning.Text = string.Join(" ", alarmMessages.ToArray());
                    break;
                       
            }
        }

        private void Device_AlarmTriggerEvent(bool trigger, Variable variable)
        {
            try
            {
                if (trigger)
                {
                    CommonMethods.AddLogAction(1, variable.Remark + "触发");
                    var log = new SysLog()
                    {
                         InsertTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                         Note = variable.Remark,
                         AlarmType = "触发",
                         Operator = CommonMethods.CurrentUser.LoginName,
                         VarName = variable.VarName,
                    };
                    logManager.AddLog(log);
                    if (!alarmMessages.Contains(variable.Remark))
                    {
                        this.scroll_warning.Invoke(new Action(() =>
                        {
                            alarmMessages.Add(variable.Remark);
                        }));
                    }
                }
                else
                {
                    CommonMethods.AddLogAction(0, variable.Remark + "消除");
                    var log = new SysLog()
                    {
                        InsertTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Note = variable.Remark,
                        AlarmType = "消除",
                        Operator = CommonMethods.CurrentUser.LoginName,
                        VarName = variable.VarName,
                    };
                    logManager.AddLog(log);
                    if (alarmMessages.Contains(variable.Remark))
                    {
                        this.scroll_warning.Invoke(new Action(() =>
                        {
                            alarmMessages.Remove(variable.Remark);
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";
        private string variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";

        private async Task DeviceCommunication(Device device)
        {
            while (!cts.IsCancellationRequested)
            {
                if (device.IsConnected)
                {
                    foreach (var group in device.GroupList)
                    {
                        var storeArea = group.StoreArea;
                        byte[] data = null;
                        // 应该返回的长度
                        int resLength = 0;
                        if(storeArea == "输入线圈" ||  storeArea == "输出线圈")
                        {
                            resLength = ShortLib.GetByteLengthFromBoolLength(group.Length);
                            switch (storeArea) 
                            {
                                case "输入线圈":
                                    data = CommonMethods.Modbus.ReadInputCoils(group.Start, group.Length);
                                    break;
                                case "输出线圈":
                                    data = CommonMethods.Modbus.ReadOutputCoils(group.Start, group.Length);
                                    break;
                            }
                            if(data != null && data.Length == resLength)
                            {
                                // 解析变量
                                foreach (var item in group.VarList)
                                {
                                    int start = item.Start - group.Start;
                                    item.VarValue = BitLib.GetBitFromByteArray(data, start,item.Length);
                                }
                            }
                            else
                            {
                                device.IsConnected = false;
                                break;
                            }
                        }
                        else
                        {
                            resLength = group.Length * 2;
                            switch (storeArea)
                            {
                                case "输出寄存器":
                                    data = CommonMethods.Modbus.ReadOutputRegisters(group.Start, group.Length);
                                    break;
                                case "输入寄存器":
                                    data = CommonMethods.Modbus.ReadInputRegisters(group.Start, group.Length);
                                    break;
                            }
                            if(data != null && data.Length == resLength)
                            {
                                foreach (var item in group.VarList)
                                {
                                    // 一个寄存器 = 2字节
                                    int start = (item.Start - group.Start) * 2;
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), item.DataType);
                                    switch(dataType)
                                    {
                                        case DataType.Bool:
                                            item.VarValue = BitLib.GetBitFrom2BytesArray(data, start,item.Length, 
                                                dataFormat == DataFormat.BADC || dataFormat == DataFormat.DCBA);
                                            break;
                                        case DataType.Byte:
                                            item.VarValue = ByteLib.GetByteFromByteArray(data, 
                                                dataFormat == DataFormat.BADC || dataFormat == DataFormat.DCBA ? start + 1 : start);
                                            break;
                                        case DataType.UShort:
                                            item.VarValue = UShortLib.GetUShortFromByteArray(data,start,dataFormat);
                                            break;
                                        case DataType.Short:
                                            item.VarValue = ShortLib.GetShortFromByteArray(data, start, dataFormat);
                                            break;
                                        case DataType.UInt:
                                            item.VarValue = UIntLib.GetUIntFromByteArray(data, start, dataFormat);
                                            break;
                                        case DataType.Int:
                                            item.VarValue = IntLib.GetIntFromByteArray(data, start, dataFormat);
                                            break;
                                        case DataType.Float:
                                            item.VarValue = FloatLib.GetFloatFromByteArray(data, start, dataFormat);
                                            break;
                                        case DataType.Double:
                                            item.VarValue = DoubleLib.GetDoubleFromByteArray(data, start, dataFormat);
                                            break;
                                        case DataType.ULong:
                                            item.VarValue = ULongLib.GetULongFromByteArray(data, start, dataFormat);
                                            break;
                                        case DataType.Long:
                                            item.VarValue = LongLib.GetLongFromByteArray(data, start, dataFormat);
                                            break;
                                        case DataType.String:
                                            item.VarValue = StringLib.GetStringFromByteArrayByEncoding(data, start, item.Length, Encoding.ASCII);
                                            break;
                                        case DataType.ByteArray:
                                            item.VarValue = ByteArrayLib.GetByteArrayFromByteArray(data, start,item.Length);
                                            break;
                                        case DataType.HexString:
                                            item.VarValue = StringLib.GetHexStringFromByteArray(data, start, item.Length);
                                            break;
                                    }

                                    item.VarValue = MigrationLib.GetMigrationValue(item.VarValue, item.Scale.ToString(), item.Offset.ToString()).Content;
                                    device.UpdateVariable(item);
                                }

                            }
                            else
                            {
                                device.IsConnected = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    CommonMethods.Modbus = new ModbusTCP();
                    if (!device.ReConnectSinge)
                    {
                        CommonMethods.Modbus?.DisConnect();
                        await Task.Delay(device.ReConnectTime);
                    }
                    device.IsConnected = CommonMethods.Modbus.Connect(device.IPAddress, device.Port);
                    if (device.ReConnectSinge)
                    {
                        CommonMethods.AddLogAction(device.IsConnected ? 0 : 1, 
                            device.IsConnected ? "控制器重连成功" : "控制器重连失败");
                    }else
                    {
                        device.ReConnectSinge = true;
                        CommonMethods.AddLogAction(device.IsConnected ? 0 : 1,
                            device.IsConnected ? "控制器连接成功" : "控制器连接失败");
                    }

                }
            }
        }

        private Device LoadDevice(string path)
        {
            var ip = IniConfigHelper.ReadIniData("deviceParams", "IPAddress", "127.0.0.1", devPath);
            try
            {
                var device = new Device()
                {
                    IPAddress = IniConfigHelper.ReadIniData("deviceParams", "IPAddress", "127.0.0.1", devPath),
                    Port = Convert.ToInt32(IniConfigHelper.ReadIniData("deviceParams", "Port", "502", devPath)),
                    CurrentRecipe = JSONHelper.JSONToEntity<RecipeInfo>(IniConfigHelper.ReadIniData("配方参数", "当前配方", string.Empty, devPath))
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
                        frm = new FrmRecipe(devPath);
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

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
