using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;

namespace Nobody.DigitaPlatform.Models
{
    public class ThumbModel
    {
        public string Header { get; set; }
        public List<ThumbItemModel> Children { get; set; } = new List<ThumbItemModel>();
    }

    public class ThumbItemModel
    {
        public string Header { get; set; }
        public string Icon { get; set; }
        public string TargetType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public RelayCommand<object> ThumbCommand { get; }

        public ThumbItemModel()
        {
            ThumbCommand = new RelayCommand<object>(DoThumbCommand);
        }

        private void DoThumbCommand(object obj)
        {
            DragDrop.DoDragDrop(obj as DependencyObject, this, DragDropEffects.Copy);
        }
    }
}
