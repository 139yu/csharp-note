using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Demo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShellDemoPage : Shell
	{
		public ShellDemoPage ()
		{
			InitializeComponent ();
		}
	}
}