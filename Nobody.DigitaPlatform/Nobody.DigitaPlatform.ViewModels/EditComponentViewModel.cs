using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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

        public List<DevicePropOption> DevicePropsOptions { get; set; }
        public ObservableCollection<DeviceModel> DeviceList { get; set; }
        public RelayCommand<object> SaveCommand { get; }
        private ILocalDataAccess _dataAccess;
        public RelayCommand<DeviceModel> DeviceSelectCommand { get; }

        public EditComponentViewModel(ILocalDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            DeviceList = new ObservableCollection<DeviceModel>();
            DeviceList.Add(new DeviceModel()
            {
                DeviceType = "HL",
                IsVisible = false,
                Width = 2000,
                Height = 1
            });
            DeviceList.Add(new DeviceModel()
            {
                DeviceType = "VL",
                IsVisible = false,
                Height = 2000,
                Width = 1
            });
            DeviceList.Add(new DeviceModel()
            {
                DeviceType = "WidthRule",
                IsVisible = false,
                Height = 20,
                Width = 2000,
                X = 10, Y = 10
            });
            DeviceList.Add(new DeviceModel()
            {
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

        private void DoSaveCommand(object obj)
        {
            var window = obj as Window;
            VisualStateManager.GoToState(window, "successNormal", true);
            VisualStateManager.GoToState(window, "failedNormal", true);
            var ds = DeviceList.Where(d => !new string[] { "HL", "VL", "WidthRule", "HeightRule" }
                .Contains(d.DeviceType)).Select(dev => new DeviceEntity
            {
                DeviceNum = dev.DeviceNum,
                X = dev.X.ToString(),
                Y = dev.Y.ToString(),
                Z = dev.Z.ToString(),
                W = dev.Width.ToString(),
                H = dev.Height.ToString(),
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
                        Modulus = d.Modulus
                    };
                }).ToList()
            });
            try
            {
                _dataAccess.SaveDevices(ds.ToList());
                VisualStateManager.GoToState(window, "showSuccessBox", true);
            }
            catch (Exception e)
            {
                SaveFailedMsg = e.Message;
                VisualStateManager.GoToState(window, "showFailedBox", true);
            }

            // (obj as Window).DialogResult = true;
        }

        private void DoDropCommand(object obj)
        {
            var args = obj as DragEventArgs;
            ThumbItemModel data = (ThumbItemModel)args.Data.GetData(typeof(ThumbItemModel));

            var position = args.GetPosition(args.Source as IInputElement);
            var deviceItem = new DeviceModel()
            {
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
                var deviceItem = new DeviceModel()
                {
                    DeviceNum = d.DeviceNum,
                    X = double.Parse(d.X),
                    Y = double.Parse(d.Y),
                    Z = int.Parse(d.Z),
                    Width = double.Parse(d.W),
                    Height = double.Parse(d.H),
                    DeviceType = d.TypeName,
                    Devices = DeviceList.ToList,
                    DeleteCommand = new RelayCommand<DeviceModel>(model => { DeviceList.Remove(model); })
                };
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
                    values.Add("ModbusRtu");
                    values.Add("ModbusAscii");
                    values.Add("ModbusTcp");
                    values.Add("S7Net");
                    values.Add("FinsTcp");
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