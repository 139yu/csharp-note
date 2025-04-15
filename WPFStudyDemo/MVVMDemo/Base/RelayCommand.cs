using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.Base
{
    public class RelayCommand: ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?,bool> _canExecute;

        public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        } 
        
        public bool CanExecute(object? parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
             _execute.Invoke(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        
    }
}
