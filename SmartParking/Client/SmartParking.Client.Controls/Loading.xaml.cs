using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartParking.Client.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Loading : UserControl
    {
        public Loading()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty LoadingMessageProperty = DependencyProperty
            .Register(nameof(LoadingMessage), typeof(string), typeof(Loading));

        public string LoadingMessage
        {
            get { return (string)GetValue(LoadingMessageProperty); }
            set { SetValue(LoadingMessageProperty, value); }
        }
    }
}