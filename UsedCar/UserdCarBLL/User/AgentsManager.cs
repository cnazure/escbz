using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDAL.User;
using UsedCarDB;

namespace UsedCarBLL.User
{
    public class AgentsManager
    {
        private readonly AgentsService Agents = new AgentsService();
        /// <summary>
        /// 增加代理人
        /// </summary>
        public int AddAgents(T_Agents AgentsInfo)
        {
            try
            {
                return Agents.AddAgents(AgentsInfo);
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
                return Agents.UpdateAgents(AgentsInfo);
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
                return Agents.GetModel(Aid);
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
                return Agents.GetLastAid();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 获取代理人
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="pageSize">分页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageCount">当前第几页</param>
        /// <param name="totalCount">当前总数</param>        
        /// <returns></returns>
        public List<T_Agents> GetDataListWithPage(string Aid, string AName, string ATel, string AddDateFrom, string AddDateTo, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("select * from T_Agents where isUsing=1");
                if (!string.IsNullOrEmpty(Aid))
                    strSQL.AppendFormat(" and Aid={0}", Aid);
                if (!string.IsNullOrEmpty(AName))
                    strSQL.AppendFormat(" and AName like '%{0}%'", AName);
                if (!string.IsNullOrEmpty(ATel))
                    strSQL.AppendFormat(" and ATel like '%{0}%'", ATel);
                if (!string.IsNullOrEmpty(AddDateFrom))
                    strSQL.AppendFormat(" and AddDate>='{0}'", AddDateFrom);
                if (!string.IsNullOrEmpty(AddDateTo))
                    strSQL.AppendFormat(" and AddDate<='{0}'", AddDateTo);
                strSQL.Append(" order by AddDate desc");
                return new AgentsService().GetDataListWithPage(strSQL.ToString(), pageSize, pageIndex, out pageCount, out totalCount);
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
                return Agents.GetDataListWithPage(pageSize, pageIndex, out pageCount, out totalCount);
            }
            catch
            {

                throw;
            }

        }


        /// <summary>
        /// 获取代理人
        /// </summary>
        public List<T_Agents> GetAllAgents()
        {
            try
            {
                return Agents.GetAllAgents();
            }
            catch
            {

                throw;
            }

        }
    }
}
