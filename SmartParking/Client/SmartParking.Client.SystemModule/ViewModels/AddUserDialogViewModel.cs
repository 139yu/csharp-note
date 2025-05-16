using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SmartParking.Client.Commons.Entity.Request;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;
using SmartParking.Client.SystemModule.Models;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class AddUserDialogViewModel: BindableBase, IDialogAware
    {
        private IUserBll _userBll;
        private IDialogService _dialogService;
        private string mode;
        public AddUserDialogViewModel(IUserBll userBll, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _userBll = userBll;
        }

        private UserItemModel _userItem;

        public UserItemModel UserItem
        {
            get => _userItem;
            set => SetProperty(ref _userItem, value);
        }

        #region Command

        private ICommand _submitCommand;
        private ICommand _cancelCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new DelegateCommand(DoSubmitCommand);
                }

                return _submitCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new DelegateCommand(DoCancelCommand);
                }

                return _cancelCommand;
            }
        }

        private void DoCancelCommand()
        {
            RequestClose?.Invoke(new DialogResult());
        }

        private void DoSubmitCommand()
        {
            Task.Run(async () =>
            {
                ResponseResult result = await _userBll.RegisterUser(new UserRegisterParams()
                {
                    Username = UserItem.Username,
                    Password = UserItem.Password,
                    RealName = UserItem.RealName,
                    Birthday = UserItem.Birthday,
                    
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

        #endregion
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
            if (parameters.ContainsKey("mode"))
            {
                mode = parameters.GetValue<string>("mode");
                if (mode == "add")
                {
                    Title = "添加用户";
                    UserItem = new UserItemModel();
                }
                else
                {
                    Title = "编辑用户";
                    UserItem = parameters.GetValue<UserItemModel>("user");
                }
            }
        }

        public string Title { get; private set; }
        public event Action<IDialogResult> RequestClose;

        #endregion
        
    }
}