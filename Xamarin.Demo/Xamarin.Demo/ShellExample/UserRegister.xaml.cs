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
	public partial class UserRegister : ContentPage
	{
		public UserRegister ()
		{
			InitializeComponent ();
		}

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("user_info"); // Navigate back to the previous page
        }

        /*private async void GlobalSearch(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//user_info");
        }*/
        private async void GoDetails(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("user_details");
        }
    }
}