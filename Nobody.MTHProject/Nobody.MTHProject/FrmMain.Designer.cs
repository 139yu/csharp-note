namespace Nobody.MTHProject
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.naviButton6 = new Nobody.MTHControlLib.NaviButton();
            this.naviButton5 = new Nobody.MTHControlLib.NaviButton();
            this.naviButton3 = new Nobody.MTHControlLib.NaviButton();
            this.naviButton4 = new Nobody.MTHControlLib.NaviButton();
            this.naviButton2 = new Nobody.MTHControlLib.NaviButton();
            this.navi_monitor = new Nobody.MTHControlLib.NaviButton();
            this.exit_btn = new System.Windows.Forms.Button();
            this.top_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.scroll_warning = new SeeSharpTools.JY.GUI.ScrollingText();
            this.label6 = new System.Windows.Forms.Label();
            this.right_btn = new System.Windows.Forms.Button();
            this.center_title = new System.Windows.Forms.Label();
            this.left_btn = new System.Windows.Forms.Button();
            this.mainPanel = new Nobody.MTHControlLib.PanelEx();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.naviButton6);
            this.panel1.Controls.Add(this.naviButton5);
            this.panel1.Controls.Add(this.naviButton3);
            this.panel1.Controls.Add(this.naviButton4);
            this.panel1.Controls.Add(this.naviButton2);
            this.panel1.Controls.Add(this.navi_monitor);
            this.panel1.Controls.Add(this.exit_btn);
            this.panel1.Controls.Add(this.top_title);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1440, 133);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // naviButton6
            // 
            this.naviButton6.BackColor = System.Drawing.Color.Transparent;
            this.naviButton6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton6.BackgroundImage")));
            this.naviButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton6.IsLeft = false;
            this.naviButton6.IsSelected = false;
            this.naviButton6.Location = new System.Drawing.Point(1282, 72);
            this.naviButton6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton6.Name = "naviButton6";
            this.naviButton6.Size = new System.Drawing.Size(129, 43);
            this.naviButton6.TabIndex = 3;
            this.naviButton6.TitleName = "用户管理";
            this.naviButton6.Click += new System.EventHandler(this.CommNaviBtn_Click);
            // 
            // naviButton5
            // 
            this.naviButton5.BackColor = System.Drawing.Color.Transparent;
            this.naviButton5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton5.BackgroundImage")));
            this.naviButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton5.IsLeft = false;
            this.naviButton5.IsSelected = false;
            this.naviButton5.Location = new System.Drawing.Point(1134, 72);
            this.naviButton5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton5.Name = "naviButton5";
            this.naviButton5.Size = new System.Drawing.Size(129, 43);
            this.naviButton5.TabIndex = 3;
            this.naviButton5.TitleName = "历史趋势";
            this.naviButton5.Click += new System.EventHandler(this.CommNaviBtn_Click);
            // 
            // naviButton3
            // 
            this.naviButton3.BackColor = System.Drawing.Color.Transparent;
            this.naviButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton3.BackgroundImage")));
            this.naviButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton3.IsLeft = true;
            this.naviButton3.IsSelected = false;
            this.naviButton3.Location = new System.Drawing.Point(324, 72);
            this.naviButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton3.Name = "naviButton3";
            this.naviButton3.Size = new System.Drawing.Size(129, 43);
            this.naviButton3.TabIndex = 3;
            this.naviButton3.TitleName = "配方管理";
            this.naviButton3.Click += new System.EventHandler(this.CommNaviBtn_Click);
            // 
            // naviButton4
            // 
            this.naviButton4.BackColor = System.Drawing.Color.Transparent;
            this.naviButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton4.BackgroundImage")));
            this.naviButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton4.IsLeft = false;
            this.naviButton4.IsSelected = false;
            this.naviButton4.Location = new System.Drawing.Point(986, 72);
            this.naviButton4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton4.Name = "naviButton4";
            this.naviButton4.Size = new System.Drawing.Size(129, 43);
            this.naviButton4.TabIndex = 3;
            this.naviButton4.TitleName = "报警追溯";
            this.naviButton4.Click += new System.EventHandler(this.CommNaviBtn_Click);
            // 
            // naviButton2
            // 
            this.naviButton2.BackColor = System.Drawing.Color.Transparent;
            this.naviButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviButton2.BackgroundImage")));
            this.naviButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.naviButton2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviButton2.IsLeft = true;
            this.naviButton2.IsSelected = false;
            this.naviButton2.Location = new System.Drawing.Point(176, 72);
            this.naviButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviButton2.Name = "naviButton2";
            this.naviButton2.Size = new System.Drawing.Size(129, 43);
            this.naviButton2.TabIndex = 3;
            this.naviButton2.TitleName = "参数设置";
            this.naviButton2.Click += new System.EventHandler(this.CommNaviBtn_Click);
            // 
            // navi_monitor
            // 
            this.navi_monitor.BackColor = System.Drawing.Color.Transparent;
            this.navi_monitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navi_monitor.BackgroundImage")));
            this.navi_monitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navi_monitor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navi_monitor.IsLeft = true;
            this.navi_monitor.IsSelected = false;
            this.navi_monitor.Location = new System.Drawing.Point(28, 72);
            this.navi_monitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navi_monitor.Name = "navi_monitor";
            this.navi_monitor.Size = new System.Drawing.Size(129, 43);
            this.navi_monitor.TabIndex = 3;
            this.navi_monitor.TitleName = "集中监控";
            this.navi_monitor.Click += new System.EventHandler(this.CommNaviBtn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.Exit;
            this.exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit_btn.FlatAppearance.BorderSize = 0;
            this.exit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.Location = new System.Drawing.Point(1347, 3);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(80, 30);
            this.exit_btn.TabIndex = 2;
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // top_title
            // 
            this.top_title.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.top_title.ForeColor = System.Drawing.Color.White;
            this.top_title.Location = new System.Drawing.Point(558, 36);
            this.top_title.Name = "top_title";
            this.top_title.Size = new System.Drawing.Size(321, 46);
            this.top_title.TabIndex = 1;
            this.top_title.Text = "多温湿度采集监控系统";
            this.top_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nobody";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Nobody.MTHProject.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Nobody.MTHProject.Properties.Resources.User;
            this.pictureBox2.Location = new System.Drawing.Point(12, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(38, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "管理员";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(98, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "欢迎登录！现在时间是";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(254, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "2025年9月13日 10:23:08 星期六";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.right_btn);
            this.panel2.Controls.Add(this.center_title);
            this.panel2.Controls.Add(this.left_btn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1440, 65);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.Alarm;
            this.panel3.Controls.Add(this.scroll_warning);
            this.panel3.Location = new System.Drawing.Point(1009, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 27);
            this.panel3.TabIndex = 4;
            // 
            // scroll_warning
            // 
            this.scroll_warning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(35)))), ((int)(((byte)(89)))));
            this.scroll_warning.BorderColor = System.Drawing.Color.Transparent;
            this.scroll_warning.BorderVisible = true;
            this.scroll_warning.Cursor = System.Windows.Forms.Cursors.Default;
            this.scroll_warning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scroll_warning.ForeColor = System.Drawing.Color.White;
            this.scroll_warning.Location = new System.Drawing.Point(0, 0);
            this.scroll_warning.Name = "scroll_warning";
            this.scroll_warning.Padding = new System.Windows.Forms.Padding(3);
            this.scroll_warning.ScrollDirection = SeeSharpTools.JY.GUI.ScrollingText.TextDirection.RightToLeft;
            this.scroll_warning.ScrollSpeed = 25;
            this.scroll_warning.Size = new System.Drawing.Size(300, 27);
            this.scroll_warning.TabIndex = 0;
            this.scroll_warning.Text = "当前系统无报警";
            this.scroll_warning.VerticleAligment = SeeSharpTools.JY.GUI.ScrollingText.TextVerticalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1315, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "通信状态";
            // 
            // right_btn
            // 
            this.right_btn.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.Right;
            this.right_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.right_btn.FlatAppearance.BorderSize = 0;
            this.right_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.right_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.right_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.right_btn.Location = new System.Drawing.Point(805, 11);
            this.right_btn.Name = "right_btn";
            this.right_btn.Size = new System.Drawing.Size(50, 40);
            this.right_btn.TabIndex = 2;
            this.right_btn.UseVisualStyleBackColor = true;
            // 
            // center_title
            // 
            this.center_title.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.center_title.ForeColor = System.Drawing.Color.White;
            this.center_title.Image = global::Nobody.MTHProject.Properties.Resources.Current;
            this.center_title.Location = new System.Drawing.Point(620, 9);
            this.center_title.Name = "center_title";
            this.center_title.Size = new System.Drawing.Size(189, 46);
            this.center_title.TabIndex = 1;
            this.center_title.Text = "集中监控";
            this.center_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // left_btn
            // 
            this.left_btn.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.Left;
            this.left_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.left_btn.FlatAppearance.BorderSize = 0;
            this.left_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.left_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.left_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left_btn.Location = new System.Drawing.Point(564, 11);
            this.left_btn.Name = "left_btn";
            this.left_btn.Size = new System.Drawing.Size(50, 40);
            this.left_btn.TabIndex = 2;
            this.left_btn.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.mainPanel.BorderWidth = 2F;
            this.mainPanel.BottomGrap = 20;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.LeftGrap = 10;
            this.mainPanel.Location = new System.Drawing.Point(0, 198);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RightGrap = 10;
            this.mainPanel.Size = new System.Drawing.Size(1440, 762);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.TopGrap = 20;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.Main;
            this.ClientSize = new System.Drawing.Size(1440, 960);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Label top_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button right_btn;
        private System.Windows.Forms.Button left_btn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label center_title;
        private MTHControlLib.NaviButton naviButton6;
        private MTHControlLib.NaviButton naviButton5;
        private MTHControlLib.NaviButton naviButton3;
        private MTHControlLib.NaviButton naviButton4;
        private MTHControlLib.NaviButton naviButton2;
        private MTHControlLib.NaviButton navi_monitor;
        private MTHControlLib.PanelEx mainPanel;
        private SeeSharpTools.JY.GUI.ScrollingText scroll_warning;
    }
}

