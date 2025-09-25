using Nobody.MTHControlLib;
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

namespace Nobody.MTHProject
{
    public partial class FrmMonitor : Form
    {
        private Timer updateTimer = new Timer();
        public FrmMonitor()
        {
            InitializeComponent();
            SetChart();

            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += UpdateTimer_Tick;
            this.updateTimer.Start();
            this.FormClosed += FrmMonitor_FormClosed;
        }

        private void FrmMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.updateTimer.Stop();
            this.updateTimer.Dispose();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            var device = CommonMethods.Device;
            if (device.IsConnected)
            {
                foreach (var item in this.panel_main.Controls.OfType<THMControl>())
                {
                    UpdateMTHControl(item);
                }
                List<double> ydata = new List<double>();
                for (int i = 1; i <= 6; i++)
                {
                    ydata.Add(Convert.ToDouble(device.CurrentValue[$"模块{i}温度"]));
                    ydata.Add(Convert.ToDouble(device.CurrentValue[$"模块{i}湿度"]));
                }
                this.chart_ActualTrend.PlotSingle(ydata.ToArray());
            }
        }
        private void UpdateMTHControl(THMControl item)
        {
            var currentValue = CommonMethods.Device.CurrentValue;
            if (currentValue.ContainsKey(item.HumidityVarName))
            {
                item.HumidityValue = currentValue[item.HumidityVarName].ToString();
            }
            if (currentValue.ContainsKey(item.TempVarName))
            {
                item.TempValue = currentValue[item.TempVarName].ToString();
            }
            if (currentValue.ContainsKey(item.StateVarName))
            {
                item.ErrorState = currentValue[item.StateVarName].ToString().Equals("True");
            }
        }


        private void SetChart()
        {
            // 设置X轴数据类型
            this.chart_ActualTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.chart_ActualTrend.TimeStampFormat = "HH:mm:ss";
            // 设置图例
            this.chart_ActualTrend.LegendVisible = true;
            // 显示数据点
            this.chart_ActualTrend.DisplayPoints = 4000;

            this.chart_ActualTrend.AxisY.Minimum = 0.0;
            this.chart_ActualTrend.AxisY.Maximum = 100.0;
            this.chart_ActualTrend.AxisY.AutoScale = false;
            // 清除曲线
            this.chart_ActualTrend.Series.Clear();
            // 设置曲线数量
            this.chart_ActualTrend.SeriesCount = 12;
             for (int i = 0;i < 12; i++)
            {
                this.chart_ActualTrend.Series[i].Name = i % 2 == 0 ? $"{i / 2 + 1}#站点温度" : $"{i / 2 + 1}#站点湿度";
                //设置曲线不可见，勾选后才可见
                this.chart_ActualTrend.Series[i].Visible = false;
                //设置曲线粗细，中性
                this.chart_ActualTrend.Series[i].Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                //设置曲线的Y轴
                this.chart_ActualTrend.Series[i].YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            }
        }

        public string CurrentTime { get => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        public void AddLog(int level,string message)
        {
            if(level> 2)
            {
                level = 2;
            }else if (level < 0)
            {
                level = 0;
            }

            if (this.lv_log.InvokeRequired)
            {
                this.lv_log.Invoke(new Action<int,string>(AddLog),level,message);
            }
            else
            {
                var item = new ListViewItem(" " + CurrentTime, level);
                item.SubItems.Add(message);
                this.lv_log.Items.Add(item);
                this.lv_log.Items[this.lv_log.Items.Count - 1].EnsureVisible();
            }
        }

        private void chk_Common_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBoxEx;
            var index = int.Parse(chk.Tag.ToString()) - 1;
            bool checkFlag = (sender as CheckBoxEx).Checked;
            this.chart_ActualTrend.Series[index].Visible = checkFlag;
        }
    }
}
