using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Demo.Nav;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin.Demo.EssentialsExample.ViewModels
{
    public class DeviceAPIViewModel: INotifyPropertyChanged
    {
        public DeviceModel CurrentDevice { get; set; }
        public ObservableCollection<ContactModel> ContactList { get; set; } = new ObservableCollection<ContactModel>();
        public string NetworkStatus { get; set; }
        private double _lat;
        private double _lng;
        private string _addresss;
        private double _xSpeed;
        private double _ySpeed;
        private double _zSpeed;
        public double ZSpeed
        {
            get => _zSpeed;
            set => SetField(ref _zSpeed, value);
        }   
        public double XSpeed
        {
            get => _xSpeed;
            set => SetField(ref _xSpeed, value);
        }
        public double YSpeed
        {
            get => _ySpeed;
            set => SetField(ref _ySpeed, value);
        }
        public string Address
        {
            get => _addresss;
            set => SetField(ref _addresss, value);
        }
        public double Lat
        {
            get => _lat;
            set => SetField(ref _lat, value);
        }
        public double Lng
        {
            get => _lng;
            set => SetField(ref _lng, value);
        }

        public DeviceAPIViewModel()
        {
            GetDeviceInfo();
            GetBatteryInfo();
            GetContacts();
            GetNetworkStatus();
            GetLocation();
            GetAccelerometer();
        }

        private void GetAccelerometer()
        {
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.Stop();
                Accelerometer.ReadingChanged -= AccelerometerOnReadingChanged;
            }
            else
            {
                Accelerometer.ReadingChanged += AccelerometerOnReadingChanged;
                Accelerometer.Start(SensorSpeed.UI);
            }
        }

        private void AccelerometerOnReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            XSpeed = e.Reading.Acceleration.X;
            YSpeed = e.Reading.Acceleration.Y;
            ZSpeed = e.Reading.Acceleration.Z;
        }

        private async void GetLocation()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                status =  await Permissions.RequestAsync<Permissions.LocationAlways>();
            }
            var location = await Geolocation.GetLocationAsync();
            if (location != null)
            {
                Lat = location.Latitude;
                Lng = location.Longitude;
                var placemarksAsync = await Geocoding.GetPlacemarksAsync(location);
                foreach (var placemark in placemarksAsync)
                {
                    Address = placemark.ToString();
                    // Address = $"{placemark.CountryName}-{placemark.AdminArea}-{placemark.Locality}-{placemark.SubLocality}-{placemark.FeatureName}";
                }
            }
            
        }

        private void GetNetworkStatus()
        {
            var access = Connectivity.NetworkAccess;
            NetworkStatus = access.ToString();
            Console.WriteLine($"current network access is:{access}");
            Connectivity.ConnectivityChanged += (obj, args) =>
            {
                var networkAccess = args.NetworkAccess;
                NetworkStatus = networkAccess.ToString();
            };
        }

        private void ConnectivityOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async Task GetContacts()
        {
            // 检查是否授权
            var status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();
            // 未授权
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.ContactsRead>();
            }

            if (status != PermissionStatus.Granted)
            {
                throw new Exception("未授权");
            }

            var contacts = await Contacts.GetAllAsync();
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    ContactList.Add(new ContactModel()
                    {
                        Name = contact.DisplayName,
                        Phone = contact.Phones[0].PhoneNumber
                    });
                }
            }
        }

        private void GetBatteryInfo()
        {
            // 电量
            var chargeLevel = Battery.ChargeLevel * 100;
        }

        private void Themes()
        {
            var appTheme = Application.Current.RequestedTheme;
            Console.WriteLine(appTheme);
        }

        public void GetDeviceInfo()
        {
            CurrentDevice = new DeviceModel
            {
                Model = DeviceInfo.Model,
                Manufacturer = DeviceInfo.Manufacturer,
                Name = DeviceInfo.Name,
                Version = DeviceInfo.VersionString,
                DevicePlatform = DeviceInfo.Platform.ToString(),
                DeviceIdiom = DeviceInfo.Idiom.ToString(),
                DeviceType = DeviceInfo.DeviceType.ToString()
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class ContactModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class DeviceModel
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string DevicePlatform { get; set; }
        public string DeviceIdiom { get; set; }
        public string DeviceType { get; set; }
    }

}