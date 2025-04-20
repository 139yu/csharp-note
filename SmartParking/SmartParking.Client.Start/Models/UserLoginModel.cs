using Prism.Mvvm;

namespace SmartParking.Client.Start.Models
{
    public class UserLoginModel: BindableBase
    {
        private string _username;
        private string _password;
        public string Username 
        { 
            get => _username;
            set
            {
                SetProperty(ref _username, value);
            }
        }
        public string Password 
        { 
            get => _password;
            set
            { 
                SetProperty(ref _password, value);
            }
        }
    }
}