using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Demo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Demo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CollectionViewPage : ContentPage
	{
		public CollectionViewPage ()
        {
            this.BindingContext = new CollectionViewModel();
			InitializeComponent ();
		}

        private void RefreshView_OnRefreshing(object sender, EventArgs e)
        {
            Console.WriteLine(11111);
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                // Application.Current.Dispatcher
                this.rv.IsRefreshing = false;
            });
            
        }

        private void ItemsView_OnRemainingItemsThresholdReached(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}