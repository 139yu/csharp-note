using System;
using Prism.Commands;
using Prism.Mvvm;

namespace Study.CompositeCommand.ViewModels
{
    public class MainWindowViewModel: BindableBase
    {
        private int _num1;
        private int _num2;

        public int Num1
        {
            get { return _num1; }
            set { SetProperty(ref _num1, value); }
        }

        public int Num2
        {
            get { return _num2; }
            set { SetProperty(ref _num2, value); }
        }
        
        public DelegateCommand GenerateNum1Command { get; }
        public DelegateCommand GenerateNum2Command { get; }
        public Prism.Commands.CompositeCommand UnionCommand { get; }

        public MainWindowViewModel()
        {
            UnionCommand = new Prism.Commands.CompositeCommand();
            GenerateNum1Command = new DelegateCommand(GenerateNum1);
            GenerateNum2Command = new DelegateCommand(GenerateNum2);
            UnionCommand.RegisterCommand(GenerateNum1Command);
            UnionCommand.RegisterCommand(GenerateNum2Command);
        }

        private void GenerateNum1()
        {
            Num1 = new Random().Next(1000,99999);
        }
        private void GenerateNum2()
        {
            Num2 = new Random().Next(1000,99999);
        }
    }
}