using System;
using System.Windows;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using Study.PrismApp.ViewModel;
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
            // 直接注入某个实例类型
            // containerRegistry.Register(typeof(BusinessServiceImpl));
            // 注入实例接口及其实现类
            // containerRegistry.Register(typeof(IBusinessService), typeof(BusinessServiceImpl));
            // containerRegistry.Register<IBusinessService,BusinessServiceImpl>();
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
        protected override void ConfigureViewModelLocator()
        {
            // 设置View类型对应的ViewModel类型，所有视图都遵循此规则
            // ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(ViewTypeToViewModelTypeResolver);
            //ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => new MainWindowViewModel());
            //ViewModelLocationProvider.Register(typeof (MainWindow).ToString(), typeof (MainWindow));
        }
        /// <summary>
        /// 返回视图类型对应的ViewModel类型
        /// </summary>
        /// <param name="viewType">视图类型</param>
        /// <returns>ViewModel</returns>
        public Type ViewTypeToViewModelTypeResolver(Type viewType)
        {
            
            return null;
        }
    }
}