using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHDAL
{
    public class BaseDal<T> where T: class,new()
    {
        /// <summary>
        /// 插入一个实体
        /// </summary>
        public int Add(T entity)
        {
            return SQLSugarHelper.Db.Insertable(entity).ExecuteCommand();
        }

        /// <summary>
        /// 插入实体并返回自增主键
        /// </summary>
        public int AddReturnIdentity(T entity)
        {
            return SQLSugarHelper.Db.Insertable(entity).ExecuteReturnIdentity();
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        public int AddBatch(List<T> entities)
        {
            return SQLSugarHelper.Db.Insertable(entities).ExecuteCommand();
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        public bool Delete(int id)
        {
            return SQLSugarHelper.Db.Deleteable<T>(id).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 根据实体删除（通常根据主键）
        /// </summary>
        public bool Delete(T entity)
        {
            return SQLSugarHelper.Db.Deleteable(entity).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 更新一个实体
        /// </summary>
        public bool Update(T entity)
        {
            return SQLSugarHelper.Db.Updateable(entity).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 根据主键查询单个实体
        /// </summary>
        public T GetById(int id)
        {
            return SQLSugarHelper.Db.Queryable<T>().InSingle(id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        public List<T> GetAll()
        {
            return SQLSugarHelper.Db.Queryable<T>().ToList();
        }

        /// <summary>
        /// 根据条件查询列表
        /// </summary>
        public List<T> GetList(Expression<Func<T, bool>> whereExpression)
        {
            return SQLSugarHelper.Db.Queryable<T>().WhereIF(whereExpression != null, whereExpression).ToList();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public List<T> GetPageList(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, int pageIndex, int pageSize,ref int totalCount)
        {
            return SQLSugarHelper.Db.Queryable<T>()
                .WhereIF(whereExpression != null, whereExpression)
                .OrderByIF(orderByExpression != null, orderByExpression, OrderByType.Asc)
                .ToPageList(pageIndex, pageSize,ref totalCount);
        }
    }
}
