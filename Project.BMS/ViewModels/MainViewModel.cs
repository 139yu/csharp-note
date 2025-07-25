using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using Project.BMS.Base;

namespace Project.BMS.ViewModels;

public class MainViewModel : NotifyBase
{
    private static readonly string PageNamesapce = "Project.BMS.Views.Pages.";
    private object _currentPage;
    private Dictionary<string, object> _pageMaps = new Dictionary<string, object>();

    public object CurrentPage
    {
        get => _currentPage;
        set => SetField(ref _currentPage, value);
    }

    public BaseCommand NavCommand { get; set; }
    public BaseCommand CloseCommand { get; set; }

    public MainViewModel()
    {
        GetPageObject("MonitorPage");
        NavCommand = new BaseCommand(pageName => GetPageObject(pageName.ToString()));
        CloseCommand = new BaseCommand((obj) => { Application.Current.Shutdown(); });
        GenerateData();
    }

    private void GetPageObject(string pageName)
    {
        string fullname = PageNamesapce + pageName;
        if (!_pageMaps.ContainsKey(fullname))
        {
            Type? type = Assembly.GetExecutingAssembly().GetType(fullname);
            var instance = (FrameworkElement)Activator.CreateInstance(type);
            _pageMaps.Add(fullname, instance);
        }

        CurrentPage = _pageMaps[fullname];
    }

    private void GenerateData()
    {
        for (int i = 0; i < 30; i++)
        {
            BatteryItems.Add($"{i}");
        }

        for (int i = 0; i < 10; i++)
        {
            BatteryMessages.Add($"{i}");
        }

        Task.Run(async () =>
        {
            var item_1 = new ObservableCollection<double>();
            var item_2 = new ObservableCollection<double>();
            ChartValues.Add(item_1);
            ChartValues.Add(item_2);
            var random = new Random(1000);
            while (true)
            {
                await Task.Delay(1000);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    item_2.Add(random.NextDouble() * random.Next(1, 1000) + 1);
                    item_1.Add(random.NextDouble() * random.Next(1, 1000) + 1);
                });

            }
        });
    }
    /*
     * 将子页面数据放在MainViewModel中，即使子页面被销毁了，该数据也不会被销毁
     *
     */

    #region 趋势图标数据

    private ObservableCollection<ObservableCollection<double>> _chartValues;

    public ObservableCollection<ObservableCollection<double>> ChartValues
    {
        get
        {
            if (_chartValues == null)
            {
                _chartValues = new ObservableCollection<ObservableCollection<double>>();
            }

            return _chartValues;
        }
        set => SetField(ref _chartValues, value);
    }

    #endregion

    #region MonitorPage数据

    private ObservableCollection<string> _batteryItems;

    public ObservableCollection<string> BatteryItems
    {
        get
        {
            if (_batteryItems == null)
            {
                _batteryItems = new ObservableCollection<string>();
            }

            return _batteryItems;
        }
        set => SetField(ref _batteryItems, value);
    }

    private ObservableCollection<string> _batteryMessages;

    public ObservableCollection<string> BatteryMessages
    {
        get
        {
            if (_batteryMessages == null)
            {
                _batteryMessages = new ObservableCollection<string>();
            }

            return _batteryMessages;
        }
        set => SetField(ref _batteryMessages, value, nameof(BatteryMessages));
    }

    #endregion
}