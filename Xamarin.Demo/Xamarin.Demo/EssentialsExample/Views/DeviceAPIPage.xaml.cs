using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Demo.EssentialsExample.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Demo.EssentialsExample.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeviceAPIPage : ContentPage
	{
		public DeviceAPIPage ()
        {
            this.BindingContext = new DeviceAPIViewModel();
			InitializeComponent ();
		}

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.bilibili.com/");
        }
    }
}