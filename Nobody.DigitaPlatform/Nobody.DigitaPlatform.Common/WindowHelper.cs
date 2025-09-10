using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nobody.DigitaPlatform.Common
{
    public class WindowHelper
    {

        public static bool GetClose(DependencyObject obj)
        {
            return (bool)obj.GetValue(CloseProperty);
        }
        public static void SetClose(DependencyObject obj, bool value)
        {
            obj.SetValue(CloseProperty, value);
        }
        public static DependencyProperty CloseProperty = DependencyProperty.RegisterAttached(
            "Close", typeof(bool), typeof(WindowHelper), new PropertyMetadata(false, OnCloseChanged));

        private static void OnCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newVal = (bool)e.NewValue;
            if (newVal)
            {
                (d as Window).Close();
            }
        }
    }
}
