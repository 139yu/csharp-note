using System;
using SqlSugar;

namespace SqlSugarDemo.entity
{
    [SugarTable(TableName = "sys_user", TableDescription = "用户信息表")]
    public class SysUser
    {
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id", IsIdentity = true, IsNullable = false,
            ColumnDataType = "int(4)")]
        public int Id { get; set; }

        [SugarColumn(ColumnName = "username", ColumnDescription = "用户名", ColumnDataType = "varchar", Length = 20)]
        public string Username { get; set; }

        [SugarColumn(ColumnName = "password", ColumnDescription = "密码", ColumnDataType = "varchar", Length = 20)]
        public string Password { get; set; }

        [SugarColumn(ColumnName = "phone", ColumnDescription = "手机号", ColumnDataType = "varchar", Length = 20)]
        public string Phone { get; set; }

        [SugarColumn(ColumnName = "dept_id", ColumnDescription = "部门ID", ColumnDataType = "int(4)")]
        public int DeptId { get; set; }

        [SugarColumn(ColumnName = "birth_day",ColumnDescription = "出生时间",ColumnDataType = "timestamp")] 
        public DateTime BirthDay { get; set; }
    }
}