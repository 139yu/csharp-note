using System;
using System.Windows.Data;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Study.PrismApp.Event;
using Unity;

namespace Study.PrismApp.ViewModels
{
    public class MainWindowViewModel: BindableBase
    {
        private string _textValue = "1234";
        private SubscriptionToken _token;
        public string TextValue
        {
            get { return _textValue; }
            set
            {
                SetProperty(ref _textValue, value);
            }
        }
        private IEventAggregator _eventAggregator;
        [Dependency]
        private IDialogService dialogService { get;set; }
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(ExecuteSaveCommand);
            _token = _eventAggregator.GetEvent<SaveEvent>().Subscribe(ConsumerEvent);
            ShowDialogCommand = new DelegateCommand(ExecuteOpenDialog);
        }

        private void ExecuteOpenDialog()
        {
            dialogService.ShowDialog("DialogContent");
        }

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand ShowDialogCommand { get; }
        public void ExecuteSaveCommand()
        {
            _eventAggregator.GetEvent<SaveEvent>().Publish(_textValue);
        }

        public void ConsumerEvent(string s)
        {
            Console.WriteLine(s);
        }

        public void Destroy()
        {
            _eventAggregator.GetEvent<SaveEvent>().Unsubscribe(_token);
        }
    }
}