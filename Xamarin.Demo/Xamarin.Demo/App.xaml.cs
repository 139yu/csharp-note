using System;
using Xamarin.Demo.EssentialsExample.Views;
using Xamarin.Demo.Nav;
using Xamarin.Demo.ShellExample;
using Xamarin.Demo.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomePage = Xamarin.Demo.ShellExample.HomePage;

namespace Xamarin.Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DeviceAPIPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
