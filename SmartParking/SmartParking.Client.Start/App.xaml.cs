using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Logging;
using NLog;
using Prism.DryIoc;
using Prism.Ioc;
using SamrtParking.Client.IDAL;
using SmartParking.Client.BLL;
using SmartParking.Client.Commons.IServices;
using SmartParking.Client.Commons.Models;
using SmartParking.Client.Commons.Services;
using SmartParking.Client.DAL;
using SmartParking.Client.IBLL;
using SmartParking.Client.Start.Views;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace SmartParking.Client.Start
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.Register(typeof(ILogger<>),typeof(NLogLoggerAdapter<>));
            containerRegistry.Register<HttpClient>();
            containerRegistry.Register<ITokenProvider, TokenProvider>();
            containerRegistry.Register<IHttpService>(c =>
            {
                var httpClient = Container.Resolve<HttpClient>();
                var logger = Container.Resolve<ILogger<HttpService>>();
                return new HttpService(httpClient, logger,new HttpServiceOptions());
            });
            containerRegistry.Register<ILoginBll, LoginBll>();
            containerRegistry.Register<ILoginDal, LoginDal>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            if (Container.Resolve<LoginWindow>().ShowDialog() == true)
            {
                shell.ShowDialog();
            }

            Application.Current.Shutdown();
        }
    }
}