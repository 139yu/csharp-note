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

namespace Nobody.DigitaPlatform.Components
{
    /// <summary>
    /// Meter.xaml 的交互逻辑
    /// </summary>
    public partial class Meter : UserControl
    {
        public Meter()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty
            .Register(nameof(Header), typeof(string), typeof(Meter), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty UnitProperty = DependencyProperty
            .Register(nameof(Unit), typeof(string), typeof(Meter), new FrameworkPropertyMetadata(default(string)));
        public static readonly DependencyProperty ValueProperty = DependencyProperty
            .Register(nameof(Value), typeof(double), typeof(Meter), new FrameworkPropertyMetadata(0.0));

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public string Unit
        {
            get => (string)GetValue(UnitProperty);
            set => SetValue(UnitProperty, value);
        }

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}
