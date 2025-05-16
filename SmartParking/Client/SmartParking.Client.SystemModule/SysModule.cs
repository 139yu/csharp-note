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
            containerRegistry.RegisterForNavigation<FileUploadView>();
            containerRegistry.RegisterForNavigation<MenuManagerView>();
            containerRegistry.RegisterForNavigation<MainHeaderView>();
            containerRegistry.RegisterForNavigation<UserManagerView>();

            containerRegistry.RegisterDialog<AddFileDialog>();
            containerRegistry.RegisterDialog<AddUserDialog>();
            containerRegistry.RegisterDialog<AddMenuDialog>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftMenuRegion", "MenuTreeView");
            regionManager.RegisterViewWithRegion("TopHeaderRegion", "MainHeaderView");
        }
    }
}