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
    /// TestMouseEventWin.xaml 的交互逻辑
    /// </summary>
    public partial class TestMouseEventWin : Window
    {
        public TestMouseEventWin()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"[{e.Source}] ButtonBase_OnClick");
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"[{e.Source}] UIElement_OnMouseLeftButtonDown");
        }

        private void UIElement_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"[{e.Source}] UIElement_OnPreviewMouseLeftButtonDown");
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"[{e.Source}] ButtonBase_OnClick");
        }

        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var eSource = e.Source;
            Debug.WriteLine($"[{eSource}] UIElement_OnMouseUp");
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"[{e.Source}] UIElement_OnMouseLeftButtonUp");
        }
    }
}
