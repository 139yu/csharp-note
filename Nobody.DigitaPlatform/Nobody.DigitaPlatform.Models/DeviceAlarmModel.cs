using GalaSoft.MvvmLight.Command;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.DataAccess.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Nobody.DigitaPlatform.Common.Attributes;

namespace Nobody.DigitaPlatform.Models
{
    public class DeviceAlarmModel: ObservableObject
    {
        [ExcelColumn("序号",0)]
        public int Index { get; set; }
        public string AlarmNum { get; set; }
        public string CNum { get; set; }
        public string DNum { get; set; }
        public string VNum { get; set; }
        [ExcelColumn("报警变量",20)]
        public string VarName { get; set; }
        [ExcelColumn("报警设备", 10)]
        public string DeviceName { get; set; }
        [ExcelColumn("报警信息", 30)]
        public string AlarmContent { get; set; }
        [ExcelColumn("报警值", 21)]
        public string AlarmValue { get; set; }
        [ExcelColumn("报警时间", 40)]
        public string DateTime { get; set; }
        [ExcelColumn("报警登记", 42)]
        public int Level { get; set; }
        private int _state;

        public int State
        {
            get => _state;
            set
            {
                Set(ref _state, value);
                if (_state == 0)
                {
                    StateName = "待处理";
                }
                else if (_state == 1)
                {
                    StateName = "已处理";
                }
            }
        }

        private string _stateName;

        [ExcelColumn("报警状态", 52)]
        public string StateName
        {
            get => _stateName;
            set => Set(ref _stateName, value);
        }
        public string UserId { get; set; }
        [ExcelColumn("处理用户", 52)]
        public string UserName { get; set; }
        [ExcelColumn("处理时间", 60)]
        public string SolveTime { get; set; }
        private ILocalDataAccess _dataAccess;

        public DeviceAlarmModel()
        {
            
        }
        public DeviceAlarmModel(ILocalDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            CancelAlarmCommand = new RelayCommand(DoCancelAlarmCommand,DoCanCancelAlarm);
        }

        private bool DoCanCancelAlarm()
        {
            return this.State == 0;
        }

        public RelayCommand CancelAlarmCommand { get; set; }

        private void DoCancelAlarmCommand()
        {
            this.State = 1;

            CancelAlarmCommand.RaiseCanExecuteChanged();
            this.SolveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _dataAccess.UpdateAlarmState(AlarmNum, this.SolveTime);

            Messenger.Default.Send(this.DNum, "CancelAlarm");
        }
    }
}