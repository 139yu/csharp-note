namespace NegAndPosMove
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.close_card = new System.Windows.Forms.Button();
            this.init_card = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_axis = new System.Windows.Forms.ComboBox();
            this.stop_speed = new System.Windows.Forms.NumericUpDown();
            this.dec_time = new System.Windows.Forms.NumericUpDown();
            this.inc_time = new System.Windows.Forms.NumericUpDown();
            this.s_time = new System.Windows.Forms.NumericUpDown();
            this.run_speed = new System.Windows.Forms.NumericUpDown();
            this.run_pos = new System.Windows.Forms.NumericUpDown();
            this.start_speed = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stop_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dec_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inc_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.run_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.run_pos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_speed)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.close_card);
            this.groupBox1.Controls.Add(this.init_card);
            this.groupBox1.Location = new System.Drawing.Point(48, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "初始化卡";
            // 
            // close_card
            // 
            this.close_card.Location = new System.Drawing.Point(196, 31);
            this.close_card.Name = "close_card";
            this.close_card.Size = new System.Drawing.Size(75, 23);
            this.close_card.TabIndex = 0;
            this.close_card.Text = "关闭卡";
            this.close_card.UseVisualStyleBackColor = true;
            this.close_card.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // init_card
            // 
            this.init_card.Location = new System.Drawing.Point(75, 31);
            this.init_card.Name = "init_card";
            this.init_card.Size = new System.Drawing.Size(75, 23);
            this.init_card.TabIndex = 0;
            this.init_card.Text = "初始化卡";
            this.init_card.UseVisualStyleBackColor = true;
            this.init_card.Click += new System.EventHandler(this.Btn_Init_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(48, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运动模式选择";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(196, 38);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "绝对";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(75, 38);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "相对";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_axis);
            this.groupBox3.Controls.Add(this.stop_speed);
            this.groupBox3.Controls.Add(this.dec_time);
            this.groupBox3.Controls.Add(this.inc_time);
            this.groupBox3.Controls.Add(this.s_time);
            this.groupBox3.Controls.Add(this.run_speed);
            this.groupBox3.Controls.Add(this.run_pos);
            this.groupBox3.Controls.Add(this.start_speed);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.sTime);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(48, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 158);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "运动参数";
            // 
            // comboBox_axis
            // 
            this.comboBox_axis.FormattingEnabled = true;
            this.comboBox_axis.Location = new System.Drawing.Point(88, 120);
            this.comboBox_axis.Name = "comboBox_axis";
            this.comboBox_axis.Size = new System.Drawing.Size(82, 20);
            this.comboBox_axis.TabIndex = 3;
            // 
            // stop_speed
            // 
            this.stop_speed.Location = new System.Drawing.Point(259, 31);
            this.stop_speed.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.stop_speed.Name = "stop_speed";
            this.stop_speed.Size = new System.Drawing.Size(82, 21);
            this.stop_speed.TabIndex = 2;
            this.stop_speed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // dec_time
            // 
            this.dec_time.DecimalPlaces = 2;
            this.dec_time.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.dec_time.Location = new System.Drawing.Point(259, 92);
            this.dec_time.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dec_time.Name = "dec_time";
            this.dec_time.Size = new System.Drawing.Size(82, 21);
            this.dec_time.TabIndex = 2;
            this.dec_time.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // inc_time
            // 
            this.inc_time.DecimalPlaces = 2;
            this.inc_time.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.inc_time.Location = new System.Drawing.Point(88, 92);
            this.inc_time.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inc_time.Name = "inc_time";
            this.inc_time.Size = new System.Drawing.Size(82, 21);
            this.inc_time.TabIndex = 2;
            this.inc_time.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // s_time
            // 
            this.s_time.DecimalPlaces = 2;
            this.s_time.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.s_time.Location = new System.Drawing.Point(259, 64);
            this.s_time.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.s_time.Name = "s_time";
            this.s_time.Size = new System.Drawing.Size(82, 21);
            this.s_time.TabIndex = 2;
            this.s_time.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // run_speed
            // 
            this.run_speed.Location = new System.Drawing.Point(88, 62);
            this.run_speed.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.run_speed.Name = "run_speed";
            this.run_speed.Size = new System.Drawing.Size(82, 21);
            this.run_speed.TabIndex = 2;
            this.run_speed.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // run_pos
            // 
            this.run_pos.Location = new System.Drawing.Point(259, 119);
            this.run_pos.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.run_pos.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.run_pos.Name = "run_pos";
            this.run_pos.Size = new System.Drawing.Size(82, 21);
            this.run_pos.TabIndex = 2;
            this.run_pos.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // start_speed
            // 
            this.start_speed.Location = new System.Drawing.Point(88, 31);
            this.start_speed.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.start_speed.Name = "start_speed";
            this.start_speed.Size = new System.Drawing.Size(82, 21);
            this.start_speed.TabIndex = 2;
            this.start_speed.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "运动轴号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "减速时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "加速时间：";
            // 
            // sTime
            // 
            this.sTime.AutoSize = true;
            this.sTime.Location = new System.Drawing.Point(194, 66);
            this.sTime.Name = "sTime";
            this.sTime.Size = new System.Drawing.Size(59, 12);
            this.sTime.TabIndex = 0;
            this.sTime.Text = "S段时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "停止速度:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "运行速度:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "运动位置:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始速度:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "执行运动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(48, 483);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 12);
            this.errorLabel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 507);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "相对与绝对运动";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stop_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dec_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inc_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.run_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.run_pos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button close_card;
        private System.Windows.Forms.Button init_card;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown stop_speed;
        private System.Windows.Forms.NumericUpDown start_speed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown dec_time;
        private System.Windows.Forms.NumericUpDown inc_time;
        private System.Windows.Forms.NumericUpDown s_time;
        private System.Windows.Forms.NumericUpDown run_speed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_axis;
        private System.Windows.Forms.NumericUpDown run_pos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label errorLabel;
    }
}

