using SqlSugar;

namespace SqlSugarDemo.entity
{
    [SugarTable(TableName = "sys_dept",TableDescription = "部门")]
    public class SysDept
    {
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id", IsIdentity = true, IsNullable = false,
            ColumnDataType = "int(4)")]
        public int Id { get; set; }
        [SugarColumn( ColumnName = "dept_name",  IsNullable = false,ColumnDescription = "部门名称",
            ColumnDataType = "varchar(30)")]
        public string DeptName { get; set; }
        [SugarColumn( ColumnName = "dept_desc",  IsNullable = true,ColumnDescription = "部门描述",
            ColumnDataType = "varchar(255)")]
        public string DeptDesc { get; set; }
    }
}