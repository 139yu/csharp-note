using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Services.Dialogs;
using Prism.Unity;
using Study.Prism02.Base;
using Study.Prism02.ViewModels;
using Study.Prism02.Views;

namespace Study.Prism02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DialogView,DialogViewModel>("DialogView");
            containerRegistry.RegisterDialogWindow<DialogBaseWindow>("DialogBaseWindow");
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}
