using System.Runtime.CompilerServices;
using Prism.Ioc;
using Prism.Modularity;
using Study.PrismModule.Sub.ViewModels;
using Study.PrismModule.Sub.Views;

namespace Study.PrismModule.Sub
{
    [Module(ModuleName = "SubModule", OnDemand = false)]
    public class SubModule: IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA,ViewAViewModel>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}