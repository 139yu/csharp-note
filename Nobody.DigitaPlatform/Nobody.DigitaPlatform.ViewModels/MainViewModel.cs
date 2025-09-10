using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Nobody.DigitaPlatform.Common;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.DeviceAccess;
using Nobody.DigitaPlatform.DeviceAccess.Base;
using Nobody.DigitaPlatform.DeviceAccess.Execute;
using Nobody.DigitaPlatform.Entities;
using Nobody.DigitaPlatform.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public UserModel CurrentUser { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }

        #region Command Prop

        public RelayCommand<object> SwitchPageCommand { get; }
        public RelayCommand EditComponentCommand { get; }

        #endregion


        private ObservableCollection<RankingItemModel> _rankingItems;

        public ObservableCollection<RankingItemModel> RankingItems
        {
            get => _rankingItems;
            set => Set(ref _rankingItems, value);
        }

        private bool _isWindowClose = false;

        public bool IsWindowClose
        {
            get => _isWindowClose;
            set => Set(ref _isWindowClose, value);
        }

        private ObservableCollection<WaringItem> _waringItems;

        public ObservableCollection<WaringItem> WaringItems
        {
            get => _waringItems;
            set => Set(ref _waringItems, value);
        }

        private object _contentView;

        public object ContentView
        {
            get => _contentView;
            set => Set(ref _contentView, value);
        }

        private List<DeviceModel> _deviceList;

        public List<DeviceModel> DeviceList
        {
            get => _deviceList;
            set => Set(ref _deviceList, value);
        }

        private ILocalDataAccess _dataAccess;
        public RelayCommand DoLogoutCommand { get; }

        public MainViewModel(ILocalDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            GenerateData();
            SwitchPageCommand = new RelayCommand<object>(DoSwitchPageCommand);
            EditComponentCommand = new RelayCommand(DoEditComponentCommand);
            DoLogoutCommand = new RelayCommand(() => { DoLogout(); });
            this.Monitor();

            Messenger.Default.Register<Action<Func<string[], List<DeviceModel>>>>(this, "DeviceInfo",
                a => a.Invoke(dNums => { return DeviceList.Where(d => dNums.Contains(d.DeviceNum)).ToList(); }));

            // Messenger.Default.Register<DeviceAlarmModel>(this, "Alarm", ReceiveAlarm);

            Messenger.Default.Register<string>(this, "CancelAlarm", num =>
            {
                var device = DeviceList.FirstOrDefault(d => d.DeviceNum.Equals(num));
                if (device == null)
                {
                    return;
                }

                device.IsWarning = false;
            });
        }

        private void ReceiveAlarm(DeviceAlarmModel alarmModel)
        {
            var deviceModel = this.DeviceList.FirstOrDefault(d => d.DeviceNum.Equals(alarmModel.DNum));
            if (deviceModel != null && !deviceModel.IsWarning)
            {
                deviceModel.WarningMessage = alarmModel;
                SetWarningMessage(alarmModel.AlarmNum,
                    alarmModel.AlarmContent,
                    deviceModel,
                    alarmModel.AlarmValue, alarmModel.VNum, alarmModel.Level);
            }
        }

        private DataTable dataTable = new DataTable();
        private List<Task> _tasks;
        private CancellationTokenSource cts = new CancellationTokenSource();

        private void Monitor()
        {
            _tasks = new List<Task>();
            var communication = Communication.GetInstance();

            foreach (var item in DeviceList)
            {
                if (item.DeviceProps == null || item.DeviceProps.Count == 0 || item.DeviceVariables.Count == 0)
                {
                    continue;
                }

                var props = item.DeviceProps.Select(p => new DevicePropEntity()
                {
                    PropName = p.PropName,
                    PropValue = p.PropValue
                }).ToList();
                var variables = item.DeviceVariables;
                var eoResult = communication.GetExecuteObject(props);
                if (!eoResult.Status)
                {
                    SetWarningMessage("BE0001", eoResult.Message, item, "");
                    continue;
                }

                ExecuteObject executeObject = eoResult.Data;
                var task = Task.Run(async () =>
                {
                    // 数据刷新频率
                    int refreshRate = 500;
                    var refresh = props.FirstOrDefault(p => p.PropName.Equals("RefreshRata"));
                    if (refresh != null && int.TryParse(refresh.PropValue, out int rate))
                    {
                        refreshRate = rate;
                    }

                    List<VariableProperty> varProps = item.DeviceVariables.Select(v => new VariableProperty()
                    {
                        VarNum = v.VarNum,
                        ValueType = Type.GetType("System." + v.VarType),
                        VarAddr = v.VarAddress
                    }).ToList();
                    var addressResult = executeObject.GroupAddress(varProps);
                    if (!addressResult.Status)
                    {
                        SetWarningMessage("BE0002", addressResult.Message, item, "");
                        return;
                    }

                    var mas = addressResult.Data;
                    while (!cts.IsCancellationRequested)
                    {
                        await Task.Delay(refreshRate);

                        var readResult = executeObject.Read(mas);
                        if (!readResult.Status)
                        {
                            SetWarningMessage("BE0002", readResult.Message, item, "");
                            continue;
                        }

                        foreach (var ma in mas)
                        {
                            foreach (var addr in ma.Variables)
                            {
                                string unionNum = null;
                                string alarmNum = null;
                                var valueBytes = addr.ValueBytes.ToList();
                                var varNum = addr.VarNum;
                                var variableModel = item.DeviceVariables
                                    .FirstOrDefault(v => v.VarNum == varNum);
                                var targetResult = communication.ConvertType(valueBytes,
                                    Type.GetType("System." + variableModel.VarType));
                                if (!targetResult.Status)
                                {
                                    SetWarningMessage("BE0003", targetResult.Message, item, addr.VarNum);
                                    continue;
                                }

                                if (variableModel.VarType.Equals("Boolean"))
                                {
                                    variableModel.Value = targetResult.Data;
                                }
                                else
                                {
                                    variableModel.Value = dataTable.Compute(
                                        $"{targetResult.Data}*{variableModel.Modulus} + {variableModel.Offset}", "");
                                }
                                // 报警条件检查
                                if (variableModel.AlarmConditions.Count > 0)
                                {
                                    AlarmConditionModel alarmModel = null;
                                    foreach (var alarmCondition in variableModel.AlarmConditions)
                                    {
                                        string exp = variableModel.Value + alarmCondition.Condition +
                                                     alarmCondition.AlarmValue;
                                        bool state = false;
                                        if (bool.TryParse(dataTable.Compute(exp, "").ToString(), out state) && state)
                                        {
                                            if (!new string[] {"==","!="}.Contains(alarmCondition.Condition))
                                            {
                                                alarmModel = CompareValue(variableModel.AlarmConditions.ToList(),alarmCondition.Condition,variableModel.Value);
                                            }
                                        }
                                    }

                                    if (alarmModel != null)
                                    {
                                        alarmNum = alarmModel.ConditionNum;
                                        DeviceAlarmModel deviceAlarmModel = new DeviceAlarmModel(_dataAccess)
                                        {
                                            AlarmNum = "A-" + DateTime.Now.ToString("yyyyMMddHHmmssFFF"),
                                            CNum = alarmModel.ConditionNum,
                                            DNum = variableModel.DeviceNum,
                                            VNum = variableModel.VarNum,
                                            AlarmContent = alarmModel.AlarmMessage,
                                            AlarmValue = variableModel.Value.ToString(),
                                            DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                            Level = 1,
                                            State = 0
                                        };
                                        ReceiveAlarm(deviceAlarmModel);
                                    }
                                }
                                // 联控设备触发
                                if (variableModel.UnionConditions.Count > 0)
                                {
                                    foreach (var condition in variableModel.UnionConditions)
                                    {
                                        string exp = variableModel.Value + condition.Condition + condition.AlarmValue;
                                        bool flag = false;
                                        if (bool.TryParse(dataTable.Compute(exp, "").ToString(), out flag) && flag)
                                        {
                                            foreach (var unionDevice in condition.UnionDevices)
                                            {
                                                var device = DeviceList.FirstOrDefault(d =>
                                                    unionDevice.DNum.Equals(d.DeviceNum));
                                                if (device == null) continue;
                                                var result = communication.GetExecuteObject(device.DeviceProps
                                                    .Select(p => new DevicePropEntity()
                                                    {
                                                        PropName = p.PropName, PropValue = p.PropValue
                                                    }).ToList());
                                                if (!result.Status) continue;
                                                var exe = result.Data;
                                                var commAddress = exe.AnalyzeAddress(new VariableProperty()
                                                {
                                                    VarAddr = unionDevice.Address,
                                                    ValueType = Type.GetType("System." + unionDevice.ValueType),
                                                    VarNum = variableModel.VarNum,
                                                }, isWrite: true);
                                                commAddress.ValueBytes = BitConverter
                                                    .GetBytes(UInt16.Parse(unionDevice.Value)).Reverse().ToArray();
                                                exe.Write(new List<CommAddress>() { commAddress });
                                            }
                                        }
                                    }
                                }


                                ViewModelLocator.AddRecord(new RecordWriteEntity()
                                {
                                    DeviceNum = variableModel.DeviceNum,
                                    DeviceName = item.Header,
                                    VarNum = variableModel.VarNum,
                                    VarName = variableModel.VarName,
                                    RecordValue = variableModel.Value.ToString(),
                                    AlarmNum = alarmNum,
                                    UnionNum = unionNum,
                                    RecordTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    UserName = CurrentUser.Username
                                });
                            }
                        }
                    }

                    executeObject.Dispose();
                }, cts.Token);
                _tasks.Add(task);
            }
        }
        private AlarmConditionModel CompareValue(List<AlarmConditionModel> AlarmConditions, string operatorStr, object currentVal)
        {
            var q = (from c in AlarmConditions
                where c.Condition.Equals(operatorStr) &&
                      bool.TryParse(dataTable.Compute(currentVal + operatorStr + c.AlarmValue, "").ToString(),
                          out bool res)
                      && res
                select c).ToList();
            if (q.Count > 1)
            {
                if (operatorStr.Equals(">") || operatorStr.Equals(">="))
                {
                    var max = q.Max(c => double.Parse(c.AlarmValue));
                    return q.FirstOrDefault(c => c.AlarmValue.Equals(max));
                }
                else if (operatorStr.Equals("<") || operatorStr.Equals("<="))
                {
                    var min = q.Min(c => double.Parse(c.AlarmValue));
                    return q.FirstOrDefault(c => c.AlarmValue.Equals(min));
                }
            }

            return q[0];
        }
        private void SetWarningMessage(string key, string message, DeviceModel device, string value, string VarNum = "",
            int level = 1)
        {
            if (device.IsWarning) return;
            device.IsWarning = true;
            device.WarningMessage = new DeviceAlarmModel()
            {
                AlarmContent = message,
                AlarmNum = DateTime.Now.ToString("yyyyMMddHHmmssFFF"),
                CNum = key,
                DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Level = level,
                DeviceName = device.Header,
                DNum = device.DeviceNum,
                State = 0
            };
            var count = _dataAccess.SaveAlarmMessage(new AlarmEntity()
            {
                AlarmContent = message,
                AlarmNum = device.WarningMessage.AlarmNum,
                CNum = device.WarningMessage.CNum,
                RecordTime = device.WarningMessage.DateTime,
                AlarmLevel = level.ToString(),
                State = "0",
                DeviceName = device.Header,
                DeviceNum = device.DeviceNum,
                VariableNum = VarNum,
                UserId = CurrentUser.Username
            });
            Console.WriteLine(count);
        }

        #region Do Command

        private void DoEditComponentCommand()
        {
            var userType = CurrentUser.UserType;
            if (userType != 0)
            {
                var dialogResult = ActionManager.ExecuteAndResult<bool>("ShowRightDialog");
                if (dialogResult)
                {
                    DoLogout();
                }

                return;
            }

            var result = ActionManager.ExecuteAndResult<bool>("ShowEditComponentView");
            if (result)
            {
                cts.Cancel();
                Task.WaitAll(_tasks.ToArray());
                QueryDeviceList();
                _tasks.Clear();
                cts = new CancellationTokenSource();
                Monitor();
            }
        }

        private void DoLogout()
        {
            Process.Start("Nobody.DigitaPlatform.exe");
            this.IsWindowClose = true;
        }

        private void DoSwitchPageCommand(object obj)
        {
            var menuModel = obj as MenuItemModel;
            if (ContentView != null)
            {
                var currentViewName = ContentView.GetType().Name;
                if (currentViewName.Equals(menuModel.TargetView))
                {
                    return;
                }
            }

            if (menuModel != null)
            {
                Type type = Assembly.Load("Nobody.DigitaPlatform.Views")
                    .GetType("Nobody.DigitaPlatform.Views.Pages." + menuModel.TargetView);
                ContentView = Activator.CreateInstance(type);
            }
        }

        #endregion


        #region Generate Data

        private void GenerateRankingItems()
        {
            RankingItems = new ObservableCollection<RankingItemModel>();
            string[] quality = new string[]
            {
                "车间-1", "车间-2", "车间-3", "车间-4",
                "车间-5"
            };
            RankingItems = new ObservableCollection<RankingItemModel>();
            Random random = new Random();
            foreach (var q in quality)
            {
                RankingItems.Add(new RankingItemModel()
                {
                    Label = q,
                    PlanValue = random.Next(100, 200),
                    ActualValue = random.Next(10, 150),
                });
            }
        }

        private void GenerateWaringItems()
        {
            string[] types = { "保养到期", "故障", "电量不足", "未知异常" };
            WaringItems = new ObservableCollection<WaringItem>();
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                WaringItems.Add(new WaringItem()
                {
                    DeviceName = $"PLT-{i + 1}",
                    Message = types[random.Next(4)],
                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
        }

        private void GenerateMenus()
        {
            MenuItems = new List<MenuItemModel>();
            MenuItems.Add(new MenuItemModel
            {
                IsSelected = true,
                MenuName = "监控",
                MenuIcon = "\ue61d",
                TargetView = "MonitorPage"
            });
            MenuItems.Add(new MenuItemModel
            {
                MenuName = "趋势",
                MenuIcon = "\ue63c",
                TargetView = "TrendPage"
            });
            MenuItems.Add(new MenuItemModel
            {
                MenuName = "报警",
                MenuIcon = "\ue65b",
                TargetView = "AlarmPage"
            });
            MenuItems.Add(new MenuItemModel
            {
                MenuName = "报表",
                MenuIcon = "\ue605",
                TargetView = "ReportPage"
            });
            MenuItems.Add(new MenuItemModel
            {
                MenuName = "配置",
                MenuIcon = "\ue630",
                TargetView = "SettingsPage"
            });
            DoSwitchPageCommand(MenuItems[0]);
        }

        private void QueryDeviceList()
        {
            var ds = _dataAccess.GetDeviceList();
            if (ds == null || ds.Count == 0)
            {
                DeviceList = new List<DeviceModel>();
                return;
            }

            DeviceList = ds.Select(d =>
            {
                return new DeviceModel(_dataAccess)
                {
                    IsMonitor = true,
                    DeviceNum = d.DeviceNum,
                    Header = d.DeviceName,
                    X = double.Parse(d.X),
                    Y = double.Parse(d.Y),
                    Z = int.Parse(d.Z),
                    Width = double.Parse(d.W),
                    Height = double.Parse(d.H),
                    DeviceType = d.TypeName,
                    Rotate = int.Parse(d.Rotate),
                    FlowDirection = int.Parse(d.FlowDirection),
                    DeviceVariables = new ObservableCollection<VariableModel>(d.Vars.Select(v => new VariableModel()
                    {
                        DeviceNum = v.DeviceNum,
                        Modulus = v.Modulus,
                        Offset = v.Offset,
                        VarName = v.Header,
                        VarNum = v.VarNum,
                        VarAddress = v.Address,
                        VarType = v.VarType,
                        AlarmConditions = new ObservableCollection<AlarmConditionModel>(v.Conditions.AsReadOnly()
                            .Select(c => new AlarmConditionModel()
                            {
                                AlarmMessage = c.AlarmContent,
                                Condition = c.Operator,
                                ConditionNum = c.CNum,
                                AlarmValue = c.CompareValue
                            }).ToList()),
                        UnionConditions = new ObservableCollection<AlarmConditionModel>(v.UnionConditions.Select(c =>
                            new AlarmConditionModel()
                            {
                                AlarmMessage = c.AlarmContent,
                                Condition = c.Operator,
                                ConditionNum = c.CNum,
                                AlarmValue = c.CompareValue,
                                UnionDevices = new ObservableCollection<UnionDeviceModel>(c.UnionDeviceList
                                    .Select(u => new UnionDeviceModel()
                                    {
                                        Address = u.VAddr,
                                        CNum = u.CNum,
                                        DNum = u.DNum,
                                        Value = u.Value,
                                        ValueType = u.VType
                                    })
                                    .ToList())
                            }).ToList())
                    })),
                    ManualControls = new ObservableCollection<ManualControlModel>(d.ManualControls.Select(m =>
                        new ManualControlModel()
                        {
                            ControlAddress = m.Address,
                            ControlHeader = m.Header,
                            DNum = m.DNum,
                            Value = m.Value
                        }).ToList()),
                    DeviceProps = new ObservableCollection<DevicePropModel>(d.DeviceProps.Select(v =>
                        new DevicePropModel()
                        {
                            PropName = v.PropName,
                            PropValue = v.PropValue
                        }))
                };
            }).ToList();
        }

        private void GenerateData()
        {
            QueryDeviceList();
            GenerateMenus();
            GenerateRankingItems();
            GenerateWaringItems();
        }

        #endregion
    }
}