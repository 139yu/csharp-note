using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Nobody.DigitaPlatform.Common
{
    public class DataGridHelper
    {
        public static ObservableCollection<DataGridColumn> GetColumns(DependencyObject d)
        {
            return (ObservableCollection<DataGridColumn>)d.GetValue(ColumnsProperty);
        }

        public static void SetColumns(DependencyObject d, ObservableCollection<DataGridColumn> value)
        {
            d.SetValue(ColumnsProperty, value);
        }
       
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.RegisterAttached(
            "Columns",
            typeof(ObservableCollection<DataGridColumn>),
            typeof(DataGridHelper),
            new PropertyMetadata(null, OnColumnsChanged));

        private static void OnColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dataGrid = d as DataGrid;
            ;
            // 添加元素时触发
            DataGridHelper.GetColumns(d).CollectionChanged += (sender, args) =>
            {
                dataGrid.Columns.Clear();
                foreach (var item in DataGridHelper.GetColumns(d))
                {
                    dataGrid.Columns.Add(item);
                }
            };
            foreach (var item in DataGridHelper.GetColumns(d))
            {
                dataGrid.Columns.Add(item);
            }
        }
    }
}