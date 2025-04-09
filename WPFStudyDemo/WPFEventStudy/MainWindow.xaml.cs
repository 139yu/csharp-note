using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPFEventStudy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Initialized += OnInitialized;
            this.SourceInitialized += MainWindow_SourceInitialized;
            this.Loaded += OnLoaded;
            this.ContentRendered += MainWindow_ContentRendered;
            this.Closed += OnClosed;
            Thread t = new Thread(() =>
            {
                Thread.Sleep(2000);
                // throw new ArgumentException("线程异常");
            });
            t.Start();
        }

        private void MainWindow_ContentRendered(object? sender, EventArgs e)
        {
            Console.WriteLine("MainWindow_ContentRendered");
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("OnLoaded");
            Task.Run(() =>
            {
                int i = 0;
                // int j = 10 / i;
                GC.Collect();
            });
            
        }

        private void MainWindow_SourceInitialized(object? sender, EventArgs e)
        {
            Console.WriteLine("MainWindow_SourceInitialized");
        }

        private void OnInitialized(object? sender, EventArgs e)
        {
            Console.WriteLine("OnInitialized");
        }   

        private void OnClosed(object? sender, EventArgs e)
        {
            Console.WriteLine("OnClosed");
        }
    }
}
