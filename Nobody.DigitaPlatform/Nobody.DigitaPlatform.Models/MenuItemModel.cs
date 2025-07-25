using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.Models
{
    public class MenuItemModel
    {
        public bool IsSelected { get; set; }
        public int Key { get; set; }
        public string MenuName { get; set; }
        public string TargetView { get; set; }
        public string MenuIcon { get; set; }
    }
}