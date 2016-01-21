using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCarDB
{
    public class DBManager
    {
        /// <summary>
        /// 获得实体关系上下文
        /// </summary>
        /// <returns></returns>
        public static DbContext GetGoodBuyDBByEF()
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["UsedCarDBEntities"].ToString();
            UsedCarDBEntities _context = new UsedCarDBEntities();            
            return _context;
        }

        /// <summary>
        /// 执行数据源查询语句(如SQL)，获得数据查询列表
        /// </summary>
        /// <param name="commandText">查询语句</param>
        /// <param name="parameter">参数(可选)</param>
        /// <returns></returns>
        public static List<T> QueryBySql<T>(string sSql, params SqlParameter[] objectParm) where T : class
        {
            using (var ctx = GetGoodBuyDBByEF())
            {
                var v = ctx.Set<T>().SqlQuery(sSql, objectParm);
                return v.ToList<T>();
            }
        }
    }
}
