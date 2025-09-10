namespace GetCardInfo
{
    partial class form
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
            this.init_card = new System.Windows.Forms.Button();
            this.close_card = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.card_no = new System.Windows.Forms.Label();
            this.axis = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.error_info = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // init_card
            // 
            this.init_card.Location = new System.Drawing.Point(77, 48);
            this.init_card.Name = "init_card";
            this.init_card.Size = new System.Drawing.Size(85, 30);
            this.init_card.TabIndex = 0;
            this.init_card.Text = "初始化轴卡";
            this.init_card.UseVisualStyleBackColor = true;
            this.init_card.Click += new System.EventHandler(this.init_card_Click);
            // 
            // close_card
            // 
            this.close_card.Location = new System.Drawing.Point(218, 48);
            this.close_card.Name = "close_card";
            this.close_card.Size = new System.Drawing.Size(85, 30);
            this.close_card.TabIndex = 0;
            this.close_card.Text = "关闭轴卡";
            this.close_card.UseVisualStyleBackColor = true;
            this.close_card.Click += new System.EventHandler(this.init_card_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "卡号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "轴数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "固件版本";
            // 
            // card_no
            // 
            this.card_no.AutoSize = true;
            this.card_no.Location = new System.Drawing.Point(216, 142);
            this.card_no.Name = "card_no";
            this.card_no.Size = new System.Drawing.Size(35, 12);
            this.card_no.TabIndex = 1;
            this.card_no.Text = "label";
            // 
            // axis
            // 
            this.axis.AutoSize = true;
            this.axis.Location = new System.Drawing.Point(216, 178);
            this.axis.Name = "axis";
            this.axis.Size = new System.Drawing.Size(35, 12);
            this.axis.TabIndex = 1;
            this.axis.Text = "label";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(216, 214);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(35, 12);
            this.version.TabIndex = 1;
            this.version.Text = "label";
            // 
            // error_info
            // 
            this.error_info.AutoSize = true;
            this.error_info.ForeColor = System.Drawing.Color.Red;
            this.error_info.Location = new System.Drawing.Point(216, 250);
            this.error_info.Name = "error_info";
            this.error_info.Size = new System.Drawing.Size(35, 12);
            this.error_info.TabIndex = 1;
            this.error_info.Text = "label";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "错误信息";
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 386);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.error_info);
            this.Controls.Add(this.version);
            this.Controls.Add(this.axis);
            this.Controls.Add(this.card_no);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close_card);
            this.Controls.Add(this.init_card);
            this.Name = "form";
            this.Text = "获取轴卡基本信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button init_card;
        private System.Windows.Forms.Button close_card;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label card_no;
        private System.Windows.Forms.Label axis;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label error_info;
        private System.Windows.Forms.Label label4;
    }
}

