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

namespace Nobody.DigitaPlatform.Components
{
    /// <summary>
    /// HorizontalPipeline.xaml 的交互逻辑
    /// </summary>
    public partial class HorizontalPipeline : BaseComponent
    {
        public HorizontalPipeline()
        {
            InitializeComponent();
            //目标控件  要切换到的状态名称 是否使用过渡动画
            VisualStateManager.GoToState(this, "WEFlowState", false);
        }
    }
}
