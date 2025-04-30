using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using SmartParking.Client.UpgradeApp.Base;

namespace SmartParking.Client.UpgradeApp.ViewModels
{
    public class FinishViewModel: INotifyPropertyChanged
    {
        private bool _isRun = false;
        public bool IsRun
        {
            get => _isRun;
            set
            {
                if (_isRun != value)
                {
                    _isRun = value;
                    OnPropertyChanged();
                }
            }
        }

        public DelegateCommand OkCommand { get; }

        public FinishViewModel()
        {
            OkCommand = new DelegateCommand(ExecuteOk);
        }

        private void ExecuteOk(object obj)
        {
            if (IsRun)
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = "SmartParking.Client.Start.exe",
                    UseShellExecute = true
                });
            }
            Application.Current.Shutdown();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}