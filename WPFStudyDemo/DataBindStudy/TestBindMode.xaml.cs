using System.Windows;
using DataBindStudy.Models;

namespace DataBindStudy;

public partial class TestBindMode : Window
{
    public ViewModel02 ViewMode { get; set; } = new ViewModel02();
    public TestBindMode()
    {
        InitializeComponent();
        this.DataContext = ViewMode;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        this.twoWayText.Text = "";
        // 切换了数据绑定关系
        this.oneWayText.Text = "";
        ViewMode.Value02 = new Random().Next(1000).ToString();
    }
}