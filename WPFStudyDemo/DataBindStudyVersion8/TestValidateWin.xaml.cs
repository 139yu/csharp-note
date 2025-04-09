using System.Windows;
using System.Windows.Controls;

namespace DataBindStudy8;

public partial class TestValidateWin : Window
{
    public TestValidateWin()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    public static readonly DependencyProperty MyContentProperty = DependencyProperty.Register("MyContent", typeof(string),
        typeof(TestValidateWin), new FrameworkPropertyMetadata("null"), OnValidateValueCallback);

    private static bool OnValidateValueCallback(object? value)
    {
        if (value == null)
        {
            return true;
        }

        string str = value as string;
        if (str.Length > 11)
        {
            return false;
        }

        return true;
    }

    public string MyContent
    {
        get => (string)this.GetValue(MyContentProperty);
        set => this.SetValue(MyContentProperty,value);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var hasError = Validation.GetHasError(this.tb);
        if (hasError)
        {
            var errors = Validation.GetErrors(this.tb);
            foreach (ValidationError error in errors)
            {
                Console.WriteLine(error.ErrorContent);
            }
        }
    }
}