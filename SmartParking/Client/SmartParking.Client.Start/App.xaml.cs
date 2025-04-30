using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;
using NLog;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using SamrtParking.Client.IDAL;
using SmartParking.Client.BLL;
using SmartParking.Client.Commons.Config;
using SmartParking.Client.Commons.IServices;
using SmartParking.Client.Commons.Services;
using SmartParking.Client.DAL;
using SmartParking.Client.IBLL;
using SmartParking.Client.Start.Views;
using SmartParking.Client.SystemModule;
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
            containerRegistry.RegisterSingleton(typeof(ILogger<>), typeof(NLogLoggerAdapter<>));

            containerRegistry.RegisterSingleton<ITokenProvider, TokenProvider>();
            containerRegistry.RegisterSingleton<IHttpService>(c =>
            {
                var tokenAuthenticationHandler = Container.Resolve<TokenAuthenticationHandler>();
                // 指定下一个处理器 
                tokenAuthenticationHandler.InnerHandler = new HttpClientHandler();
                var httpClient = new HttpClient(tokenAuthenticationHandler);

                var logger = Container.Resolve<ILogger<HttpService>>();
                return new HttpService(httpClient, logger, new HttpServiceOptions());
            });

            #region BLL

            containerRegistry.RegisterSingleton<ILoginBll, LoginBll>();
            containerRegistry.RegisterSingleton<IFileBll, FileBll>();
            containerRegistry.RegisterSingleton<IMenuBll, MenuBll>();
            #endregion

            #region DAL

            containerRegistry.RegisterSingleton<ILoginDal, LoginDal>();
            containerRegistry.RegisterSingleton<IFileDal, FileDal>();
            containerRegistry.RegisterSingleton<IMenuDal, MenuDal>();
            containerRegistry.RegisterSingleton<ILocalDataAccess, LocalDataAccess>();

            #endregion

            containerRegistry.Register(typeof(Dispatcher), c => Application.Current.Dispatcher);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            if (Container.Resolve<LoginWindow>().ShowDialog() == false)
            {
                Application.Current.Shutdown();
            }

            
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog()
            {
                ModulePath = ".\\Modules"
            };
        }

        /*protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SysModule>("SysModule");
        }*/
    }
}