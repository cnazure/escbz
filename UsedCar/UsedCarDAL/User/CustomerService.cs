using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.User
{
    public class CustomerService
    {
        /// <summary>
        /// 增加客户
        /// </summary>
        public int AddCustomer(T_Customer CustomerInfo)
        {
            try
            {
                return Repository<T_Customer>.Instance().Add(CustomerInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改
        /// </summary>
        public int UpdateCustomer(T_Customer CustomerInfo)
        {
            try
            {
                return Repository<T_Customer>.Instance().Update(CustomerInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_Customer GetModel(string CId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_Customer where CId=@CId ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@CId",CId)
            };
                return Repository<T_Customer>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 获取生成后的最终客户帐号
        /// </summary>
        /// <returns></returns>
        public string GetLastCid()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 * from t_Customer order by CId desc");
                string strLastAgentId = Repository<T_Customer>.Instance().ExecSql(strSql.ToString(), null).ToString();
                if (!string.IsNullOrEmpty(strLastAgentId))
                {
                    return (Convert.ToInt32(strLastAgentId) + 1).ToString("0000");
                }
                else
                {
                    return "0001";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="pageSize">分页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageCount">当前第几页</param>
        /// <param name="totalCount">当前总数</param>
        /// <returns></returns>
        public List<T_Customer> GetDataListWithPage(string strSQL, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                int totalpage, totalcount = 0;
                bool iRet = Repository<T_Customer>.Instance().QueryBySqlOfPage(strSQL, pageSize, out totalpage, out totalcount);
                List<T_Customer> ls = Repository<T_Customer>.Instance().QueryBySql(strSQL, pageSize, pageIndex);
                pageCount = totalpage;
                totalCount = totalcount;
                return ls;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 获取所有客户
        /// </summary>
        public List<T_Customer> GetAllCustomer()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"SELECT  * FROM  T_Customer");
                return Repository<T_Customer>.Instance().Query(strSql.ToString());
            }
            catch
            {

                throw;
            }

        }
    }
}
