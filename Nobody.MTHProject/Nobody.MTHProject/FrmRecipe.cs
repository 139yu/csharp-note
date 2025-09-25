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
using thinger.DataConvertLib;

namespace Nobody.MTHProject
{
    public partial class FrmRecipe : Form
    {
        public FrmRecipe(string devPath)
        {
            InitializeComponent();
            RefreshDataGrid();
            this.devPath = devPath;
        }
        private string basePath = Application.StartupPath + "\\Recipe";
        private string devPath = string.Empty;
        private List<RecipeInfo> recipeInfos = new List<RecipeInfo>();
        private void btn_addRecipe_Click(object sender, EventArgs e)
        {
            RecipeInfo info = GetRecipeInof();
            var recipeName = this.txt_targetRecipe.Text.Trim();
            if (recipeName.Length == 0)
            {
                new FrmMsgBoxWithoutAck("添加配方", "配方名称为空，请检查！");
                return;
            }
            var existFlag = recipeInfos.Where(r => r.RecipeName.Equals(recipeName)).Any();
            if (existFlag)
            {
                new FrmMsgBoxWithoutAck("添加配方", "该配方名称已存在！");
                return;
            }
            string path = basePath + $"\\{info.RecipeName}.ini";
            var flag = IniConfigHelper.WriteIniData("配方", "配方数据", JSONHelper.EntityToJSON(info), path);
            if (flag)
            {
                new FrmMsgBoxWithoutAck("添加配方", "添加配方成功").Show();
                RefreshDataGrid();
            }
            else
            {
                new FrmMsgBoxWithoutAck("添加配方", "添加配方失败").Show();
            }
        }

        public RecipeInfo GetRecipeInof()
        {
            RecipeInfo info = new RecipeInfo();
            info.RecipeName = this.txt_targetRecipe.Text;
            info.RecipeParams = new List<RecipeParam>()
            {
                this.recipeControl1.RecipeParam,
                this.recipeControl2.RecipeParam,
                this.recipeControl3.RecipeParam,
                this.recipeControl4.RecipeParam,
                this.recipeControl5.RecipeParam,
                this.recipeControl6.RecipeParam,
            };
            return info;
        }

        public void RefreshDataGrid()
        {
            recipeInfos = GetAllRecipe();
            if (recipeInfos.Count > 0) this.dgv_main.Rows.Clear();
            var currentRecipe = CommonMethods.Device.CurrentRecipe;
            if (currentRecipe == null)
            {
                currentRecipe = recipeInfos[0];
            }
            for (int i = 0; i < recipeInfos.Count; i++)
            {
                var item = recipeInfos[i];
                this.dgv_main.Rows.Add();
                this.dgv_main.Rows[i].Cells[0].Value = (i + 1).ToString();
                if (item.RecipeName.Equals(currentRecipe.RecipeName))
                {
                    this.dgv_main.Rows[i].Selected = true;
                }
                this.dgv_main.Rows[i].Cells[1].Value = item.RecipeName;
            }
            dgv_main.Rows[0].Selected = true;
            SetRecipeControl(currentRecipe);
            this.lbl_currentRecipe.Text = currentRecipe.RecipeName;
        }

        public List<RecipeInfo> GetAllRecipe()
        {
            List<RecipeInfo> recipeInfos = new List<RecipeInfo>();
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
                return recipeInfos;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(basePath);
            foreach (FileInfo file in directoryInfo.GetFiles("*.ini"))
            {
                string json = IniConfigHelper.ReadIniData("配方", "配方数据", "", file.FullName);
                recipeInfos.Add(JSONHelper.JSONToEntity<RecipeInfo>(json));
            }
            return recipeInfos;
        }


        public void ModifyRecipe(string recipeName)
        {
            if (recipeName.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("修改配方", "配方名称为空，请检查！").Show();
                return;
            }
            var recipeInfo = recipeInfos.FirstOrDefault(r => r.RecipeName.Equals(recipeName));
            if (recipeInfo == null)
            {
                new FrmMsgBoxWithoutAck("修改配方", "配方不存在！").Show();
                return;
            }
            var recipeParams = recipeInfo.RecipeParams;
            recipeParams[0] = this.recipeControl1.RecipeParam;
            recipeParams[1] = this.recipeControl2.RecipeParam;
            recipeParams[2] = this.recipeControl3.RecipeParam;
            recipeParams[3] = this.recipeControl4.RecipeParam;
            recipeParams[4] = this.recipeControl5.RecipeParam;
            recipeParams[5] = this.recipeControl6.RecipeParam;
            var result = IniConfigHelper.WriteIniData("配方", "配方数据", JSONHelper.EntityToJSON(recipeInfo), $"{basePath}\\{recipeInfo.RecipeName}.ini");
            if (result)
            {
                new FrmMsgBoxWithoutAck("修改配方", "修改配方成功！").Show();
            }
            else
            {

                new FrmMsgBoxWithoutAck("修改配方", "修改配方失败！").Show();
            }
        }

        public void DeleteRecipe(string recipeName)
        {

            if (recipeName.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("删除配方", "配方名称为空，请检查！");
                return;
            }
            var recipeInfo = recipeInfos.FirstOrDefault(r => r.RecipeName.Equals(recipeName));
            if (recipeInfo == null)
            {
                new FrmMsgBoxWithoutAck("删除配方", "配方不存在！").Show();
                return;
            }
            string path = basePath + $"\\{recipeName}.ini";
            File.Delete(path);
            recipeInfos.Remove(recipeInfo);
        }

        private void btn_modifyRecipe_Click(object sender, EventArgs e)
        {
            var recipeName = this.txt_targetRecipe.Text;
            var result = new FrmMsgBoxWithAck("修改配方", "是否要修改配方？").ShowDialog();
            if (result != DialogResult.OK) return;
            ModifyRecipe(recipeName);
        }

        private void btn_delRecipe_Click(object sender, EventArgs e)
        {
            var recipeName = this.txt_targetRecipe.Text;
            var result = new FrmMsgBoxWithAck("删除配方", "是否要删除配方？").ShowDialog();
            if (result != DialogResult.OK) return;
            DeleteRecipe(recipeName);
        }

        private void dgv_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;
            DataGridView dvg = sender as DataGridView;
            var row = dvg.Rows[index];
            var repiceName = row.Cells[1].Value.ToString();
            var recipeInfo = recipeInfos.FirstOrDefault(r => r.RecipeName.Equals(repiceName));
            if (recipeInfo == null) return;
            SetRecipeControl(recipeInfo);
            this.txt_targetRecipe.Text = repiceName;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {

            var recipeName = this.txt_targetRecipe.Text;
            if(recipeName == null || recipeName.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("应用配方", "请填写配方名称！").Show();
                return;
            }
            var recipeInfo = recipeInfos.FirstOrDefault(r => r.RecipeName.Equals(recipeName));
            if(recipeInfo == null)
            {
                new FrmMsgBoxWithoutAck("应用配方", "该配方名称不存在！").Show();
                return;
            }
            if (!CommonMethods.Device.IsConnected)
            {
                new FrmMsgBoxWithoutAck("应用配方", "设备未连接，请检查设备！").Show();
                return;
            }
            var dialogResult = new FrmMsgBoxWithAck("应用配方", "是否确定应用配方？").ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            if (recipeInfo.RecipeParams.Count == 6)
            {
                var recipeParams = recipeInfo.RecipeParams;
                List<short> values = new List<short>();
                for (int i = 0; i < 6; i++)
                {

                    values.Add(Convert.ToInt16(recipeParams[i].TempHigh));
                    values.Add(Convert.ToInt16(recipeParams[i].TempLow));
                    values.Add(Convert.ToInt16(recipeParams[i].HumidityHigh));
                    values.Add(Convert.ToInt16(recipeParams[i].HumidityLow));
                }
                for (int i = 0; i < 24; i++)
                {
                    values.Add(0);
                }
                for(int i = 0;i < 6; i++)
                {
                    values.Add(recipeParams[i].TempAlarmEnable ? (short)1 : (short)0);
                    values.Add(recipeParams[i].HumidityAlarmEnable ? (short)1 : (short)0);
                }
                var result = CommonMethods.Modbus.PreSetMultiRegisters(36, ByteArrayLib.GetByteArrayFromShortArray(values.ToArray(), CommonMethods.DataFormat));
                if (result)
                {
                    new FrmMsgBoxWithoutAck("应用配方", "应用成功").Show();
                    CommonMethods.CurrentRecipe = recipeInfo;
                    IniConfigHelper.WriteIniData("参数配方","当前配方",JSONHelper.EntityToJSON(recipeInfo),devPath);
                }else
                {
                    new FrmMsgBoxWithoutAck("应用配方", "应用失败，请检查配置").Show();
                }
            }
            else
            {
                new FrmMsgBoxWithoutAck("应用配方", "配方配置错误，请检查").Show();
                return;
            }
        }

        private void SetRecipeControl(RecipeInfo recipeInfo)
        {

            this.recipeControl1.RecipeParam = recipeInfo.RecipeParams[0];
            this.recipeControl2.RecipeParam = recipeInfo.RecipeParams[1];
            this.recipeControl3.RecipeParam = recipeInfo.RecipeParams[2];
            this.recipeControl4.RecipeParam = recipeInfo.RecipeParams[3];
            this.recipeControl5.RecipeParam = recipeInfo.RecipeParams[4];
            this.recipeControl6.RecipeParam = recipeInfo.RecipeParams[5];
        }
    }
}
