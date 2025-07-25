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
	public partial class ShellApp : Shell
	{
		public ShellApp ()
        {
			Routing.RegisterRoute("mall/user_details",typeof(UserDetailsPage));
            Routing.RegisterRoute("mall/user/user_register", typeof(UserRegister));
            Routing.RegisterRoute("mall/user/user_info", typeof(UserInfoPage));
            Routing.RegisterRoute("system/user/user_register", typeof(SysUserRegister));
            InitializeComponent ();
		}
	}
}