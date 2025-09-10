using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Nobody.DigitaPlatform.Common.Attributes;
using Nobody.DigitaPlatform.DataAccess;
using Nobody.DigitaPlatform.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Nobody.DigitaPlatform.ViewModels
{
    public class AlarmViewModel
    {
        public string Keyword { get; set; }

        public List<DeviceAlarmModel> Alarms { get; set; }
        public RelayCommand ExportExcelCommand { get; }

        private ILocalDataAccess _dataAccess;

        public AlarmViewModel(ILocalDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            ExportExcelCommand = new RelayCommand(DoExportExcelCommand);
            InitAlarms();
        }

        private void DoExportExcelCommand()
        {
            IWorkbook workboot = new XSSFWorkbook();
            // 创建工作表
            ISheet sheet = workboot.CreateSheet("报警记录");
            var properties = Alarms[0].GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(ExcelColumn), true) != null)
                .ToList();
            properties.Sort((a, b) =>
                ((ExcelColumn)a.GetCustomAttribute(typeof(ExcelColumn), true)).Sort -
                ((ExcelColumn)b.GetCustomAttribute(typeof(ExcelColumn), true)).Sort);
            var headerRow = sheet.CreateRow(0);
            for (int i = 0; i < properties.Count; i++)
            {
                var attr = (ExcelColumn)properties[i].GetCustomAttribute(typeof(ExcelColumn), true);
                headerRow.CreateCell(i).SetCellValue(attr.Column);
            }

            for (var i = 0; i < Alarms.Count; i++)
            {
                var item = Alarms[i];
                IRow row = sheet.CreateRow(i +1);
                for (var j = 0; j < properties.Count; j++)
                {
                    var property = properties[j];
                    var value = property.GetValue(item).ToString();
                    var cell = row.CreateCell(j, CellType.String);
                    cell.SetCellValue(value);
                }
               
            }
            // 自动调整列宽
            for (var i = 0; i < properties.Count; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                FileName = $"报警信息{DateTime.Now:yyyyMMddHHmmss}",
                Title = "保存报警记录",
                AddExtension = true,
                Filter = "Excel文件 (*.xlsx)|*.xlsx|所有文件 (*.*)|*.*",
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    workboot.Write(fs);
                }
            }
        }


        private void InitAlarms()
        {
            int index = 1;
            Alarms = _dataAccess.GetAlarmList(Keyword).Select(t => new DeviceAlarmModel(_dataAccess)
            {
                Index = index++,
                AlarmNum = t.AlarmNum,
                CNum = t.CNum,
                AlarmContent = t.AlarmContent,
                AlarmValue = t.RecordValue,
                DateTime = t.RecordTime,
                DNum = t.DeviceNum,
                Level = int.Parse(t.AlarmLevel),
                State = int.Parse(t.State),
                VNum = t.VariableNum,
                SolveTime = t.SolveTime,
                UserId = t.UserId, UserName = t.UserName,
                DeviceName = t.DeviceName,
                VarName = t.VariableName
            }).ToList();
        }
    }
}