using Nobody.MTHModels;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHDAL
{
    public class ActualDataDal : BaseDal<ActualData>
    {
        public List<ActualData> GetActualDataList(DateTime startTime, DateTime endTime)
        {
            var exp = Expressionable.Create<ActualData>();
            exp.AndIF(startTime != null, a => a.InsertTime >= startTime)
                .AndIF(startTime != null, a => a.InsertTime  >= endTime);
            return this.GetList(exp.ToExpression());
        }
    }
}
