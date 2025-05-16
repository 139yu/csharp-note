using System.Windows;
using Prism.Services.Dialogs;

namespace SmartParking.Client.Start.Views
{
    public partial class DialogWindow : Window,IDialogWindow
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}