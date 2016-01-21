using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDAL.User;
using UsedCarDB;

namespace UsedCarBLL.User
{
    public class CustomerManager
    {
        private readonly CustomerService Customer = new CustomerService();
        /// <summary>
        /// 增加客户
        /// </summary>
        public int AddCustomer(T_Customer CustomerInfo)
        {
            try
            {
                return Customer.AddCustomer(CustomerInfo);
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
                return Customer.UpdateCustomer(CustomerInfo);
            }
            catch
            {

                throw;
            }
        }



        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_Customer GetModel(string Aid)
        {
            try
            {
                return Customer.GetModel(Aid);
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
                return Customer.GetLastCid();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 获取客户
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="pageSize">分页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageCount">当前第几页</param>
        /// <param name="totalCount">当前总数</param>        
        /// <returns></returns>
        public List<T_Customer> GetDataListWithPage(string CId, string CName, string Contacts, string AddDateFrom, string AddDateTo, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("select * from T_Customer where isUsing=1");
                if (!string.IsNullOrEmpty(CId))
                    strSQL.AppendFormat(" and CId={0}", CId);
                if (!string.IsNullOrEmpty(CName))
                    strSQL.AppendFormat(" and CName like '%{0}%'", CName);
                if (!string.IsNullOrEmpty(Contacts))
                    strSQL.AppendFormat(" and Contacts like '%{0}%'", Contacts);
                if (!string.IsNullOrEmpty(AddDateFrom))
                    strSQL.AppendFormat(" and AddDate>='{0}'", AddDateFrom);
                if (!string.IsNullOrEmpty(AddDateTo))
                    strSQL.AppendFormat(" and AddDate<='{0}'", AddDateTo);
                strSQL.Append(" order by AddDate desc");
                return new CustomerService().GetDataListWithPage(strSQL.ToString(), pageSize, pageIndex, out pageCount, out totalCount);
            }
            catch
            {
                throw;
            }
        }        


        /// <summary>
        /// 获取客户
        /// </summary>
        public List<T_Customer> GetAllCustomer()
        {
            try
            {
                return Customer.GetAllCustomer();
            }
            catch
            {

                throw;
            }

        }
    }
}
