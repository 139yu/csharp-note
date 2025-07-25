using GalaSoft.MvvmLight;
using Nobody.DigitaPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight.CommandWpf;
using Nobody.DigitaPlatform.Common;
using Nobody.DigitaPlatform.DataAccess;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public UserModel CurrentUser { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }

        #region Command Prop

        public RelayCommand<object> SwitchPageCommand { get; }
        public RelayCommand EditComponentCommand { get; }

        #endregion


        private ObservableCollection<RankingItemModel> _rankingItems;

        public ObservableCollection<RankingItemModel> RankingItems
        {
            get => _rankingItems;
            set => Set(ref _rankingItems, value);
        }

        private ObservableCollection<WaringItem> _waringItems;

        public ObservableCollection<WaringItem> WaringItems
        {
            get => _waringItems;
            set => Set(ref _waringItems, value);
        }

        private object _contentView;

        public object ContentView
        {
            get => _contentView;
            set => Set(ref _contentView, value);
        }

        private List<DeviceModel> _deviceList;

        public List<DeviceModel> DeviceList
        {
            get => _deviceList;
            set => Set(ref _deviceList, value);
        }

        private ILocalDataAccess _dataAccess;

        public MainViewModel(ILocalDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            GenerateData();
            SwitchPageCommand = new RelayCommand<object>(DoSwitchPageCommand);
            EditComponentCommand = new RelayCommand(DoEditComponentCommand);
        }

        #region Do Command

        private void DoEditComponentCommand()
        {
            var result = ActionManager.ExecuteAndResult<bool>("ShowEditComponentView");
            if (result)
            {
                QueryDeviceList();
            }
        }

        private void DoSwitchPageCommand(object obj)
        {
            var menuModel = obj as MenuItemModel;
            if (ContentView != null)
            {
                var currentViewName = ContentView.GetType().Name;
                if (currentViewName.Equals(menuModel.TargetView))
                {
                    return;
                }
            }

            if (menuModel != null)
            {
                Type type = Assembly.Load("Nobody.DigitaPlatform.Views")
                    .GetType("Nobody.DigitaPlatform.Views.Pages." + menuModel.TargetView);
                ContentView = Activator.CreateInstance(type);
            }
        }

        #endregion


        #region Generate Data

        private void GenerateRankingItems()
        {
            RankingItems = new ObservableCollection<RankingItemModel>();
            string[] quality = new string[]
            {
                "车间-1", "车间-2", "车间-3", "车间-4",
                "车间-5"
            };
            RankingItems = new ObservableCollection<RankingItemModel>();
            Random random = new Random();
            foreach (var q in quality)
            {
                RankingItems.Add(new RankingItemModel()
                {
                    Label = q,
                    PlanValue = random.Next(100, 200),
                    ActualValue = random.Next(10, 150),
                });
            }
        }

        private void GenerateWaringItems()
        {
            string[] types = { "保养到期", "故障", "电量不足", "未知异常" };
            WaringItems = new ObservableCollection<WaringItem>();
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                WaringItems.Add(new WaringItem()
                {
                    DeviceName = $"PLT-{i + 1}",
                    Message = types[random.Next(4)],
                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
        }

        private void GenerateMenus()
        {
            MenuItems = new List<MenuItemModel>();
            MenuItems.Add(new MenuItemModel
            {
                IsSelected = true,
                MenuName = "监控",
                MenuIcon = "\ue61d",
                TargetView = "MonitorPage"
            });
            MenuItems.Add(new MenuItemModel
            {
                MenuName = "趋势",
                MenuIcon = "\ue63c",
                TargetView = "TrendPage"
            });
            MenuItems.Add(new MenuItemModel
            {
                MenuName = "报警",
                MenuIcon = "\ue65b",
                TargetView = "AlarmPage"
            });
            MenuItems.Add(new MenuItemModel
            {
                MenuName = "报表",
                MenuIcon = "\ue605",
                TargetView = "ReportPage"
            });
            MenuItems.Add(new MenuItemModel
            {
                MenuName = "配置",
                MenuIcon = "\ue630",
                TargetView = "SettingsPage"
            });
            DoSwitchPageCommand(MenuItems[0]);
        }

        private void QueryDeviceList()
        {
            var ds = _dataAccess.GetDeviceList();
            if (ds == null || ds.Count == 0) 
            {
                DeviceList = new List<DeviceModel>();
                return;
            }
            DeviceList = ds.Select(d =>
            {
                return new DeviceModel()
                {
                    DeviceNum = d.DeviceNum,
                    X = double.Parse(d.X),
                    Y = double.Parse(d.Y),
                    Z = int.Parse(d.Z),
                    Width = double.Parse(d.W),
                    Height = double.Parse(d.H),
                    DeviceType = d.TypeName
                };
            }).ToList();
        }

        private void GenerateData()
        {
            QueryDeviceList();
            GenerateMenus();
            GenerateRankingItems();
            GenerateWaringItems();
        }

        #endregion
    }
}