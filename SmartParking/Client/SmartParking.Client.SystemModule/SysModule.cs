using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SmartParking.Client.SystemModule.ViewModels;
using SmartParking.Client.SystemModule.Views;

namespace SmartParking.Client.SystemModule
{
    public class SysModule: IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MenuTreeView>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftMenuRegion", "MenuTreeView");
        }
    }
}