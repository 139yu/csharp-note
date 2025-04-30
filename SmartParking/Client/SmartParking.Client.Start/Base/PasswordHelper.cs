using System.Windows;
using System.Windows.Controls;

namespace SmartParking.Client.Start.Base
{
    public class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", 
            typeof(string), 
            typeof(PasswordHelper),
            new FrameworkPropertyMetadata(default(string), new PropertyChangedCallback(OnPasswordChanged)));

     

        public static string GetPassword(DependencyObject obj) => (string)obj.GetValue(PasswordProperty);
        
        public static void SetPassword(DependencyObject obj, string value) => obj.SetValue(PasswordProperty, value);
        
        public static readonly DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach",
            typeof(string),
            typeof(PasswordHelper),
            new FrameworkPropertyMetadata( new PropertyChangedCallback(OnAttachChanged)));
        
        public static string GetAttach(DependencyObject d)
        {
            return (string)d.GetValue(AttachProperty);
        }
        public static void SetAttach(DependencyObject d, string value)
        {
            d.SetValue(AttachProperty, value);
        }
        
        private static bool _isUpdating = false; 
        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            /*PasswordBox pb = d as PasswordBox;
            pb.PasswordChanged -= Pb_PasswordChanged;
            if (!_isUpdating)
            {
                pb.Password = e.NewValue.ToString();
            }
            pb.PasswordChanged += Pb_PasswordChanged;*/
        }

        private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pb = d as PasswordBox;
            pb.PasswordChanged += Pb_PasswordChanged;
        }
        private static void Pb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            _isUpdating = true;
            SetPassword(pb, pb.Password);
            _isUpdating = false;
        }

    }
}