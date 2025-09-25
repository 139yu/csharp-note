using Nobody.MTHDAL;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHBLL
{
    public class LogManager
    {
        private LogDal logDal;
        public LogManager()
        {
            logDal = new LogDal();
        }
        public bool AddLog(SysLog log)
        {

            int count = logDal.Add(log);
            return count > 0;
        }

        public List<SysLog> GetLogList(string alarmType,string startTime,string endTime)
        {
            return logDal.GetLogList(alarmType, startTime, endTime);
        }
    }
}
