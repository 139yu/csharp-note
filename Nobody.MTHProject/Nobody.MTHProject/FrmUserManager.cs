using Nobody.MTHBLL;
using Nobody.MTHControlLib;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHProject
{
    public partial class FrmUserManager : Form
    {
        private AdminManager adminManager = new AdminManager();
        public FrmUserManager()
        {
            InitializeComponent();
            QueryData();
        }

        private List<SysAdmin> userList = null;
        private void QueryData()
        {
            userList = adminManager.GetAdminList();
            if (userList == null || userList.Count == 0) return;
            this.dgv_main.DataSource = null;
            this.dgv_main.AutoGenerateColumns = false;
            this.dgv_main.DataSource = userList;
            this.dgv_main.Rows[0].Selected = true;
        }

        private void dgv_main_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var row = e.Row;
            if (row == null || row.Cells[0] == null || row.Cells[0].Value == null) return;
            var id = int.Parse(row.Cells[0].Value.ToString());
            var user = this.userList.FirstOrDefault(u => u.LoginId == id);
            this.txt_loginName.Text = user.LoginName;
            this.txt_loginPwd.Text = user.LoginPwd;
            this.txt_confirmPwd.Text = user.LoginPwd;
            this.chk_paramSet.Checked = user.ParamSet;
            this.chk_recipe.Checked = user.Recipe;
            this.chk_historyLog.Checked = user.HistoryLog;
            this.chk_historyTrend.Checked = user.HistoryTrend;
        }

        private void btn_checkedOrNot_Click(object sender, EventArgs e)
        {
            bool selectAll = false;
            foreach (var item in Controls.OfType<CheckBoxEx>())
            {
                if(!item.Checked) selectAll = true;
            }
            foreach (var item in Controls.OfType<CheckBoxEx>())
            {
                item.Checked = selectAll;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            foreach (var item in Controls)
            {
                if(item is TextBox txtBox)
                {
                    txtBox.Text = string.Empty;
                }
                if(item is CheckBoxEx chkEx)
                {
                    chkEx.Checked = false;
                }
            }
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            var dialogResult = new FrmMsgBoxWithAck("添加用户", "是否确认要添加？").ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            var loginName = this.txt_loginName.Text;
            if (string.IsNullOrEmpty(loginName))
            {
                new FrmMsgBoxWithoutAck("添加用户", "请输入用户名！").Show();
                return;
            }
            var exists = this.userList.Where(u => u.LoginName.Equals(loginName)).Any();
            if(exists)
            {
                new FrmMsgBoxWithoutAck("添加用户", "用户名已存在！").Show();
                return;
            }
            var pwd = this.txt_confirmPwd.Text;
            var confirmPwd = this.txt_confirmPwd.Text;
            if (string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(confirmPwd) )
            {
                new FrmMsgBoxWithoutAck("添加用户", "请输入密码！").Show();
                return;
            }
            if(!pwd.Equals(confirmPwd))
            {
                new FrmMsgBoxWithoutAck("添加用户", "密码不一致，请确认密码！").Show();
                return;
            }
            SysAdmin user = new SysAdmin()
            {
                LoginName = loginName,
                LoginPwd = pwd,
                ParamSet = this.chk_paramSet.Checked,
                Recipe = this.chk_recipe.Checked,
                HistoryLog = this.chk_historyLog.Checked,
                HistoryTrend = this.chk_historyTrend.Checked,
                UserManage = this.chk_userManage.Checked,
            };
            var count = adminManager.Add(user);
            if (count > 0)
            {
                new FrmMsgBoxWithoutAck("添加用户", "添加成功！").Show();
                QueryData();
            }
            else
            {
                new FrmMsgBoxWithoutAck("添加用户", "添加失败，请检查数据！").Show();
            }
        }

        private void btn_modifyUser_Click(object sender, EventArgs e)
        {
            var dialogResult = new FrmMsgBoxWithAck("修改用户", "是否确认要修改？").ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            var loginName = this.txt_loginName.Text;
            if (string.IsNullOrEmpty(loginName))
            {
                new FrmMsgBoxWithoutAck("修改用户", "请输入用户名！").Show();
                return;
            }
            var currentUser = this.userList.FirstOrDefault(u => u.LoginName.Equals(loginName));
            if (currentUser == null)
            {
                new FrmMsgBoxWithoutAck("修改用户", "当前用户不存在！").Show();
                return;
            }
            var pwd = this.txt_confirmPwd.Text;
            var confirmPwd = this.txt_confirmPwd.Text;
            if (string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(confirmPwd))
            {
                new FrmMsgBoxWithoutAck("修改用户", "请输入密码！").Show();
                return;
            }
            if (!pwd.Equals(confirmPwd))
            {
                new FrmMsgBoxWithoutAck("修改用户", "密码不一致，请确认密码！").Show();
                return;
            }
            currentUser.LoginName = loginName;
            currentUser.LoginPwd = pwd;
            currentUser.ParamSet = this.chk_paramSet.Checked;
            currentUser.Recipe = this.chk_recipe.Checked;
            currentUser.HistoryLog = this.chk_historyLog.Checked;
            currentUser.HistoryTrend = this.chk_historyTrend.Checked;
            currentUser.UserManage = this.chk_userManage.Checked;
            bool updateFlag = adminManager.Update(currentUser);
            if (updateFlag)
            {
                new FrmMsgBoxWithoutAck("修改用户", "修改成功！").Show();
                QueryData();
            }else
            {
                new FrmMsgBoxWithoutAck("修改用户", "修改失败，请检查数据！").Show();
            }
        }

        private void btn_deleteUser_Click(object sender, EventArgs e)
        {
            var dialogResult = new FrmMsgBoxWithAck("删除用户", "是否确认要删除？").ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            var loginName = this.txt_loginName.Text;
            if (string.IsNullOrEmpty(loginName))
            {
                new FrmMsgBoxWithoutAck("删除用户", "请选择要删除用户！").Show();
                return;
            }
            var currentUser = this.userList.FirstOrDefault(u => u.LoginName.Equals(loginName));
            if (currentUser == null)
            {
                new FrmMsgBoxWithoutAck("删除用户", "当前用户不存在！").Show();
                return;
            }
            var delFlag = adminManager.Delete((int)currentUser.LoginId);
            if (delFlag)
            {
                new FrmMsgBoxWithoutAck("删除用户", "删除成功！").Show();
                QueryData();
            }
            else
            {
                new FrmMsgBoxWithoutAck("删除用户", "删除失败，请检查数据！").Show();
            }
        }

        private void dgv_main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 2)
            {
                object value = this.dgv_main.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if(value != null && value.ToString().ToLower().Equals("true"))
                {
                    e.Value = "启用";
                }else
                {
                    e.Value = "禁用";
                }
            }
        }
    }
}
