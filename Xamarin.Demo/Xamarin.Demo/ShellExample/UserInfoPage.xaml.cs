﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Demo.ShellExample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserInfoPage : ContentPage
	{
		public UserInfoPage ()
		{
			InitializeComponent ();
		}
	}
}