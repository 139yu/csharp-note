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

namespace Nobody.DigitaPlatform.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            if (new LoginView().ShowDialog() != true)
            {
                Application.Current.Shutdown();
            }

            InitializeComponent();
            ActionManager.Register<bool>("ShowEditComponentView", ShowEditComponentView);
        }

        private bool ShowEditComponentView()
        {
            return new EditComponentView()
            {
                Owner = this,
            }.ShowDialog() == true;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}