using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Nobody.DigitaPlatform.Components.Converter
{
    public class InfoToggleButtonVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                int count = 0;
                var countState = int.TryParse(values[0].ToString(), out count); 
                bool isMonitor = false;
                var monitorState = bool.TryParse(values[1].ToString(), out isMonitor);
                if (countState && monitorState &&  count > 0 && isMonitor)
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}