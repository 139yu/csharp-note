using Prism.Mvvm;
using SmartParking.Client.Commons.Config;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class MainHeaderViewModel: BindableBase
    {
        private string _realName;

        public string RealName
        {
            get => _realName;
            set => SetProperty(ref _realName, value);
        }
        public MainHeaderViewModel(IUserTokenProvider userTokenProvider)
        {
            RealName = userTokenProvider.CurrentUser.RealName;
        }
    }
}