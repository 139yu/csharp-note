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
        public string MenuTitle { get; set; }
        public string MenuIcon { get; set; }
        public string TargetView { get; set; }
        public ObservableCollection<MenuItemModel> Children { get; set; }
        private IRegionManager _regionManager;

        public MenuItemModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        private void ExecuteOpenView()
        {
            IsExpanded = !IsExpanded;
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

        private ICommand _openViewCommand;

        public ICommand OpenViewCommand
        {
            get { return _openViewCommand ??= new DelegateCommand(ExecuteOpenView); }
        }
    }
}