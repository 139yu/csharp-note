namespace Nobody.MTHControlLib
{
    partial class TextSetEx
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
            this.lbl_titleName = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.NumericUpDown();
            this.lbl_unit = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_value)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.1129F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.8871F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_titleName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_value, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_unit, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_titleName
            // 
            this.lbl_titleName.AutoSize = true;
            this.lbl_titleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_titleName.Location = new System.Drawing.Point(4, 0);
            this.lbl_titleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_titleName.Name = "lbl_titleName";
            this.lbl_titleName.Size = new System.Drawing.Size(149, 40);
            this.lbl_titleName.TabIndex = 0;
            this.lbl_titleName.Text = "1#站点温度限高";
            this.lbl_titleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_value
            // 
            this.txt_value.AutoSize = true;
            this.txt_value.DecimalPlaces = 2;
            this.txt_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_value.Location = new System.Drawing.Point(160, 8);
            this.txt_value.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(82, 23);
            this.txt_value.TabIndex = 1;
            // 
            // lbl_unit
            // 
            this.lbl_unit.AutoSize = true;
            this.lbl_unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_unit.Location = new System.Drawing.Point(248, 0);
            this.lbl_unit.Name = "lbl_unit";
            this.lbl_unit.Size = new System.Drawing.Size(49, 40);
            this.lbl_unit.TabIndex = 2;
            this.lbl_unit.Text = "°C";
            this.lbl_unit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextSetEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TextSetEx";
            this.Size = new System.Drawing.Size(300, 40);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_titleName;
        private System.Windows.Forms.NumericUpDown txt_value;
        private System.Windows.Forms.Label lbl_unit;
    }
}
