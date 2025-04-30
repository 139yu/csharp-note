using System;
using System.Globalization;
using System.Windows.Data;

namespace SmartParking.Client.Start.ValueConverter
{
    public class BooleanToBlurConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double blurValue = 0;
            if (value != null && value is bool)
            {
                if ((bool)value)
                {
                    blurValue = 15;
                }
            }
            return blurValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}