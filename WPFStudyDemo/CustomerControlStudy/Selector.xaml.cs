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
using System.Windows.Shapes;

namespace CustomerControlStudy
{
    /// <summary>
    /// Selector.xaml 的交互逻辑
    /// </summary>
    public partial class Selector : Window
    {
        public Selector()
        {
            InitializeComponent();
            DataContext = this;
        }

        public List<string> Items { get; set; } =
            new List<string>()
            {
                "111", "222", "333", "444", "555", "666"
            };
    }
}