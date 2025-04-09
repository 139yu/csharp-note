using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WPFEventStudy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // //应用程序启动时，​​主窗口实例化之前​​。
            // this.Startup += App_Startup;
            // //应用程序从后台切换到前台
            // this.Activated += OnActivated;
            // //应用程序切换到后台
            // this.Deactivated += App_Deactivated;
            // //用户注销或关闭操作系统时。
            // this.SessionEnding += App_SessionEnding;
            // //应用程序关闭时（所有窗口已关闭或调用 Shutdown()）
            // this.Exit += OnExit;
        }

     
        private void OnExit(object sender, ExitEventArgs e)
        {
            Debug.WriteLine("程序要退出了");
        }

        private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            Debug.WriteLine("要关机？");
            e.Cancel = true;
        }

        private void App_Deactivated(object? sender, EventArgs e)
        {
            Debug.WriteLine("所有页面切换到后台");
        }

        private void OnActivated(object? sender, EventArgs e)
        {
            Debug.WriteLine("有页面获得焦点");

        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            // UI线程异常
            DispatcherUnhandledException += OnDispatcherUnhandledException;
            // Task异常
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            // 其他全局异常处理（如 AppDomain）
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;  
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Debug.WriteLine($"AppDomain handler: {ex.Message}");
            }
                
        }

        private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            Debug.WriteLine($"task 发生异常：{e.Exception.Message}");
            // 标记为已处理，避免进程崩溃
            e.SetObserved();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {   
            // 阻止应用崩溃
            e.Handled = true;
            Debug.WriteLine($"发UI异常：{e.Exception.Message}");
        }
    }

    
}
