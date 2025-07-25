using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.DataAccess.Impl;
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
            SimpleIoc.Default.Register<ILocalDataAccess, LocalDataAccess>();
        }

        public LoginViewModel LoginViewModel => SimpleIoc.Default.GetInstance<LoginViewModel>();

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
        public EditComponentViewModel EditComponentViewModel => SimpleIoc.Default.GetInstance<EditComponentViewModel>();
    }
}