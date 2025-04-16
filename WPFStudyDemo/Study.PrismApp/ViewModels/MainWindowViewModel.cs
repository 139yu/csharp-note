using System.Windows.Data;
using Prism.Mvvm;

namespace Study.PrismApp.ViewModel
{
    public class MainWindowViewModel: BindableBase
    {
        private string _textValue = "1234";

        public string TextValue
        {
            get { return _textValue; }
            set
            {
                SetProperty(ref _textValue, value);
            }
        }
    }
}