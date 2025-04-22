using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartParking.Client.Commons.Models
{
    public class TokenProvider: ITokenProvider,INotifyPropertyChanged
    {
        private readonly object _lock = new object();
        private string _bearerToken;

        public string? BearerToken
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