using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Study.PrismRegion.ViewModels
{
    [RegionMemberLifetime(KeepAlive = false)]
    public class MainContentViewModel: BindableBase, INavigationAware
    {
        private string _textValue = "Hello World";

        public string TextValue
        {
            get => _textValue;
            set
            {
                SetProperty(ref _textValue, value);
            }
        }

        public MainContentViewModel()
        {
            GoForwardCommand = new DelegateCommand(ExecuteGoForwardCommand);
        }

        private void ExecuteGoForwardCommand()
        {
            if (_journal != null && _journal.CanGoForward)
            {
                _journal.GoForward();
            }
        }

        public DelegateCommand GoForwardCommand { get; }
        private IRegionNavigationJournal _journal;
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}