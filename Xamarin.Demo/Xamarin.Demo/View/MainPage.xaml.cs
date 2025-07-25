using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Demo.View
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("text changed");
        }

        private void Entry_OnCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("text completed");
        }
    }
}
