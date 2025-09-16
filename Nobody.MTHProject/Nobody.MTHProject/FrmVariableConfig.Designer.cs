namespace Nobody.MTHProject
{
    partial class FrmVariableConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new Nobody.MTHControlLib.PanelEx();
            this.btn_editVariable = new System.Windows.Forms.Button();
            this.btn_delVariable = new System.Windows.Forms.Button();
            this.btn_addVariable = new System.Windows.Forms.Button();
            this.check_negAlarm = new Nobody.MTHControlLib.CheckBoxEx();
            this.check_posAlarm = new Nobody.MTHControlLib.CheckBoxEx();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.txt_varName = new System.Windows.Forms.TextBox();
            this.selector_dataType = new System.Windows.Forms.ComboBox();
            this.selector_groupName = new System.Windows.Forms.ComboBox();
            this.dgv_main = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosAlarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NegAlarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_length = new System.Windows.Forms.NumericUpDown();
            this.txt_offset = new System.Windows.Forms.NumericUpDown();
            this.txt_scale = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_start = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_scale)).BeginInit();
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
            this.panelEx1.Controls.Add(this.btn_editVariable);
            this.panelEx1.Controls.Add(this.btn_delVariable);
            this.panelEx1.Controls.Add(this.btn_addVariable);
            this.panelEx1.Controls.Add(this.check_negAlarm);
            this.panelEx1.Controls.Add(this.check_posAlarm);
            this.panelEx1.Controls.Add(this.txt_remark);
            this.panelEx1.Controls.Add(this.txt_varName);
            this.panelEx1.Controls.Add(this.selector_dataType);
            this.panelEx1.Controls.Add(this.selector_groupName);
            this.panelEx1.Controls.Add(this.dgv_main);
            this.panelEx1.Controls.Add(this.txt_length);
            this.panelEx1.Controls.Add(this.txt_offset);
            this.panelEx1.Controls.Add(this.txt_scale);
            this.panelEx1.Controls.Add(this.label7);
            this.panelEx1.Controls.Add(this.label8);
            this.panelEx1.Controls.Add(this.txt_start);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.label9);
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
            // btn_editVariable
            // 
            this.btn_editVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_editVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editVariable.ForeColor = System.Drawing.Color.White;
            this.btn_editVariable.Location = new System.Drawing.Point(835, 173);
            this.btn_editVariable.Name = "btn_editVariable";
            this.btn_editVariable.Size = new System.Drawing.Size(110, 30);
            this.btn_editVariable.TabIndex = 11;
            this.btn_editVariable.Text = "修改变量";
            this.btn_editVariable.UseVisualStyleBackColor = false;
            this.btn_editVariable.Click += new System.EventHandler(this.btn_editVariable_Click);
            // 
            // btn_delVariable
            // 
            this.btn_delVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_delVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delVariable.ForeColor = System.Drawing.Color.White;
            this.btn_delVariable.Location = new System.Drawing.Point(663, 173);
            this.btn_delVariable.Name = "btn_delVariable";
            this.btn_delVariable.Size = new System.Drawing.Size(110, 30);
            this.btn_delVariable.TabIndex = 12;
            this.btn_delVariable.Text = "删除变量";
            this.btn_delVariable.UseVisualStyleBackColor = false;
            this.btn_delVariable.Click += new System.EventHandler(this.btn_delVariable_Click);
            // 
            // btn_addVariable
            // 
            this.btn_addVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_addVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addVariable.ForeColor = System.Drawing.Color.White;
            this.btn_addVariable.Location = new System.Drawing.Point(491, 173);
            this.btn_addVariable.Name = "btn_addVariable";
            this.btn_addVariable.Size = new System.Drawing.Size(110, 30);
            this.btn_addVariable.TabIndex = 13;
            this.btn_addVariable.Text = "新增变量";
            this.btn_addVariable.UseVisualStyleBackColor = false;
            this.btn_addVariable.Click += new System.EventHandler(this.btn_addVariable_Click);
            // 
            // check_negAlarm
            // 
            this.check_negAlarm.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.check_negAlarm.CheckButtonWidth = 20;
            this.check_negAlarm.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.check_negAlarm.ForeColor = System.Drawing.Color.White;
            this.check_negAlarm.Location = new System.Drawing.Point(423, 123);
            this.check_negAlarm.Name = "check_negAlarm";
            this.check_negAlarm.Size = new System.Drawing.Size(124, 32);
            this.check_negAlarm.TabIndex = 10;
            this.check_negAlarm.Text = "下降沿报警";
            this.check_negAlarm.UseVisualStyleBackColor = true;
            // 
            // check_posAlarm
            // 
            this.check_posAlarm.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.check_posAlarm.CheckButtonWidth = 20;
            this.check_posAlarm.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.check_posAlarm.ForeColor = System.Drawing.Color.White;
            this.check_posAlarm.Location = new System.Drawing.Point(275, 123);
            this.check_posAlarm.Name = "check_posAlarm";
            this.check_posAlarm.Size = new System.Drawing.Size(124, 32);
            this.check_posAlarm.TabIndex = 10;
            this.check_posAlarm.Text = "上升沿报警";
            this.check_posAlarm.UseVisualStyleBackColor = true;
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(128, 172);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(331, 29);
            this.txt_remark.TabIndex = 9;
            // 
            // txt_varName
            // 
            this.txt_varName.Location = new System.Drawing.Point(380, 77);
            this.txt_varName.Name = "txt_varName";
            this.txt_varName.Size = new System.Drawing.Size(138, 29);
            this.txt_varName.TabIndex = 9;
            // 
            // selector_dataType
            // 
            this.selector_dataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selector_dataType.FormattingEnabled = true;
            this.selector_dataType.Location = new System.Drawing.Point(128, 125);
            this.selector_dataType.Name = "selector_dataType";
            this.selector_dataType.Size = new System.Drawing.Size(121, 29);
            this.selector_dataType.TabIndex = 8;
            // 
            // selector_groupName
            // 
            this.selector_groupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selector_groupName.FormattingEnabled = true;
            this.selector_groupName.Location = new System.Drawing.Point(128, 76);
            this.selector_groupName.Name = "selector_groupName";
            this.selector_groupName.Size = new System.Drawing.Size(121, 29);
            this.selector_groupName.TabIndex = 8;
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
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgv_main.ColumnHeadersHeight = 30;
            this.dgv_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.VarName,
            this.Start,
            this.Length,
            this.DataType,
            this.Scale,
            this.Offset,
            this.PosAlarm,
            this.NegAlarm,
            this.Remark});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_main.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgv_main.EnableHeadersVisualStyles = false;
            this.dgv_main.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgv_main.Location = new System.Drawing.Point(26, 241);
            this.dgv_main.Name = "dgv_main";
            this.dgv_main.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_main.RowsDefaultCellStyle = dataGridViewCellStyle20;
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
            this.GroupName.HeaderText = "通信组";
            this.GroupName.Name = "GroupName";
            this.GroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VarName
            // 
            this.VarName.DataPropertyName = "VarName";
            this.VarName.HeaderText = "变量名";
            this.VarName.Name = "VarName";
            this.VarName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Start
            // 
            this.Start.DataPropertyName = "Start";
            this.Start.HeaderText = "起始地址";
            this.Start.Name = "Start";
            this.Start.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            this.Length.HeaderText = "长度";
            this.Length.Name = "Length";
            this.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Length.Width = 70;
            // 
            // DataType
            // 
            this.DataType.DataPropertyName = "DataType";
            this.DataType.HeaderText = "数据类型";
            this.DataType.Name = "DataType";
            this.DataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Scale
            // 
            this.Scale.DataPropertyName = "Scale";
            this.Scale.HeaderText = "系数";
            this.Scale.Name = "Scale";
            this.Scale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Scale.Width = 70;
            // 
            // Offset
            // 
            this.Offset.DataPropertyName = "Offset";
            this.Offset.HeaderText = "偏移量";
            this.Offset.Name = "Offset";
            this.Offset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Offset.Width = 70;
            // 
            // PosAlarm
            // 
            this.PosAlarm.DataPropertyName = "PosAlarm";
            this.PosAlarm.HeaderText = "上升沿报警";
            this.PosAlarm.Name = "PosAlarm";
            // 
            // NegAlarm
            // 
            this.NegAlarm.DataPropertyName = "NegAlarm";
            this.NegAlarm.HeaderText = "下降沿报警";
            this.NegAlarm.Name = "NegAlarm";
            this.NegAlarm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注说明";
            this.Remark.Name = "Remark";
            this.Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_length
            // 
            this.txt_length.Location = new System.Drawing.Point(837, 76);
            this.txt_length.Name = "txt_length";
            this.txt_length.Size = new System.Drawing.Size(92, 29);
            this.txt_length.TabIndex = 4;
            // 
            // txt_offset
            // 
            this.txt_offset.DecimalPlaces = 2;
            this.txt_offset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txt_offset.Location = new System.Drawing.Point(837, 125);
            this.txt_offset.Name = "txt_offset";
            this.txt_offset.Size = new System.Drawing.Size(92, 29);
            this.txt_offset.TabIndex = 4;
            // 
            // txt_scale
            // 
            this.txt_scale.DecimalPlaces = 2;
            this.txt_scale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.txt_scale.Location = new System.Drawing.Point(625, 124);
            this.txt_scale.Name = "txt_scale";
            this.txt_scale.Size = new System.Drawing.Size(92, 29);
            this.txt_scale.TabIndex = 4;
            this.txt_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(736, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "长度";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(750, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "偏移量";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_start
            // 
            this.txt_start.Location = new System.Drawing.Point(617, 77);
            this.txt_start.Name = "txt_start";
            this.txt_start.Size = new System.Drawing.Size(92, 29);
            this.txt_start.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(540, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "系数";
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
            this.label4.Text = "起始地址";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(28, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "备注说明";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.button1.Location = new System.Drawing.Point(955, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 33);
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
            this.label3.Location = new System.Drawing.Point(280, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "变量名称";
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
            this.label6.Text = "数据类型";
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
            // FrmVariableConfig
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
            this.Name = "FrmVariableConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmGroupConfig";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_start)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEx panelEx1;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txt_start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_main;
        private System.Windows.Forms.TextBox txt_varName;
        private System.Windows.Forms.NumericUpDown txt_scale;
        private MTHControlLib.CheckBoxEx check_posAlarm;
        private System.Windows.Forms.ComboBox selector_dataType;
        private System.Windows.Forms.ComboBox selector_groupName;
        private MTHControlLib.CheckBoxEx check_negAlarm;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.NumericUpDown txt_length;
        private System.Windows.Forms.NumericUpDown txt_offset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_editVariable;
        private System.Windows.Forms.Button btn_delVariable;
        private System.Windows.Forms.Button btn_addVariable;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn NegAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}