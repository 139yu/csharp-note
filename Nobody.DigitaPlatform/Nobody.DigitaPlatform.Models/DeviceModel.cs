using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace Nobody.DigitaPlatform.Models
{
    public class DeviceModel : ViewModelBase
    {
        private string _header;

        public string Header
        {
            get { return _header; }
            set { Set(ref _header, value); }
        }

        private string _deviceNum;

        public string DeviceNum
        {
            get { return _deviceNum; }
            set { Set(ref _deviceNum, value); }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }

        private double x;

        public double X
        {
            get { return x; }
            set { Set(ref x, value); }
        }

        private double y;

        public double Y
        {
            get { return y; }
            set { Set(ref y, value); }
        }

        private int z = 0;

        public int Z
        {
            get { return z; }
            set { Set(ref z, value); }
        }

        private double _width;

        public double Width
        {
            get { return _width; }
            set { Set(ref _width, value); }
        }

        private double _height;

        public double Height
        {
            get { return _height; }
            set { Set(ref _height, value); }
        }

        private bool _isVisible = true;

        public bool IsVisible
        {
            get => _isVisible;
            set => Set(ref _isVisible, value);
        }
        private int _rotate;

        public int Rotate
        {
            get { return _rotate; }
            set { Set(ref _rotate, value); }
        }
        private int _flowDirection;

        public int FlowDirection
        {
            get { return _flowDirection; }
            set { Set(ref _flowDirection, value); }
        }
        private bool _isWarning = false;
        public bool IsWarning
        {
            get { return _isWarning; }
            set { Set(ref _isWarning, value); }
        }
        private string _warningMessage;
        public string WarningMessage
        {
            get { return _warningMessage; }
            set { Set(ref _warningMessage, value); }
        }
        // 根据这个名称动态创建一个组件实例
        public string DeviceType { get; set; }

        public Func<List<DeviceModel>> Devices { get; set; }
        private List<DeviceModel> _devicesTemp;
        private List<DeviceModel> _linesTemp;
        private List<DeviceModel> _rulesTemp;
        private ObservableCollection<DevicePropModel> _deviceProps;

        public ObservableCollection<DevicePropModel> DeviceProps
        {
            get
            {
                if (_deviceProps == null)
                {
                    _deviceProps = new ObservableCollection<DevicePropModel>();
                }

                return _deviceProps;
            }
            set => Set(ref _deviceProps, value);
        }

        public RelayCommand<DeviceModel> DeleteCommand { get; set; }
        public RelayCommand AddPropCommand { get; }
        public RelayCommand<object> DelPropCommand { get; }

        public DeviceModel()
        {
            AddPropCommand = new RelayCommand(DoAddPropCommand);
            DelPropCommand = new RelayCommand<object>(DoDelPropCommand);
            DelVariableCommand = new RelayCommand<object>(DoDelVariableCommand);
            AddVariableCommand = new RelayCommand(DoAddVariableCommand);
            ResizeDownCommand = new RelayCommand<object>(DoResizeDownCommand);
            ResizeUpCommand = new RelayCommand<object>(DoResizeUpCommand);
            ResizeMoveCommand = new RelayCommand<object>(DoResizeMoveCommand);
            Messenger.Default.Register<DeviceAlarmModel>(this, DeviceNum, model =>
            {
                if (this.IsWarning)
                {

                }
            });
        }


        private void DoAddVariableCommand()
        {
            DeviceVariables.Add(new VariableModel()
            {
                VarNum = DateTime.Now.ToString("yyyyMMddHHmmss")
            });
        }

        private void DoDelVariableCommand(object obj)
        {
            DeviceVariables.Remove(obj as VariableModel);
        }

        private void DoDelPropCommand(object obj)
        {
            DeviceProps.Remove(obj as DevicePropModel);
        }

        private void DoAddPropCommand()
        {
            DeviceProps.Add(new DevicePropModel());
        }

        private ObservableCollection<VariableModel> _deviceVariables;

        public ObservableCollection<VariableModel> DeviceVariables
        {
            get
            {
                if (_deviceVariables == null)
                {
                    _deviceVariables = new ObservableCollection<VariableModel>();
                }

                return _deviceVariables;
            }
            set => Set(ref _deviceVariables, value);
        }

        public RelayCommand<object> DelVariableCommand { get; }
        public RelayCommand AddVariableCommand { get; }

        public RelayCommand<object> ResizeMoveCommand { get; }
        public RelayCommand<object> ResizeUpCommand { get; }
        public RelayCommand<object> ResizeDownCommand { get; }

        #region drag event

        private bool _isMoving = false;
        private Point _startPoint;

        public void OnMouseLeftButtonDown(object sender, MouseEventArgs args)
        {
            _isMoving = true;
            // 相对当前元素的坐标，当前元素左上角为(0,0)
            // _startPoint = args.GetPosition(GetParent<Canvas>(sender as DependencyObject));
            _startPoint = args.GetPosition(sender as IInputElement);
            _devicesTemp = Devices().Where(d => !new string[] { "HL", "VL", "WidthRule", "HeightRule" }
                    .Contains(d.DeviceType) && d != this)
                .ToList();
            _linesTemp = Devices().Where(d => new string[] { "HL", "VL" }.Contains(d.DeviceType)).ToList();
            _rulesTemp = Devices().Where(d => new string[] { "WidthRule", "HeightRule" }.Contains(d.DeviceType))
                .ToList();
            Mouse.Capture(sender as IInputElement);
            args.Handled = true;
        }

        public void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (_isMoving)
            {
                var currentPoint = args.GetPosition(GetParent<Canvas>(sender as DependencyObject));
                var toX = currentPoint.X - _startPoint.X;
                var toY = currentPoint.Y - _startPoint.Y;
                if (_devicesTemp.Count > 0)
                {
                    // 垂直线对齐
                    {
                        var minDistance = _devicesTemp
                            .Min(d => Math.Abs(d.X - toX));
                        var line = _linesTemp.FirstOrDefault(d => d.DeviceType.Equals("VL"));
                        if (minDistance < 20)
                        {
                            var targetDevice = _devicesTemp
                                .FirstOrDefault(d => Math.Abs(Math.Abs(d.X - toX) - minDistance) < 1);
                            if (targetDevice != null)
                            {
                                line.IsVisible = true;
                                line.X = targetDevice.X;

                                if (minDistance < 10)
                                {
                                    toX = targetDevice.X;
                                }
                            }
                        }
                        else
                        {
                            line.IsVisible = false;
                        }
                    }

                    // 水平对齐
                    {
                        var minDistance = _devicesTemp
                            .Min(d => Math.Abs(d.Y - toY));
                        var line = _linesTemp.FirstOrDefault(d => d.DeviceType.Equals("HL"));
                        if (minDistance < 20)
                        {
                            var targetDevice = _devicesTemp
                                .FirstOrDefault(d => Math.Abs(Math.Abs(d.Y - toY) - minDistance) < 1);
                            if (targetDevice != null)
                            {
                                line.IsVisible = true;
                                line.Y = targetDevice.Y;
                                // 小于10直接吸附
                                if (minDistance < 10)
                                {
                                    toY = targetDevice.Y;
                                }
                            }
                        }
                        else
                        {
                            line.IsVisible = false;
                        }
                    }
                }

                X = toX;
                Y = toY;
            }
        }

        public void OnMouseLeftButtonUp(object sender, MouseEventArgs args)
        {
            _isMoving = false;
            foreach (var deviceModel in _linesTemp)
            {
                deviceModel.IsVisible = false;
            }

            Mouse.Capture(null);
        }

        #endregion

        #region Resize command

        private Point _resizeStart;
        private bool _isResize = false;
        private double _oldWidth;
        private double _oldHeight;
        private DeviceModel _wr;
        private DeviceModel _hr;

        private void DoResizeMoveCommand(object obj)
        {
            var e = obj as MouseEventArgs;
            if (_isResize)
            {
                var parent = GetParent<Canvas>(e.Source as DependencyObject);
                var currentPoint = e.GetPosition(parent);
                var c = (e.Source as Ellipse).Cursor;
                if (c == null)
                {
                    return;
                }

                var width = currentPoint.X - _resizeStart.X;
                var height = currentPoint.Y - _resizeStart.Y;
                if (c == Cursors.SizeWE)
                {
                    // 水平方向
                    this.Width = ShowWidthRule(_oldWidth + width);
                }
                else if (c == Cursors.SizeNS)
                {
                    // 垂直方向
                    this.Height = ShowHeightRule(_oldHeight + height);
                }
                else if (c == Cursors.SizeNWSE)
                {
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        // 保持缩放比例
                        double rate = _oldWidth / _oldHeight;

                        if (height > width)
                        {
                            this.Height = ShowHeightRule(_oldHeight + height);
                            this.Width = this.Height * rate;
                        }
                        else
                        {
                            this.Width = ShowWidthRule(_oldWidth + width);
                            this.Height = this.Width / rate;
                        }
                    }
                    else
                    {
                        this.Width = ShowWidthRule(_oldWidth + width);
                        this.Height = ShowHeightRule(_oldHeight + height);
                        
                    }
                }

                e.Handled = true;
            }
        }

        private void DoResizeUpCommand(object obj)
        {
            var e = obj as MouseButtonEventArgs;
            foreach (var d in _rulesTemp)
            {
                d.IsVisible = false;
            }
            _isResize = false;
            Mouse.Capture(null);
        }

        private void DoResizeDownCommand(object obj)
        {
            var e = obj as MouseButtonEventArgs;
            _isResize = true;
            _resizeStart = e.GetPosition(GetParent<Canvas>(e.Source as DependencyObject));
            Mouse.Capture((IInputElement)e.Source);
            _oldHeight = this.Height;
            _oldWidth = this.Width;
            _devicesTemp = Devices().Where(d => !new string[] { "HL", "VL", "WidthRule", "HeightRule" }
                    .Contains(d.DeviceType) && d != this)
                .ToList();
            _linesTemp = Devices().Where(d => new string[] { "HL", "VL" }.Contains(d.DeviceType)).ToList();
            _rulesTemp = Devices().Where(d => new string[] { "WidthRule", "HeightRule" }.Contains(d.DeviceType))
                .ToList();
            e.Handled = true;
        }

        private double ShowWidthRule(double width)
        {
            _wr = _rulesTemp.FirstOrDefault(d => d.DeviceType.Equals("WidthRule"));
            if (_wr == null)
            {
                return width;
            }

            var model = _devicesTemp.FirstOrDefault(d => Math.Abs(d.X - X) < 1);
            if (model != null)
            {
                var dis = Math.Abs(width + X - model.X - model.Width);
                if (dis < 10)
                {
                    _wr.IsVisible = true;
                    _wr.Width = model.Width;
                    _wr.X = model.X;
                    if (Y < model.Y)
                    {
                        _wr.Y = model.Y - 15;
                    }
                    else
                    {
                        _wr.Y = model.Y + model.Height;
                    }
                        
                    if (dis < 5)
                    {
                        width = model.X + model.Width - X;
                    }
                }
                else
                {
                    _wr.IsVisible = false;
                }
            }

            return width;
        }
        private double ShowHeightRule(double height)
        {
            _hr = _rulesTemp.FirstOrDefault(d => d.DeviceType.Equals("HeightRule"));
            if (_hr == null)
            {
                return height;
            }

            var model = _devicesTemp.FirstOrDefault(d => Math.Abs(d.Y - Y) < 1);
            if (model != null)
            {
                var dis = Math.Abs(height + Y - model.Y - model.Height);
                if (dis < 10)
                {
                    _hr.IsVisible = true;
                    _hr.Height = model.Height;
                    _hr.Y = model.Y;
                    if (X < model.X)
                    {
                        _hr.X = model.X - 15;
                    }
                    else
                    {
                        _hr.X = model.X + model.Width;
                    }
                        
                    if (dis < 5)
                    {
                        height = model.Y + model.Height - Y;
                    }
                }
                else
                {
                    _hr.IsVisible = false;
                }
            }

            return height;
        }

        #endregion

        #region 组件右键菜单

        public List<Control> ContextMenus { get; set; }

        public void InitContextMenu()
        {
            ContextMenus = new List<Control>();
            ContextMenus.Add(new MenuItem()
            {
                Header = "顺时针旋转",
                Command = new RelayCommand(() =>
                {
                    this.Rotate += 90;
                }),
                Visibility = new string[] {
                    "RAJoints", "TeeJoints","Temperature","Humidity","Pressure","Flow","Speed"
                }.Contains(this.DeviceType) ? Visibility.Visible : Visibility.Collapsed
            });
            ContextMenus.Add(new MenuItem
            {
                Header = "逆时针旋转",
                Command = new RelayCommand(() => this.Rotate -= 90),
                Visibility = new string[] {
                    "RAJoints", "TeeJoints","Temperature","Humidity","Pressure","Flow","Speed"
                }.Contains(this.DeviceType) ? Visibility.Visible : Visibility.Collapsed
            });
            ContextMenus.Add(new MenuItem
            {
                Header = "改变流向",
                Command = new RelayCommand(() => this.FlowDirection = (++this.FlowDirection) % 2),
                Visibility = new string[] { "HorizontalPipeline", "VerticalPipeline" }.Contains(this.DeviceType) ? Visibility.Visible : Visibility.Collapsed
            });
            ContextMenus.Add(new Separator());

            ContextMenus.Add(new MenuItem
            {
                Header = "向上一层",
                Command = new RelayCommand(() => this.Z++)
            });
            ContextMenus.Add(new MenuItem
            {
                Header = "向下一层",
                Command = new RelayCommand(() => this.Z--)
            });
            ContextMenus.Add(new Separator { });

            ContextMenus.Add(new MenuItem
            {
                Header = "删除",
                Command = this.DeleteCommand,
                CommandParameter = this
            });

            var cms = ContextMenus.Where(cm => cm.Visibility == Visibility.Visible).ToList();
            foreach (var item in cms)
            {
                if (item is Separator)
                    item.Visibility = Visibility.Collapsed;
                else break;
            }
        }

        #endregion

        public T GetParent<T>(DependencyObject d)
        {
            dynamic obj = VisualTreeHelper.GetParent(d);
            if (obj is T)
            {
                return obj;
            }

            return GetParent<T>(obj);
        }
    }
}