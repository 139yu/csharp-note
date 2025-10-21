using System;
using SqlSugar;

namespace SqlSugarDemo.entity
{
    [SugarTable("Device")]
    public class Device
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, IsNullable = false,ColumnName = "id",ColumnDataType = "int(4)")]
        public int Id { get; set; }
        [SugarColumn(ColumnDataType = "varchar(16)", IsNullable = true,ColumnName = "dev_code")]
        public string DevCode { get; set; }
        [SugarColumn(ColumnDataType = "int(4)",IsNullable = true,ColumnName = "brand_id")]
        public int BrandId { get; set; }
        [SugarColumn(ColumnDataType = "timestamp", IsNullable = false,ColumnName = "create_time")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}