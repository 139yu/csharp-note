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
    }
}