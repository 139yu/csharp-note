using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Nobody.DigitaPlatform.Models
{
    public class AlarmConditionModel: ObservableObject
    {
        public string ConditionNum { get; set; }

        public string VarNum { get; set; }
        public string Condition { get; set; }
        public string AlarmValue { get; set; }
        public string AlarmMessage { get; set; }

        public AlarmConditionModel()
        {
            AddUnionDeviceCommand = new RelayCommand(DoAddUnionDeviceCommand);
        }

        public ObservableCollection<UnionDeviceModel> _unionDevices;

        public ObservableCollection<UnionDeviceModel> UnionDevices
        {
            get
            {
                if (_unionDevices == null)
                {
                    _unionDevices = new ObservableCollection<UnionDeviceModel>();
                }

                return _unionDevices;
            }
            set => Set(ref _unionDevices, value);
        }
        public RelayCommand<object> RemoveConditionCommand { get; set; }

        public RelayCommand AddUnionDeviceCommand { get; }
        private void DoAddUnionDeviceCommand()
        {
            UnionDevices.Add(new UnionDeviceModel()
            {
                CNum = this.ConditionNum,
                UNum = "U" + DateTime.Now.ToString("yyyyMMddHHmmssFFF")
            });
        }
    }
}