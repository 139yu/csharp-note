using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Nobody.DigitaPlatform.Common
{
    public class PasswordHelper
    {
        public static DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password",
            typeof(string), typeof(PasswordHelper),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnPasswordPropertyChanged)));

        public static DependencyProperty AttachProperty = DependencyProperty.RegisterAttached("Attach",
            typeof(bool), typeof(PasswordHelper),
            new FrameworkPropertyMetadata(false,OnAttachChanged));

       

        public static bool GetAttach(DependencyObject d)
        {
            return (bool)d.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject d, bool value)
        {
            d.SetValue(AttachProperty, value);
        }

        public static string GetPassword(DependencyObject d)
        {
            return (string)d.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject d, string value)
        {
            d.SetValue(PasswordProperty, value);
        }

        private static bool isUpdate = false;
        /// <summary>
        /// 通过此方法先监听密码修改事件
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            var attach = GetAttach(passwordBox);
            if (attach)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;
            if (!isUpdate)
            {
                passwordBox.Password = e.NewValue as string ?? string.Empty;
            }

            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            isUpdate = true;
            SetPassword(passwordBox, passwordBox.Password);
            isUpdate = false;
        }
    }
}