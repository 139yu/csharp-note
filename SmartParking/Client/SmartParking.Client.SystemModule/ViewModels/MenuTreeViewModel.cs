using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Prism.Mvvm;
using Prism.Regions;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;
using SmartParking.Client.SystemModule.Models;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class MenuTreeViewModel : BindableBase
    {
        private Dispatcher MainDispatcher { get; }
        private IMenuBll _menuBll;

        private IRegionManager _regionManager;
        private bool _isExpanded = false;

        public bool IsExpanded
        {
            get => _isExpanded;
            set { SetProperty(ref _isExpanded, value); }
        }

        private ObservableCollection<MenuItemModel> menuTree;

        public ObservableCollection<MenuItemModel> MenuTree
        {
            get => menuTree;
            set { SetProperty(ref menuTree, value); }
        }

        private bool _isSelected = false;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public MenuTreeViewModel(IMenuBll menuBll, IRegionManager regionManager)
        {
            _menuBll = menuBll;
            _regionManager = regionManager;
            MainDispatcher = Application.Current.Dispatcher;
            InitialView();
        }

        private void InitialView()
        {
            // 初始化菜单
            Task.Run(async () =>
            {
                var res = await _menuBll.GetMenuTree();
               
                if (res != null && res.Code == 200)
                {
                    MainDispatcher.Invoke(() => { MenuTree = FillMenu(res.Data); });
                }
            });
        }

        private ObservableCollection<MenuItemModel> FillMenu(List<MenuEntity> menus)
        {
            var observableCollection = new ObservableCollection<MenuItemModel>();
            if (menus == null)
            {
                return observableCollection;
            }

            var list = menus.Select(m => new MenuItemModel(_regionManager)
            {
                MenuTitle = m.MenuTitle,
                MenuIcon = m.MenuIcon,
                TargetView = m.TargetView,
                Children = m.Children == null ? null : FillMenu(m.Children)
            }).ToList();

            observableCollection.AddRange(list);
            return observableCollection;
        }
    }
}