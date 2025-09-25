namespace Nobody.MTHControlLib
{
    partial class TextSet
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_value = new System.Windows.Forms.Label();
            this.lbl_unit = new System.Windows.Forms.Label();
            this.led_alarm = new SeeSharpTools.JY.GUI.LED();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.6875F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.0625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.875F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_value, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_unit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.led_alarm, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(4, 0);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(143, 40);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "1#站点温度限高";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_title.DoubleClick += new System.EventHandler(this.lbl_Value_DoubleClick);
            // 
            // lbl_value
            // 
            this.lbl_value.AutoSize = true;
            this.lbl_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_value.ForeColor = System.Drawing.Color.White;
            this.lbl_value.Location = new System.Drawing.Point(155, 0);
            this.lbl_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_value.Name = "lbl_value";
            this.lbl_value.Size = new System.Drawing.Size(74, 40);
            this.lbl_value.TabIndex = 1;
            this.lbl_value.Text = "0.0";
            this.lbl_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_value.DoubleClick += new System.EventHandler(this.lbl_Value_DoubleClick);
            // 
            // lbl_unit
            // 
            this.lbl_unit.AutoSize = true;
            this.lbl_unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_unit.ForeColor = System.Drawing.Color.White;
            this.lbl_unit.Location = new System.Drawing.Point(237, 0);
            this.lbl_unit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_unit.Name = "lbl_unit";
            this.lbl_unit.Size = new System.Drawing.Size(56, 40);
            this.lbl_unit.TabIndex = 2;
            this.lbl_unit.Text = "°C";
            this.lbl_unit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_unit.DoubleClick += new System.EventHandler(this.lbl_Value_DoubleClick);
            // 
            // led_alarm
            // 
            this.led_alarm.BlinkColor = System.Drawing.Color.Lime;
            this.led_alarm.BlinkInterval = 1000;
            this.led_alarm.BlinkOn = false;
            this.led_alarm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.led_alarm.Interacton = SeeSharpTools.JY.GUI.LED.InteractionStyle.Indicator;
            this.led_alarm.Location = new System.Drawing.Point(307, 8);
            this.led_alarm.Margin = new System.Windows.Forms.Padding(10, 8, 4, 4);
            this.led_alarm.Name = "led_alarm";
            this.led_alarm.OffColor = System.Drawing.Color.Lime;
            this.led_alarm.OnColor = System.Drawing.Color.Red;
            this.led_alarm.Size = new System.Drawing.Size(24, 24);
            this.led_alarm.Style = SeeSharpTools.JY.GUI.LED.LedStyle.Circular;
            this.led_alarm.TabIndex = 3;
            this.led_alarm.Value = false;
            // 
            // TextSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TextSet";
            this.Size = new System.Drawing.Size(340, 40);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_value;
        private System.Windows.Forms.Label lbl_unit;
        private SeeSharpTools.JY.GUI.LED led_alarm;
    }
}
