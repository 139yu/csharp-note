using GalaSoft.MvvmLight;
using Nobody.DigitaPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class AlarmConditionViewModel : ViewModelBase
    {
        public List<ConditionOperatorModel> Operators { get; set; } = new List<ConditionOperatorModel>();

        public AlarmConditionViewModel()
        {
            if (!IsInDesignMode)
            {
                // 只处理基本的逻辑运算     扩展：组件逻辑处理   &&   ||    ()
                Operators.Add(new ConditionOperatorModel() { Header = "大于", Value = ">" });
                Operators.Add(new ConditionOperatorModel() { Header = "小于", Value = "<" });
                Operators.Add(new ConditionOperatorModel() { Header = "等于", Value = "==" });
                Operators.Add(new ConditionOperatorModel() { Header = "大于等于", Value = ">=" });
                Operators.Add(new ConditionOperatorModel() { Header = "小于等于", Value = "<=" });
                Operators.Add(new ConditionOperatorModel() { Header = "不等于", Value = "!=" });
            }
        }
    }
}