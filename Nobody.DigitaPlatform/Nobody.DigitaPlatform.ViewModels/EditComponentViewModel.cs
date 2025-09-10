using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Nobody.DigitaPlatform.Common;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.Entities;
using Nobody.DigitaPlatform.Models;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class EditComponentViewModel : ViewModelBase
    {
        private string _saveFailedMsg;

        public string SaveFailedMsg
        {
            get => _saveFailedMsg;
            set => Set(ref _saveFailedMsg, value);
        }

        public RelayCommand<object> DropCommand { get; }
        public List<ThumbModel> ThumbList { get; set; }
        private DeviceModel _currentDevice;

        public DeviceModel CurrentDevice
        {
            get => _currentDevice;
            set => Set(ref _currentDevice, value);
        }

        public ObservableCollection<DeviceModel> DeviceDropList
        {
            get
            {
                return new ObservableCollection<DeviceModel>(DeviceList
                    .Where(d => !_filterDeviceName.Contains(d.DeviceType) && !string.IsNullOrEmpty(d.Header))
                    .ToList());
            }
        }

        public List<DevicePropOption> DevicePropsOptions { get; set; }
        public ObservableCollection<DeviceModel> DeviceList { get; set; }
        public RelayCommand<object> SaveCommand { get; }
        private ILocalDataAccess _dataAccess;
        public RelayCommand<DeviceModel> DeviceSelectCommand { get; }
        public RelayCommand<object> CloseCommand { get; }
        public RelayCommand<object> CloseFailedBoxCommand { get; }

        public EditComponentViewModel(ILocalDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            DeviceList = new ObservableCollection<DeviceModel>();
            CloseCommand = new RelayCommand<object>(sender => { (sender as Window).DialogResult = isSave; });
            CloseFailedBoxCommand = new RelayCommand<object>(sender =>
            {
                VisualStateManager.GoToElementState(sender as Window, "SaveFailedClose", true);
            });
            DeviceList.Add(new DeviceModel(_dataAccess)
            {
                IsMonitor = false,
                DeviceType = "HL",
                IsVisible = false,
                Width = 2000,
                Height = 1
            });
            DeviceList.Add(new DeviceModel(_dataAccess)
            {
                IsMonitor = false,
                DeviceType = "VL",
                IsVisible = false,
                Height = 2000,
                Width = 1
            });
            DeviceList.Add(new DeviceModel(_dataAccess)
            {
                IsMonitor = false,
                DeviceType = "WidthRule",
                IsVisible = false,
                Height = 20,
                Width = 2000,
                X = 10, Y = 10
            });
            DeviceList.Add(new DeviceModel(_dataAccess)
            {
                IsMonitor = false,
                DeviceType = "HeightRule",
                IsVisible = false,
                Height = 2000,
                Width = 20,
                X = 10,
                Y = 10
            });
            GenerateData();
            DropCommand = new RelayCommand<object>(DoDropCommand);
            SaveCommand = new RelayCommand<object>(DoSaveCommand);
            DeviceSelectCommand = new RelayCommand<DeviceModel>(DoSelectedCommand);
            OpenAlarmConditionDialog = new RelayCommand(() =>
            {
                if (CurrentDevice != null)
                {
                    ActionManager.ExecuteAndResult<DeviceModel, bool>("OpenAlarmConditionDialog", CurrentDevice);
                }
            });
            OpenUnionConditionDialog = new RelayCommand(() =>
            {
                if (CurrentDevice != null)
                {
                    ActionManager.ExecuteAndResult<DeviceModel, bool>("OpenUnionConditionDialog", CurrentDevice);
                }
            });
        }

        private void DoSelectedCommand(DeviceModel model)
        {
            if (CurrentDevice != null)
            {
                CurrentDevice.IsSelected = false;
            }

            if (model == null)
            {
                CurrentDevice = null;
            }
            else
            {
                model.IsSelected = true;
                CurrentDevice = model;
            }
        }

        private bool isSave = false;
        public RelayCommand OpenAlarmConditionDialog { get; set; }
        public RelayCommand OpenUnionConditionDialog { get; }

        private List<string> _filterDeviceName = new List<string>()
        {
            "WidthRule", "HeightRule", "HV", "WV", "RAJoints", "VerticalPipeline", "HorizontalPipeline"
        };

        private void DoSaveCommand(object obj)
        {
            bool state = VisualStateManager.GoToElementState(obj as Window, "NormalSuccess", true);
            state = VisualStateManager.GoToElementState(obj as Window, "SaveFailedNormal", true);
            var visualStateGroups = VisualStateManager.GetVisualStateGroups(obj as Window);

            var ds = DeviceList.Where(d => !new string[] { "HL", "VL", "WidthRule", "HeightRule" }
                .Contains(d.DeviceType)).Select(dev => new DeviceEntity
            {
                DeviceName = dev.Header,
                DeviceNum = dev.DeviceNum,
                X = dev.X.ToString(),
                Y = dev.Y.ToString(),
                Z = dev.Z.ToString(),
                W = dev.Width.ToString(),
                H = dev.Height.ToString(),
                Rotate = dev.Rotate.ToString(),
                FlowDirection = dev.FlowDirection.ToString(),
                TypeName = dev.DeviceType,
                DeviceProps = dev.DeviceProps.Select(d =>
                {
                    return new DevicePropEntity()
                    {
                        PropName = d.PropName,
                        PropValue = d.PropValue
                    };
                }).ToList(),

                Vars = dev.DeviceVariables.Select(d =>
                {
                    return new VariableEntity()
                    {
                        VarNum = d.VarNum,
                        Header = d.VarName,
                        Address = d.VarAddress,
                        Offset = d.Offset,
                        Modulus = d.Modulus,
                        VarType = d.VarType,
                        Conditions = d.AlarmConditions.Select(c =>
                        {
                            return new ConditionEntity()
                            {
                                CNum = c.ConditionNum,
                                VarNum = c.VarNum,
                                Operator = c.Condition,
                                CompareValue = c.AlarmValue,
                                AlarmContent = c.AlarmMessage
                            };
                        }).ToList(),
                        UnionConditions = d.UnionConditions.Select(c => new ConditionEntity()
                        {
                            CNum = c.ConditionNum,
                            VarNum = c.VarNum,
                            Operator = c.Condition,
                            CompareValue = c.AlarmValue,
                            AlarmContent = c.AlarmMessage,
                            UnionDeviceList = c.UnionDevices.Select(ud => new UnionDeviceEntity()
                            {
                                UNum = ud.UNum,
                                DNum = ud.DNum,
                                VAddr = ud.Address,
                                Value = ud.Value,
                                VType = ud.ValueType
                            }).ToList()
                        }).ToList(),
                    };
                }).ToList(),
                ManualControls = dev.ManualControls.Select(m => new ManualEntity()
                {
                    Header = m.ControlHeader,
                    Value = m.Value,
                    DNum = m.DNum,
                    Address = m.ControlAddress,
                }).ToList()
            });
            try
            {
                _dataAccess.SaveDevices(ds.ToList());
                VisualStateManager.GoToElementState(obj as Window, "SaveSuccess", true);
                isSave = true;
            }
            catch (Exception e)
            {
                SaveFailedMsg = e.Message;
                VisualStateManager.GoToElementState(obj as Window, "SaveFailedShow", true);
            }

            // (obj as Window).DialogResult = true;
        }

        private void DoDropCommand(object obj)
        {
            var args = obj as DragEventArgs;
            ThumbItemModel data = (ThumbItemModel)args.Data.GetData(typeof(ThumbItemModel));

            var position = args.GetPosition(args.Source as IInputElement);
            var deviceItem = new DeviceModel(_dataAccess)
            {
                IsMonitor = false,
                Header = data.Header,
                DeviceNum = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Height = data.Height,
                Width = data.Width,
                X = position.X - data.Width / 2,
                Y = position.Y - data.Height / 2,
                DeviceType = data.TargetType,
                Devices = DeviceList.ToList,
                DeleteCommand = new RelayCommand<DeviceModel>(model => { DeviceList.Remove(model); })
            };
            deviceItem.InitContextMenu();
            DeviceList.Add(deviceItem);
        }

        private void QueryDevices()
        {
            var ds = _dataAccess.GetDeviceList();

            ds.ForEach(d =>
            {
                var deviceItem = new DeviceModel(_dataAccess)
                {
                    IsMonitor = false,
                    Header = d.DeviceName,
                    DeviceNum = d.DeviceNum,
                    X = double.Parse(d.X),
                    Y = double.Parse(d.Y),
                    Z = int.Parse(d.Z),
                    Width = double.Parse(d.W),
                    Height = double.Parse(d.H),
                    Rotate = int.Parse(d.Rotate),
                    FlowDirection = int.Parse(d.FlowDirection),
                    DeviceType = d.TypeName,
                    Devices = DeviceList.ToList,
                    DeleteCommand = new RelayCommand<DeviceModel>(model => { DeviceList.Remove(model); })
                };
                deviceItem.DeviceVariables =
                    new ObservableCollection<VariableModel>(d.Vars.Select(v => new VariableModel()
                    {
                        Modulus = v.Modulus,
                        Offset = v.Offset,
                        VarName = v.Header,
                        VarNum = v.VarNum,
                        VarAddress = v.Address,
                        VarType = v.VarType,
                        AlarmConditions = new ObservableCollection<AlarmConditionModel>(v.Conditions
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
                                        DNum = u.DNum, Value = u.Value, ValueType = u.VType
                                    })
                                    .ToList())
                            }).ToList())
                    }));
                deviceItem.DeviceProps = new ObservableCollection<DevicePropModel>(d.DeviceProps.Select(v =>
                    new DevicePropModel()
                    {
                        PropName = v.PropName,
                        PropValue = v.PropValue
                    }));
                deviceItem.ManualControls = new ObservableCollection<ManualControlModel>(d.ManualControls.Select(m =>
                    new ManualControlModel()
                    {
                        ControlAddress = m.Address,
                        ControlHeader = m.Header,
                        DNum = m.DNum,
                        Value = m.Value
                    }).ToList());
                deviceItem.InitContextMenu();
                DeviceList.Add(deviceItem);
            });
        }

        private void GenerateData()
        {
            QueryDevices();
            QueryThumbs();
            QueryProps();
        }

        private void QueryThumbs()
        {
            string ns = "pack://application:,,,/Nobody.DigitaPlatform.Assets;component/Images/Thumbs/";
            ThumbList = _dataAccess.GetThumbList()
                .GroupBy(d => d.Category)
                .Select(g =>
                {
                    return new ThumbModel()
                    {
                        Header = g.Key,
                        Children = g.Select(item => new ThumbItemModel()
                        {
                            Header = item.Header,
                            Icon = ns + item.Icon,
                            TargetType = item.TargetType,
                            Width = item.Width,
                            Height = item.Height,
                        }).ToList()
                    };
                }).ToList();
        }

        private void QueryProps()
        {
            DevicePropsOptions = _dataAccess.GetPropertyList().Select(d =>
            {
                var option = new DevicePropOption()
                {
                    PropHeader = d.PropHeader,
                    PropType = d.PropType,
                    PropName = d.PropName,
                    DefaultSelectedIndex = 0
                };
                int defaultIndex = 0;
                var values = InitPropValues(option.PropName, out defaultIndex);
                option.PropValueOptions = values;
                option.DefaultSelectedIndex = defaultIndex;
                return option;
            }).ToList();
        }

        private List<string> InitPropValues(string propName, out int OptionDefaultIndex)
        {
            List<string> values = new List<string>();
            OptionDefaultIndex = 0;
            switch (propName)
            {
                case "Protocol":
                    values.Add("ModbusRTU");
                    values.Add("ModbusASCII");
                    values.Add("ModbusTCP");
                    values.Add("S7COMM");
                    values.Add("FinsTCP");
                    values.Add("MC3E");
                    break;
                case "PortName":
                    values = new List<string>(SerialPort.GetPortNames());
                    break;
                case "BaudRate":
                    values.Add("2400");
                    values.Add("4800");
                    values.Add("9600");
                    values.Add("19200");
                    values.Add("38400");
                    values.Add("57600");
                    values.Add("115200");

                    OptionDefaultIndex = 2;
                    break;
                case "DataBit":
                    values.Add("5");
                    values.Add("7");
                    values.Add("8");

                    OptionDefaultIndex = 2;
                    break;
                case "Parity":
                    values = new List<string>(Enum.GetNames<Parity>());
                    break;
                case "StopBit":
                    values = new List<string>(Enum.GetNames<StopBits>());

                    OptionDefaultIndex = 1;
                    break;
                default: break;
            }

            return values;
        }
    }
}