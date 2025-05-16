using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace SmartParking.Client.SystemModule.Models
{
    public class MenuItemModel : BindableBase
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuTitle { get; set; }
        private string _menuIcon;

        public string MenuIcon
        {
            get => _menuIcon;
            set => SetProperty(ref _menuIcon, value);
        }
        public string TargetView { get; set; }
        public bool IsLastChild { get; set; }
        public ObservableCollection<MenuItemModel> Children { get; set; }
        private IRegionManager _regionManager;

        public MenuItemModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }


        private bool _isExpanded = false;

        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }

        private bool _isSelected = false;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        private bool _isChecked = false;

        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }
        #region Command

        private ICommand _openViewCommand;

        public ICommand OpenViewCommand
        {
            get { return _openViewCommand ??= new DelegateCommand(ExecuteOpenView); }
        }
        private void ExecuteOpenView()
        {
            if ((Children == null || Children.Count == 0) && !string.IsNullOrEmpty(TargetView))
            {
                var nvaParams = new NavigationParameters();
                nvaParams.Add("ViewName", TargetView);
                _regionManager.RequestNavigate("MainContentRegion",TargetView, nvaParams);
            }
            else
            {
                IsExpanded = !IsExpanded;
            }
            

        }
        
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion
    }
}