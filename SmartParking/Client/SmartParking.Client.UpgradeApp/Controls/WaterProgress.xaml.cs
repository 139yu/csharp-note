using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartParking.Client.UpgradeApp.Controls
{
    /// <summary>
    /// WaterProgress.xaml 的交互逻辑
    /// </summary>
    public partial class WaterProgress : UserControl
    {
        public static readonly DependencyProperty ProgressValueProperty =
            DependencyProperty.Register(nameof(ProgressValue), typeof(double), typeof(WaterProgress),
                new FrameworkPropertyMetadata(0.0000000000001d, new PropertyChangedCallback(OnProgressChanged)));

        public double ProgressValue
        {
            get { return (double)GetValue(ProgressValueProperty); }
            set
            {
                Console.WriteLine(value);
                SetValue(ProgressValueProperty, value);
            }
        }
        private static readonly double MaxTransform = 166.0;
        public WaterProgress()
        {
            InitializeComponent();
        }
        
        private static void OnProgressChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            double step = MaxTransform / 100;
            double y = MaxTransform - step * (double)e.NewValue;
            var waterProgress = d as WaterProgress;
            DoubleAnimation animation = new DoubleAnimation(y,TimeSpan.FromMilliseconds(200));
            waterProgress.ttg.BeginAnimation(TranslateTransform.YProperty, animation);
        }
    }
}