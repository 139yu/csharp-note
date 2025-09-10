using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Wpf;

namespace Nobody.DigitaPlatform.Models
{
    public class TrendModel : ViewModelBase
    {
        public string TNum { get; set; } = "T" + DateTime.Now.ToString("yyyyMMddHHmmssFFF");
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }

        private string _trendHeader = "新建趋势图";

        public string TrendHeader
        {
            get { return _trendHeader; }
            set { Set(ref _trendHeader, value); }
        }

        // 图例处理
        private bool _isShowLegend;

        public bool IsShowLegend
        {
            get { return _isShowLegend; }
            set
            {
                Set(ref _isShowLegend, value);
                if (value)
                    LegendLocation = LegendLocation.Top;
                else
                    LegendLocation = LegendLocation.None;

                this.RaisePropertyChanged("LegendLocation");
            }
        }

        public LegendLocation LegendLocation { get; set; } = LegendLocation.None;

        private ObservableCollection<TrendAxisModel> _axisList = new ObservableCollection<TrendAxisModel>()
            { new TrendAxisModel() { IsShowSeperator = true, Title = "新建纵轴" } };

        public ObservableCollection<TrendAxisModel> AxisList
        {
            get => _axisList;
            set
            {
                _axisList = value;

                YAxis.Clear();
                foreach (var item in value)
                {
                    YAxis.Add(item.Axis);
                }
            }
        }
            

        // 来自于LiveCharts
        public AxesCollection YAxis { get; set; } = new AxesCollection();
        public AxesCollection XAxis { get; set; } = new AxesCollection();

        // 图表序列
        private ObservableCollection<TrendSeriesModel> _series;

        public ObservableCollection<TrendSeriesModel> Series
        {
            get
            {
                if (_series == null)
                {
                    _series = new ObservableCollection<TrendSeriesModel>();
                }

                return _series;
            }
            set
            {
                _series = value;
                ChartSeries.Clear();
                foreach (var model in _series)
                {
                    ChartSeries.Add(model.Series);
                }
            }
        }

        public SeriesCollection ChartSeries { get; set; } =
            new SeriesCollection();

        public TrendModel()
        {
            // 初始化横轴
            var axis = new Axis();
            XAxis.Add(axis);
            XAxis[0].Labels = new List<string>();
            XAxis[0].Separator = new Separator()
            {
                Step = 1,
                StrokeThickness = 0
            };
            XAxis[0].LabelsRotation = -45;
            //初始化纵轴
            YAxis.Add(AxisList[0].Axis);
            // XAxis
            Series.CollectionChanged += Series_CollectionChanged;
        }

        private void Series_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            this.Dispose();
            cts = new CancellationTokenSource();
            this.ChartScan();
        }

        public RelayCommand AddYAxisCommand
        {
            get => new RelayCommand(() =>
            {
                var model = new TrendAxisModel();
                AxisList.Add(model);
                YAxis.Add(model.Axis);
            });
        }

        public RelayCommand<TrendAxisModel> DelYAxisCommand
        {
            get => new RelayCommand<TrendAxisModel>((model) =>
            {
                if (AxisList.Count == 0)
                {
                    return;
                }

                AxisList.Remove(model);
            });
        }

        public int ScanRate { get; set; } = 1000;
        CancellationTokenSource cts = new CancellationTokenSource();
        private List<Task> _taskList = new List<Task>();

        public void ChartScan()
        {
            List<DeviceModel> deviceList = null;
            // 获取设备信息
            Messenger.Default.Send<Action<Func<string[], List<DeviceModel>>>>(func =>
            {
                var dNums = this.Series.Select(s => s.DNum).ToArray();
                deviceList = func.Invoke(dNums);
            }, "DeviceInfo");
            if (deviceList == null || deviceList.Count == 0) return;
            var task = Task.Run(async () =>
            {
                while (!cts.IsCancellationRequested)
                {
                    await Task.Delay(ScanRate);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        XAxis[0].Labels.Add(DateTime.Now.ToString("HH:mm:ss"));
                        if (XAxis[0].Labels.Count > 30)
                        {
                            XAxis[0].Labels.RemoveAt(0);
                        }
                    });

                    foreach (var item in Series)
                    {
                        var device = deviceList.FirstOrDefault(d => d.DeviceNum.Equals(item.DNum));
                        var varModel = device.DeviceVariables.First(v => v.VarNum.Equals(item.VNum));
                        if (varModel == null) continue;
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            if (varModel.Value != null)
                            {
                                item.Series.Values.Add(double.Parse(varModel.Value.ToString()));
                                if (item.Series.Values.Count > 30)
                                {
                                    item.Series.Values.RemoveAt(0);
                                }
                            }
                        });
                    }
                }
            }, cts.Token);
            _taskList.Add(task);
        }

        public override void Cleanup()
        {
            Dispose();
        }

        public void Dispose()
        {
            cts.Cancel();
            Task.WaitAll(_taskList.ToArray(), 500);
        }
    }
}