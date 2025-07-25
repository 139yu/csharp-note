using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Demo.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoPage : ContentPage
    {
        public DemoPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ModalPage(), true);
        }
    }
}