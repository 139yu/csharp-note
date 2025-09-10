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
using System.Windows.Shapes;

namespace Nobody.DigitaPlatform.Views.Dialog
{
    /// <summary>
    /// RightDialog.xaml 的交互逻辑
    /// </summary>
    public partial class RightDialog : Window
    {
        public RightDialog()
        {
            InitializeComponent();
        }

        private void ReLogin(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
