using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Nobody.DigitaPlatform.Common.Converter
{
    /// <summary>
    /// textBox获取焦点时，让listBoxItem选中
    /// </summary>
    public class FocuseToSelectedConverter : IValueConverter
    {
        private ListBoxItem listBoxItem = null;

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            (value as TextBox).GotFocus -= OnGotFocus;
            (value as TextBox).GotFocus += OnGotFocus;
            return Visibility.Visible;
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            ((sender as TextBox).Tag as ListBoxItem).IsSelected = true;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}