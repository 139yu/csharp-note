using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFEventStudy
{
    /// <summary>
    /// TestRouteEventsWin.xaml 的交互逻辑
    /// </summary>
    public partial class TestRouteEventsWin : Window
    {
        public TestRouteEventsWin()
        {
            InitializeComponent();
            this.AddHandler(Button.MouseLeftButtonDownEvent,new RoutedEventHandler((sender, e) =>
            {
                Debug.WriteLine("MouseLeftButtonDownEvent");
            }),false);
        }

        private void Button_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Button_OnMouseLeftButtonDown");
        }

        private void StackPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("StackPanel_OnMouseLeftButtonDown");
        }

        private void Grid_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Grid_OnMouseLeftButtonDown");
        }

        private void Grid_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Grid_OnPreviewMouseLeftButtonDown");
        }

        private void StackPanel_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("StackPanel_OnPreviewMouseLeftButtonDown");
        }

        private void Border_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Border_OnPreviewMouseLeftButtonDown");
        }

        private void CustomerSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var eNewValue = e.NewValue;
            var eOldValue = e.OldValue;
            Debug.WriteLine($"old value: {eOldValue}---new value: {eNewValue}");
        }
    }
}
