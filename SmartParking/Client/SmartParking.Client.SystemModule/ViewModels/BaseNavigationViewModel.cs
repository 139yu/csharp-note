using System;
using System.Linq;
using System.Windows.Input;
using DryIoc;
using ImTools;
using NLog.Fluent;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class BaseNavigationViewModel : BindableBase, INavigationAware
    {
        public string PageTitle { get; set; }
        private string _viewName;

        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

        protected IContainer _container;
        protected IRegionManager _regionManager;

        public BaseNavigationViewModel(IContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        private DelegateCommand<string> _closeCommand;

        public DelegateCommand<string> CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new DelegateCommand<string>(DoCloseCommand);
                }

                return _closeCommand;
            }
        }

        private void DoCloseCommand(string viewName)
        {
            
            var obj = _container
                .GetServiceRegistrations().Where(s =>
                {
                    if (s.OptionalServiceKey != null && s.OptionalServiceKey.ToString() == viewName)
                    {
                        return true;
                    }

                    return false;
                }).FirstOrDefault();
                

            var viewType = obj.ImplementationType;
            if (viewType != null)
            {
                var region = _regionManager.Regions["MainContentRegion"];
                var view = region.Views.FirstOrDefault(v => v.GetType() == viewType);
                region.Remove(view);
            }
        }

        #region INavigationAware

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("ViewName"))
            {
                ViewName = navigationContext.Parameters["ViewName"].ToString();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        #endregion
    }
}