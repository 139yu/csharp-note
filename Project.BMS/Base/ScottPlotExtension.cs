using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ScottPlot;

namespace Project.BMS.Base
{
    public class ScottPlotExtension
    {
        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.RegisterAttached("DataSource",
            typeof(ObservableCollection<ObservableCollection<double>>),
            typeof(ScottPlotExtension),
            new PropertyMetadata(null, new PropertyChangedCallback(OnDataSourceChanged))
        );

        public static ObservableCollection<ObservableCollection<double>> GetDataSource(DependencyObject o)
        {
            return (ObservableCollection<ObservableCollection<double>>)o.GetValue(DataSourceProperty);
        }

        public static void SetDataSource(DependencyObject o, ObservableCollection<ObservableCollection<double>> value)
        {
            o.SetValue(DataSourceProperty, value);
        }

        private static WpfPlot plot;
        private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            plot = d as WpfPlot;
            if (plot == null)
            {
                return;
            }

            var newValue = (ObservableCollection<ObservableCollection<double>>)e.NewValue;
            plot.Plot.Clear();
            foreach (var item in newValue)
            {
                item.CollectionChanged += ItemOnCollectionChanged;
                plot.Plot.AddSignal(item.ToArray());
            }
            plot.Refresh();
        }

        private static void ItemOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (plot == null)
            {
                return;
            }

            plot.Plot.Clear();
            foreach (var collection in GetDataSource(plot))
            {
                plot.Plot.AddSignal(collection.ToArray());
            }

            plot.Refresh();
        }
    }
}