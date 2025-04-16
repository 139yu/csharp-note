using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Study.MVVMTookit.ViewModels
{
    public class MainViewModel: ObservableRecipient
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _description = "1234";
                SetProperty(ref _title, value, nameof(Description));
            }
        }
        
        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                
                //SetProperty(ref _description,value , nameof (Description));
            }
        }

        public MainViewModel()
        {
            ChangeTitleCommand = new RelayCommand(() =>
            {
                Title = "Github";
            });
        }

        public RelayCommand ChangeTitleCommand { get; }
    }
}