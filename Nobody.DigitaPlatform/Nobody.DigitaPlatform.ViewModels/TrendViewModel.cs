using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Nobody.DigitaPlatform.Common;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.DataAccess.Impl;
using Nobody.DigitaPlatform.Entities;
using Nobody.DigitaPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class TrendViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private ILocalDataAccess _dataAccess;

        public TrendViewModel(MainViewModel mainViewModel, ILocalDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _mainViewModel = mainViewModel;
            ShowAxisDialogCommand = new RelayCommand(() =>
            {
                if (CurrentTrend == null) return;
                ActionManager
                    .ExecuteAndResult<TrendAxisDialogViewModel, bool>("ShowAxisEditDialog",
                        new TrendAxisDialogViewModel()
                        {
                            Trend = CurrentTrend,
                            BrushList = BrushList
                        });
            });

            ChartInit();

            SaveTrend = new RelayCommand(DoSaveTrend);
            foreach (var trend in TrendModels)
            {
                trend.ChartScan();
            }
        }


        private TrendModel _currentTrend;

        public TrendModel CurrentTrend
        {
            get => _currentTrend;
            set => Set(ref _currentTrend, value);
        }

        public List<string> BrushList
        {
            get { return typeof(Brushes).GetProperties().Select(p => p.Name).ToList(); }
        }

        public ObservableCollection<TrendModel> TrendModels { get; set; } = new ObservableCollection<TrendModel>()
        {
            new TrendModel()
            {
                IsSelected = true
            }
        };

        public RelayCommand SaveTrend { get; }
        public RelayCommand AddTrendCommand => new RelayCommand(DoAddTrendCommand);
        public RelayCommand<TrendModel> DelTrendCommand => new RelayCommand<TrendModel>(DoDelTrendCommand);
        public RelayCommand ShowAxisDialogCommand { get; }

        public RelayCommand ShowDeviceVarDialogCommand
        {
            get => new RelayCommand(() =>
            {
                if (CurrentTrend == null) return;
                ActionManager
                    .ExecuteAndResult<object, bool>("ShowTrendVars",
                        new TrendDeviceDialogViewModel(CurrentTrend, BrushList, _mainViewModel));
            });
        }

        public RelayCommand<object> SaveToImageCommand
        {
            get => new RelayCommand<object>((obj) =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Chart" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".png";
                // 检查路径是否有效
                saveFileDialog.CheckFileExists = false;
                if (saveFileDialog.ShowDialog() == true)
                {
                    CreateBitmapFromVisual(obj as Visual, saveFileDialog.FileName);
                }
            });
        }

        /// <summary>
        /// 将对象保存为图片
        /// </summary>
        /// <param name="target">要保存的对象</param>
        /// <param name="fileName">文件名</param>
        private void CreateBitmapFromVisual(Visual target, string fileName)
        {
            if (target == null || string.IsNullOrEmpty(fileName)) return;
            //获取元素及其所有后代的边界
            var bounds = VisualTreeHelper.GetDescendantBounds(target);
            var bitmap = new RenderTargetBitmap((Int32)bounds.Width, (Int32)bounds.Height,96,96,PixelFormats.Pbgra32);
            //创建轻量级绘图容器
            DrawingVisual dv = new DrawingVisual();
            using (var context = dv.RenderOpen())
            {
                var visualBrush = new VisualBrush(target);
                // 绘制矩形填充整个边界区域
                context.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
            }
            // 渲染到目标位图
            bitmap.Render(dv);
            var png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bitmap));
            using (Stream stream = File.Create(fileName))
            {
                png.Save(stream);
            }
        }

        private void DoAddTrendCommand()
        {
            TrendModels.Add(new TrendModel());
        }

        private void DoSaveTrend()
        {
            var trendEntities = TrendModels.Select(t => new TrendEntity()
            {
                TNum = t.TNum,
                TrendHeader = t.TrendHeader,
                ShowLegend = t.IsShowLegend,
                Series = t.Series.Select(s => new TrendSeriesEntity()
                {
                    DNum = s.DNum,
                    VNum = s.VNum,
                    Title = s.Title,
                    Color = s.Color,
                    AxisNum = s.AxisNum
                }).ToList(),
                TrendAxisList = t.AxisList.Select(a => new TrendAxisEntity()
                {
                    ANum = a.ANum,
                    Title = a.Title,
                    IsShowTitle = a.IsShowTitle,
                    Minimum = a.Minimum.ToString(),
                    Maximum = a.Maximum.ToString(),
                    IsShowSeperator = a.IsShowSeperator,
                    LabelFormatter = a.LabelFormater,
                    Position = a.Position,
                    Sections = a.Sections.Select(s => new TrendSectionEntity()
                        {
                            Value = s.Value.ToString(),
                            Color = s.Color
                        })
                        .ToList()
                }).ToList()
            }).ToList();
            _dataAccess.SaveTrend(trendEntities);
        }

        private void DoDelTrendCommand(TrendModel model)
        {
            if (TrendModels.Count == 1) return;
            int index = Math.Max(0, TrendModels.IndexOf(model) - 1);
            TrendModels.Remove(model);
            if (model.IsSelected)
            {
                TrendModels[index].IsSelected = true;
            }
        }

        private void ChartInit()
        {
            var tes = _dataAccess.GetTrends();
            this.TrendModels = new ObservableCollection<TrendModel>(tes.Select(t => new TrendModel
            {
                TNum = t.TNum,
                TrendHeader = t.TrendHeader,
                IsShowLegend = t.ShowLegend,

                AxisList = new ObservableCollection<TrendAxisModel>(t.TrendAxisList.Select(a => new TrendAxisModel
                {
                    ANum = a.ANum,
                    Title = a.Title,
                    IsShowTitle = a.IsShowTitle,
                    Minimum = string.IsNullOrEmpty(a.Minimum) ? 0 : double.Parse(a.Minimum),
                    Maximum = string.IsNullOrEmpty(a.Maximum) ? 100 : double.Parse(a.Maximum),
                    IsShowSeperator = a.IsShowSeperator,
                    LabelFormater = a.LabelFormatter,
                    Position = a.Position,

                    Sections = new ObservableCollection<TrendSectionModel>(a.Sections.Select(s => new TrendSectionModel
                    {
                        Value = string.IsNullOrEmpty(s.Value) ? 0 : double.Parse(s.Value),
                        Color = s.Color
                    }))
                })),

                Series = new ObservableCollection<TrendSeriesModel>(t.Series.Select(s => new TrendSeriesModel
                {
                    DNum = s.DNum,
                    VNum = s.VNum,
                    Title = s.Title,
                    Color = s.Color,
                    AxisNum = string.IsNullOrEmpty(s.AxisNum) ? t.TrendAxisList[0].ANum : s.AxisNum
                }))
            }));

            if (this.TrendModels.Count > 0)
                this.TrendModels[0].IsSelected = true;
        }

        public override void Cleanup()
        {
            foreach (var trendModel in TrendModels)
            {
                trendModel.Cleanup();
            }

            base.Cleanup();
        }
    }
}