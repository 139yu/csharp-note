using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using Nobody.DigitaPlatform.Components;

namespace Nobody.DigitaPlatform.Common.Converter
{
    public class DeviceConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value.ToString().Equals("HL"))
            {
                return new Line()
                {
                    Width = 2000,
                    StrokeThickness = 1,
                    Stroke = Brushes.Red,
                    StrokeDashArray = new DoubleCollection { 3.0, 3.0 },
                    X1 = 0,
                    Y1 = 0,
                    X2 = 2000,
                    Y2 = 0
                };
            }
            else if (value.ToString().Equals("VL"))
            {
                return new Line()
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new DoubleCollection { 3.0, 3.0 },
                    Height = 2000,
                    X1 = 0,
                    Y1 = 0,
                    X2 = 0,
                    Stroke = Brushes.Red,
                    Y2 = 2000
                };
            }

            string ns = "Nobody.DigitaPlatform.Components";
            var assembly = Assembly.Load(ns);
            var type = assembly.GetType($"{ns}.{value.ToString()}");
            if (type == null)
            {
                throw new ArgumentException($"Type '{value}' not found in assembly '{assembly.FullName}'.");
            }

            var c = Activator.CreateInstance(type);
            if (value.ToString().Equals("WidthRule") || value.ToString().Equals("HeightRule"))
            {
                return c;
            }

            var instance = c as BaseComponent;

            Binding binding = new Binding();
            binding.Path = new PropertyPath("DeleteCommand");
            instance.SetBinding(BaseComponent.DeleteCommandProperty, binding);
            // 没有设置Path，相当于<BaseComponent DeleteParameter="{Binding}"/>
            binding = new Binding();
            instance.SetBinding(BaseComponent.DeleteParameterProperty, binding);
            binding = new Binding();
            binding.Path = new PropertyPath("IsSelected");
            instance.SetBinding(BaseComponent.IsSelectedProperty, binding);

            /*binding = new Binding();
            binding.Path = new PropertyPath("Width");
            binding.Mode = BindingMode.TwoWay;
            instance.SetBinding(BaseComponent.ShowWidthProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("Height");
            binding.Mode = BindingMode.TwoWay;
            instance.SetBinding(BaseComponent.ShowHeightProperty, binding);*/

            binding = new Binding();
            binding.Path = new PropertyPath("Rotate");
            binding.Mode = BindingMode.TwoWay;
            instance.SetBinding(BaseComponent.RotateAngleProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("FlowDirection");
            binding.Mode = BindingMode.TwoWay;
            instance.SetBinding(BaseComponent.FlowDirectionProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("ResizeDownCommand");
            instance.SetBinding(BaseComponent.ResizeDownCommandProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("ResizeUpCommand");
            instance.SetBinding(BaseComponent.ResizeUpCommandProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("ResizeMoveCommand");
            instance.SetBinding(BaseComponent.ResizeMoveCommandProperty, binding);


            binding = new Binding();
            binding.Path = new PropertyPath("IsWarning");
            instance.SetBinding(BaseComponent.IsWarningProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("WarningMessage");
            instance.SetBinding(BaseComponent.WarningMessageProperty, binding);
            return instance;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}