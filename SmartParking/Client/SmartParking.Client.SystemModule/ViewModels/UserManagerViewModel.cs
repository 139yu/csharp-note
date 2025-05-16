using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using DryIoc;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using SmartParking.Client.Commons.Entity.Request;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class UserManagerViewModel : BaseNavigationViewModel
    {
        private IUserBll _userBll;
        private IDialogService _dialogService;
        public UserManagerViewModel(IContainer container, IRegionManager regionManager, IUserBll userBll,IDialogService dialogService) : base(
            container, regionManager)
        {
            _dialogService = dialogService;
            PageTitle = "用户管理";
            _userBll = userBll;
            QueryData();
        }

        #region property

        private bool _loadingVisibility = false;

        public bool LoadingVisibility
        {
            get => _loadingVisibility;
            set => SetProperty(ref _loadingVisibility, value);
        }
        private QueryUser _query;

        public QueryUser Query
        {
            get
            {
                if (_query == null)
                {
                    _query = new QueryUser();
                }

                return _query;
            }
        }

        private ObservableCollection<UserEntity> _userList;

        public ObservableCollection<UserEntity> UserList
        {
            get
            {
                if (_userList == null)
                {
                    _userList = new ObservableCollection<UserEntity>();
                }

                return _userList;
            }
            set => SetProperty(ref _userList, value);
        }

        #endregion

        public async Task QueryData()
        {
            
            try
            {
                LoadingVisibility = true;
                await Task.Delay(100);
                UserList.Clear();
                Task.Run(async () =>
                {
                    var result = await _userBll.GetUserList(Query);
                    if (result != null && result.Code == 200)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            
                            UserList.AddRange(result.Data);
                        });
                    }

                });
            }
            finally
            {
                LoadingVisibility = false;
            }
        }

        #region Command

        private ICommand _refreshCommand;
        private ICommand _addUserCommand;

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

        public ICommand AddUserCommand
        {
            get
            {
                if (_addUserCommand == null)
                {
                    _addUserCommand = new DelegateCommand(DoAddUserCommand);
                }

                return _addUserCommand;
            }
        }

        private void DoAddUserCommand()
        {
            var dialogParams = new DialogParameters();
            dialogParams.Add("mode","add");
            _dialogService.ShowDialog("AddUserDialog",dialogParams, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    QueryData();
                }
            });
        }

        private void DoRefreshCommand()
        {
            QueryData();
        }

        #endregion

    }
}