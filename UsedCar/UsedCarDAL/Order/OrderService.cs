using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.Order
{
    public class OrderService
    {

        /// <summary>
        /// 增加车辆订单
        /// </summary>
        public int AddCarOrder(T_CarOrder CarOrder)
        {
            try
            {
                return Repository<T_CarOrder>.Instance().Add(CarOrder);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改车辆订单
        /// </summary>
        public int UpdateCarOrder(T_CarOrder CarOrder)
        {
            try
            {
                return Repository<T_CarOrder>.Instance().Update(CarOrder);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据订单编号查询订单
        /// </summary>
        /// <param name="strOrderId">订单编号</param>
        /// <returns></returns>
        public T_CarOrder GetOrderInfo(string strOrderId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_CarOrder where OrderId=@OrderId ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@OrderId",strOrderId)
            };
                return Repository<T_CarOrder>.Instance().QueryBySql(strSql.ToString(), parameters);
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
        public List<View_OrderInfo> GetViewOrderInfoWithPage(string strSQL, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                int totalpage, totalcount = 0;
                bool iRet = Repository<View_OrderInfo>.Instance().QueryBySqlOfPage(strSQL, pageSize, out totalpage, out totalcount);
                List<View_OrderInfo> ls = Repository<View_OrderInfo>.Instance().QueryBySql(strSQL, pageSize, pageIndex);
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
        /// 根据订单编号查询订单(车辆信息)
        /// </summary>
        /// <param name="strOrderId">订单编号</param>
        /// <returns></returns>
        public View_OrderInfo GetViewOrderInfoWithId(string strOrderId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from View_OrderInfo where OrderId=@OrderId ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@OrderId",strOrderId)
            };
                return Repository<View_OrderInfo>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }



        /// <summary>
        /// 获取生成后的最终产品订单号
        /// </summary>
        /// <returns></returns>
        public string GetOrderId()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 * from T_CarOrder order by OrderId desc");
                object obj = Repository<T_CarOrder>.Instance().ExecSql(strSql.ToString(), null);
                if (obj != null)
                {
                    string strLastOrderId = obj.ToString();
                    if (!string.IsNullOrEmpty(strLastOrderId))
                    {
                        return DateTime.Now.ToString("MMdd") + (Convert.ToInt32(strLastOrderId.Remove(0, 4)) + 1).ToString("000000");
                    }
                    else
                    {
                        return DateTime.Now.ToString("MMdd") + "000001";
                    }
                }
                else
                {
                    return DateTime.Now.ToString("MMdd") + "000001";
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
