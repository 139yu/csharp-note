namespace Nobody.MTHProject
{
    partial class FrmMonitor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries1 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitor));
            this.chart_ActualTrend = new SeeSharpTools.JY.GUI.StripChartX();
            this.lv_log = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.checkBoxEx12 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx8 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx4 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx11 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx10 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx7 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx6 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx9 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx3 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx5 = new Nobody.MTHControlLib.CheckBoxEx();
            this.checkBoxEx2 = new Nobody.MTHControlLib.CheckBoxEx();
            this.chk_temp1 = new Nobody.MTHControlLib.CheckBoxEx();
            this.title2 = new Nobody.MTHControlLib.Title();
            this.title1 = new Nobody.MTHControlLib.Title();
            this.thmControl6 = new Nobody.MTHControlLib.THMControl();
            this.thmControl5 = new Nobody.MTHControlLib.THMControl();
            this.thmControl4 = new Nobody.MTHControlLib.THMControl();
            this.thmControl3 = new Nobody.MTHControlLib.THMControl();
            this.thmControl2 = new Nobody.MTHControlLib.THMControl();
            this.thmControl1 = new Nobody.MTHControlLib.THMControl();
            this.panel_main = new Nobody.MTHControlLib.PanelEnhanced();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_ActualTrend
            // 
            this.chart_ActualTrend.AxisX.AutoScale = false;
            this.chart_ActualTrend.AxisX.AutoZoomReset = false;
            this.chart_ActualTrend.AxisX.Color = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisX.InitWithScaleView = false;
            this.chart_ActualTrend.AxisX.IsLogarithmic = false;
            this.chart_ActualTrend.AxisX.LabelAngle = 0;
            this.chart_ActualTrend.AxisX.LabelEnabled = true;
            this.chart_ActualTrend.AxisX.LabelFormat = null;
            this.chart_ActualTrend.AxisX.MajorGridColor = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisX.MajorGridCount = 4;
            this.chart_ActualTrend.AxisX.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisX.Maximum = 1000D;
            this.chart_ActualTrend.AxisX.Minimum = 0D;
            this.chart_ActualTrend.AxisX.MinorGridColor = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisX.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisX.TickWidth = 1F;
            this.chart_ActualTrend.AxisX.Title = "";
            this.chart_ActualTrend.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisX.ViewMaximum = 1000D;
            this.chart_ActualTrend.AxisX.ViewMinimum = 0D;
            this.chart_ActualTrend.AxisX2.AutoScale = false;
            this.chart_ActualTrend.AxisX2.AutoZoomReset = false;
            this.chart_ActualTrend.AxisX2.Color = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisX2.InitWithScaleView = false;
            this.chart_ActualTrend.AxisX2.IsLogarithmic = false;
            this.chart_ActualTrend.AxisX2.LabelAngle = 0;
            this.chart_ActualTrend.AxisX2.LabelEnabled = true;
            this.chart_ActualTrend.AxisX2.LabelFormat = null;
            this.chart_ActualTrend.AxisX2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX2.MajorGridCount = 6;
            this.chart_ActualTrend.AxisX2.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisX2.Maximum = 1000D;
            this.chart_ActualTrend.AxisX2.Minimum = 0D;
            this.chart_ActualTrend.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_ActualTrend.AxisX2.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisX2.TickWidth = 1F;
            this.chart_ActualTrend.AxisX2.Title = "";
            this.chart_ActualTrend.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisX2.ViewMaximum = 1000D;
            this.chart_ActualTrend.AxisX2.ViewMinimum = 0D;
            this.chart_ActualTrend.AxisY.AutoScale = true;
            this.chart_ActualTrend.AxisY.AutoZoomReset = false;
            this.chart_ActualTrend.AxisY.Color = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisY.InitWithScaleView = false;
            this.chart_ActualTrend.AxisY.IsLogarithmic = false;
            this.chart_ActualTrend.AxisY.LabelAngle = 0;
            this.chart_ActualTrend.AxisY.LabelEnabled = true;
            this.chart_ActualTrend.AxisY.LabelFormat = null;
            this.chart_ActualTrend.AxisY.MajorGridColor = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisY.MajorGridCount = 6;
            this.chart_ActualTrend.AxisY.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisY.Maximum = 3D;
            this.chart_ActualTrend.AxisY.Minimum = 0D;
            this.chart_ActualTrend.AxisY.MinorGridColor = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisY.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisY.TickWidth = 1F;
            this.chart_ActualTrend.AxisY.Title = "";
            this.chart_ActualTrend.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisY.ViewMaximum = 3.5D;
            this.chart_ActualTrend.AxisY.ViewMinimum = 0.5D;
            this.chart_ActualTrend.AxisY2.AutoScale = true;
            this.chart_ActualTrend.AxisY2.AutoZoomReset = false;
            this.chart_ActualTrend.AxisY2.Color = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisY2.InitWithScaleView = false;
            this.chart_ActualTrend.AxisY2.IsLogarithmic = false;
            this.chart_ActualTrend.AxisY2.LabelAngle = 0;
            this.chart_ActualTrend.AxisY2.LabelEnabled = true;
            this.chart_ActualTrend.AxisY2.LabelFormat = null;
            this.chart_ActualTrend.AxisY2.MajorGridColor = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisY2.MajorGridCount = 6;
            this.chart_ActualTrend.AxisY2.MajorGridEnabled = true;
            this.chart_ActualTrend.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_ActualTrend.AxisY2.Maximum = 3.5D;
            this.chart_ActualTrend.AxisY2.Minimum = 0.5D;
            this.chart_ActualTrend.AxisY2.MinorGridColor = System.Drawing.Color.White;
            this.chart_ActualTrend.AxisY2.MinorGridEnabled = false;
            this.chart_ActualTrend.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_ActualTrend.AxisY2.TickWidth = 1F;
            this.chart_ActualTrend.AxisY2.Title = "";
            this.chart_ActualTrend.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_ActualTrend.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_ActualTrend.AxisY2.ViewMaximum = 3.5D;
            this.chart_ActualTrend.AxisY2.ViewMinimum = 0.5D;
            this.chart_ActualTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.chart_ActualTrend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chart_ActualTrend.ChartAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.chart_ActualTrend.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.LeftToRight;
            this.chart_ActualTrend.DisplayPoints = 4000;
            this.chart_ActualTrend.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chart_ActualTrend.ForeColor = System.Drawing.Color.White;
            this.chart_ActualTrend.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.chart_ActualTrend.LegendBackColor = System.Drawing.Color.Transparent;
            this.chart_ActualTrend.LegendFont = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chart_ActualTrend.LegendForeColor = System.Drawing.Color.White;
            this.chart_ActualTrend.LegendVisible = true;
            stripChartXSeries1.Color = System.Drawing.Color.Orange;
            stripChartXSeries1.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries1.Name = "1#站点温度";
            stripChartXSeries1.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries1.Visible = true;
            stripChartXSeries1.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries1.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries1.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            this.chart_ActualTrend.LineSeries.Add(stripChartXSeries1);
            this.chart_ActualTrend.Location = new System.Drawing.Point(809, 63);
            this.chart_ActualTrend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart_ActualTrend.Miscellaneous.CheckInfinity = false;
            this.chart_ActualTrend.Miscellaneous.CheckNaN = false;
            this.chart_ActualTrend.Miscellaneous.CheckNegtiveOrZero = false;
            this.chart_ActualTrend.Miscellaneous.DirectionChartCount = 3;
            this.chart_ActualTrend.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.chart_ActualTrend.Miscellaneous.MaxSeriesCount = 32;
            this.chart_ActualTrend.Miscellaneous.MaxSeriesPointCount = 4000;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.chart_ActualTrend.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.chart_ActualTrend.Miscellaneous.SplitViewAutoLayout = true;
            this.chart_ActualTrend.Name = "chart_ActualTrend";
            this.chart_ActualTrend.NextTimeStamp = new System.DateTime(((long)(0)));
            this.chart_ActualTrend.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.chart_ActualTrend.SeriesCount = 1;
            this.chart_ActualTrend.Size = new System.Drawing.Size(591, 242);
            this.chart_ActualTrend.SplitView = false;
            this.chart_ActualTrend.StartIndex = 0;
            this.chart_ActualTrend.TabIndex = 2;
            this.chart_ActualTrend.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.chart_ActualTrend.TimeStampFormat = null;
            this.chart_ActualTrend.XCursor.AutoInterval = true;
            this.chart_ActualTrend.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_ActualTrend.XCursor.Interval = 0.001D;
            this.chart_ActualTrend.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.chart_ActualTrend.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_ActualTrend.XCursor.Value = double.NaN;
            this.chart_ActualTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.chart_ActualTrend.YCursor.AutoInterval = true;
            this.chart_ActualTrend.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_ActualTrend.YCursor.Interval = 0.001D;
            this.chart_ActualTrend.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.chart_ActualTrend.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_ActualTrend.YCursor.Value = double.NaN;
            // 
            // lv_log
            // 
            this.lv_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.lv_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_log.ForeColor = System.Drawing.Color.White;
            this.lv_log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_log.HideSelection = false;
            this.lv_log.Location = new System.Drawing.Point(809, 541);
            this.lv_log.Name = "lv_log";
            this.lv_log.ShowItemToolTips = true;
            this.lv_log.Size = new System.Drawing.Size(591, 192);
            this.lv_log.SmallImageList = this.imageList1;
            this.lv_log.TabIndex = 4;
            this.lv_log.UseCompatibleStateImageBehavior = false;
            this.lv_log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日志时间";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "日志内容";
            this.columnHeader2.Width = 350;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "info.png");
            this.imageList1.Images.SetKeyName(1, "warning.png");
            this.imageList1.Images.SetKeyName(2, "error.png");
            // 
            // checkBoxEx12
            // 
            this.checkBoxEx12.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx12.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx12.CheckButtonWidth = 20;
            this.checkBoxEx12.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx12.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx12.Location = new System.Drawing.Point(1295, 433);
            this.checkBoxEx12.Name = "checkBoxEx12";
            this.checkBoxEx12.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx12.TabIndex = 3;
            this.checkBoxEx12.Tag = "12";
            this.checkBoxEx12.Text = "6#站点湿度";
            this.checkBoxEx12.UseVisualStyleBackColor = false;
            this.checkBoxEx12.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx8
            // 
            this.checkBoxEx8.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx8.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx8.CheckButtonWidth = 20;
            this.checkBoxEx8.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx8.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx8.Location = new System.Drawing.Point(1295, 384);
            this.checkBoxEx8.Name = "checkBoxEx8";
            this.checkBoxEx8.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx8.TabIndex = 3;
            this.checkBoxEx8.Tag = "8";
            this.checkBoxEx8.Text = "4#站点湿度";
            this.checkBoxEx8.UseVisualStyleBackColor = false;
            this.checkBoxEx8.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx4
            // 
            this.checkBoxEx4.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx4.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx4.CheckButtonWidth = 20;
            this.checkBoxEx4.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx4.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx4.Location = new System.Drawing.Point(1295, 335);
            this.checkBoxEx4.Name = "checkBoxEx4";
            this.checkBoxEx4.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx4.TabIndex = 3;
            this.checkBoxEx4.Tag = "4";
            this.checkBoxEx4.Text = "2#站点湿度";
            this.checkBoxEx4.UseVisualStyleBackColor = false;
            this.checkBoxEx4.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx11
            // 
            this.checkBoxEx11.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx11.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx11.CheckButtonWidth = 20;
            this.checkBoxEx11.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx11.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx11.Location = new System.Drawing.Point(1133, 433);
            this.checkBoxEx11.Name = "checkBoxEx11";
            this.checkBoxEx11.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx11.TabIndex = 3;
            this.checkBoxEx11.Tag = "11";
            this.checkBoxEx11.Text = "6#站点温度";
            this.checkBoxEx11.UseVisualStyleBackColor = false;
            this.checkBoxEx11.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx10
            // 
            this.checkBoxEx10.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx10.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx10.CheckButtonWidth = 20;
            this.checkBoxEx10.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx10.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx10.Location = new System.Drawing.Point(971, 433);
            this.checkBoxEx10.Name = "checkBoxEx10";
            this.checkBoxEx10.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx10.TabIndex = 3;
            this.checkBoxEx10.Tag = "10";
            this.checkBoxEx10.Text = "5#站点湿度";
            this.checkBoxEx10.UseVisualStyleBackColor = false;
            this.checkBoxEx10.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx7
            // 
            this.checkBoxEx7.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx7.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx7.CheckButtonWidth = 20;
            this.checkBoxEx7.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx7.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx7.Location = new System.Drawing.Point(1133, 384);
            this.checkBoxEx7.Name = "checkBoxEx7";
            this.checkBoxEx7.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx7.TabIndex = 3;
            this.checkBoxEx7.Tag = "7";
            this.checkBoxEx7.Text = "4#站点温度";
            this.checkBoxEx7.UseVisualStyleBackColor = false;
            this.checkBoxEx7.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx6
            // 
            this.checkBoxEx6.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx6.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx6.CheckButtonWidth = 20;
            this.checkBoxEx6.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx6.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx6.Location = new System.Drawing.Point(971, 384);
            this.checkBoxEx6.Name = "checkBoxEx6";
            this.checkBoxEx6.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx6.TabIndex = 3;
            this.checkBoxEx6.Tag = "6";
            this.checkBoxEx6.Text = "3#站点湿度";
            this.checkBoxEx6.UseVisualStyleBackColor = false;
            this.checkBoxEx6.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx9
            // 
            this.checkBoxEx9.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx9.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx9.CheckButtonWidth = 20;
            this.checkBoxEx9.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx9.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx9.Location = new System.Drawing.Point(809, 433);
            this.checkBoxEx9.Name = "checkBoxEx9";
            this.checkBoxEx9.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx9.TabIndex = 3;
            this.checkBoxEx9.Tag = "9";
            this.checkBoxEx9.Text = "5#站点温度";
            this.checkBoxEx9.UseVisualStyleBackColor = false;
            this.checkBoxEx9.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx3
            // 
            this.checkBoxEx3.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx3.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx3.CheckButtonWidth = 20;
            this.checkBoxEx3.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx3.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx3.Location = new System.Drawing.Point(1133, 335);
            this.checkBoxEx3.Name = "checkBoxEx3";
            this.checkBoxEx3.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx3.TabIndex = 3;
            this.checkBoxEx3.Tag = "3";
            this.checkBoxEx3.Text = "2#站点温度";
            this.checkBoxEx3.UseVisualStyleBackColor = false;
            this.checkBoxEx3.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx5
            // 
            this.checkBoxEx5.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx5.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx5.CheckButtonWidth = 20;
            this.checkBoxEx5.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx5.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx5.Location = new System.Drawing.Point(809, 384);
            this.checkBoxEx5.Name = "checkBoxEx5";
            this.checkBoxEx5.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx5.TabIndex = 3;
            this.checkBoxEx5.Tag = "5";
            this.checkBoxEx5.Text = "3#站点温度";
            this.checkBoxEx5.UseVisualStyleBackColor = false;
            this.checkBoxEx5.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx2
            // 
            this.checkBoxEx2.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx2.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxEx2.CheckButtonWidth = 20;
            this.checkBoxEx2.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx2.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx2.Location = new System.Drawing.Point(971, 335);
            this.checkBoxEx2.Name = "checkBoxEx2";
            this.checkBoxEx2.Size = new System.Drawing.Size(115, 26);
            this.checkBoxEx2.TabIndex = 3;
            this.checkBoxEx2.Tag = "2";
            this.checkBoxEx2.Text = "1#站点湿度";
            this.checkBoxEx2.UseVisualStyleBackColor = false;
            this.checkBoxEx2.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_temp1
            // 
            this.chk_temp1.BackColor = System.Drawing.Color.Transparent;
            this.chk_temp1.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chk_temp1.CheckButtonWidth = 20;
            this.chk_temp1.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_temp1.ForeColor = System.Drawing.Color.White;
            this.chk_temp1.Location = new System.Drawing.Point(809, 335);
            this.chk_temp1.Name = "chk_temp1";
            this.chk_temp1.Size = new System.Drawing.Size(115, 26);
            this.chk_temp1.TabIndex = 3;
            this.chk_temp1.Tag = "1";
            this.chk_temp1.Text = "1#站点温度";
            this.chk_temp1.UseVisualStyleBackColor = false;
            this.chk_temp1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // title2
            // 
            this.title2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.title2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title2.BackgroundImage")));
            this.title2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(809, 484);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(100, 30);
            this.title2.TabIndex = 1;
            this.title2.TitleName = "系统日志";
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.title1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title1.BackgroundImage")));
            this.title1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(809, 14);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(100, 30);
            this.title1.TabIndex = 1;
            this.title1.TitleName = "实时趋势";
            // 
            // thmControl6
            // 
            this.thmControl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl6.ErrorState = false;
            this.thmControl6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl6.HumidityValue = "0";
            this.thmControl6.HumidityVarName = "模块6湿度";
            this.thmControl6.Location = new System.Drawing.Point(392, 509);
            this.thmControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl6.Name = "thmControl6";
            this.thmControl6.Size = new System.Drawing.Size(338, 224);
            this.thmControl6.StateVarName = "模块6状态";
            this.thmControl6.TabIndex = 0;
            this.thmControl6.TempValue = "0";
            this.thmControl6.TempVarName = "模块6温度";
            this.thmControl6.Title = "6#站点";
            // 
            // thmControl5
            // 
            this.thmControl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl5.ErrorState = false;
            this.thmControl5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl5.HumidityValue = null;
            this.thmControl5.HumidityVarName = "模块5湿度";
            this.thmControl5.Location = new System.Drawing.Point(13, 509);
            this.thmControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl5.Name = "thmControl5";
            this.thmControl5.Size = new System.Drawing.Size(338, 224);
            this.thmControl5.StateVarName = "模块5状态";
            this.thmControl5.TabIndex = 0;
            this.thmControl5.TempValue = "0";
            this.thmControl5.TempVarName = "模块5温度";
            this.thmControl5.Title = "5#站点";
            // 
            // thmControl4
            // 
            this.thmControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl4.ErrorState = false;
            this.thmControl4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl4.HumidityValue = null;
            this.thmControl4.HumidityVarName = "模块4湿度";
            this.thmControl4.Location = new System.Drawing.Point(392, 265);
            this.thmControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl4.Name = "thmControl4";
            this.thmControl4.Size = new System.Drawing.Size(338, 224);
            this.thmControl4.StateVarName = "模块4状态";
            this.thmControl4.TabIndex = 0;
            this.thmControl4.TempValue = "0";
            this.thmControl4.TempVarName = "模块4温度";
            this.thmControl4.Title = "4#站点";
            // 
            // thmControl3
            // 
            this.thmControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl3.ErrorState = false;
            this.thmControl3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl3.HumidityValue = null;
            this.thmControl3.HumidityVarName = "模块3湿度";
            this.thmControl3.Location = new System.Drawing.Point(13, 265);
            this.thmControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl3.Name = "thmControl3";
            this.thmControl3.Size = new System.Drawing.Size(338, 224);
            this.thmControl3.StateVarName = "模块3状态";
            this.thmControl3.TabIndex = 0;
            this.thmControl3.TempValue = "0";
            this.thmControl3.TempVarName = "模块3温度";
            this.thmControl3.Title = "3#站点";
            // 
            // thmControl2
            // 
            this.thmControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl2.ErrorState = false;
            this.thmControl2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl2.HumidityValue = null;
            this.thmControl2.HumidityVarName = "模块2湿度";
            this.thmControl2.Location = new System.Drawing.Point(392, 14);
            this.thmControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl2.Name = "thmControl2";
            this.thmControl2.Size = new System.Drawing.Size(338, 224);
            this.thmControl2.StateVarName = "模块2状态";
            this.thmControl2.TabIndex = 0;
            this.thmControl2.TempValue = "0";
            this.thmControl2.TempVarName = "模块2温度";
            this.thmControl2.Title = "2#站点";
            // 
            // thmControl1
            // 
            this.thmControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.thmControl1.ErrorState = false;
            this.thmControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl1.HumidityValue = null;
            this.thmControl1.HumidityVarName = "模块1湿度";
            this.thmControl1.Location = new System.Drawing.Point(13, 14);
            this.thmControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl1.Name = "thmControl1";
            this.thmControl1.Size = new System.Drawing.Size(338, 224);
            this.thmControl1.StateVarName = "模块1状态";
            this.thmControl1.TabIndex = 0;
            this.thmControl1.TempValue = "0";
            this.thmControl1.TempVarName = "模块1温度";
            this.thmControl1.Title = "1#站点";
            // 
            // panel_main
            // 
            this.panel_main.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.BackGround;
            this.panel_main.Controls.Add(this.lv_log);
            this.panel_main.Controls.Add(this.thmControl2);
            this.panel_main.Controls.Add(this.checkBoxEx12);
            this.panel_main.Controls.Add(this.thmControl1);
            this.panel_main.Controls.Add(this.checkBoxEx8);
            this.panel_main.Controls.Add(this.thmControl3);
            this.panel_main.Controls.Add(this.checkBoxEx4);
            this.panel_main.Controls.Add(this.thmControl4);
            this.panel_main.Controls.Add(this.checkBoxEx11);
            this.panel_main.Controls.Add(this.thmControl5);
            this.panel_main.Controls.Add(this.checkBoxEx10);
            this.panel_main.Controls.Add(this.thmControl6);
            this.panel_main.Controls.Add(this.checkBoxEx7);
            this.panel_main.Controls.Add(this.title1);
            this.panel_main.Controls.Add(this.checkBoxEx6);
            this.panel_main.Controls.Add(this.title2);
            this.panel_main.Controls.Add(this.checkBoxEx9);
            this.panel_main.Controls.Add(this.chart_ActualTrend);
            this.panel_main.Controls.Add(this.checkBoxEx3);
            this.panel_main.Controls.Add(this.chk_temp1);
            this.panel_main.Controls.Add(this.checkBoxEx5);
            this.panel_main.Controls.Add(this.checkBoxEx2);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1440, 760);
            this.panel_main.TabIndex = 5;
            // 
            // FrmMonitor
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1440, 760);
            this.Controls.Add(this.panel_main);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.THMControl thmControl1;
        private MTHControlLib.Title title1;
        private MTHControlLib.Title title2;
        private SeeSharpTools.JY.GUI.StripChartX chart_ActualTrend;
        private MTHControlLib.CheckBoxEx chk_temp1;
        private MTHControlLib.CheckBoxEx checkBoxEx2;
        private System.Windows.Forms.ListView lv_log;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private MTHControlLib.THMControl thmControl2;
        private MTHControlLib.CheckBoxEx checkBoxEx3;
        private MTHControlLib.CheckBoxEx checkBoxEx4;
        private MTHControlLib.CheckBoxEx checkBoxEx5;
        private MTHControlLib.CheckBoxEx checkBoxEx6;
        private MTHControlLib.CheckBoxEx checkBoxEx7;
        private MTHControlLib.CheckBoxEx checkBoxEx8;
        private MTHControlLib.CheckBoxEx checkBoxEx9;
        private MTHControlLib.CheckBoxEx checkBoxEx10;
        private MTHControlLib.CheckBoxEx checkBoxEx11;
        private MTHControlLib.CheckBoxEx checkBoxEx12;
        private MTHControlLib.THMControl thmControl3;
        private MTHControlLib.THMControl thmControl4;
        private MTHControlLib.THMControl thmControl5;
        private MTHControlLib.THMControl thmControl6;
        private MTHControlLib.PanelEnhanced panel_main;
    }
}
