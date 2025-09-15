using MiniExcelLibs;
using Nobody.MTHProject;
using Nobody.MTHHelper;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHProject
{
    public partial class FrmGroupConfig : Form
    {
        public FrmGroupConfig()
        {
            InitializeComponent();
            this.selector_storeArea.DataSource = new string[] {
                "输入线圈","输出线圈","输入寄存器","输出寄存器"
            };
            var groups = GetAllGroups();
            this.dgv_main.AutoGenerateColumns = false;
            if (groups != null && groups.Count > 0)
            {
                totalGroups = GetAllGroups();
                RefreshGroup();
            }
        }

        private List<Group> totalGroups { get; set; } = new List<Group>();
        private string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";

        private List<Group> GetAllGroups()
        {
            if (File.Exists(groupPath))
            {
                return MiniExcel.Query<Group>(groupPath).ToList();
            }
            return null;
        }
        private void btn_addGroup_Click(object sender, EventArgs e)
        {
            totalGroups.Add(new Group()
            {
                GroupName = this.txt_groupName.Text,
                Start = ushort.Parse(this.txt_start.Text.Trim()),
                Length = ushort.Parse(this.txt_length.Text.Trim()),
                StoreArea = this.selector_storeArea.SelectedValue.ToString().Trim(),
                Remark = this.txt_remark.Text.Trim(),
            });
            try
            {
                MiniExcel.SaveAs(groupPath, totalGroups, overwriteFile:true);
                new FrmMsgBoxWithoutAck("添加通信组件", "添加通信组件成功").Show();
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("添加通信组件", "添加通信组件失败：" + ex.Message).Show();
            }
        }

        private void RefreshGroup()
        {
            this.dgv_main.DataSource = null;
            this.dgv_main.DataSource = totalGroups;
        }

        private void dgv_main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            DataGridViewHelper.DgvRowPostPaint(dataGrid, e);
        }

        private void dgv_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                var  group = totalGroups[rowIndex];
                UpdateGroup(group);
            }
        }

        private void UpdateGroup(Group group)
        {
            if (group == null)
            {
                return;
            }
            this.txt_groupName.Text = group.GroupName;
            this.txt_start.Value = group.Start;
            this.txt_length.Value = group.Length;
            if (!string.IsNullOrEmpty(group.StoreArea))
            {
                this.selector_storeArea.SelectedItem = group.StoreArea;
            }
            
            this.txt_remark.Text = group.Remark;
        }

        private void btn_editGroup_Click(object sender, EventArgs e)
        {
            var groupName = this.txt_groupName.Text;
            if (string.IsNullOrEmpty(groupName))
            {
                return;
            }
            var group = totalGroups.FirstOrDefault(g => g.GroupName.Equals(groupName));
            if (group == null)
            {
                return;
            }
            group.Start = decimal.ToUInt16(txt_start.Value);
            group.Length = decimal.ToUInt16(txt_length.Value);
            group.StoreArea = selector_storeArea.SelectedValue.ToString();
            group.Remark = this.txt_remark.Text;
            MiniExcel.SaveAs(groupPath,totalGroups,overwriteFile:true);
            new FrmMsgBoxWithoutAck("修改通信组", "修改通信组成功！").Show();
            RefreshGroup();
        }

        private void btn_delGroup_Click(object sender, EventArgs e)
        {
            var groupName = this.txt_groupName.Text;
            if (string.IsNullOrEmpty(groupName))
            {
                return;
            }
            var group = totalGroups.FirstOrDefault(g => g.GroupName.Equals(groupName));
            UpdateGroup(group);
            totalGroups.Remove(group);
            MiniExcel.SaveAs(groupPath, totalGroups, overwriteFile: true);
            new FrmMsgBoxWithoutAck("删除通信组", "删除通信组成功！").Show();
            RefreshGroup();
        }

        private void dgv_main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) 
            {
                object value = this.dgv_main.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == null || value.ToString().Length == 0)
                {
                    e.Value = "---";
                }
            }
        }
    }
}
