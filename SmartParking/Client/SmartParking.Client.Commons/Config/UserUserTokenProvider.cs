using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SmartParking.Client.Commons.Entity.Response;

namespace SmartParking.Client.Commons.Config
{
    public class UserUserTokenProvider: IUserTokenProvider,INotifyPropertyChanged
    {
        private readonly object _lock = new object();
        private string _bearerToken;

        public UserEntity _currentUser;
        public UserEntity CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    OnPropertyChanged();
                }
            }
        }

        public string BearerToken
        {
            get
            {
                lock (_lock)
                {
                    return _bearerToken;
                }
            }
            set
            {
                lock (_lock)
                {
                    if (_bearerToken == value)
                    {
                        return;
                    }
                    _bearerToken = value;
                }

                OnTokenUpdated();
                OnPropertyChanged(nameof(BearerToken));
                
            }
        }

        public event EventHandler TokenUpdated;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnTokenUpdated()
        {
            TokenUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}