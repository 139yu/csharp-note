using Nobody.DigitaPlatform.Common;
using Nobody.DigitaPlatform.Models;
using Nobody.DigitaPlatform.ViewModels;
using Nobody.DigitaPlatform.Views.Dialog;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

            ActionManager.Register<bool>("ShowEditComponentView", () => ShowDialog(new EditComponentView()
            {
                Owner = this,
            }));

            ActionManager.Register<bool>("ShowRightDialog", () => ShowDialog(new RightDialog()
            {
                Owner = this
            }));
            ActionManager
                .Register<TrendAxisDialogViewModel, bool>("ShowAxisEditDialog", obj => ShowDialog(new TrendAxisEditDialog()
                {
                    DataContext = obj,
                    Owner = this
                }));
            ActionManager.Register<object,bool>("ShowTrendVars", obj => ShowDialog(new TrendDeviceChooseDialog() { Owner = this, DataContext = obj }));
            InitializeComponent();
        }


        private bool ShowDialog(Window window)
        {
            this.Effect = new BlurEffect() { Radius = 10 };
            var state = window.ShowDialog() == true;
            this.Effect = null;
            return state;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}