﻿using System;
using System.Windows;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
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
            containerRegistry.RegisterDialog<DialogContentWindow>("DialogContent");
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    
    }
}