using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Nobody.DigitaPlatform.Models
{
    public class VariableModel : ObservableObject
    {
        public string DeviceNum { get; set; }
        // 唯一编码
        public string VarNum { get; set; }

        // 名称
        public string VarName { get; set; }

        // 地址
        public string VarAddress { get; set; }

        private DataTable dataTable = new DataTable();

        // 读取返回数据
        private object _value;

        public object Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;

                // foreach (var condition in AlarmConditions)
                // {
                //     bool res = false;
                //     string exp = value + condition.Condition + condition.AlarmValue;
                //     if (bool.TryParse(dataTable.Compute(exp, "").ToString(), out res) && res)
                //     {
                //         var alarmModel = CompareValue(condition.Condition, value);
                //         Messenger.Default.Send<DeviceAlarmModel>(new DeviceAlarmModel()
                //         {
                //             AlarmContent = alarmModel.AlarmMessage,
                //             AlarmNum = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                //             CNum = alarmModel.ConditionNum,
                //             VNum = alarmModel.VarNum,
                //             DNum = DeviceNum,
                //             DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                //             Level = 1,
                //             State = 0
                //         },"Alarm");
                //     }
                // }

                Set(ref _value, value);
            }
        }

        // 偏移量
        public double Offset { get; set; }

        // 系数
        public double Modulus { get; set; } = 1;
        public string VarType { get; set; }

        public VariableModel()
        {
            AddConditionCommand = new RelayCommand(DoAddConditionCommand);
            AddUnionConditionCommand = new RelayCommand(DoAddUnionConditionCommand);
            DelUnionConditionCommand = new RelayCommand<AlarmConditionModel>(DoDelUnionConditionCommand);
        }



        private ObservableCollection<AlarmConditionModel> _alarmConditions;

        public ObservableCollection<AlarmConditionModel> AlarmConditions
        {
            get
            {
                if (_alarmConditions == null)
                {
                    _alarmConditions = new ObservableCollection<AlarmConditionModel>();
                }

                return _alarmConditions;
            }
            set => Set(ref _alarmConditions, value);
        }

        private ObservableCollection<AlarmConditionModel> _unionConditions;
        public ObservableCollection<AlarmConditionModel> UnionConditions
        {
            get
            {
                if (_unionConditions == null)
                {
                    _unionConditions = new ObservableCollection<AlarmConditionModel>();
                }
                return _unionConditions;
            }
            set => Set(ref _unionConditions, value);
        }


        public RelayCommand AddConditionCommand { get; set; }
        private void DoAddConditionCommand()
        {
            AlarmConditions.Add(new AlarmConditionModel()
            {
                VarNum = this.VarNum,
                ConditionNum = "A" + DateTime.Now.ToString("yyyyMMddHHmmssFFF"),
                RemoveConditionCommand = new RelayCommand<object>(obj =>
                {
                    if (obj != null)
                    {
                        var model = obj as AlarmConditionModel;
                        AlarmConditions.Remove(model);
                    }
                })
            });
        }
        public RelayCommand AddUnionConditionCommand { get; }

        private void DoAddUnionConditionCommand()
        {
            UnionConditions.Add(new AlarmConditionModel()
            {
                VarNum = this.VarNum,
                ConditionNum = "U" + DateTime.Now.ToString("yyyyMMddHHmmssFFF"),
            });
        }

        private void DoDelUnionConditionCommand(AlarmConditionModel obj)
        {
            UnionConditions.Remove(obj);
        }
        public RelayCommand<AlarmConditionModel> DelUnionConditionCommand { get; }

        
        
    }
}