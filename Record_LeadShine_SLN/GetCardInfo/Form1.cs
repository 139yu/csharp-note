using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csLTDMC;

namespace GetCardInfo
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void init_card_Click(object sender, EventArgs e)
        {
            short res = 0;
            res = LTDMC.dmc_board_init();
            if (res <= 0 || res >8)
            {
                error_info.Text = "初始化轴卡失败";
                return;
            }
            // 初始化成功卡数
            ushort cardNum = 0;
            // 固件类型数组，CardTypeList 类型为十六进制
            uint[] cardTypeList = new uint[8];
            // 控制卡ID数组
            ushort[] cardList = new ushort[8];
            res = LTDMC.dmc_get_CardInfList(ref cardNum, cardTypeList, cardList);
            if (res == 0)
            {
                card_no.Text = cardList[0].ToString();
                version.Text = Convert.ToString(cardTypeList[0], 16);
            }

            uint totalAxis = 0;
            res = LTDMC.dmc_get_total_axes(cardList[0], ref totalAxis);
            axis.Text = totalAxis.ToString();
        }
    }
}
