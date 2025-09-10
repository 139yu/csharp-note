using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Nobody.DigitaPlatform.Models
{
    public class TrendSeriesModel
    {
        public string DNum { get; set; }
        public string VNum { get; set; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Series.Title = value;
            }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                Series.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value));
            }
        }
        private string _axisNum;

        public string AxisNum
        {
            get { return _axisNum; }
            set
            {
                _axisNum = value;

                var index = AxisIndexFunc?.Invoke(value);
                Series.ScalesYAt = (index == null ? 0 : (int)index);
            }
        }
        public Func<string, int> AxisIndexFunc { get; set; }


        public LineSeries Series { get; set; } = new LineSeries()
        {
            Values = new ChartValues<double>(),
            Fill = Brushes.Transparent,
            StrokeThickness = 2
        };
    }
}
