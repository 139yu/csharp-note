namespace Nobody.MTHProject
{
    partial class FrmUserManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManager));
            this.panelEx1 = new Nobody.MTHControlLib.PanelEx();
            this.dgv_main = new System.Windows.Forms.DataGridView();
            this.LoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserManage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_deleteUser = new System.Windows.Forms.Button();
            this.btn_modifyUser = new System.Windows.Forms.Button();
            this.btn_addUser = new System.Windows.Forms.Button();
            this.btn_checkedOrNot = new System.Windows.Forms.Button();
            this.chk_userManage = new Nobody.MTHControlLib.CheckBoxEx();
            this.chk_historyTrend = new Nobody.MTHControlLib.CheckBoxEx();
            this.chk_historyLog = new Nobody.MTHControlLib.CheckBoxEx();
            this.chk_recipe = new Nobody.MTHControlLib.CheckBoxEx();
            this.chk_paramSet = new Nobody.MTHControlLib.CheckBoxEx();
            this.txt_confirmPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_loginPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_loginName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.title3 = new Nobody.MTHControlLib.Title();
            this.title2 = new Nobody.MTHControlLib.Title();
            this.title1 = new Nobody.MTHControlLib.Title();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.panelEx1.BorderWidth = 1F;
            this.panelEx1.BottomGrap = 5;
            this.panelEx1.Controls.Add(this.dgv_main);
            this.panelEx1.Controls.Add(this.btn_clear);
            this.panelEx1.Controls.Add(this.btn_deleteUser);
            this.panelEx1.Controls.Add(this.btn_modifyUser);
            this.panelEx1.Controls.Add(this.btn_addUser);
            this.panelEx1.Controls.Add(this.btn_checkedOrNot);
            this.panelEx1.Controls.Add(this.chk_userManage);
            this.panelEx1.Controls.Add(this.chk_historyTrend);
            this.panelEx1.Controls.Add(this.chk_historyLog);
            this.panelEx1.Controls.Add(this.chk_recipe);
            this.panelEx1.Controls.Add(this.chk_paramSet);
            this.panelEx1.Controls.Add(this.txt_confirmPwd);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.txt_loginPwd);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.txt_loginName);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.title3);
            this.panelEx1.Controls.Add(this.title2);
            this.panelEx1.Controls.Add(this.title1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.LeftGrap = 5;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightGrap = 5;
            this.panelEx1.Size = new System.Drawing.Size(1424, 721);
            this.panelEx1.TabIndex = 0;
            this.panelEx1.TopGrap = 5;
            // 
            // dgv_main
            // 
            this.dgv_main.AllowUserToAddRows = false;
            this.dgv_main.AllowUserToDeleteRows = false;
            this.dgv_main.AllowUserToResizeColumns = false;
            this.dgv_main.AllowUserToResizeRows = false;
            this.dgv_main.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            this.dgv_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginId,
            this.LoginName,
            this.LoginPwd,
            this.ParamSet,
            this.Recipe,
            this.HistoryLog,
            this.HistoryTrend,
            this.UserManage});
            this.dgv_main.Enabled = false;
            this.dgv_main.EnableHeadersVisualStyles = false;
            this.dgv_main.Location = new System.Drawing.Point(364, 33);
            this.dgv_main.Name = "dgv_main";
            this.dgv_main.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_main.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_main.RowTemplate.Height = 23;
            this.dgv_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_main.Size = new System.Drawing.Size(1007, 612);
            this.dgv_main.TabIndex = 9;
            this.dgv_main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_main_CellFormatting);
            this.dgv_main.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_main_RowStateChanged);
            // 
            // LoginId
            // 
            this.LoginId.DataPropertyName = "LoginId";
            this.LoginId.HeaderText = "ID";
            this.LoginId.Name = "LoginId";
            this.LoginId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginId.Width = 70;
            // 
            // LoginName
            // 
            this.LoginName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoginName.DataPropertyName = "LoginName";
            this.LoginName.HeaderText = "用户名";
            this.LoginName.Name = "LoginName";
            this.LoginName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoginPwd
            // 
            this.LoginPwd.DataPropertyName = "LoginPwd";
            this.LoginPwd.HeaderText = "用户密码";
            this.LoginPwd.Name = "LoginPwd";
            this.LoginPwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginPwd.Width = 150;
            // 
            // ParamSet
            // 
            this.ParamSet.DataPropertyName = "ParamSet";
            this.ParamSet.HeaderText = "参数设置";
            this.ParamSet.Name = "ParamSet";
            this.ParamSet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Recipe
            // 
            this.Recipe.HeaderText = "配方管理";
            this.Recipe.Name = "Recipe";
            this.Recipe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Recipe.Width = 150;
            // 
            // HistoryLog
            // 
            this.HistoryLog.DataPropertyName = "HistoryLog";
            this.HistoryLog.HeaderText = "报警追溯";
            this.HistoryLog.Name = "HistoryLog";
            this.HistoryLog.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // HistoryTrend
            // 
            this.HistoryTrend.DataPropertyName = "HistoryTrend";
            this.HistoryTrend.HeaderText = "历史趋势";
            this.HistoryTrend.Name = "HistoryTrend";
            this.HistoryTrend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserManage
            // 
            this.UserManage.DataPropertyName = "UserManage";
            this.UserManage.HeaderText = "用户管理";
            this.UserManage.Name = "UserManage";
            this.UserManage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(167, 615);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(100, 30);
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "清空信息";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_deleteUser
            // 
            this.btn_deleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_deleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteUser.ForeColor = System.Drawing.Color.White;
            this.btn_deleteUser.Location = new System.Drawing.Point(35, 615);
            this.btn_deleteUser.Margin = new System.Windows.Forms.Padding(4);
            this.btn_deleteUser.Name = "btn_deleteUser";
            this.btn_deleteUser.Size = new System.Drawing.Size(100, 30);
            this.btn_deleteUser.TabIndex = 8;
            this.btn_deleteUser.Text = "删除用户";
            this.btn_deleteUser.UseVisualStyleBackColor = false;
            this.btn_deleteUser.Click += new System.EventHandler(this.btn_deleteUser_Click);
            // 
            // btn_modifyUser
            // 
            this.btn_modifyUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_modifyUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modifyUser.ForeColor = System.Drawing.Color.White;
            this.btn_modifyUser.Location = new System.Drawing.Point(167, 556);
            this.btn_modifyUser.Margin = new System.Windows.Forms.Padding(4);
            this.btn_modifyUser.Name = "btn_modifyUser";
            this.btn_modifyUser.Size = new System.Drawing.Size(100, 30);
            this.btn_modifyUser.TabIndex = 8;
            this.btn_modifyUser.Text = "修改用户";
            this.btn_modifyUser.UseVisualStyleBackColor = false;
            this.btn_modifyUser.Click += new System.EventHandler(this.btn_modifyUser_Click);
            // 
            // btn_addUser
            // 
            this.btn_addUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_addUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addUser.ForeColor = System.Drawing.Color.White;
            this.btn_addUser.Location = new System.Drawing.Point(35, 556);
            this.btn_addUser.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addUser.Name = "btn_addUser";
            this.btn_addUser.Size = new System.Drawing.Size(100, 30);
            this.btn_addUser.TabIndex = 8;
            this.btn_addUser.Text = "  ";
            this.btn_addUser.UseVisualStyleBackColor = false;
            this.btn_addUser.Click += new System.EventHandler(this.btn_addUser_Click);
            // 
            // btn_checkedOrNot
            // 
            this.btn_checkedOrNot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_checkedOrNot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_checkedOrNot.ForeColor = System.Drawing.Color.White;
            this.btn_checkedOrNot.Location = new System.Drawing.Point(167, 425);
            this.btn_checkedOrNot.Margin = new System.Windows.Forms.Padding(4);
            this.btn_checkedOrNot.Name = "btn_checkedOrNot";
            this.btn_checkedOrNot.Size = new System.Drawing.Size(100, 30);
            this.btn_checkedOrNot.TabIndex = 8;
            this.btn_checkedOrNot.Text = "全选/不选";
            this.btn_checkedOrNot.UseVisualStyleBackColor = false;
            this.btn_checkedOrNot.Click += new System.EventHandler(this.btn_checkedOrNot_Click);
            // 
            // chk_userManage
            // 
            this.chk_userManage.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chk_userManage.CheckButtonWidth = 20;
            this.chk_userManage.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_userManage.Location = new System.Drawing.Point(38, 425);
            this.chk_userManage.Name = "chk_userManage";
            this.chk_userManage.Size = new System.Drawing.Size(100, 20);
            this.chk_userManage.TabIndex = 3;
            this.chk_userManage.Text = "用户管理";
            this.chk_userManage.UseVisualStyleBackColor = true;
            // 
            // chk_historyTrend
            // 
            this.chk_historyTrend.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chk_historyTrend.CheckButtonWidth = 20;
            this.chk_historyTrend.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_historyTrend.Location = new System.Drawing.Point(167, 374);
            this.chk_historyTrend.Name = "chk_historyTrend";
            this.chk_historyTrend.Size = new System.Drawing.Size(100, 20);
            this.chk_historyTrend.TabIndex = 3;
            this.chk_historyTrend.Text = "历史趋势";
            this.chk_historyTrend.UseVisualStyleBackColor = true;
            // 
            // chk_historyLog
            // 
            this.chk_historyLog.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chk_historyLog.CheckButtonWidth = 20;
            this.chk_historyLog.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_historyLog.Location = new System.Drawing.Point(38, 374);
            this.chk_historyLog.Name = "chk_historyLog";
            this.chk_historyLog.Size = new System.Drawing.Size(100, 20);
            this.chk_historyLog.TabIndex = 3;
            this.chk_historyLog.Text = "报警追溯";
            this.chk_historyLog.UseVisualStyleBackColor = true;
            // 
            // chk_recipe
            // 
            this.chk_recipe.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chk_recipe.CheckButtonWidth = 20;
            this.chk_recipe.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_recipe.Location = new System.Drawing.Point(167, 323);
            this.chk_recipe.Name = "chk_recipe";
            this.chk_recipe.Size = new System.Drawing.Size(100, 20);
            this.chk_recipe.TabIndex = 3;
            this.chk_recipe.Text = "配方管理";
            this.chk_recipe.UseVisualStyleBackColor = true;
            // 
            // chk_paramSet
            // 
            this.chk_paramSet.CheckBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chk_paramSet.CheckButtonWidth = 20;
            this.chk_paramSet.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_paramSet.Location = new System.Drawing.Point(38, 323);
            this.chk_paramSet.Name = "chk_paramSet";
            this.chk_paramSet.Size = new System.Drawing.Size(100, 20);
            this.chk_paramSet.TabIndex = 3;
            this.chk_paramSet.Text = "参数设置";
            this.chk_paramSet.UseVisualStyleBackColor = true;
            // 
            // txt_confirmPwd
            // 
            this.txt_confirmPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            this.txt_confirmPwd.ForeColor = System.Drawing.Color.White;
            this.txt_confirmPwd.Location = new System.Drawing.Point(117, 194);
            this.txt_confirmPwd.Name = "txt_confirmPwd";
            this.txt_confirmPwd.Size = new System.Drawing.Size(150, 23);
            this.txt_confirmPwd.TabIndex = 2;
            this.txt_confirmPwd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(35, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "确认密码：";
            // 
            // txt_loginPwd
            // 
            this.txt_loginPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            this.txt_loginPwd.ForeColor = System.Drawing.Color.White;
            this.txt_loginPwd.Location = new System.Drawing.Point(117, 142);
            this.txt_loginPwd.Name = "txt_loginPwd";
            this.txt_loginPwd.Size = new System.Drawing.Size(150, 23);
            this.txt_loginPwd.TabIndex = 2;
            this.txt_loginPwd.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(35, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户密码：";
            // 
            // txt_loginName
            // 
            this.txt_loginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(32)))), ((int)(((byte)(73)))));
            this.txt_loginName.ForeColor = System.Drawing.Color.White;
            this.txt_loginName.Location = new System.Drawing.Point(117, 90);
            this.txt_loginName.Name = "txt_loginName";
            this.txt_loginName.Size = new System.Drawing.Size(150, 23);
            this.txt_loginName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(35, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名称：";
            // 
            // title3
            // 
            this.title3.BackColor = System.Drawing.Color.Transparent;
            this.title3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title3.BackgroundImage")));
            this.title3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title3.Location = new System.Drawing.Point(35, 485);
            this.title3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title3.Name = "title3";
            this.title3.Size = new System.Drawing.Size(100, 30);
            this.title3.TabIndex = 0;
            this.title3.TitleName = "用户操作";
            // 
            // title2
            // 
            this.title2.BackColor = System.Drawing.Color.Transparent;
            this.title2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title2.BackgroundImage")));
            this.title2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(35, 257);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(100, 30);
            this.title2.TabIndex = 0;
            this.title2.TitleName = "权限配置";
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.Transparent;
            this.title1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title1.BackgroundImage")));
            this.title1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(35, 33);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(100, 30);
            this.title1.TabIndex = 0;
            this.title1.TitleName = "用户信息";
            // 
            // FrmUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nobody.MTHProject.Properties.Resources.BackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1424, 721);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUserManager";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEx panelEx1;
        private System.Windows.Forms.TextBox txt_confirmPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_loginPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_loginName;
        private System.Windows.Forms.Label label1;
        private MTHControlLib.Title title1;
        private MTHControlLib.CheckBoxEx chk_paramSet;
        private MTHControlLib.Title title2;
        private MTHControlLib.CheckBoxEx chk_userManage;
        private MTHControlLib.CheckBoxEx chk_historyTrend;
        private MTHControlLib.CheckBoxEx chk_historyLog;
        private MTHControlLib.CheckBoxEx chk_recipe;
        private System.Windows.Forms.Button btn_checkedOrNot;
        private System.Windows.Forms.DataGridView dgv_main;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_deleteUser;
        private System.Windows.Forms.Button btn_modifyUser;
        private System.Windows.Forms.Button btn_addUser;
        private MTHControlLib.Title title3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserManage;
    }
}
