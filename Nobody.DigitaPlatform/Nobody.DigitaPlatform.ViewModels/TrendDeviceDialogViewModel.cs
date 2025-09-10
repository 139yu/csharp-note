using Nobody.DigitaPlatform.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class TrendDeviceDialogViewModel
    {
        public TrendModel Trend { get; set; }
        public List<string> BrushList { get; set; }

        public List<TrendDeviceModel> ChooseDevicesList { get; set; } = new List<TrendDeviceModel>();

        private MainViewModel _mainViewModel;

        public TrendDeviceDialogViewModel(TrendModel trend, List<string> brushList, MainViewModel model)
        {
            _mainViewModel = model;
            Trend = trend;
            BrushList = brushList;
            ChooseDevicesList = _mainViewModel.DeviceList
                .Where(d => d.DeviceVariables.Count > 0)
                .Select(d => new TrendDeviceModel()
                {
                    Header = d.Header,
                    VarList = d.DeviceVariables.Select(v => InitDevices(d, v)).ToList()
                })
                .ToList();
        }


        private TrendDeviceVarModel InitDevices(DeviceModel dm, VariableModel vm)
        {
            var item = Trend.Series.ToList()
                .FirstOrDefault(s => s.DNum.Equals(vm.DeviceNum) && s.VNum.Equals(vm.VarNum));
            TrendDeviceVarModel varModel = new TrendDeviceVarModel();

            varModel.IsSelected = item != null;
            varModel.DNum = dm.DeviceNum;
            varModel.VNum = vm.VarNum;
            varModel.VarName = vm.VarName;
            varModel.VarType = vm.VarType;

            varModel.AxisNum = item == null ? Trend.AxisList[0].ANum : item.AxisNum;
            varModel.Color = item == null ? BrushList[new Random().Next(0, BrushList.Count)] : item.Color;
            varModel.PropertyChanged += (se, ev) =>
            {
                if (ev.PropertyName == "IsSelected")
                {
                    SeriesChanged(se as TrendDeviceVarModel);
                }
                else if (ev.PropertyName == "Color" || ev.PropertyName == "AxisNum")
                {
                    var m = se as TrendDeviceVarModel;
                    if (m == null) return;
                    var si = Trend.Series.FirstOrDefault(ts => ts.DNum == m.DNum && ts.VNum == m.VNum);
                    if (si == null) return;

                    si.Color = m.Color;
                    si.AxisNum = m.AxisNum;
                }
            };
            return varModel;
        }

        private void SeriesChanged(TrendDeviceVarModel model)
        {
            if (Trend == null) return;
            if (model.IsSelected)
            {
                // 添加序列
                TrendSeriesModel tsModel = new TrendSeriesModel
                {
                    DNum = model.DNum,
                    VNum = model.VNum,
                    
                    Title = model.VarName,
                    Color = model.Color,
                    AxisIndexFunc = num => Trend.AxisList.ToList().
                        FindIndex(a => a.ANum == num)
                };
                tsModel.AxisNum = model.AxisNum;
                Trend.Series.Add(tsModel);
                Trend.ChartSeries.Add(tsModel.Series);
            }
            else
            {
                // 移除序列
                int index = Trend.Series.ToList().FindIndex(s => s.DNum == model.DNum && s.VNum == model.VNum);
                Trend.Series.RemoveAt(index);
                Trend.ChartSeries.RemoveAt(index);
            }
        }
    }
}