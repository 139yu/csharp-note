using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SmartParking.Client.UpgradeApp.Views;

namespace SmartParking.Client.UpgradeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args == null || e.Args.Length < 2)
            {
                MessageBox.Show("未提供参数", "错误信息",MessageBoxButton.OK,MessageBoxImage.Error);
                Current.Shutdown();
                return;
            }

            if (e.Args[0].ToString() != "--mainifest")
            {
                MessageBox.Show("参数错误", "错误信息",MessageBoxButton.OK,MessageBoxImage.Error);
                Current.Shutdown();
                return;
            }
            new MainWindow(e.Args[1]).Show();
        }
    }
}