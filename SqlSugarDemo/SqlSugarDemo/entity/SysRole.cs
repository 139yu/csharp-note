using SqlSugar;

namespace SqlSugarDemo.entity
{
    [SugarTable(TableName = "sys_role")]
    public class SysRole
    {
        [SugarColumn(IsPrimaryKey = true,ColumnName = "id", ColumnDataType = "bigint")]
        public long Id { get; set; }
        [SugarColumn(ColumnName = "role_name", ColumnDataType = "varchar",Length = 30 )]
        public string RoleName { get; set; }
    }
}