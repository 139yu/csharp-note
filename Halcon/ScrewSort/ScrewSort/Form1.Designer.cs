namespace ScrewSort
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
            this.halconWindow = new HalconDotNet.HWindowControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // halconWindow
            // 
            this.halconWindow.BackColor = System.Drawing.Color.Black;
            this.halconWindow.BorderColor = System.Drawing.Color.Black;
            this.halconWindow.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.halconWindow.Location = new System.Drawing.Point(200, 26);
            this.halconWindow.Name = "halconWindow";
            this.halconWindow.Size = new System.Drawing.Size(397, 302);
            this.halconWindow.TabIndex = 0;
            this.halconWindow.WindowSize = new System.Drawing.Size(397, 302);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "螺丝分拣";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.halconWindow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HalconDotNet.HWindowControl halconWindow;
        private System.Windows.Forms.Button button1;
    }
}

