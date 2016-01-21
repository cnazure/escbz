using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCarDB.IRepository
{
    public interface IRepository<T> where T : EntityObject
    {
        /// <summary>
        /// 增加实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>影响的行数</returns>
        int Add(T entity);

        /// <summary>
        /// 增加实体对象集合
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>影响的行数</returns>
        int Add(List<T> entity);
        //int Count(ICriteria criteria);
        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>影响的行数</returns>
        int Delete(T entity);

        /// <summary>
        /// 删除List集合对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(List<T> entity);


        int ExecuteStoreCommand(string commandText, params ObjectParameter[] paramete);
        ObjectResult<T> ExecuteStoreQuery(string commandText, params ObjectParameter[] paramete);        
        IList<T> FindAll();

        /// <summary>
        /// 获得数据库里的数据，并放入缓存
        /// </summary>
        /// <returns>返回获得的数据</returns>
        IList<T> GetALLAndInsertCache();

        IList<T> FindAll(Func<T, bool> exp);
        ObjectSet<T> FindQuerySet();
        ObjectContext GetObjectContext();
        ObjectQuery<T> GetQuery(string query, params ObjectParameter[] parameter);
        int SaveChanges();

        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>影响的行数</returns>
        int Update(T entity);

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="Source"> 源对象</param>
        /// <param name="entity">更改后对象</param>
        /// <returns></returns>
        int Update(T entity, T Source);
        
    }
}
