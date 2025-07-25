using System.Windows.Input;

namespace Project.BMS.Base;

public class BaseCommand : ICommand
{
    public Action<object?> DoExecute { get; set; }

    public BaseCommand(Action<object?> doExecute)
    {
        DoExecute = doExecute;
    }

    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        DoExecute?.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}