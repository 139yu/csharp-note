using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMStudy.Base
{
    public class BaseCommand: ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?,bool> _canExecute;

        public BaseCommand(Action<object?> execute, Func<object?, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) == true;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }

        
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
