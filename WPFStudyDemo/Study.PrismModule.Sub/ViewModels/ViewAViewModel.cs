using Prism.Mvvm;

namespace Study.PrismModule.Sub.ViewModels
{
    public class ViewAViewModel: BindableBase
    {
        private string _textValue = "this is ViewA";

        public string TextValue
        {
            get { return _textValue; }
            set { SetProperty(ref _textValue, value); }
        }
    }
}