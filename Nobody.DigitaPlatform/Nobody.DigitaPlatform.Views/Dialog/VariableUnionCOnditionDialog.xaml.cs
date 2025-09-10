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
using Nobody.DigitaPlatform.Common;

namespace Nobody.DigitaPlatform.Views.Dialog
{
    /// <summary>
    /// VariableUnionCOnditionDialog.xaml 的交互逻辑
    /// </summary>
    public partial class VariableUnionCOnditionDialog : Window
    {
        public VariableUnionCOnditionDialog()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}