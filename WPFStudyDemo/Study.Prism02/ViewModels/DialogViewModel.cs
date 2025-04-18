using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services.Dialogs;

namespace Study.Prism02.ViewModels
{
    public class DialogViewModel: IDialogAware
    {
        private string _textValue = "12346555";
        
        public string TextValue {
            get
            {
                return _textValue;
            }
            set
            {
                _textValue = value;
            }
        }
        
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

        public string Title { get; } = "test dialog";
        public event Action<IDialogResult>? RequestClose;
    }
}
