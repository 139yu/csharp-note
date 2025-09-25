using Nobody.MTHDAL;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHBLL
{
    public class ActualDataManager
    {
        private ActualDataDal acutalDataDal;
        public ActualDataManager()
        {
            acutalDataDal = new ActualDataDal();
        }

        public bool AddActualData(ActualData data)
        {
            return acutalDataDal.Add(data) > 0;
        }

        public List<ActualData> GetActualDataList(DateTime startTime, DateTime endTime)
        {
            return acutalDataDal.GetActualDataList(startTime, endTime);
        }
    }
}
