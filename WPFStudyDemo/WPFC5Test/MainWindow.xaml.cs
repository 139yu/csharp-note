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
using WPFC5Test.Models;

namespace WPFC5Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewTestMode TestMode { get; set; } = new ViewTestMode();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = TestMode;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.oneWayText.Text = "";
            TestMode.Value = new Random().Next(12341);
        }
    }
}