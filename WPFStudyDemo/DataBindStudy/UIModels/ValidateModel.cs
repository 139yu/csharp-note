using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindStudy.UIModels;

public class ValidateModel
{
    private string _value="123434567";

    public string Value
    {
        get => _value;
        set
        {
            if (value.Length > 10)
            {
                throw new ArgumentException("Value must be less than 10 characters.");
            }
            _value = value;
        }
    }
}