/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Mvvmlight.Framework"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Mvvmlight.Framework.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            // 程序设计时
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else //程序运行时
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            // 将类型注册到容器，容器可以提前获取到类型的构造器之类的信息，方便反射创建对象
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                // 每次传入不同值，容器每次都返回不同对象
                // ServiceLocator.Current.GetInstance<MainViewModel>(uuid);
                // 通过反射创建对象，默认是单例
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        /// <summary>
        /// 释放对象资源
        /// </summary>
        public static void Cleanup<T>() where T : ViewModelBase
        {
            // TODO Clear the ViewModels
            // 每个实例重写Cleanup方法，实现自己的释放资源的逻辑
            ServiceLocator.Current.GetInstance<T>().Cleanup();
            SimpleIoc.Default.Unregister<T>();
            // 重新注册目的：为了下次打开窗口的时候有对象可用
            SimpleIoc.Default.Register<T>();
        }
    }
}