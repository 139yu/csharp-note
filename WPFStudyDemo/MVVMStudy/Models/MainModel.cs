using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MVVMStudy.Base;

namespace MVVMStudy.Models
{
    public class MainModel: INotifyPropertyChanged
    {
        private string _username = String.Empty;
        private string _password = String.Empty;

        public MainModel()
        {
            Command = new BaseCommand(Login, CanLogin);
        }
        public BaseCommand Command { get; set; }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                SetField(ref _username, value);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                SetField(ref _password, value);
            }
        }

        public void Login(object? o)
        {
            Debug.WriteLine($"{_username}使用{_password}登录了");
        }

        public bool CanLogin(object? o)
        {
            return !(string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_username));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}