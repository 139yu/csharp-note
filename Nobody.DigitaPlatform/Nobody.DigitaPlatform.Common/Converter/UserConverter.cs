using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Nobody.DigitaPlatform.Common.Converter
{
    public class UserConverter: IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value.Equals(0))
            {
                return "管理員";
            } else if (value.Equals(1))
            {
                return "普通用戶";
            }

            return "测试员";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
