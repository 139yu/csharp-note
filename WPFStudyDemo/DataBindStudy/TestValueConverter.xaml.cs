using System.Diagnostics;
using System.Windows;

namespace DataBindStudy;

public partial class TestValueConverter : Window
{
    private int _gender = 2;

    public int Gender
    {
        get
        {
            return this._gender;
        }
        set
        { 
            _gender = value;
            Debug.WriteLine($"----------{value}");
        }
    }

    public TestValueConverter()
    {
        InitializeComponent();
        this.DataContext = this;
    }
}