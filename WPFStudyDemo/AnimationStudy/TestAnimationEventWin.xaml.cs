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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimationStudy
{
    /// <summary>
    /// TestAnimationEventWin.xaml 的交互逻辑
    /// </summary>
    public partial class TestAnimationEventWin : Window
    {
        private Storyboard moveStoryboard;
        public TestAnimationEventWin()
        {
            InitializeComponent();
            moveStoryboard = (Storyboard)FindResource("MoveAnimation");

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Start animation");
            moveStoryboard.Begin();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pause animation");
            moveStoryboard.Pause();
        }

        private void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Resume animation");
            moveStoryboard.Resume();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Stop animation");
            moveStoryboard.Stop();
        }

        private void SeekButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Stop animation");
            moveStoryboard.Seek(new TimeSpan(0,0,2));
        }
    }
}
