using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmartParking.Client.Start.ValueConverter
{
    public class BooleanToVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;
            if (value != null && value is bool)
            {
                flag = (bool)value;
            }
            return flag ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;
            if (value != null && value is Visibility)
            {
                flag = (Visibility)value == Visibility.Visible;
            }
            return flag;
        }
    }
}