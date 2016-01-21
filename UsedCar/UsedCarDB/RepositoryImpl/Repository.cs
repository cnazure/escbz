using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCarDB.RepositoryImpl
{
    public class Repository<T> where T : class
    {

        private static DbContext _objectContext = null;


        #region objectContext
        /// <summary>
        /// 获得提供用于查询和使用对象形式的实体数据功能
        /// </summary>
        /// <returns>数据库上下文</returns>
        public virtual DbContext GetObjectContext()
        {
            if (_objectContext == null)
                _objectContext = DBManager.GetGoodBuyDBByEF();

            return _objectContext;
        }
        #endregion
        public static Repository<T> Instance()
        {
            if (_repository == null)
            {
                _repository = new Repository<T>();
            }
            return _repository;
        }
        private static Repository<T> _repository;
        private Repository()
        {
#if Cache
            if (Tool.GetAppSettings("Iscached") == "TRUE")
                reqCached = true;
#endif
        }



        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改成功的对象数</returns>
        public int Add(T entity)
        {
            using (UsedCarDBEntities objectContext = new UsedCarDBEntities())
            {

                objectContext.Configuration.AutoDetectChangesEnabled = false;
                objectContext.Set<T>().Add(entity);
                var result = objectContext.SaveChanges();

#if Cache

                if ((int)result > 0 && reqCached)
                {

                    ICached cached = CacheManager.GetCached();
                    List<T> lst = (List<T>)DBManager.GetFromCache<T>();

                    
                    if (lst != null)
                    {
                        //限制缓存的数量，最多为1000条
                        if (lst.Count > 1000)
                        {
                            lst.RemoveRange(0, lst.Count - 1000);
                        }
                        lst.Add(entity);
                        cached.PutValue(typeof(T).FullName, lst);
                    }
                }

#endif
                return result;
            }
        }


        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">将被删除的对象</param>
        /// <returns>删除的数量</returns>
        public int Delete(T entity)
        {
            //objectContext.Attach(entity);           
            using (UsedCarDBEntities objectContext = new UsedCarDBEntities())
            {
                try
                {
                    objectContext.Configuration.AutoDetectChangesEnabled = false;

                    objectContext.Entry(entity).State = System.Data.EntityState.Deleted;

                }
                catch (Exception e)
                {
                    UsedCarPublic.Log.ExceptionLog.writeFile(e);
                }
                var result = objectContext.SaveChanges();

#if Cache
                if ((int)result > 0 && reqCached)
                {
                    ICached cached = CacheManager.GetCached();
                    List<T> lst = (List<T>)DBManager.GetFromCache<T>();
                    if (lst != null)
                    {
                        lst.Remove(entity);
                        cached.PutValue(typeof(T).FullName, lst);
                    }
                }
#endif

                return result;
            }
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">将被删除的对象</param>
        /// <returns>删除的数量</returns>
        public int Delete(List<T> entity)
        {
            int result = 0;
            //objectContext.Attach(entity);           
            using (UsedCarDBEntities objectContext = new UsedCarDBEntities())
            {
                try
                {

                    foreach (T item in entity)
                    {
                        objectContext.Entry(item).State = System.Data.EntityState.Deleted;
                    }
                    result = objectContext.SaveChanges();


                }
                catch (Exception e)
                {
                    UsedCarPublic.Log.ExceptionLog.writeFile(e);
                }


#if Cache
                if ((int)result > 0 && reqCached)
                {
                    ICached cached = CacheManager.GetCached();
                    List<T> lst = (List<T>)DBManager.GetFromCache<T>();
                    if (lst != null)
                    {
                        lst.Remove(entity);
                        cached.PutValue(typeof(T).FullName, lst);
                    }
                }
#endif

                return result;
            }
        }

        /// <summary>
        /// 提交所有修改
        /// </summary>
        public int SaveChanges()
        {
            if (_objectContext != null)
                return _objectContext.SaveChanges();
            else
                return -1;
        }


        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>影响的行数</returns>
        public int Update(T entity)
        {
            using (UsedCarDBEntities objectContext = new UsedCarDBEntities())
            {
                var result = 0;
                try
                {
                    objectContext.Configuration.AutoDetectChangesEnabled = false;
                    objectContext.Entry(entity).State = System.Data.EntityState.Modified;


                    result = objectContext.SaveChanges();

                    return result;
                }
                catch (OptimisticConcurrencyException e)
                {
                    UsedCarPublic.Log.ExceptionLog.writeFile(e);

                    return result;
                }
            }
        }
        /// <summary>
        /// 查询记录的总共页数
        /// </summary>
        /// <param name="sSql">查询的sql语句</param>
        /// <param name="PageCount">每页记录数量</param>
        /// <param name="totalPage">总共的页数</param>
        /// <param name="totalCount">记录总数</param>
        /// <param name="objs">查询参数</param>
        /// <returns>返回查询结果，true 成功，false 失败</returns>
        public bool QueryBySqlOfPage(string sSql, int PageCount, out int totalPage, out int totalCount, params object[] objs)
        {
            bool iRet = false;
            totalPage = 0;
            totalCount = 0;
            using (UsedCarDBEntities objectContext = new UsedCarDBEntities())
            {
                objectContext.Configuration.AutoDetectChangesEnabled = false;
                try
                {
                    totalCount = objectContext.Database.SqlQuery<T>(sSql, objs).Count();
                    if (totalCount % PageCount == 0)
                    {
                        totalPage = (int)(totalCount / PageCount);
                    }
                    else
                    {
                        totalPage = (int)(totalCount / PageCount) + 1;
                    }
                }
                catch (Exception e)
                {
                    UsedCarPublic.Log.ExceptionLog.writeFile(e);
                }
            }
            return iRet;
        }

        /// <summary>
        /// 查询数据List数组
        /// </summary>
        /// <param name="sSql">查询语句</param>
        /// <param name="countPerPage">每页数据记录数</param>
        /// <param name="pageLoc">第n页</param>
        /// <param name="objs">参数数组，例子("select * from T_LOAN_DETAIL where id=@p0",24)</param>
        /// <returns>查询结果List集合</returns>
        public List<T> QueryBySql(string sSql, int countPerPage, int pageLoc, params object[] objs)
        {
            List<T> results = new List<T>();
            pageLoc--;
            using (UsedCarDBEntities objectContext = new UsedCarDBEntities())
            {
                objectContext.Configuration.AutoDetectChangesEnabled = false;
                try
                {
                    results = objectContext.Database.SqlQuery<T>(sSql, objs).Skip(countPerPage * pageLoc).Take(countPerPage).ToList<T>();
                }
                catch (Exception e)
                {
                    UsedCarPublic.Log.ExceptionLog.writeFile(e);


                }
            }

            return results;
        }


        /// <summary>
        /// 查询一个数据对象
        /// </summary>
        /// <param name="sSql">查询sql语句</param>
        /// <param name="objs">参数数组</param>
        /// <returns>查询结果对象</returns>
        public T QueryBySql(string sSql, params object[] objs)
        {
            T results = null;

            using (UsedCarDBEntities objectContext = new UsedCarDBEntities())
            {
                objectContext.Configuration.AutoDetectChangesEnabled = false;
                try
                {
                    results = objectContext.Set<T>().SqlQuery(sSql, objs).FirstOrDefault();
                }
                catch (Exception e)
                {
                    UsedCarPublic.Log.ExceptionLog.writeFile(e);


                }
            }

            return results;
        }


        public List<T> Query(string sSql, params object[] objs)
        {
            List<T> results = null;

            using (UsedCarDBEntities objectContext = new UsedCarDBEntities())
            {
                objectContext.Configuration.AutoDetectChangesEnabled = false;
                try
                {
                    results = objectContext.Database.SqlQuery<T>(sSql, objs).ToList<T>();
                }
                catch (Exception e)
                {
                    UsedCarPublic.Log.ExceptionLog.writeFile(e);
                }
            }

            return results;
        }

        public object ExecSql(string sSql, params object[] objs)
        {
            object results = null;
            using (SqlConnection connection = GetConnectinon())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand(sSql, connection))
                {
                    if (objs != null)
                        com.Parameters.AddRange(objs);
                    results = com.ExecuteScalar();
                }
            }
            return results;


        }

        public IList<T> GetALLAndInsertCache()
        {
            using (var objectContext = GetObjectContext())
            {
                var v = objectContext.Set<T>();

                IList<T> lst = v.ToList();

#if Cache

                try
                {
                    ICached cached = CacheManager.GetCached();

                    cached.PutValue(typeof(T).FullName, lst);

                }
                catch (Exception ex)
                {
                    throw ex;  
                    
                }

#endif
                return lst;
            }


        }

        private SqlConnection GetConnectinon()
        {
            return new SqlConnection(SqlConnection);
        }

        private string SqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["UsedCarCon"].ToString();


        public DataSet GetDataSet(string sSql)
        {
            using (SqlConnection connection = GetConnectinon())
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sSql, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }
}
