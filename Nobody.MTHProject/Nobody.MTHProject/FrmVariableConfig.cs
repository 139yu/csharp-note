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
    public partial class FrmVariableConfig : Form
    {
        public FrmVariableConfig()
        {
            InitializeComponent();
            totalGroups = GetAllGroups();
            if (totalGroups == null || totalGroups.Count == 0)
            {
                new FrmMsgBoxWithoutAck("添加变量", "请先添加通信组");
                return;
            }
            this.selector_groupName.DataSource = totalGroups;
            this.selector_groupName.DisplayMember = "GroupName";
            this.selector_groupName.ValueMember = "GroupName";
            this.selector_dataType.DataSource = new string[] { "UInt16", "Int16", "UInt32", "Int32","Boolean","Single", "Double", "UInt64","Int64" };
            
            totalVars = GetAllVars();
            this.dgv_main.AutoGenerateColumns = false;
            if (totalVars.Count > 0)
            {
                RefreshVars();
            }
        }

        private List<Variable> totalVars { get; set; } = new List<Variable>();
        private List<Group> totalGroups { get; set; } = new List<Group>();
        private string variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";
        private string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";

        private List<Variable> GetAllVars()
        {
            try
            {
                return MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception)
            {

                return new List<Variable>();
            }
        }

        private List<Group> GetAllGroups()
        {
            try
            {
                return MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception)
            {

                return new List<Group>();
            }
        }
        private void btn_addVariable_Click(object sender, EventArgs e)
        {
            var groupName = this.selector_groupName.SelectedText;
            var dataType = this.selector_dataType.SelectedText;
            if (string.IsNullOrEmpty(groupName) || string.IsNullOrEmpty(dataType))
            {
                new FrmMsgBoxWithoutAck("添加变量", "请选择通信组或数据类型").Show();
                return;
            }
            totalVars.Add(new Variable()
            {
                GroupName = groupName,
                VarName = this.txt_varName.Text,
                Start = decimal.ToUInt16(this.txt_start.Value),
                Length = decimal.ToUInt16(this.txt_length.Value),
                DataType = this.selector_dataType.SelectedText,
                PosAlarm = this.check_posAlarm.Checked,
                NegAlarm = this.check_negAlarm.Checked,
                Scale = decimal.ToSingle(this.txt_scale.Value),
                Offset = decimal.ToSingle(this.txt_offset.Value),
                Remark = this.txt_remark.Text
            });
            try
            {
                MiniExcel.SaveAs(variablePath, totalVars, overwriteFile:true);
                new FrmMsgBoxWithoutAck("添加通信组件", "添加通信组件成功").Show();
                RefreshVars();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("添加通信组件", "添加通信组件失败：" + ex.Message).Show();
            }
        }

        private void RefreshVars()
        {
            this.dgv_main.DataSource = null;
            this.dgv_main.DataSource = totalVars;
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
                var  variable = totalVars[rowIndex];
                UpdateVariable(variable);
            }
        }

        private void UpdateVariable(Variable variable)
        {
            if (variable == null)
            {
                return;
            }
            this.selector_groupName.SelectedText = variable.GroupName;
            this.txt_start.Value = variable.Start;
            this.txt_start.Value = variable.Length;
           
            
            this.txt_remark.Text = variable.Remark;
        }

        private void btn_editVariable_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_delVariable_Click(object sender, EventArgs e)
        {
            
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
