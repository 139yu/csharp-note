using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Unity;

namespace Study.Prism02.ViewModels
{
    public class MainWindowViewModel: BindableBase
    {
        private string _textValue = "1234";

        public string TextValue
        {
            get => _textValue;
            set
            {
                SetProperty(ref _textValue, value);
            }
        }
        // 修饰不能是private
        [Dependency] 
        public IDialogService dialogService;
        public MainWindowViewModel()
        {
            ShowDialogCommand = new DelegateCommand(ExecuteDialog);
        }

        private void ExecuteDialog()
        {
            dialogService.ShowDialog("DialogView", new DialogParameters(),i => {}, "DialogBaseWindow");
        }

        public DelegateCommand ShowDialogCommand { get; }
    }
}
