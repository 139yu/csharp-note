using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nobody.DigitaPlatform.Entities;

namespace Nobody.DigitaPlatform.DataAccess
{
    public interface ILocalDataAccess
    {
        DataTable Login(string username, string password);
        int SaveDevices(List<DeviceEntity> deviceList);
        List<DeviceEntity> GetDeviceList();

        List<ThumbEntity> GetThumbList();

        List<PropertyEntity> GetPropertyList();

        int SaveTrend(List<TrendEntity> trneds);
        List<TrendEntity> GetTrends();
        int SaveAlarmMessage(AlarmEntity alarm);

        List<AlarmEntity> GetAlarmList(string condition);
        int UpdateAlarmState(string alarmNum, string solveTime);

        List<RecordReadEntity> GetRecords();
        int SaveRecord(List<RecordWriteEntity> records);
        
        List<UserEntity> getUserList();
        void SaveSettings(List<BaseInfoEntity> configs, List<UserEntity> users);
        List<BaseInfoEntity> GetBaseInfos();
    }
}