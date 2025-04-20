using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SamrtParking.Server.IService.Service
{
    public interface IBaseService
    {
        #region Query

        T Find<T>(int id) where T : class;

        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;

        #endregion

        #region Add

        T Insert<T>(T t) where T : class;

        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region Update

        void Update<T>(T t) where T : class;

        void Update<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region Delete

        void Delete<T>(int id) where T : class;

        void Delete<T>(T t) where T : class;

        void Delete<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region Commit

        void Commit();

        #endregion
    }
}