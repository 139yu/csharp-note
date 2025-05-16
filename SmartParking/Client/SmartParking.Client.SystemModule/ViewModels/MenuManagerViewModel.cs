using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DryIoc;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;
using SmartParking.Client.SystemModule.Models;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class MenuManagerViewModel : BaseNavigationViewModel
    {
        private IMenuBll _menuBll;
        private IDialogService _dialogService;
        public MenuManagerViewModel(IContainer container,IRegionManager regionManager,IMenuBll menuBll,IDialogService dialogService) : base(container,regionManager)
        {
            _dialogService = dialogService;
            PageTitle = "菜单管理";
            _menuBll = menuBll;
            QueryData();
        }
        private ObservableCollection<MenuItemModel> menuTree;

        public ObservableCollection<MenuItemModel> MenuTree
        {
            get
            {
                if (menuTree == null)
                {
                    menuTree = new ObservableCollection<MenuItemModel>();
                }

                return menuTree;
            }
            set { SetProperty(ref menuTree, value); }
        }
        private void QueryData()
        {
            Task.Run(async () =>
            {
                var result = await _menuBll.GetMenuTree();
                if (result != null && result.Code == 200)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MenuTree.Clear();
                        MenuTree.Add(new MenuItemModel(_regionManager)
                        {
                            MenuTitle = "根节点",
                            MenuId = 0,
                            IsExpanded = true,
                            Children = FillMenu(result.Data)
                        });
                        Console.WriteLine(1);
                    });
                }
            });
        }
        private ObservableCollection<MenuItemModel> FillMenu(List<MenuEntity> menus)
        {
            
            if (menus == null || menus.Count == 0)
            {
                return null;
            }
            var observableCollection = new ObservableCollection<MenuItemModel>();
            var list = menus.Select(m => new MenuItemModel(_regionManager)
            {
                MenuTitle = m.MenuTitle,
                MenuId = m.MenuId,
                ParentId = m.ParentId,
                MenuIcon = m.MenuIcon,
                TargetView = m.TargetView,
                AddCommand = new DelegateCommand(() =>
                {
                    DoAddMenuCommand(m.MenuId,m.MenuTitle);
                }),
                Children = m.Children == null ? null : FillMenu(m.Children)
            }).ToList();
            list.Last().IsLastChild = true;
            observableCollection.AddRange(list);
            return observableCollection;
        }

        private void DoAddMenuCommand(int parentId,string parentTitle)
        {
            var parameters = new DialogParameters();
            parameters.Add("parentId", parentId);
            parameters.Add("parentTitle", parentTitle);
            _dialogService.ShowDialog("AddMenuDialog",parameters, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    QueryData();
                }
            });
        }
    }
}