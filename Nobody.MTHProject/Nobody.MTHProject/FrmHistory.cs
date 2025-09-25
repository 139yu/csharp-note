using Nobody.MTHBLL;
using Nobody.MTHControlLib;
using Nobody.MTHModels;
using SeeSharpTools.JY.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHProject
{
    public partial class FrmHistory : Form
    {
        public FrmHistory()
        {
            InitializeComponent();
            this.time_startTime.Value = DateTime.Now.AddHours(-2);
            this.time_endTime.Value = DateTime.Now;
            InitChart();
            UpdateChart(QueryData());
        }
        private void InitChart()
        {
            // 设置X轴类型
            this.chart_main.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.String;
            this.chart_main.LegendVisible = false;
            // 最大显示点数
            this.chart_main.DisplayPoints = 100000;
            this.chart_main.AxisY.Minimum = 0.0f;
            this.chart_main.AxisY.Maximum = 100.0f;

        }
        private ActualDataManager actualDataManager = new ActualDataManager();
        private Dictionary<string, string> paramList = new Dictionary<string, string>();
        private void GetParams()
        {
            paramList.Clear();
            foreach (var item in panel_params.Controls.OfType<CheckBoxEx>())
            {
                if (item.Checked)
                {
                    paramList.Add(item.Tag.ToString(), item.Text);
                }
            }
        }

        private void btn_timeQuery_Click(object sender, EventArgs e)
        {
            
            var dataList = QueryData();
            UpdateChart(dataList);
        }

        private List<ActualData> QueryData()
        {
            GetParams();
            if (paramList.Count == 0)
            {
                new FrmMsgBoxWithoutAck("查询出错", "请勾选显示参数！").Show();
                return null;
            }
            var startTime = this.time_startTime.Value;
            var endTime = this.time_endTime.Value;
            return actualDataManager.GetActualDataList(startTime, endTime);
        }

        private void UpdateChart(List<ActualData> dataList)
        {
            if (dataList.Count == 0) return;
            int rowCount = dataList.Count;
            int columnCount = paramList.Count;
            this.chart_main.Clear();
            this.chart_main.Series.Clear();
            this.chart_main.SeriesCount = columnCount;
            for (int i = 0; i < paramList.Count; i++)
            {
                var series = new StripChartXSeries();
                series.Width = StripChartXSeries.LineWidth.Middle;
                series.Name = paramList.Values.ToList()[i];
                this.chart_main.Series.Add(series);
            }
            this.chart_main.LegendVisible = true;
            double[,] yData = new double[columnCount, rowCount];
            string[] xData = new string[rowCount];

            for (int i = 0; i < paramList.Count; i++)
            {
                var propName = paramList.Keys.ToList()[i];
                for (int j = 0; j < dataList.Count; j++)
                {
                    var data = dataList[j];
                    var dataType = data.GetType();
                    var prop = dataType.GetProperty(propName);
                    if (prop != null && prop.GetValue(data) != null)
                    {
                        yData[i, j] = double.Parse(prop.GetValue(data).ToString());
                    }else
                    {
                        yData[i, j] = 0;
                    }
                    
                    xData[j] = data.InsertTime.ToString("HH:mm:ss");
                }
            }

            this.chart_main.Plot(yData, xData);
           
        }

        private void btn_exportImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "图片文件(*.jpg)|*.jpg;*.png|所有文件(*.*)|*.*";
            saveFileDialog.DefaultExt = "jpg";
            saveFileDialog.Title = "历史趋势保存";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = "历史趋势图片" + DateTime.Now.ToString("yyyyMMddHHmmss"); 
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.chart_main.SaveAsImage(saveFileDialog.FileName);
                if(new FrmMsgBoxWithAck("打开趋势图片","图片保存成功，是否立即打开？").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }

        private void btn_exportCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV(*.csv)|*.csv|所有文件(*.*)|*.*";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.Title = "历史趋势保存";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = "历史趋势图片" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.chart_main.SaveAsCsv(saveFileDialog.FileName);
                if (new FrmMsgBoxWithAck("打开趋势CSV", "CSV保存成功，是否立即打开？").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }
    }
}
