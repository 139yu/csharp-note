using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindStudyVersion8.Models;

public class ViewModel02 : INotifyPropertyChanged
{
    private string _value02 = "1234";
    public string Value02
    {
        get { return this._value02; }
        set
        {
            Console.WriteLine(value);
            this._value02 = value;
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Value02"));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}