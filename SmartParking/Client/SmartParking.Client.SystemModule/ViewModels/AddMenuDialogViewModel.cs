using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;
using SmartParking.Client.SystemModule.Models;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class AddMenuDialogViewModel : BindableBase, IDialogAware
    {
        private IMenuBll _menuBll;

        public AddMenuDialogViewModel(IMenuBll menuBll)
        {
            _menuBll = menuBll;
        }

        private string _parentTitle;
        private MenuItemModel _menuModel;
        public MenuItemModel MenuItem
        {
            get => _menuModel;
            set => SetProperty(ref _menuModel, value);
        }
        
        public string ParentTitle
        {
            get => _parentTitle;
            set => SetProperty(ref _parentTitle, value);
        }

        private bool _isChecked;

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new DelegateCommand(DoAddCommand);
                }

                return _addCommand;
            }
        }

        private void DoAddCommand()
        {
            Task.Run(async () =>
            {
                var result = await _menuBll.addMenu(new MenuEntity()
                {
                    ParentId = MenuItem.ParentId,
                    TargetView = MenuItem.TargetView,
                    MenuIcon = MenuItem.MenuIcon,
                    MenuTitle = MenuItem.MenuTitle,
                    MenuType = 0
                });
                if (result != null && result.Code == 200)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("添加成功");
                        RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                    });
                }
            });
        }

        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }
        
        #region IDialogAware

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("parentId"))
            {
                MenuItem = new MenuItemModel(null)
                {
                    ParentId = parameters.GetValue<int>("parentId")
                };
                ParentTitle = parameters.GetValue<string>("parentTitle");
            }
        }

        public string Title { get; } = "添加菜单";
        public event Action<IDialogResult> RequestClose;

        #endregion

        
    }
}