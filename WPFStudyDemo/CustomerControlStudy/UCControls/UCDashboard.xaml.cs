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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerControlStudy.UCControls
{
    /// <summary>
    /// UCDashboard.xaml 的交互逻辑
    /// </summary>
    public partial class UCDashboard : UserControl
    {
        private static readonly double CircleAngle = 270;

        // 字体颜色
        public static readonly DependencyProperty FontColorProperty = DependencyProperty
            .Register("FontColor", typeof(Brush), typeof(UCDashboard)
                , new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White), OnPropertyChangedCallback));

        public static readonly DependencyProperty ValueProperty = DependencyProperty
            .Register(nameof(Value),
                typeof(int),
                typeof(UCDashboard), new FrameworkPropertyMetadata(0,OnPropertyChangedCallback));

        // 圆的半径
        public static readonly DependencyProperty RadiusProperty = DependencyProperty
            .Register(nameof(Radius), typeof(double), typeof(UCDashboard),
                new FrameworkPropertyMetadata(100d, OnPropertyChangedCallback));

        // 最小刻度
        public static readonly DependencyProperty MinimumProperty = DependencyProperty
            .Register(nameof(Minimum), typeof(int), typeof(UCDashboard),
                new FrameworkPropertyMetadata(0, OnPropertyChangedCallback));

        // 最大刻度
        public static readonly DependencyProperty MaximumProperty = DependencyProperty
            .Register(nameof(Maximum), typeof(int), typeof(UCDashboard),
                new FrameworkPropertyMetadata(100, OnPropertyChangedCallback));

        //最大刻度步长
        public static readonly DependencyProperty IntervalProperty = DependencyProperty
            .Register(nameof(Interval), typeof(int), typeof(UCDashboard),
                new FrameworkPropertyMetadata(5, OnPropertyChangedCallback));

        public UCDashboard()
        {
            InitializeComponent();
            SizeChanged += UCDashboard_SizeChanged;
            Refresh();
        }

        private void UCDashboard_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Refresh();
        }

        public Brush FontColor
        {
            get => (Brush)GetValue(FontColorProperty);
            set => SetValue(FontColorProperty, value);
        }

        public int Value
        {
            get => (int)this.GetValue(ValueProperty);
            set => this.SetValue(ValueProperty, value);
        }

        public double Radius
        {
            get => (double)this.GetValue(RadiusProperty);
            set
            {
                this.SetValue(RadiusProperty, value);
                Refresh();
            }
        }

        public int Minimum
        {
            get => (int)this.GetValue(MinimumProperty);
            set => this.SetValue(MinimumProperty, value);
        }

        public int Maximum
        {
            get => (int)this.GetValue(MaximumProperty);
            set => this.SetValue(MaximumProperty, value);
        }

        public int Interval
        {
            get => (int)this.GetValue(IntervalProperty);
            set => this.SetValue(IntervalProperty, value);
        }

        private static void OnPropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((UCDashboard)o).Refresh();
        }

        private void Refresh()
        {
            if (Maximum <= Minimum)
            {
                throw new ArgumentException("Maximum、Minimum参数异常");
            }

            double thickness = Radius / 2;
            double width = Radius * 2;
            double height = Radius * 2;
            this.border.Width = width;
            this.border.Height = height;
            this.border.CornerRadius = new CornerRadius(Radius);
            var geometryConverter = TypeDescriptor.GetConverter(typeof(Geometry));
            //仪表盘圆弧 "M4,100A96,96 270 1 1 100,296"
            
            int diff = Maximum - Minimum;
            this.plateCanvas.Children.Clear();
            // 仪表盘刻度
            // 每个小刻度间隔度数
            double minAngleStep = CircleAngle / diff;
            //每个大刻度间隔度数
            double maxAngleStep = CircleAngle / ((double)diff / Interval);
            var colorBrush = new SolidColorBrush();
            colorBrush.Color = Color.FromRgb(214, 171, 113);
            double interval = 0;
            // 小刻度
            for (int i = 0; i < diff; i++)
            {
                Line line = new Line();
                line.X1 = Radius - (Radius - 5) * Math.Cos(i * minAngleStep * Math.PI / 180);
                line.Y1 = Radius - (Radius - 5) * Math.Sin(i * minAngleStep * Math.PI / 180);
                line.X2 = Radius - (Radius - 10) * Math.Cos(i * minAngleStep * Math.PI / 180);
                line.Y2 = Radius - (Radius - 10) * Math.Sin(i * minAngleStep * Math.PI / 180);
                line.StrokeThickness = 2;
                line.Stroke = colorBrush;
                this.plateCanvas.Children.Add(line);
            }

            // 大刻度
            int label = 0;
            do
            {
                Line line = new Line();
                line.X1 = Radius - (Radius - 5) * Math.Cos(interval * Math.PI / 180);
                line.Y1 = Radius - (Radius - 5) * Math.Sin(interval * Math.PI / 180);
                line.X2 = Radius - (Radius - 15) * Math.Cos(interval * Math.PI / 180);
                line.Y2 = Radius - (Radius - 15) * Math.Sin(interval * Math.PI / 180);
                line.StrokeThickness = 3;
                line.Stroke = colorBrush;
                this.plateCanvas.Children.Add(line);
                // 添加文本
                TextBlock tb = new TextBlock();
                tb.Foreground = FontColor;
                tb.Text = label.ToString();
                tb.RenderTransformOrigin = new Point(0.5, 0.5);
                tb.RenderTransform = new RotateTransform(45);
                Canvas.SetLeft(tb, Radius - (Radius - 30) * Math.Cos(interval * Math.PI / 180) - 10);
                Canvas.SetTop(tb, Radius - (Radius - 30) * Math.Sin(interval * Math.PI / 180) - 8);
                this.plateCanvas.Children.Add(tb);
                label += Interval;
                interval += maxAngleStep;
            } while (interval <= CircleAngle);

            // 指针
            string pointerData =
                $"M{Radius},{Radius} {(Radius + 10) * Math.Cos(1.5 * Math.PI / 180)},{Radius - (Radius + 10) * Math.Sin(1.5 * Math.PI / 180)} {width - 55},{Radius} {(Radius + 10) * Math.Cos(-1.5 * Math.PI / 180)},{Radius - (Radius + 10) * Math.Sin(-1.5 * Math.PI / 180)}z";
            this.pointer.Data = (Geometry)geometryConverter.ConvertFrom(pointerData);
            this.pointer.Stroke = new SolidColorBrush(Colors.Bisque);
            double translateAngle = Value * minAngleStep;
            this.pointer.RenderTransform = new RotateTransform(translateAngle + 135);
            // 是否画大圆弧
            int largeAce = translateAngle > 180 ? 1 : 0;
            double startX = thickness / 2;
            double startY = Radius;
            double endX = Radius - (Radius - thickness / 2) * Math.Cos(translateAngle * Math.PI / 180);
            double endY = Radius - (Radius - thickness / 2) * Math.Sin(translateAngle * Math.PI / 180);
            string circleData = $"M{startX},{startY}A{Radius - thickness / 2},{Radius - thickness / 2} 0 {largeAce} 1 {endX},{endY}";
            this.circle.Data = (Geometry)geometryConverter.ConvertFrom(circleData);
            this.circle.StrokeThickness = thickness;
        }
    }
}