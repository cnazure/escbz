using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.User
{
    public class AgentsService
    {
        /// <summary>
        /// 增加代理人
        /// </summary>
        public int AddAgents(T_Agents AgentsInfo)
        {
            try
            {
                return Repository<T_Agents>.Instance().Add(AgentsInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改
        /// </summary>
        public int UpdateAgents(T_Agents AgentsInfo)
        {
            try
            {
                return Repository<T_Agents>.Instance().Update(AgentsInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_Agents GetModel(string Aid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_Agents where Aid=@Aid ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@Aid",Aid)
            };
                return Repository<T_Agents>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 获取生成后的最终代理人帐号
        /// </summary>
        /// <returns></returns>
        public string GetLastAid() 
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 * from t_agents order by Aid desc");
                string strLastAgentId = Repository<T_Agents>.Instance().ExecSql(strSql.ToString(), null).ToString();
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
        public List<T_Agents> GetDataListWithPage(string strSQL, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                int totalpage, totalcount = 0;
                bool iRet = Repository<T_Agents>.Instance().QueryBySqlOfPage(strSQL, pageSize, out totalpage, out totalcount);
                List<T_Agents> ls = Repository<T_Agents>.Instance().QueryBySql(strSQL, pageSize, pageIndex);
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
        /// 分页
        /// </summary>
        public List<T_Agents> GetDataListWithPage(int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                int totalpage, totalcount = 0;

                bool iRet = Repository<T_Agents>.Instance().QueryBySqlOfPage("select top 1000 * from T_Agents order by AddDate desc", pageSize, out totalpage, out totalcount);

                List<T_Agents> ls = Repository<T_Agents>.Instance().QueryBySql("select top 1000 * from T_Agents order by AddDate desc", pageSize, pageIndex);

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
        /// 获取所有代理人
        /// </summary>
        public List<T_Agents> GetAllAgents()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"SELECT  * FROM  T_Agents");
                return Repository<T_Agents>.Instance().Query(strSql.ToString());
            }
            catch
            {

                throw;
            }

        }
    }
}
