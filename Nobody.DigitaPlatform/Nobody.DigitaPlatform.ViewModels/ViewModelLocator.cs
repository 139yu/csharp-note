using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.DataAccess.Impl;
using Nobody.DigitaPlatform.Entities;
using Nobody.DigitaPlatform.ViewModels;

namespace Nobody.DigitaPlatform
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EditComponentViewModel>();
            SimpleIoc.Default.Register<AlarmConditionViewModel>();
            SimpleIoc.Default.Register<TrendViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
            SimpleIoc.Default.Register<AlarmViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
            SimpleIoc.Default.Register<ILocalDataAccess, LocalDataAccess>();
        }

        public LoginViewModel LoginViewModel => SimpleIoc.Default.GetInstance<LoginViewModel>();
        public SettingViewModel SettingViewModel => SimpleIoc.Default.GetInstance<SettingViewModel>();
        public AlarmConditionViewModel AlarmConditionViewModel => SimpleIoc.Default.GetInstance<AlarmConditionViewModel>();

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
        public ReportViewModel ReportViewModel => SimpleIoc.Default.GetInstance<ReportViewModel>();
        public AlarmViewModel AlarmViewModel => SimpleIoc.Default.GetInstance<AlarmViewModel>();
        public TrendViewModel TrendViewModel => SimpleIoc.Default.GetInstance<TrendViewModel>();
        public EditComponentViewModel EditComponentViewModel => SimpleIoc.Default.GetInstance<EditComponentViewModel>();
        private static List<RecordWriteEntity> Records = new List<RecordWriteEntity>();

        public static void AddRecord(RecordWriteEntity entity)
        {
            Records.Add(entity);
            if (Records.Count >= 100)
            {
                ServiceLocator.Current.GetInstance<ILocalDataAccess>().SaveRecord(Records);
                Records.Clear();
            }
        }
        public static void Cleanup<T>() where T : ViewModelBase
        {
            if (SimpleIoc.Default.IsRegistered<T>() && SimpleIoc.Default.ContainsCreated<T>())
            {
                var instances = SimpleIoc.Default.GetAllCreatedInstances<T>();
                foreach (var instance in instances)
                {
                    instance.Cleanup();
                }
                SimpleIoc.Default.Unregister<T>();
                SimpleIoc.Default.Register<T>();
            }
        }
    }
}