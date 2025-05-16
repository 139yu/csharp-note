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
    /// Input.xaml 的交互逻辑
    /// </summary>
    public partial class Input : UserControl
    {
        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty
            .Register(nameof(PlaceHolder), typeof(string), typeof(Input), new FrameworkPropertyMetadata("请输入"));
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(Input),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty
            .Register(nameof(BorderThickness),typeof(Thickness),typeof(Input),
                new FrameworkPropertyMetadata(default(Thickness), new PropertyChangedCallback(OnBorderThicknessChanged)));
        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty
            .Register(nameof(BorderBrush), typeof(Brush),typeof(Input),new FrameworkPropertyMetadata(default(Brush),new PropertyChangedCallback(OnBorderBrushChanged)));
        public static readonly DependencyProperty IconProperty = DependencyProperty
            .Register(nameof(Icon),typeof(string),typeof(Input));
        public static readonly DependencyProperty IconFontFontFamilyProperty = DependencyProperty
            .Register(nameof(IconFontFontFamilyProperty), typeof(FontFamily), typeof(Input), new PropertyMetadata(default(FontFamily)));
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty
            .Register(nameof(CornerRadius), typeof(CornerRadius), typeof(Input), new PropertyMetadata(default(CornerRadius)));
        public Input()
        {
            InitializeComponent();
            innerTextBox.SetBinding(TextBox.TextProperty, new Binding(nameof(Text)) { Source = this ,Mode = BindingMode.TwoWay});
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)this.GetValue(CornerRadiusProperty);
            set => this.SetValue(CornerRadiusProperty, value);
        }
        public string Icon
        {
            get => (string)this.GetValue(IconProperty);
            set => this.SetValue(IconProperty,value);
        }

        public FontFamily IconFontFamily
        {
            get => (FontFamily)this.GetValue(IconFontFontFamilyProperty);
            set => this.SetValue(IconFontFontFamilyProperty, value);
        }
        public string PlaceHolder
        {
            get => (string)this.GetValue(PlaceHolderProperty);

            set => this.SetValue(PlaceHolderProperty, value);
        }

        public string Text
        {
            get => (string)this.GetValue(TextProperty);
            set => this.SetValue(TextProperty, value);
        }

        public Thickness BorderThickness
        {
            get => (Thickness)this.GetValue(BorderThicknessProperty);
            set => this.SetValue(BorderThicknessProperty,value);
        }

        public Brush BorderBrush
        {
            get => (Brush)this.GetValue(BorderBrushProperty);
            set => this.SetValue(BorderBrushProperty, value);
        }

        private static void OnBorderThicknessChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is Input input && input.innerTextBox != null)
            {
                input.innerTextBox.BorderThickness = (Thickness)e.NewValue;
            }
        }

        private static void OnBorderBrushChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is Input input && input.innerTextBox != null)
            {
                input.innerTextBox.BorderBrush = (Brush)e.NewValue;
            }
        }
    }
}
