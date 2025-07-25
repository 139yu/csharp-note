using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.App;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Xamarin.Demo.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Xamarin.Demo.Android")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]

// 电池状态权限
[assembly: UsesPermission(Android.Manifest.Permission.BatteryStats)]

// 联系人读写权限
[assembly: UsesPermission(Android.Manifest.Permission.ReadContacts)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteContacts)]

// 地理信息相关权限
[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
// Android 10以上版本需要
[assembly: UsesPermission(Android.Manifest.Permission.AccessBackgroundLocation)]
[assembly: UsesFeature(name: "android.hardware.location", Required = false)]
[assembly: UsesFeature(name: "android.hardware.location.gps", Required = false)]
[assembly: UsesFeature(name: "android.hardware.location.network", Required = false)]
