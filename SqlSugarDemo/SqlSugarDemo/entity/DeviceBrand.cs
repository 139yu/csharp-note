using SqlSugar;

namespace SqlSugarDemo.entity
{
    [SugarTable]
    public class DeviceBrand
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true,ColumnName = "id")]
        public int Id { get; set; }
        [SugarColumn(ColumnName = "brand_name", ColumnDataType = "varchar(50)")]
        public string BrandName { get; set; }
    }
}