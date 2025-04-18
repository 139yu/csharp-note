using System.Windows;
using Prism.Services.Dialogs;

namespace Study.Prism02.Base
{
    public partial class DialogBaseWindow : Window, IDialogWindow
    {
        public DialogBaseWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}