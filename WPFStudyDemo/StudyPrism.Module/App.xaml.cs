using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Study.PrismModule.Api;
using StudyPrism.Module.BLL;
using StudyPrism.Module.ViewModels;
using StudyPrism.Module.Views;

namespace StudyPrism.Module
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB,ViewBViewModel>();
            containerRegistry.Register<ITestService, TestService>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        // protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        // {
        //     Console.WriteLine(typeof(SubModule).AssemblyQualifiedName);
        //     moduleCatalog.AddModule<SubModule>(InitializationMode.OnDemand);
        //     // SubModule模块名称
        //     // InitializationMode默认值WhenAvailable
        //     // moduleCatalog.AddModule<SubModule>("SubModule", InitializationMode.OnDemand);
        // }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            // 自动读取App.config文件
            // return new ConfigurationModuleCatalog();
            // return new XamlModuleCatalog(new Uri("pack://application:,,,/StudyPrism.Module;component/ModuleConfig/ModulesCatalog.xaml"));
            return new DirectoryModuleCatalog(){ModulePath = ".\\Modules" };
        }
    }
}