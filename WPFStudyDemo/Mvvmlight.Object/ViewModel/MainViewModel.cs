using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Mvvmlight.Object.Views;

namespace Mvvmlight.Object.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
           
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            BtnCommand = new RelayCommand<string>(HandlerClick);
        }
        private string _value;

        public string Value
        {
            get => this._value;
            set
            {
                Set(ref _value, value);
            }
        }

        public RelayCommand<string> BtnCommand { get; set; }

        public void HandlerClick(string msg)
        {
            Value = "send success";
            // Messenger.Default.Send<string,MainWindow>(msg);
            // 使用NotificationMessage
            // Messenger.Default.Send<NotificationMessage>(new NotificationMessage(this,typeof(MainWindow),msg));
            var notificationMessage = new NotificationMessageAction<string>(this,typeof(MainWindow),msg, HandlerCallback);
            Messenger.Default.Send<NotificationMessageAction<string>,MainWindow>(notificationMessage);
        }

        private void HandlerCallback(string param)
        {
            // 处理回调逻辑
        }
    }
}