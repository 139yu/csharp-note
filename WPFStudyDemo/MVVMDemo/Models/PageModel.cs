using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMDemo.Models
{
    public class PageModel
    {
        public string PageTitle { get; set; }
        public Window CurrentPage { get; set; }
        public MainMenu CheckedMenu { get; set; }
    }
}
