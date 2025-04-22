using System;
using System.Threading.Tasks;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using SmartParking.Client.IBLL;
using SmartParking.Client.Start.Models;

namespace SmartParking.Client.Start.ViewModels
{
    public class LoginWindowViewModel: BindableBase
    {
        public UserLoginModel LoginModel { get; set; } = new UserLoginModel();
        public DelegateCommand<object> LoginCommand { get;  }
        private string _errorMessage;
        private ILoginBll _loginBll;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }
        public LoginWindowViewModel(ILoginBll loginBll)
        {
            _loginBll = loginBll;
            LoginCommand = new DelegateCommand<object>(ExecuteLogin);
        }

        private void ExecuteLogin(object sender)
        {
            var window = sender as Window;
            var username = LoginModel.Username;
            var password = LoginModel.Password;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ErrorMessage = "请输入账号或密码！";
            }

            Task.Run(async () =>
            {
                try
                {
                    var loginRes = _loginBll.Login(LoginModel);
                    if (loginRes != null)
                    {
                        var result = loginRes.GetAwaiter().GetResult();
                        if (result == null || result.Code != 200)
                        {
                            ErrorMessage = result.Msg ?? "登录失败";
                        }
                    }
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            });
        }
        
    }
}