namespace Nobody.MTHProject
{
    partial class FrmGroupConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new Nobody.MTHControlLib.PanelEx();
            this.dgv_main = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_editGroup = new System.Windows.Forms.Button();
            this.btn_delGroup = new System.Windows.Forms.Button();
            this.btn_addGroup = new System.Windows.Forms.Button();
            this.selector_storeArea = new System.Windows.Forms.ComboBox();
            this.txt_length = new System.Windows.Forms.NumericUpDown();
            this.txt_start = new System.Windows.Forms.NumericUpDown();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.txt_groupName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_start)).BeginInit();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.panelEx1.BorderWidth = 2F;
            this.panelEx1.BottomGrap = 5;
            this.panelEx1.Controls.Add(this.dgv_main);
            this.panelEx1.Controls.Add(this.btn_editGroup);
            this.panelEx1.Controls.Add(this.btn_delGroup);
            this.panelEx1.Controls.Add(this.btn_addGroup);
            this.panelEx1.Controls.Add(this.selector_storeArea);
            this.panelEx1.Controls.Add(this.txt_length);
            this.panelEx1.Controls.Add(this.txt_start);
            this.panelEx1.Controls.Add(this.txt_remark);
            this.panelEx1.Controls.Add(this.txt_groupName);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.panel_top);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.label6);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.LeftGrap = 5;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightGrap = 5;
            this.panelEx1.Size = new System.Drawing.Size(1000, 640);
            this.panelEx1.TabIndex = 0;
            this.panelEx1.TopGrap = 5;
            // 
            // dgv_main
            // 
            this.dgv_main.AllowUserToAddRows = false;
            this.dgv_main.AllowUserToDeleteRows = false;
            this.dgv_main.AllowUserToOrderColumns = true;
            this.dgv_main.AllowUserToResizeColumns = false;
            this.dgv_main.AllowUserToResizeRows = false;
            this.dgv_main.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_main.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_main.ColumnHeadersHeight = 30;
            this.dgv_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.Start,
            this.Length,
            this.StoreArea,
            this.Remark});
            this.dgv_main.EnableHeadersVisualStyles = false;
            this.dgv_main.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgv_main.Location = new System.Drawing.Point(26, 241);
            this.dgv_main.Name = "dgv_main";
            this.dgv_main.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_main.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_main.RowTemplate.Height = 25;
            this.dgv_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_main.Size = new System.Drawing.Size(943, 371);
            this.dgv_main.TabIndex = 7;
            this.dgv_main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_main_CellClick);
            this.dgv_main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_main_CellFormatting);
            this.dgv_main.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_main_RowPostPaint);
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "通信组名称";
            this.GroupName.Name = "GroupName";
            this.GroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GroupName.Width = 140;
            // 
            // Start
            // 
            this.Start.DataPropertyName = "Start";
            this.Start.HeaderText = "起始地址";
            this.Start.Name = "Start";
            this.Start.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Start.Width = 120;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            this.Length.HeaderText = "长度";
            this.Length.Name = "Length";
            this.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Length.Width = 120;
            // 
            // StoreArea
            // 
            this.StoreArea.DataPropertyName = "StoreArea";
            this.StoreArea.HeaderText = "储存区名称";
            this.StoreArea.Name = "StoreArea";
            this.StoreArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StoreArea.Width = 140;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注说明";
            this.Remark.Name = "Remark";
            this.Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn_editGroup
            // 
            this.btn_editGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_editGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editGroup.ForeColor = System.Drawing.Color.White;
            this.btn_editGroup.Location = new System.Drawing.Point(859, 127);
            this.btn_editGroup.Name = "btn_editGroup";
            this.btn_editGroup.Size = new System.Drawing.Size(110, 30);
            this.btn_editGroup.TabIndex = 6;
            this.btn_editGroup.Text = "修改通信组";
            this.btn_editGroup.UseVisualStyleBackColor = false;
            this.btn_editGroup.Click += new System.EventHandler(this.btn_editGroup_Click);
            // 
            // btn_delGroup
            // 
            this.btn_delGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_delGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delGroup.ForeColor = System.Drawing.Color.White;
            this.btn_delGroup.Location = new System.Drawing.Point(687, 127);
            this.btn_delGroup.Name = "btn_delGroup";
            this.btn_delGroup.Size = new System.Drawing.Size(110, 30);
            this.btn_delGroup.TabIndex = 6;
            this.btn_delGroup.Text = "删除通信组";
            this.btn_delGroup.UseVisualStyleBackColor = false;
            this.btn_delGroup.Click += new System.EventHandler(this.btn_delGroup_Click);
            // 
            // btn_addGroup
            // 
            this.btn_addGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_addGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addGroup.ForeColor = System.Drawing.Color.White;
            this.btn_addGroup.Location = new System.Drawing.Point(515, 127);
            this.btn_addGroup.Name = "btn_addGroup";
            this.btn_addGroup.Size = new System.Drawing.Size(110, 30);
            this.btn_addGroup.TabIndex = 6;
            this.btn_addGroup.Text = "新增通信组";
            this.btn_addGroup.UseVisualStyleBackColor = false;
            this.btn_addGroup.Click += new System.EventHandler(this.btn_addGroup_Click);
            // 
            // selector_storeArea
            // 
            this.selector_storeArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selector_storeArea.FormattingEnabled = true;
            this.selector_storeArea.Location = new System.Drawing.Point(848, 77);
            this.selector_storeArea.Name = "selector_storeArea";
            this.selector_storeArea.Size = new System.Drawing.Size(121, 29);
            this.selector_storeArea.TabIndex = 5;
            // 
            // txt_length
            // 
            this.txt_length.Location = new System.Drawing.Point(617, 77);
            this.txt_length.Name = "txt_length";
            this.txt_length.Size = new System.Drawing.Size(92, 29);
            this.txt_length.TabIndex = 4;
            // 
            // txt_start
            // 
            this.txt_start.Location = new System.Drawing.Point(391, 77);
            this.txt_start.Name = "txt_start";
            this.txt_start.Size = new System.Drawing.Size(92, 29);
            this.txt_start.TabIndex = 4;
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(128, 126);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(355, 29);
            this.txt_remark.TabIndex = 3;
            // 
            // txt_groupName
            // 
            this.txt_groupName.Location = new System.Drawing.Point(128, 77);
            this.txt_groupName.Name = "txt_groupName";
            this.txt_groupName.Size = new System.Drawing.Size(121, 29);
            this.txt_groupName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(742, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "储存区名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(511, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "长度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.button1);
            this.panel_top.Controls.Add(this.label1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1000, 55);
            this.panel_top.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑 Light", 13.75F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(954, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "通信组配置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(285, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "起始地址";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(22, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "备注说明";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "通信组名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmGroupConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.BackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmGroupConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmGroupConfig";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_start)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEx panelEx1;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txt_length;
        private System.Windows.Forms.NumericUpDown txt_start;
        private System.Windows.Forms.TextBox txt_groupName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selector_storeArea;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_main;
        private System.Windows.Forms.Button btn_editGroup;
        private System.Windows.Forms.Button btn_delGroup;
        private System.Windows.Forms.Button btn_addGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}