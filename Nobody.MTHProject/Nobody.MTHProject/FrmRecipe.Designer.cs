namespace Nobody.MTHProject
{
    partial class FrmRecipe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Nobody.MTHModels.RecipeParam recipeParam1 = new Nobody.MTHModels.RecipeParam();
            Nobody.MTHModels.RecipeParam recipeParam2 = new Nobody.MTHModels.RecipeParam();
            Nobody.MTHModels.RecipeParam recipeParam3 = new Nobody.MTHModels.RecipeParam();
            Nobody.MTHModels.RecipeParam recipeParam4 = new Nobody.MTHModels.RecipeParam();
            Nobody.MTHModels.RecipeParam recipeParam5 = new Nobody.MTHModels.RecipeParam();
            Nobody.MTHModels.RecipeParam recipeParam6 = new Nobody.MTHModels.RecipeParam();
            this.panelEnhanced1 = new Nobody.MTHControlLib.PanelEnhanced();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_currentRecipe = new System.Windows.Forms.Label();
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_delRecipe = new System.Windows.Forms.Button();
            this.btn_modifyRecipe = new System.Windows.Forms.Button();
            this.btn_addRecipe = new System.Windows.Forms.Button();
            this.txt_targetRecipe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_main = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeControl6 = new Nobody.MTHControlLib.RecipeControl();
            this.recipeControl5 = new Nobody.MTHControlLib.RecipeControl();
            this.recipeControl4 = new Nobody.MTHControlLib.RecipeControl();
            this.recipeControl3 = new Nobody.MTHControlLib.RecipeControl();
            this.recipeControl2 = new Nobody.MTHControlLib.RecipeControl();
            this.recipeControl1 = new Nobody.MTHControlLib.RecipeControl();
            this.panelEnhanced1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackColor = System.Drawing.Color.Transparent;
            this.panelEnhanced1.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.BackGround;
            this.panelEnhanced1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelEnhanced1.Controls.Add(this.splitContainer1);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1440, 760);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbl_currentRecipe);
            this.splitContainer1.Panel1.Controls.Add(this.btn_apply);
            this.splitContainer1.Panel1.Controls.Add(this.btn_delRecipe);
            this.splitContainer1.Panel1.Controls.Add(this.btn_modifyRecipe);
            this.splitContainer1.Panel1.Controls.Add(this.btn_addRecipe);
            this.splitContainer1.Panel1.Controls.Add(this.txt_targetRecipe);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_main);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl6);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl5);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl4);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl3);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl2);
            this.splitContainer1.Panel2.Controls.Add(this.recipeControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1440, 760);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbl_currentRecipe
            // 
            this.lbl_currentRecipe.BackColor = System.Drawing.Color.Transparent;
            this.lbl_currentRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_currentRecipe.Location = new System.Drawing.Point(111, 527);
            this.lbl_currentRecipe.Name = "lbl_currentRecipe";
            this.lbl_currentRecipe.Size = new System.Drawing.Size(160, 23);
            this.lbl_currentRecipe.TabIndex = 15;
            this.lbl_currentRecipe.Text = "当前配方";
            this.lbl_currentRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_apply
            // 
            this.btn_apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_apply.ForeColor = System.Drawing.Color.White;
            this.btn_apply.Location = new System.Drawing.Point(162, 687);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(110, 30);
            this.btn_apply.TabIndex = 14;
            this.btn_apply.Text = "应用配方";
            this.btn_apply.UseVisualStyleBackColor = false;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // btn_delRecipe
            // 
            this.btn_delRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_delRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delRecipe.ForeColor = System.Drawing.Color.White;
            this.btn_delRecipe.Location = new System.Drawing.Point(25, 687);
            this.btn_delRecipe.Name = "btn_delRecipe";
            this.btn_delRecipe.Size = new System.Drawing.Size(110, 30);
            this.btn_delRecipe.TabIndex = 14;
            this.btn_delRecipe.Text = "删除配方";
            this.btn_delRecipe.UseVisualStyleBackColor = false;
            this.btn_delRecipe.Click += new System.EventHandler(this.btn_delRecipe_Click);
            // 
            // btn_modifyRecipe
            // 
            this.btn_modifyRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_modifyRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modifyRecipe.ForeColor = System.Drawing.Color.White;
            this.btn_modifyRecipe.Location = new System.Drawing.Point(162, 628);
            this.btn_modifyRecipe.Name = "btn_modifyRecipe";
            this.btn_modifyRecipe.Size = new System.Drawing.Size(110, 30);
            this.btn_modifyRecipe.TabIndex = 14;
            this.btn_modifyRecipe.Text = "修改配方";
            this.btn_modifyRecipe.UseVisualStyleBackColor = false;
            this.btn_modifyRecipe.Click += new System.EventHandler(this.btn_modifyRecipe_Click);
            // 
            // btn_addRecipe
            // 
            this.btn_addRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_addRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addRecipe.ForeColor = System.Drawing.Color.White;
            this.btn_addRecipe.Location = new System.Drawing.Point(25, 628);
            this.btn_addRecipe.Name = "btn_addRecipe";
            this.btn_addRecipe.Size = new System.Drawing.Size(110, 30);
            this.btn_addRecipe.TabIndex = 14;
            this.btn_addRecipe.Text = "添加配方";
            this.btn_addRecipe.UseVisualStyleBackColor = false;
            this.btn_addRecipe.Click += new System.EventHandler(this.btn_addRecipe_Click);
            // 
            // txt_targetRecipe
            // 
            this.txt_targetRecipe.Location = new System.Drawing.Point(112, 570);
            this.txt_targetRecipe.Name = "txt_targetRecipe";
            this.txt_targetRecipe.Size = new System.Drawing.Size(160, 23);
            this.txt_targetRecipe.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label2.Location = new System.Drawing.Point(21, 572);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "配方名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label1.Location = new System.Drawing.Point(21, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前配方：";
            // 
            // dgv_main
            // 
            this.dgv_main.AllowUserToAddRows = false;
            this.dgv_main.AllowUserToDeleteRows = false;
            this.dgv_main.AllowUserToResizeColumns = false;
            this.dgv_main.AllowUserToResizeRows = false;
            this.dgv_main.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_main.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_main.ColumnHeadersHeight = 30;
            this.dgv_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_main.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_main.EnableHeadersVisualStyles = false;
            this.dgv_main.GridColor = System.Drawing.Color.White;
            this.dgv_main.Location = new System.Drawing.Point(12, 23);
            this.dgv_main.Name = "dgv_main";
            this.dgv_main.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_main.RowHeadersVisible = false;
            this.dgv_main.RowHeadersWidth = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgv_main.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_main.RowTemplate.Height = 23;
            this.dgv_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_main.Size = new System.Drawing.Size(280, 467);
            this.dgv_main.TabIndex = 0;
            this.dgv_main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_main_CellClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(38)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "配方名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // recipeControl6
            // 
            this.recipeControl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.recipeControl6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl6.Location = new System.Drawing.Point(753, 405);
            this.recipeControl6.Margin = new System.Windows.Forms.Padding(4);
            this.recipeControl6.Name = "recipeControl6";
            recipeParam1.HumidityAlarmEnable = false;
            recipeParam1.HumidityHigh = 0F;
            recipeParam1.HumidityLow = 0F;
            recipeParam1.TempAlarmEnable = false;
            recipeParam1.TempHigh = 0F;
            recipeParam1.TempLow = 0F;
            this.recipeControl6.RecipeParam = recipeParam1;
            this.recipeControl6.SiteName = "6#站点";
            this.recipeControl6.Size = new System.Drawing.Size(305, 328);
            this.recipeControl6.TabIndex = 0;
            // 
            // recipeControl5
            // 
            this.recipeControl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.recipeControl5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl5.Location = new System.Drawing.Point(385, 405);
            this.recipeControl5.Margin = new System.Windows.Forms.Padding(4);
            this.recipeControl5.Name = "recipeControl5";
            recipeParam2.HumidityAlarmEnable = false;
            recipeParam2.HumidityHigh = 0F;
            recipeParam2.HumidityLow = 0F;
            recipeParam2.TempAlarmEnable = false;
            recipeParam2.TempHigh = 0F;
            recipeParam2.TempLow = 0F;
            this.recipeControl5.RecipeParam = recipeParam2;
            this.recipeControl5.SiteName = "5#站点";
            this.recipeControl5.Size = new System.Drawing.Size(305, 328);
            this.recipeControl5.TabIndex = 0;
            // 
            // recipeControl4
            // 
            this.recipeControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.recipeControl4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl4.Location = new System.Drawing.Point(17, 405);
            this.recipeControl4.Margin = new System.Windows.Forms.Padding(4);
            this.recipeControl4.Name = "recipeControl4";
            recipeParam3.HumidityAlarmEnable = false;
            recipeParam3.HumidityHigh = 0F;
            recipeParam3.HumidityLow = 0F;
            recipeParam3.TempAlarmEnable = false;
            recipeParam3.TempHigh = 0F;
            recipeParam3.TempLow = 0F;
            this.recipeControl4.RecipeParam = recipeParam3;
            this.recipeControl4.SiteName = "4#站点";
            this.recipeControl4.Size = new System.Drawing.Size(305, 328);
            this.recipeControl4.TabIndex = 0;
            // 
            // recipeControl3
            // 
            this.recipeControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.recipeControl3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl3.Location = new System.Drawing.Point(753, 23);
            this.recipeControl3.Margin = new System.Windows.Forms.Padding(4);
            this.recipeControl3.Name = "recipeControl3";
            recipeParam4.HumidityAlarmEnable = false;
            recipeParam4.HumidityHigh = 0F;
            recipeParam4.HumidityLow = 0F;
            recipeParam4.TempAlarmEnable = false;
            recipeParam4.TempHigh = 0F;
            recipeParam4.TempLow = 0F;
            this.recipeControl3.RecipeParam = recipeParam4;
            this.recipeControl3.SiteName = "3#站点";
            this.recipeControl3.Size = new System.Drawing.Size(305, 328);
            this.recipeControl3.TabIndex = 0;
            // 
            // recipeControl2
            // 
            this.recipeControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.recipeControl2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl2.Location = new System.Drawing.Point(385, 23);
            this.recipeControl2.Margin = new System.Windows.Forms.Padding(4);
            this.recipeControl2.Name = "recipeControl2";
            recipeParam5.HumidityAlarmEnable = false;
            recipeParam5.HumidityHigh = 0F;
            recipeParam5.HumidityLow = 0F;
            recipeParam5.TempAlarmEnable = false;
            recipeParam5.TempHigh = 0F;
            recipeParam5.TempLow = 0F;
            this.recipeControl2.RecipeParam = recipeParam5;
            this.recipeControl2.SiteName = "2#站点";
            this.recipeControl2.Size = new System.Drawing.Size(305, 328);
            this.recipeControl2.TabIndex = 0;
            // 
            // recipeControl1
            // 
            this.recipeControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.recipeControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recipeControl1.Location = new System.Drawing.Point(17, 23);
            this.recipeControl1.Margin = new System.Windows.Forms.Padding(4);
            this.recipeControl1.Name = "recipeControl1";
            recipeParam6.HumidityAlarmEnable = false;
            recipeParam6.HumidityHigh = 0F;
            recipeParam6.HumidityLow = 0F;
            recipeParam6.TempAlarmEnable = false;
            recipeParam6.TempHigh = 0F;
            recipeParam6.TempLow = 0F;
            this.recipeControl1.RecipeParam = recipeParam6;
            this.recipeControl1.SiteName = "1#站点";
            this.recipeControl1.Size = new System.Drawing.Size(305, 328);
            this.recipeControl1.TabIndex = 0;
            // 
            // FrmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1440, 760);
            this.Controls.Add(this.panelEnhanced1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRecipe";
            this.panelEnhanced1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_main;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox txt_targetRecipe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button btn_delRecipe;
        private System.Windows.Forms.Button btn_modifyRecipe;
        private System.Windows.Forms.Button btn_addRecipe;
        private MTHControlLib.RecipeControl recipeControl6;
        private MTHControlLib.RecipeControl recipeControl5;
        private MTHControlLib.RecipeControl recipeControl4;
        private MTHControlLib.RecipeControl recipeControl3;
        private MTHControlLib.RecipeControl recipeControl2;
        private MTHControlLib.RecipeControl recipeControl1;
        private System.Windows.Forms.Label lbl_currentRecipe;
    }
}
