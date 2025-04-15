using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;

namespace Mvvmlight.Object.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<string>(this, ConsumerMsg);
            Messenger.Default.Register<NotificationMessage>(this,ConsumerMsg);
            Messenger.Default.Register<NotificationMessageAction<string>>(this,ConsumerActionMsg);
        }

        private void ConsumerMsg(string msg)
        {
            Debug.WriteLine(msg);
        }
        
        private void ConsumerMsg(NotificationMessage msg)
        {
            Debug.WriteLine(msg.Notification);
        }
        
        private void ConsumerActionMsg(NotificationMessageAction<string> action)
        {
            // 执行回调，传参给消息发送者
            action.Execute(111);
        }
    }
}
