using GalaSoft.MvvmLight.Command;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.Entities;
using Nobody.DigitaPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class ReportViewModel: ViewModelBase
    {
        public ObservableCollection<RecordReadEntity> AllDatas { get; set; } =
            new ObservableCollection<RecordReadEntity>();
        public ObservableCollection<DataGridColumn> Columns { get; set; } =
            new ObservableCollection<DataGridColumn>();

        // 所有可能显示的列，可供选择的列
        public ObservableCollection<DataGridColumnModel> AllColumns { get; set; } =
            new ObservableCollection<DataGridColumnModel>();

        private ILocalDataAccess _dataAccess;

        public ReportViewModel(ILocalDataAccess localDataAccess)
        {
            _dataAccess = localDataAccess;
            InitColumns();
            Reshresh();
            CheckColumnCommand = new RelayCommand<DataGridColumnModel>(DoCheckColumnCommand);
            RefreshCommand = new RelayCommand(Reshresh);
        }

        private int index = 0;

        private void InitColumns()
        {
            // 初始化列列表
            AllColumns.Add(new DataGridColumnModel { Header = "设备编号", BindingPath = "DeviceNum", ColumnWidth = 100 });
            AllColumns.Add(new DataGridColumnModel
                { IsSelected = true, Header = "设备名称", BindingPath = "DeviceName", ColumnWidth = 90 });
            AllColumns.Add(new DataGridColumnModel { Header = "变量编号", BindingPath = "VariableNum", ColumnWidth = 100 });
            AllColumns.Add(new DataGridColumnModel
                { IsSelected = true, Header = "变量名称", BindingPath = "VariableName", ColumnWidth = 90 });
            AllColumns.Add(new DataGridColumnModel { Header = "最新值", BindingPath = "LastValue", ColumnWidth = 90 });
            AllColumns.Add(new DataGridColumnModel { Header = "平均值", BindingPath = "AvgValue", ColumnWidth = 90 });
            AllColumns.Add(new DataGridColumnModel { Header = "最大值", BindingPath = "MaxValue", ColumnWidth = 90 });
            AllColumns.Add(new DataGridColumnModel { Header = "最小值", BindingPath = "MinValue", ColumnWidth = 90 });
            AllColumns.Add(new DataGridColumnModel { Header = "报警触发次数", BindingPath = "AlarmCount", ColumnWidth = 90 });
            AllColumns.Add(new DataGridColumnModel { Header = "联控触发次数", BindingPath = "UnionCount", ColumnWidth = 90 });
            AllColumns.Add(new DataGridColumnModel { Header = "记录次数", BindingPath = "RecordCount", ColumnWidth = 80 });
            AllColumns.Add(new DataGridColumnModel { Header = "最后记录时间", BindingPath = "LastTime", ColumnWidth = 120 });
            foreach (var item in AllColumns)
            {
                DoCheckColumnCommand(item);
            }
        }

        private void Reshresh()
        {
            var data = _dataAccess.GetRecords();
            AllDatas = new ObservableCollection<RecordReadEntity>(data);
            this.RaisePropertyChanged(nameof(AllDatas));
        }
        public RelayCommand<DataGridColumnModel> CheckColumnCommand { get; }
        public RelayCommand RefreshCommand { get; }

        public void DoCheckColumnCommand(DataGridColumnModel item)
        {
            if (item.IsSelected)
            {
                item.Index = index++;
                var style = new Style(typeof(TextBlock));
                style.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center));
                style.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center));
                Columns.Add(new DataGridTextColumn()
                {
                    Header = item.Header,
                    Binding = new Binding(item.BindingPath),
                    Width = item.ColumnWidth,
                    ElementStyle = style
                });
            }
            else
            {
                var column = Columns.FirstOrDefault(c => c.Header.ToString() == item.Header);
                Columns.Remove(column);
            }
        }
    }
}