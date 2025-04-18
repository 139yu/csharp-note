using System;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace Study.PrismRegion.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        public DelegateCommand<string> ChangeRegionCommand { get; private set; }
        public DelegateCommand AddViewToRegionCommand { get; private set; }

        [Dependency]
        public IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            AddViewToRegionCommand = new DelegateCommand(ExecuteAddViewToRegion);
            ChangeRegionCommand = new DelegateCommand<string>(ExecuteChangeRegionCommand);
            
        }
        
        public void ExecuteAddViewToRegion()
        {
        }
        public void ExecuteChangeRegionCommand(string viewName)
        {
            _regionManager.RequestNavigate("MainContent", viewName, result =>
            {
                Console.WriteLine(result.Result);
            });
            
        }
    }
}