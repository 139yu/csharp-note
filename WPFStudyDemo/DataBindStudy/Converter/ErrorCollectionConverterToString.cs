using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataBindStudy.Converter
{
    public class ErrorCollectionConverterToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable errors)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in errors)
                {
                    if (error is ValidationError result)
                    {
                        sb.Append(result.ErrorContent.ToString());
                    }
                }
                return sb.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}