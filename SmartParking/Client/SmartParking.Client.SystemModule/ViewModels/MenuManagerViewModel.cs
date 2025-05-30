using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DryIoc;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;
using SmartParking.Client.SystemModule.Enum;
using SmartParking.Client.SystemModule.Models;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class MenuManagerViewModel : BaseNavigationViewModel
    {
        private IMenuBll _menuBll;
        private IDialogService _dialogService;

        public MenuManagerViewModel(IContainer container, IRegionManager regionManager, IMenuBll menuBll,
            IDialogService dialogService) : base(container, regionManager)
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
                        var root = new MenuItemModel(_regionManager)
                        {
                            MenuTitle = "根节点",
                            MenuId = 0,
                            IsExpanded = true,
                            AddCommand = new DelegateCommand(() => { this.DoAddMenuCommand(0, "根节点"); })
                            // Children = FillMenu(result.Data)
                        };
                        root.Children = FillMenu(result.Data, root);
                        MenuTree.Add(root);
                    });
                }
            });
        }

        private ObservableCollection<MenuItemModel> FillMenu(List<MenuEntity> menus, MenuItemModel parentMenu)
        {
            if (menus == null || menus.Count == 0)
            {
                return null;
            }

            var observableCollection = new ObservableCollection<MenuItemModel>();
            foreach (var menu in menus)
            {
                var mm = new MenuItemModel(_regionManager)
                {
                    MenuTitle = menu.MenuTitle,
                    MenuId = menu.MenuId,
                    ParentId = menu.ParentId,
                    MenuIcon = menu.MenuIcon,
                    TargetView = menu.TargetView,
                    AddCommand = new DelegateCommand(() => { DoAddMenuCommand(menu.MenuId, menu.MenuTitle); }),
                    IsLastChild = false,
                    ParentMenu = parentMenu
                };
                if (menu.Children != null && menu.Children.Count > 0)
                {
                    mm.Children = FillMenu(menu.Children, mm);
                }

                observableCollection.Add(mm);
                mm.MouseMoveCommand = new DelegateCommand<object>(obj => this.DoMouseOverCommand(obj, mm));
                mm.DropCommand = new DelegateCommand<object>(obj => this.DoDropCommand(obj, mm));
                mm.DragLeaveCommand = new DelegateCommand<object>(obj => this.DoDragLeaveCommand(obj, mm));
                mm.DragOverCommand = new DelegateCommand<object>(obj => this.DoDragOverCommand(obj, mm));
            }

            observableCollection.Last().IsLastChild = true;
            return observableCollection;
        }

        private ICommand _refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new DelegateCommand(DoRefreshCommand);
                }

                return _refreshCommand;
            }
        }

        private void DoRefreshCommand()
        {
            QueryData();
        }

        /// <summary>
        /// 拖拽操作离开控件区域时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="dragModel">被拖拽对象</param>
        private void DoDragLeaveCommand(object sender, MenuItemModel dragModel)
        {
            dragModel.MouseLocation = MouseLocationEnum.None;
        }

        /// <summary>
        /// 拖拽过程中鼠标悬停在允许放置的控件上时持续触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="targetModel">鼠标悬停的对象</param>
        private void DoDragOverCommand(object sender, MenuItemModel targetModel)
        {
            DragEventArgs ea = sender as DragEventArgs;
            if (ea == null) return;
            targetModel.MouseLocation = MouseLocationEnum.None;
            Console.WriteLine(111111);
            //被拖动对象
            var data = ea.Data.GetData(typeof(MenuItemModel)) as MenuItemModel;
            if (data == null || data.MenuId == targetModel.MenuId) return;
            //ea.Source：被拖拽的ui元素
            TreeViewItem tv = this.FindParent<TreeViewItem>(ea.Source as DependencyObject);
            if (tv == null)
            {
                return;
            }

            //拖拽目标相对鼠标悬停目标的坐标
            Point point = ea.GetPosition(tv);
            var pointY = point.Y;
            if (pointY <= 10)
            {
                targetModel.MouseLocation = MouseLocationEnum.TargetBefore;
            }
            else if (!targetModel.IsExpanded && pointY > 10 && pointY < tv.ActualHeight - 10 &&
                     (targetModel.Children != null && targetModel.Children.Count > 0))
            {
                targetModel.MouseLocation = MouseLocationEnum.TargetChildren;
            }
            else if (pointY >= tv.ActualHeight - 10)
            {
                targetModel.MouseLocation = MouseLocationEnum.TargetAfter;
            }
        }

        /// <summary>
        /// 释放鼠标，拖拽结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="targetModel">放置的目标对象</param>
        private void DoDropCommand(object sender, MenuItemModel targetModel)
        {
            var ea = sender as DragEventArgs;
            if (ea == null) return;
            ea.Handled = true;
            // 被拖动的model
            MenuItemModel data = ea.Data.GetData(typeof(MenuItemModel)) as MenuItemModel;
            if (data == null) return;
            var originParent = data.ParentMenu;
            if (targetModel.MouseLocation == MouseLocationEnum.TargetBefore)
            {
                originParent.Children.Remove(data);
                var children = targetModel.ParentMenu.Children;
                data.ParentMenu = targetModel.ParentMenu;
                data.ParentId = targetModel.ParentId;
                data.IsLastChild = false;
                var index = children.IndexOf(targetModel);

                children.Insert(index, data);
                children.Last().IsLastChild = true;
            }
            else if (targetModel.MouseLocation == MouseLocationEnum.TargetAfter)
            {
                originParent.Children.Remove(data);
                var children = targetModel.ParentMenu.Children;
                var index = children.IndexOf(targetModel);
                data.ParentMenu = targetModel.ParentMenu;
                data.ParentId = targetModel.ParentId;

                data.IsLastChild = false;
                if (index + 1 < children.Count)
                {
                    children.Insert(index + 1, data);
                    children.Last().IsLastChild = true;
                }
                else
                {
                    data.IsLastChild = true;
                    children.Add(data);
                }
            }
            else if (targetModel.MouseLocation == MouseLocationEnum.TargetChildren)
            {
                originParent.Children.Remove(data);
                originParent.Children.Last().IsLastChild = true;
                if (targetModel.Children == null || targetModel.Children.Count == 0)
                {
                    return;
                }

                targetModel.Children.Last().IsLastChild = false;
                data.ParentMenu = targetModel;
                data.ParentId = targetModel.MenuId;
                data.IsLastChild = true;
                targetModel.Children.Add(data);
            }

            if (originParent.Children != null && originParent.Children.Count > 0)
            {
                originParent.Children.Last().IsLastChild = true;
            }
            
        }

        /// <summary>
        /// 鼠标拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item">被拖拽对象</param>
        private void DoMouseOverCommand(object sender, MenuItemModel item)
        {
            var ea = sender as MouseEventArgs;
            // 左键鼠标按下才触发事件
            if (ea == null || ea.LeftButton != MouseButtonState.Pressed ||
                !(ea.OriginalSource is FrameworkElement)) return;
            // 启动拖放操作
            DragDrop.DoDragDrop(ea.OriginalSource as FrameworkElement, item, DragDropEffects.Move);
        }

        private void DoAddMenuCommand(int parentId, string parentTitle)
        {
            var parameters = new DialogParameters();
            parameters.Add("parentId", parentId);
            parameters.Add("parentTitle", parentTitle);
            _dialogService.ShowDialog("AddMenuDialog", parameters, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    QueryData();
                }
            });
        }

        private T FindParent<T>(DependencyObject ele) where T : DependencyObject
        {
            DependencyObject parentEle = VisualTreeHelper.GetParent(ele);
            if (parentEle != null)
            {
                if (parentEle is T)
                {
                    return parentEle as T;
                }
                else
                {
                    parentEle = FindParent<TreeViewItem>(parentEle);
                    if (parentEle != null && parentEle is T)
                    {
                        return parentEle as T;
                    }
                }
            }

            return null;
        }
    }
}