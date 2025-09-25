using Nobody.MTHModels;
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
    public partial class RecipeControl : UserControl
    {
        public RecipeControl()
        {
            InitializeComponent();
        }
        private string siteName = "1#站点";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("站点名称")]
        public string SiteName
        {
            get { return siteName; }
            set { siteName = value;
                this.lbl_title.TitleName = siteName;
                this.textSetEx1.TitleName = siteName + "温度高限";
                this.textSetEx2.TitleName = siteName + "温度低限";
                this.textSetEx3.TitleName = siteName + "湿度高限";
                this.textSetEx4.TitleName = siteName + "湿度低限";
                this.Invalidate();
            }
        }
        private RecipeParam recipeParam = new RecipeParam();
        public RecipeParam RecipeParam
        {
            get
            {
                recipeParam = GetRecipeParam();
                return recipeParam;
            }
            set
            {
                recipeParam = value;
                SetRecipeParam(recipeParam);
            }
        }

        public RecipeParam GetRecipeParam()
        {
            return new RecipeParam()
            {
                TempHigh = this.textSetEx1.CurrentValue,
                TempLow = this.textSetEx2.CurrentValue,
                HumidityHigh = this.textSetEx3.CurrentValue,
                HumidityLow = this.textSetEx4.CurrentValue,
                HumidityAlarmEnable = this.checkBoxEx1.Checked,
                TempAlarmEnable = this.checkBoxEx2.Checked,
            };
        }
        public void SetRecipeParam(RecipeParam recipeParam)
        {
            this.textSetEx1.CurrentValue = recipeParam.TempHigh;
            this.textSetEx2.CurrentValue = recipeParam.TempLow;
            this.textSetEx3.CurrentValue = recipeParam.HumidityHigh;
            this.textSetEx4.CurrentValue = recipeParam.HumidityLow;
            this.checkBoxEx1.Checked = recipeParam.TempAlarmEnable;
            this.checkBoxEx2.Checked = recipeParam.HumidityAlarmEnable;
        }
    }
}
