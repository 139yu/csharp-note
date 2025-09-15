using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHControlLib
{
    // 双击生成事件
    [DefaultEvent("Click")]
    public partial class NaviButton : UserControl
    {
        public NaviButton()
        {
            InitializeComponent();
        }

        private bool _isSelected;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("是否选中")]
        public bool IsSelected
        {
            get { return _isSelected; }
            set 
            { 
                _isSelected = value;
                UpdateImage();
            }
        }

        private bool _isLeft;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("是否左边")]
        public bool IsLeft
        {
            get { return _isLeft; }
            set 
            { 
                _isLeft = value;
                UpdateImage();
            }
        }
        private string _titleName;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置按钮文本内容")]
        public string TitleName
        {
            get { return _titleName; }
            set 
            { 
                _titleName = value; 
                this.lbl_text.Text = value;
            }
        }
        public new EventHandler Click;


        private void UpdateImage()
        {
            if (IsLeft) 
            {
                this.BackgroundImage = IsSelected ? Properties.Resources.LeftSelected : Properties.Resources.LeftUnSelected;
            }else
            {
                this.BackgroundImage = IsSelected ? Properties.Resources.RightSelected : Properties.Resources.RightUnSelected;
            }
        }

        private void lbl_text_Click(object sender, EventArgs e)
        {
            this.Click?.Invoke(this, e);
        }
    }
}
