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

namespace NegAndPosMove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ushort _cardNum = 0;
        private uint[] _axis = new uint[8];
        private bool _initFlag = false;

        private void Btn_Init_Click(object sender, EventArgs e)
        {
            init_card.Enabled = false;
            init_card.Enabled = true;
            short res = 0;
            res = LTDMC.dmc_board_init();
            if (res <= 0 || res > 8)
            {
                errorLabel.Text = $"初始化轴卡失败！错误代码：{res}";
                return;
            }

            ushort cardNum = 0;
            uint[] cardTypeList = new uint[8];
            // 控制卡ID数组
            ushort[] cardList = new ushort[8];
            res = LTDMC.dmc_get_CardInfList(ref cardNum, cardTypeList, cardList);
            if (res == 0)
            {
                _cardNum = cardList[0];
            }

            uint totalAxis = 0;
            res = LTDMC.dmc_get_total_axes(_cardNum, ref totalAxis);
            if (res != 0)
            {
                errorLabel.Text = "获取轴数量失败！";
                return;
            }

            comboBox_axis.Items.Clear();
            for (uint i = 0; i < totalAxis; i++)
            {
                _axis[i] = i;
                comboBox_axis.Items.Add($"{i}-Axis");
            }

            comboBox_axis.SelectedIndex = 0;
            _initFlag = true;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            if (!_initFlag) return;
            short res = LTDMC.dmc_board_close();
            if (res == 0)
            {
                _initFlag = false;
                init_card.Enabled = true;
                close_card.Enabled = false;
            }
        }

        private void SetMoveParameters()
        {
            if (!_initFlag) return;
            // 起始速度
            double startSpeed = Decimal.ToDouble(start_speed.Value);
            // 停止速度
            double stopSpeed = Decimal.ToDouble(stop_speed.Value);
            // 运行速度
            double runSpeed = Decimal.ToDouble(run_speed.Value);
            // s段时间
            double sTime = Decimal.ToDouble(s_time.Value);
            // 加速时间
            double incTime = Decimal.ToDouble(inc_time.Value);
            // 减速时间
            double decTime = Decimal.ToDouble(dec_time.Value);

            ushort axis = (ushort)_axis[comboBox_axis.SelectedIndex];
            // 运动位置
            double runPos = Decimal.ToDouble(run_pos.Value);

            // 单轴运动速度曲线设置
            short res = LTDMC.dmc_set_profile(_cardNum, axis, startSpeed, runSpeed, incTime, decTime, stopSpeed);
            if (res != 0)
            {
                errorLabel.Text = $"轴{axis}速度曲线设置失败！错误代码：{res}";
            }

            // 设置单轴速度曲线 S 段参数值
            res = LTDMC.dmc_set_s_profile(_cardNum, axis, 0, sTime);
            if (res != 0)
            {
                errorLabel.Text = $"轴{axis} S 段参数设置失败！错误代码：{res}";
            }

            //设置减速停止时间
            res = LTDMC.dmc_set_dec_stop_time(_cardNum, axis, decTime);
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (!_initFlag) return;
            SetMoveParameters();
            int runPos = Decimal.ToInt32(run_pos.Value);
            ushort posiMode = (ushort)(radioButton1.Checked ? 0 : 1);
            short res = LTDMC.dmc_pmove(_cardNum, (ushort)_axis[comboBox_axis.SelectedIndex], runPos, posiMode);
        }
    }
}