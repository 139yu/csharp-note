using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using Study.PrismApp.View;
using Study.PrismApp.Views;

namespace Study.PrismApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
            // containerRegistry.Register<MainWindow>();
        }

        protected override Window CreateShell()
        {
            return new MainWindow();
        }
        // 在CreateShell后会执行此方法
        /*protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
            var loginWindow = Container.Resolve<LoginWindow>();
            if (loginWindow == null || loginWindow.ShowDialog() != true)
            {
                Current.Shutdown();
            }
        }*/
    }
}