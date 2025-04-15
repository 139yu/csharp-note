using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace CustomerControlStudy
{
    public class Switch: ToggleButton
    {
        static Switch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Switch),new FrameworkPropertyMetadata(typeof(Switch)));
        }
    }
}
