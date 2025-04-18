using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using Study.PrismRegion.Config;
using Study.PrismRegion.ViewModels;
using Study.PrismRegion.Views;

namespace Study.PrismRegion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainContent,MainContentViewModel>("MainContent");
            containerRegistry.RegisterForNavigation<DataContent,DataContentViewModel>("DataContent");
            // containerRegistry.RegisterForNavigation;
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            // var container = Container.GetContainer();
            // container.Resolve(typeof(CanvasRegionAdapter),"CanvasRegionAdapter");
            regionAdapterMappings.RegisterMapping<Canvas, CanvasRegionAdapter>();
        }
    }
}