using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    [SugarTable("ActualData")]
    public class ActualData
    {
        [SugarColumn(ColumnName ="Id",IsPrimaryKey =true,IsIdentity =true)]
        public int Id { get; set; }
        [SugarColumn]
        public DateTime InsertTime {  get; set; }
        [SugarColumn]
        public string Station1Temp { get; set; }
        [SugarColumn]
        public string Station1Humidity { get; set; }
        [SugarColumn]
        public string Station2Temp { get; set; }
        [SugarColumn]
        public string Station2Humidity { get; set; }
        [SugarColumn]
        public string Station3Temp { get; set; }
        [SugarColumn]
        public string Station3Humidity { get; set; }
        public string Station4Temp { get; set; }
        [SugarColumn]
        public string Station4Humidity { get; set; }
        [SugarColumn]
        public string Station5Temp { get; set; }
        [SugarColumn]
        public string Station5Humidity { get; set; }
        public string Station6Temp { get; set; }
        [SugarColumn]
        public string Station6Humidity { get; set; }

    }
}
