using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.Entities;
using Nobody.DigitaPlatform.Models;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {
        #region 系统基础配置

        public string SystemName { get; set; }
        public int MaxBufferSize { get; set; } = 0;
        public int MaxLogBufferSize { get; set; } = 0;
        public string LogPath { get; set; }

        #endregion

        public List<DeviceModel> DeviceList { get; set; }
        private List<SettingModel> _monitorList;

        public List<SettingModel> MonitorList
        {
            get
            {
                if (_monitorList == null)
                {
                    _monitorList = new List<SettingModel>();
                }

                return _monitorList;
            }
            set
            {
                Set(ref _monitorList, value);
            }
        } 
        public ObservableCollection<UserModel> UserList { get; set; }

        public List<UserTypeModel> UserTypeList { get; set; } =
            new List<UserTypeModel>()
            {
                new UserTypeModel(0, "操作员"),
                new UserTypeModel(1, "技术员"),
                new UserTypeModel(10, "信息管理员"),
            };

        public RelayCommand<UserModel> RemoveUserCommand { get; }
        public RelayCommand<UserModel> ResetPasswordCommand { get; }
        public RelayCommand AddUserCommand { get; }
        public RelayCommand SaveSettingCommand { get; }

        private ILocalDataAccess _dataAccess;

        public SettingViewModel(ILocalDataAccess dataAccess, MainViewModel mainViewModel)
        {
            _dataAccess = dataAccess;
            DeviceList = mainViewModel.DeviceList.Where(d => d.DeviceVariables.Count > 0).ToList();
            InitMonitorSettings();
            GetUserList();
            RemoveUserCommand = new RelayCommand<UserModel>(model =>
            {
                var username = model.Username;
                if (username.Equals("admin"))
                {
                    return;
                }

                UserList.Remove(model);
            });

            AddUserCommand = new RelayCommand(() =>
            {
                UserList.Add(new UserModel()
                {
                    DisplayGender = "男",
                    UserType = 0,
                    Username = "",
                    Password = "123456"
                });
            });
            SaveSettingCommand = new RelayCommand(DoSaveSettingCommand);


            InitPage();
        }

        private void DoSaveSettingCommand()
        {
            List<BaseInfoEntity> configs = new List<BaseInfoEntity>();
            configs.Add(new BaseInfoEntity()
            {
                BaseNum = "B001",
                Value = SystemName,
                type = "1"
            });
            configs.Add(new BaseInfoEntity()
            {
                BaseNum = "B002",
                Value = MaxBufferSize.ToString(),
                type = "1"
            });
            configs.Add(new BaseInfoEntity()
            {
                BaseNum = "B003",
                Value = MaxLogBufferSize.ToString(),
                type = "1"
            });
            configs.Add(new BaseInfoEntity()
            {
                BaseNum = "B004",
                Value = LogPath,
                type = "1"
            });
            configs.AddRange(MonitorList.Select(m => new BaseInfoEntity()
            {
                BaseNum = m.BaseNum,
                DeviceNum = m.DeviceNum,
                Description = m.Desc,
                Header = m.Header,
                type = "2",
                VariableNum = m.VariableNum
            }));
            List<UserEntity> users = new List<UserEntity>(UserList.Select(u => new UserEntity()
            {
                Username = u.Username, UserType = u.UserType.ToString(), RealName = u.RealName, Password = u.Password
            }));
            _dataAccess.SaveSettings(configs, users);
        }

        private void GetUserList()
        {
            UserList = new ObservableCollection<UserModel>(_dataAccess
                .getUserList()
                .Select(u => new UserModel()
                {
                    UserType = int.Parse(u.UserType),
                    Username = u.Username,
                    Password = u.Password,
                    Gender = int.Parse(u.Gender),
                    PhoneNum = u.PhoneNum,
                    RealName = u.RealName
                }));
        }

        private void InitMonitorSettings()
        {
            MonitorList.Add(new SettingModel()
            {
                BaseNum = "B005",
                Header = "监测温度",
                Desc = "配置监控页面中温度数据的关联设备及相关信息",
                DeviceList = DeviceList
            });
            MonitorList.Add(new SettingModel()
            {
                BaseNum = "B006",
                Header = "监测湿度",
                Desc = "配置监控页面中湿度数据的关联设备及相关信息",
                DeviceList = DeviceList
            });
            MonitorList.Add(new SettingModel()
            {
                BaseNum = "B007",
                Header = "监测PM2.5",
                Desc = "配置监控页面中PM2.5数据的关联设备及相关信息",
                DeviceList = DeviceList
            });
            MonitorList.Add(new SettingModel()
            {
                BaseNum = "B008",
                Header = "监测母管压力",
                Desc = "配置监控页面中母管压力数据的关联设备及相关信息",
                DeviceList = DeviceList
            });
            MonitorList.Add(new SettingModel()
            {
                BaseNum = "B009",
                Header = "监测母管瞬时流量",
                Desc = "配置监控页面中母管瞬时流量数据的关联设备及相关信息",
                DeviceList = DeviceList
            });
        }


        private void InitPage()
        {
            List<BaseInfoEntity> baseInfos = _dataAccess.GetBaseInfos();
            this.MonitorList = baseInfos
                .Where(b => int.Parse(b.BaseNum.Substring(b.BaseNum.Length - 1)) > 4)
                .Select(b => new SettingModel()
                {
                    BaseNum = b.BaseNum, Desc = b.Description, DeviceList = DeviceList, Header = b.Header,
                    DeviceNum = b.DeviceNum,
                    VariableNum = b.VariableNum
                }).ToList();
            SystemName = baseInfos[0].Value;
            MaxBufferSize = string.IsNullOrEmpty(baseInfos[1].Value) ? 0 : int.Parse(baseInfos[1].Value);
            MaxLogBufferSize = string.IsNullOrEmpty(baseInfos[2].Value) ? 0 : int.Parse(baseInfos[2].Value);
            LogPath = baseInfos[3].Value;
        }
    }
}