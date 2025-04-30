using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Models;

namespace SmartParking.Server.Service.Impl
{
    public class BaseService: IBaseService
    {
        private DbContext dbContext;

        public BaseService(IDBConfig.IDBConfig dbConfig)
        {
            dbContext = dbConfig.GetDbContext();
        }

        #region Query

        public T Find<T>(int id) where T : class
        {
            return dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return dbContext.Set<T>().Where(funcWhere);
        }

        #endregion


        #region Add

        public T Insert<T>(T t) where T : class
        {
            this.dbContext.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this.dbContext.Set<T>().AddRange(tList);
            this.Commit();
            return tList;
        }

        #endregion

        #region Update

        public void Update<T>(T t) where T : class
        {
            if (t == null)
            {
                throw new Exception("t can not be null");
            }

            this.dbContext.Set<T>().Attach(t);
            this.dbContext.Entry<T>(t).State = EntityState.Modified;
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this.dbContext.Set<T>().Attach(t);
                this.dbContext.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }

        #endregion


        #region Delete

        public void Delete<T>(int id) where T : class
        {
            T t = this.Find<T>(id);
            if (t== null)
            {
                throw new Exception($"not find id: {id}");
            }

            this.dbContext.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null)
            {
                throw new Exception("t can not be null");
            }

            this.dbContext.Set<T>().Attach(t);
            this.dbContext.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this.dbContext.Set<T>().Attach(t);
            }
            this.dbContext.Set<T>().RemoveRange(tList);
            this.Commit();
        }

        #endregion

        #region Commit

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        #endregion
    }
}
