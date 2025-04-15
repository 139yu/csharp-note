using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;
using MVVMDemo.Base;
using MVVMDemo.Models;

namespace MVVMDemo.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public List<MainMenu> MenuList { get; set; }
        public UserModel CurrentUser { get; set; }
        public LogModel AppLog { get; set; }
        public RelayCommand SelectMenuCommand { get; set; }
        private MainMenu _checkMenu;

        public MainMenu CheckedMenu
        {
            get
            {
                return _checkMenu;
            }
            set
            {
                _checkMenu = value;
                OnPropertyChanged(nameof(CheckedMenu));
                ShowContent();
            }
        }
        private static readonly string Namespace = typeof(MainViewModel).Namespace;
        private Dictionary<string, Window> _windows = new Dictionary<string, Window>();
        public MainViewModel()
        {
            Initialized();
            SelectMenuCommand = new RelayCommand(SelectMenu, CanSelectMenu);
        }


        private void Initialized()
        {
            MenuList = new List<MainMenu>()
            {
                new MainMenu(){MenuIcon = "\ue657",TargetView = "DonutWindow",MenuTitle = "咖啡"},
                new MainMenu(){MenuIcon = "\ue658",TargetView = "",MenuTitle = "薯条"},
                new MainMenu(){MenuIcon = "\ue660",TargetView = "",MenuTitle = "爆米花"},
                new MainMenu(){MenuIcon = "\ue663",TargetView = "",MenuTitle = "天妇罗"},
                new MainMenu(){MenuIcon = "\ue689",TargetView = "",MenuTitle = "泡面"},
                new MainMenu(){MenuIcon = "\ue68d",TargetView = "",MenuTitle = "甜甜圈"},
            };
            CheckedMenu = MenuList[0];
            CurrentUser = new UserModel() { UserName = "JS", Avatar = "pack://application:,,,/MVVMDemo;component/Resources/tom.jpg" };
            AppLog = new LogModel() { LogTitle = "Nobody", LogUrl = "pack://application:,,,/MVVMDemo;component/Resources/tom.jpg" };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool CanSelectMenu(object? o)
        {
            return true;
        }

        private void SelectMenu(object? o)
        {
            if (o is MainMenu menu)
            {
                _checkMenu = menu;
            }
        }

        private void ShowContent()
        {
            var targetView = CheckedMenu.TargetView;
            if (targetView != null)
            {
                if (!_windows.ContainsKey(targetView))
                {
                    string fullname = Namespace + targetView;
                    var assembly = this.GetType().Assembly;
                    var targetType = assembly.GetType(fullname);
                    var window = (Window)Activator.CreateInstance(targetType);
                    
                }
                else
                {
                    _windows[targetView].ShowDialog();
                }
            }
            
        }
    }
}
