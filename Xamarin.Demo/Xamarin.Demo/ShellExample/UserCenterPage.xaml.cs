using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Demo.ShellExample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserCenterPage : ContentPage
	{
		public UserCenterPage ()
		{
			InitializeComponent ();
		}

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("mall/user/user_register");
        }

        

        private async void GoSysUserReg(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("system/user/user_register");
        }
    }
}