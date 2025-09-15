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
    public partial class Title : UserControl
    {
        public Title()
        {
            InitializeComponent();
        }

        private string titleName = "标题";
        [Browsable(true)]
        [Description("标题")]
        [Category("自定义属性")]
        public string TitleName
        {
            get { return titleName ; }
            set 
            {
                titleName = value;
                this.lbl_title.Text = titleName;
            }
        }

    }
}
