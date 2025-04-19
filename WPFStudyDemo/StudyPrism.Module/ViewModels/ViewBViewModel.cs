using Prism.Mvvm;

namespace StudyPrism.Module.ViewModels
{
    public class ViewBViewModel: BindableBase
    {
        private string _textValue = "this is ViewB";

        public string TextValue
        {
            get { return _textValue; }
            set { SetProperty(ref _textValue, value); }
        }
    }
}