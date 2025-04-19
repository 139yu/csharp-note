using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Study.PrismModule.Api;

namespace StudyPrism.Module.ViewModels
{
    public class MainWindowViewModel: BindableBase
    {
        public DelegateCommand<string> ChangeViewCommand { get; private set; }
        public IRegionManager _regionManager;
        public IModuleManager _moduleManager;
        public MainWindowViewModel(IRegionManager regionManager,IModuleManager moduleManager,ITestService testService)
        {
            testService.Test();
            _moduleManager = moduleManager;
            _regionManager = regionManager;
            ChangeViewCommand = new DelegateCommand<string>(ExecuteChangeView);
        }
        
        public void ExecuteChangeView(string viewName)
        {
            if (viewName.Contains("A"))
            {
                _moduleManager.LoadModule("SubModule");
            }
            _regionManager.RequestNavigate("MainContent", viewName);
        }
    }
}