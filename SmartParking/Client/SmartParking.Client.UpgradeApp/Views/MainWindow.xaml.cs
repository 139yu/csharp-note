using System;
using System.Collections.Generic;
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
using SmartParking.Client.UpgradeApp.ViewModels;

namespace SmartParking.Client.UpgradeApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        public MainWindow(string tempfile)
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel(tempfile);
            viewModel.DownloadAllSuccessHandler += HandlerDownloadSuccess;
            this.DataContext = viewModel;
        }

        private void HandlerDownloadSuccess(object sender, EventArgs e)
        {
            FinishView finishView = new FinishView();
            finishView.ShowDialog();
            viewModel.DownloadAllSuccessHandler -= HandlerDownloadSuccess;
        }
    }
}