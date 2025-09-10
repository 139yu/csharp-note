using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nobody.DigitaPlatform.Common;
using Nobody.DigitaPlatform.Models;
using Nobody.DigitaPlatform.ViewModels;
using Nobody.DigitaPlatform.Views.Dialog;

namespace Nobody.DigitaPlatform.Views.Pages
{
    /// <summary>
    /// TrendPage.xaml 的交互逻辑
    /// </summary>
    public partial class TrendPage : UserControl
    {
        public TrendPage()
        {
            InitializeComponent();
            this.Unloaded += TrendPage_Unloaded;
        }

        private void TrendPage_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Cleanup<TrendViewModel>();
        }
    }
}
