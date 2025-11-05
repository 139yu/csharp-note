namespace DrawROIRegion
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
            this.win_control = new HalconDotNet.HWindowControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_selectRoiRegion = new System.Windows.Forms.Button();
            this.btn_selectDeference = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // win_control
            // 
            this.win_control.BackColor = System.Drawing.Color.Black;
            this.win_control.BorderColor = System.Drawing.Color.Black;
            this.win_control.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.win_control.Location = new System.Drawing.Point(205, 20);
            this.win_control.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.win_control.Name = "win_control";
            this.win_control.Size = new System.Drawing.Size(860, 575);
            this.win_control.TabIndex = 0;
            this.win_control.WindowSize = new System.Drawing.Size(860, 575);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1270, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_openFile});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // menu_openFile
            // 
            this.menu_openFile.Name = "menu_openFile";
            this.menu_openFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menu_openFile.Size = new System.Drawing.Size(180, 22);
            this.menu_openFile.Text = "打开文件";
            this.menu_openFile.Click += new System.EventHandler(this.menu_openFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // btn_selectRoiRegion
            // 
            this.btn_selectRoiRegion.Location = new System.Drawing.Point(349, 685);
            this.btn_selectRoiRegion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_selectRoiRegion.Name = "btn_selectRoiRegion";
            this.btn_selectRoiRegion.Size = new System.Drawing.Size(135, 62);
            this.btn_selectRoiRegion.TabIndex = 2;
            this.btn_selectRoiRegion.Text = "选择ROI区域";
            this.btn_selectRoiRegion.UseVisualStyleBackColor = true;
            this.btn_selectRoiRegion.Click += new System.EventHandler(this.btn_selectRoiRegion_Click);
            // 
            // btn_selectDeference
            // 
            this.btn_selectDeference.Location = new System.Drawing.Point(550, 685);
            this.btn_selectDeference.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_selectDeference.Name = "btn_selectDeference";
            this.btn_selectDeference.Size = new System.Drawing.Size(135, 62);
            this.btn_selectDeference.TabIndex = 2;
            this.btn_selectDeference.Text = "选择不关注区域";
            this.btn_selectDeference.UseVisualStyleBackColor = true;
            this.btn_selectDeference.Click += new System.EventHandler(this.btn_selectDeference_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 843);
            this.Controls.Add(this.btn_selectDeference);
            this.Controls.Add(this.btn_selectRoiRegion);
            this.Controls.Add(this.win_control);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl win_control;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_selectRoiRegion;
        private System.Windows.Forms.Button btn_selectDeference;
    }
}

