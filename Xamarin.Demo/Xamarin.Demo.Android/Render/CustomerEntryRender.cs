using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Demo.Droid.Render;
using Xamarin.Demo.UIControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomerEntry), typeof(CustomerEntryRender))]
namespace Xamarin.Demo.Droid.Render
{
    public class CustomerEntryRender : EntryRenderer
    {
        public CustomerEntryRender(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            // 去除entry的下划线
            Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
        }
    }
}