using System.Globalization;
using System.Windows.Data;

namespace DataBindStudyVersion8.Converter;

public class GenderConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value.ToString() == parameter.ToString();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isChecked && isChecked)
        {
            return parameter;
        }
        return Binding.DoNothing;
    }
}