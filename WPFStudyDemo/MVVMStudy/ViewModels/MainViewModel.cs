using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMStudy.Base;
using MVVMStudy.Models;

namespace MVVMStudy.ViewModels
{
    public class MainViewModel
    {
       public MainModel Main { get; set; } = new MainModel();
       public BaseCommand DoubleClickCommand { get; set; }

       public MainViewModel()
       {
           DoubleClickCommand = new BaseCommand((obj) =>
           {
               Debug.WriteLine("double click");
           }, (obj) =>
           {
               return true;
           });
       }
    }
}
