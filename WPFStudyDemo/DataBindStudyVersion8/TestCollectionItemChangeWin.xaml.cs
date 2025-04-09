using System.Collections.ObjectModel;
using System.Windows;
using DataBindStudyVersion8.Models;

namespace DataBindStudyVersion8;

public partial class TestCollectionItemChangeWin : Window
{
    public ObservableCollection<ViewModel02> ListView02 { get; set; } =
        new ObservableCollection<ViewModel02>()
        {
            new ViewModel02() { Value02 = "001" },
            new ViewModel02() { Value02 = "002" },
            new ViewModel02() { Value02 = "003" },
            new ViewModel02() { Value02 = "004" },
        };

    public TestCollectionItemChangeWin()
    {
        InitializeComponent();
        this.DataContext = this;
        Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(2000);
                ListView02[1].Value02 = new Random().Next(1000000).ToString();
                // 切换到UI线程
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ListView02.Add(new ViewModel02());
                });
            }
        });
    }
}