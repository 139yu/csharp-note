using Prism.Mvvm;
using SmartParking.Client.Start.Models;

namespace SmartParking.Client.Start.ViewModels
{
    public class LoginWindowViewModel
    {
        public UserLoginModel LoginModel { get; set; } = new UserLoginModel();

        public LoginWindowViewModel()
        {
        }
        
        
    }
}