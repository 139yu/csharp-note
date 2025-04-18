using System;
using Prism.Services.Dialogs;

namespace Study.PrismApp.ViewModels
{
    public class DialogContentWindowViewModel: IDialogAware
    {
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        public string Title { get; } = "Dialog Content";
        public event Action<IDialogResult> RequestClose;
    }
}