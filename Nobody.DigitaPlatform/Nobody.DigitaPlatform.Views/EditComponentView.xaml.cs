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
using Nobody.DigitaPlatform.Views.Dialog;

namespace Nobody.DigitaPlatform.Views
{
    /// <summary>
    /// EditComponentView.xaml 的交互逻辑
    /// </summary>
    public partial class EditComponentView : Window
    {
        public EditComponentView()
        {
            InitializeComponent();
            ActionManager.Register("OpenAlarmConditionDialog", 
                (object obj) => new VariableAlarmConditionDialog()
                    {
                        Owner = this,
                        DataContext = obj
                    }
                    .ShowDialog() == true);

            ActionManager.Register("OpenUnionConditionDialog",
                (object obj) => new VariableUnionCOnditionDialog()
                    {
                        Owner = this,
                        DataContext = obj
                    }
                    .ShowDialog() == true);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ActionManager.UnRegister("OpenAlarmConditionDialog");
            ActionManager.UnRegister("OpenUnionConditionDialog");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
