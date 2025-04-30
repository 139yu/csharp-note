using System.Windows;
using Prism.Events;
using SmartParking.Client.Start.Events;

namespace SmartParking.Client.Start.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow(IEventAggregator ea)
        {
            InitializeComponent();
            ea.GetEvent<WindowCloseEvent>().Subscribe(HandleWindowClosing, ThreadOption.UIThread);
        }

        public void HandleWindowClosing()
        {
            this.Close();
        }
    }
}