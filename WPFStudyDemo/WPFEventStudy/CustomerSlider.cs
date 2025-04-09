using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFEventStudy
{
    public class CustomerSlider : Slider
    {


        public static readonly RoutedEvent ValueChangedEvent = EventManager
            .RegisterRoutedEvent(
                "ValueChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<double>),
                typeof(CustomerSlider));

        public event RoutedPropertyChangedEventHandler<double> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            RoutedPropertyChangedEventArgs<double> e =
                new RoutedPropertyChangedEventArgs<double>(oldValue, newValue,ValueChangedEvent);
            RaiseEvent(e);
        }

    }
}
