using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.Models;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public UserModel LoginUser { get; set; } = new UserModel();
        public RelayCommand<object> LoginCommand { get; set; }
        private ILocalDataAccess _localDataAccess;
        private string _failedMsg;

        public string FailedMsg
        {
            get => _failedMsg;
            set => Set(ref _failedMsg, value);
        }


        public LoginViewModel(ILocalDataAccess localDataAccess)
        {
            LoginCommand = new RelayCommand<object>(DoExecuteLogin);
            _localDataAccess = localDataAccess;
        }


        private void DoExecuteLogin(object source)
        {
            try
            {
                var username = LoginUser.Username;
                var password = LoginUser.Password;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("请输入用户名或密码！");
                }

                var userData = _localDataAccess.Login(username, password);
                if (userData == null)
                {
                    throw new Exception("登录失败，请检查用户名/密码是否正确");
                }

                var main = SimpleIoc.Default.GetInstance<MainViewModel>();
                if (main != null)
                {
                    main.CurrentUser = new UserModel
                    {
                        Username = userData.Rows[0]["username"].ToString(),
                        RealName = userData.Rows[0]["real_name"].ToString(),
                        UserType = Convert.ToInt32(userData.Rows[0]["user_type"]),
                        PhoneNum = userData.Rows[0]["phone_num"].ToString(),
                        Gender = Convert.ToInt32(userData.Rows[0]["gender"]),
                    };
                    (source as Window).DialogResult = true;
                }
            }
            catch (Exception e)
            {
                FailedMsg = e.Message;
            }
        }
    }
}