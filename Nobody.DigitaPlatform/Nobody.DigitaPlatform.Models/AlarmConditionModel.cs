using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace Nobody.DigitaPlatform.Models
{
    public class AlarmConditionModel
    {
        public string ConditionNum { get; set; }

        public string VarNum { get; set; }
        public string Condition { get; set; }
        public string AlarmValue { get; set; }
        public string AlarmMessage { get; set; }

        public RelayCommand<object> RemoveConditionCommand { get; set; }
    }
}