using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using csLTDMC;
using DevExpress.Data.ODataLinq.Helpers;
using Timer = System.Windows.Forms.Timer;

namespace LeiSai3800Demo
{
    public partial class FrmMain : Form
    {
        private Motion _motion = new Motion();
        private Timer updateTimer;
        private Thread monitorThread;

        public FrmMain()
        {
            InitializeComponent();
            updateTimer = new Timer();
            updateTimer.Interval = 200;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
            monitorThread = new Thread(new ThreadStart(MonitorLimit));
            monitorThread.Start();
            this.FormClosing += FrmMain_FormClosing;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer.Stop();
            updateTimer.Dispose();
            monitorThread.Interrupt();
            if (!monitorThread.Join(1000))
            {
                monitorThread.Abort();
            }

            _motion?.CloseCard();

            monitorThread = null;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (_motion.InitStatus)
            {
                bool xStatus = _motion.IsMoving(XAxis);
                bool yStatus = _motion.IsMoving(YAxis);
                bool zStatus = _motion.IsMoving(ZAxis);
                x_status_label.Text = xStatus ? "运动" : "停止";
                y_status_label.Text = yStatus ? "运动" : "停止";
                z_status_label.Text = zStatus ? "运动" : "停止";

                var xSpeed = _motion.GetCurrentSpeed(XAxis);
                var ySpeed = _motion.GetCurrentSpeed(YAxis);
                var zSpeed = _motion.GetCurrentSpeed(ZAxis);
                x_speed_label.Text = xSpeed.ToString("F1");
                y_speed_label.Text = ySpeed.ToString("F1");
                z_speed_label.Text = zSpeed.ToString("F1");

                var xPos = _motion.GetPosition(XAxis);
                var yPos = _motion.GetPosition(YAxis);
                var zPos = _motion.GetPosition(ZAxis);
                x_pos_label.Text = xPos.ToString();
                y_pos_label.Text = yPos.ToString();
                z_pos_label.Text = zPos.ToString();
            }
        }

        private ushort XAxis = 0;
        private ushort YAxis = 1;
        private ushort ZAxis = 2;

        private void Btn_Jog_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is Button)) return;
            Button btn = sender as Button;
            var tag = btn.Tag.ToString();
            ushort axis = ushort.Parse(tag.Split(':')[0]);
            ushort direction = ushort.Parse(tag.Split(':')[1]);
            /*if (_setParamsFlag)
            {
                SetParams(axis);
                _setParamsFlag = true;
            }*/

            var result = _motion.VMove(axis, direction);
            if (!result.Status)
            {
                MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool _setParamsFlag = false;

        private void SetParams(ushort axis)
        {
            double startSpeed = decimal.ToDouble(start_speed.Value);
            double stopSpeed = decimal.ToDouble(stop_speed.Value);
            double maxSpeed = decimal.ToDouble(run_speed.Value);
            double sTime = decimal.ToDouble(s_time.Value);
            double incTime = decimal.ToDouble(inc_time.Value);
            double decTime = decimal.ToDouble(dec_time.Value);
            var result = _motion.SetMoveParameters(axis, startSpeed, maxSpeed, stopSpeed, incTime, sTime, decTime);
            if (!result.Status)
            {
                MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void SetParams2(ushort[] axisArr)
        {
            double startSpeed = decimal.ToDouble(start1_speed.Value);
            double stopSpeed = decimal.ToDouble(stop1_speed.Value);
            double maxSpeed = decimal.ToDouble(max1_speed.Value);
            double sTime = decimal.ToDouble(s1_time.Value);
            double incTime = decimal.ToDouble(inc1_time.Value);
            double decTime = decimal.ToDouble(dec1_time.Value);

            for (ushort i = 0; i < axisArr.Length; i++)
            {
                var result = _motion.SetMoveParameters(axisArr[i], startSpeed, maxSpeed, stopSpeed, incTime, sTime,
                    decTime);
                if (!result.Status)
                {
                    MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Btn_Jog_MouseUp(object sender, MouseEventArgs e)
        {
            if (!(sender is Button)) return;
            Button btn = sender as Button;
            var tag = btn.Tag.ToString();
            ushort axis = ushort.Parse(tag.Split(':')[0]);
            // ushort direction = ushort.Parse(tag.Split(':')[1]);
            var result = _motion.StopAxis(axis, 0);
            if (!result.Status)
            {
                MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            _setParamsFlag = false;
        }

        private void init_btn_Click(object sender, EventArgs e)
        {
            var btnTxt = (sender as Button).Text;
            if (btnTxt.Equals("打开轴卡"))
            {
                var result = _motion.InitCard();
                if (result.Status)
                {
                    for (ushort i = 0; i < 3; i++)
                    {
                        result = _motion.SetElMode(i, 1, 0, 0);
                        if (!result.Status)
                        {
                            MessageBox.Show("初始化轴卡失败：" + result.Msg, "错误提示", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                    (sender as Button).Text = "关闭轴卡";
                    MessageBox.Show("初始化轴卡成功");
                }
            }
            else
            {
                _motion.CloseCard();
                MessageBox.Show("关闭成功");
                (sender as Button).Text = "打开轴卡";
            }
        }

        private void stopAll_btn_Click(object sender, EventArgs e)
        {
            for (ushort i = 0; i < 3; i++)
            {
                _motion.StopAxis(i, 0);
            }
        }


        private void Move_Btn_Click(object sender, EventArgs e)
        {
            var axis = GetSelectedAxis();
            if (axis > 7)
            {
                MessageBox.Show("请选择轴", "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            int dist = decimal.ToInt32(dist_ipt.Value);
            var tag = (sender as Button).Tag;

            var result = _motion.PMove(axis, dist, ushort.Parse(tag.ToString()));
            if (!result.Status)
            {
                MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void stop_move_btn_Click(object sender, EventArgs e)
        {
            var axis = GetSelectedAxis();
            if (axis > 7)
            {
                MessageBox.Show("请选择轴", "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            var result = _motion.WaitStop(axis);
            if (!result.Status)
            {
                MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 位置清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_Origin_Click(object sender, EventArgs e)
        {
            var axis = GetSelectedAxis();
            if (axis > 7)
            {
                MessageBox.Show("请选择轴", "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            var result = _motion.SetOrigin(axis);
            if (!result.Status)
            {
                MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }


        private ushort GetSelectedAxis()
        {
            ushort axis = 8;
            foreach (Control control in single_axis_group.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    axis = ushort.Parse(radioButton.Tag.ToString());
                    break;
                }
            }

            return axis;
        }

        private void init_origin_Click(object sender, EventArgs e)
        {
        }

        // 正限位
        const uint POS_LIMIT_MASK = 0X02;

        // 负限位
        const uint NEG_LIMIT_MASK = 0X04;

        private void MonitorLimit()
        {
            while (true)
            {
                for (ushort i = 0; i < 3; i++)
                {
                    uint ioStatus = _motion.CheckAxisIoStatus(i);
                    foreach (Control control in groupBox2.Controls)
                    {
                        if (control is Label label && label.Name.Equals($"io{i}_label"))
                        {
                            label.Invoke(new Action(() => { label.Text = ioStatus.ToString(); }));
                        }
                    }

                    if ((ioStatus & POS_LIMIT_MASK) != 0)
                    {
                        HandlerLimitTrigger(i, 1);
                    }
                    else if ((ioStatus & NEG_LIMIT_MASK) != 0)
                    {
                        HandlerLimitTrigger(i, 0);
                    }
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction">1：正限位；0：负限位</param>
        private void HandlerLimitTrigger(ushort axis, ushort direction)
        {
            var labelName = direction == 0 ? $"off_{axis}_label" : $"on_{axis}_label";
            foreach (Control control in groupBox2.Controls)
            {
                if (control is Label label)
                {
                    label.Invoke(new Action(() => { label.BackColor = Color.Gray; }));
                    if (label.Name.Equals(labelName))
                    {
                        label.Invoke(new Action(() => { label.BackColor = Color.Red; }));
                    }
                }
            }
        }

        private void xy_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (xy_radio.Checked)
            {
                z_pos_ipt.Enabled = false;
            }
            else
            {
                z_pos_ipt.Enabled = true;
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            ushort[] axisArr = null;
            if (xy_radio.Checked = true)
            {
                axisArr = new ushort[2] { XAxis, YAxis };
            }
            else
            {
                axisArr = new ushort[3] { XAxis, YAxis, ZAxis };
            }

            SetParams2(axisArr);

            foreach (var axis in axisArr)
            {
                int dist = 0;
                if (axis == XAxis)
                {
                    dist = decimal.ToInt32(x_pos_ipt.Value);
                }
                else if (axis == YAxis)
                {
                    dist = decimal.ToInt32(y_pos_ipt.Value);
                }
                else if (axis == ZAxis)
                {
                    dist = decimal.ToInt32(z_pos_ipt.Value);
                }

                ushort posiMode = 0;
                if (abs_radio.Checked)
                {
                    posiMode = 1;
                }

                var result = _motion.PMove(axis, dist, 1);
                if (!result.Status)
                {
                    MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            ushort[] axisArr = null;
            if (xy_radio.Checked = true)
            {
                axisArr = new ushort[2] { XAxis, YAxis };
            }
            else
            {
                axisArr = new ushort[3] { XAxis, YAxis, ZAxis };
            }

            foreach (var axis in axisArr)
            {
                _motion.StopAxis(axis, 0);
            }
        }

        private void start_line_btn_Click(object sender, EventArgs e)
        {
            var crd = decimal.ToUInt16(crd_ipt.Value);
            _motion.SetAxisPosition(XAxis, 0);
            _motion.SetAxisPosition(YAxis, 0);
            _motion.SetVectorProfileMulticoor(crd, decimal.ToDouble(max1_speed.Value),
                decimal.ToDouble(dec1_time.Value));
            var axisList = new ushort[] { XAxis, YAxis };
            var posList = new int[] { decimal.ToInt32(x_line_pos_int.Value), decimal.ToInt32(y_line_pos_int.Value) };
            _motion.LineMulticoor(crd, 2, axisList, posList, 0);
        }

        private void stop_line_btn_Click(object sender, EventArgs e)
        {
            var crd = decimal.ToUInt16(crd_ipt.Value);
            _motion.StopAllAxis(crd, 0);
        }

        private void start_arc_btn_Click(object sender, EventArgs e)
        {
            var crd = decimal.ToUInt16(crd_ipt.Value);
            _motion.SetAxisPosition(XAxis, 0);
            _motion.SetAxisPosition(YAxis, 0);
            _motion.SetVectorProfileMulticoor(crd, decimal.ToDouble(max1_speed.Value),
                decimal.ToDouble(dec1_time.Value));
            var axisList = new ushort[] { XAxis, YAxis };
            var targetPos = new int[] { decimal.ToInt32(x_dis_ipt.Value), decimal.ToInt32(y_dis_ipt.Value) };
            var cenPos = new int[] { decimal.ToInt32(cenx_ipt.Value), decimal.ToInt32(ceny_ipt.Value) };
            ushort arcDir = (ushort)(cw_radio.Checked ? 0 : 1);
            MessageBox.Show(
                $"DistanceX:{targetPos[0]},DistanceY:{targetPos[1]},CenterX:{cenPos[0]},CenterY:{cenPos[1]},");
            var result = _motion.ArcMoveMulticoor(crd, axisList, targetPos, cenPos, arcDir, 1);
            if (!result.Status)
            {
                MessageBox.Show(result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }

        private void Back_origin_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var axis = ushort.Parse(btn.Tag.ToString());
            var result = _motion.SetHomePinLogic(axis, 0);
            if (!result.Status)
            {
                MessageBox.Show("设置原点开关的有效电平失败：" + result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            ushort homeDict = pos_radio.Checked ? (ushort)1 : (ushort)0;
            result = _motion.SetHomeMode(axis, homeDict, 1, 3);
            if (!result.Status)
            {
                MessageBox.Show("设置回原点方式失败：" + result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SetParams(axis);
            // result = _motion.SetHomePosition(axis,1,0);
            // if (!result.Status)
            // {
            //     MessageBox.Show("设置回零偏移量及清零模式失败：" + result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //     return;
            // }
            result = _motion.HomeMove(axis);
            if (!result.Status)
            {
                MessageBox.Show("回零失败：" + result.Msg, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }
    }
}