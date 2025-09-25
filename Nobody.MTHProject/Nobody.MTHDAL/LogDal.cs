using Nobody.MTHModels;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHDAL
{
    public class LogDal: BaseDal<SysLog>
    {

        public List<SysLog> GetLogList(string alarmType,string startTime,string endTime)
        {
            var exp = Expressionable.Create<SysLog>();
            exp
                .AndIF(!string.IsNullOrEmpty(alarmType),
                e => e.AlarmType.Equals(alarmType))
                .AndIF(!string.IsNullOrEmpty(startTime), e => Convert.ToDateTime(e.InsertTime) >= Convert.ToDateTime(startTime))
                .AndIF(!string.IsNullOrEmpty(endTime), e => Convert.ToDateTime(e.InsertTime) <= Convert.ToDateTime(endTime));
            return GetList(exp.ToExpression());
        }
    }
}
