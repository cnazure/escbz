using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDAL.Order;
using UsedCarDB;

namespace UsedCarBLL.Order
{
    public class OrderManager
    {
        private readonly OrderService OrderInfo = new OrderService();
        /// <summary>
        /// 获取生成后的最终产品订单号
        /// </summary>
        /// <returns></returns>
        public string GetOrderId()
        {
            try
            {
                return OrderInfo.GetOrderId();
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
                return OrderInfo.GetOrderInfo(strOrderId);
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
                return OrderInfo.GetViewOrderInfoWithId(strOrderId);
            }
            catch 
            {   
                throw;
            }
        }

        /// <summary>
        /// 增加订单信息
        /// </summary>
        public int AddCarOrder(T_CarOrder CarOrder)
        {
            try
            {
                return OrderInfo.AddCarOrder(CarOrder);

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改订单信息
        /// </summary>
        public int UpdateCarOrder(T_CarOrder CarOrder)
        {
            try
            {
                return OrderInfo.UpdateCarOrder(CarOrder);
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
        public List<View_OrderInfo> GetViewOrderInfoWithPage(
            string txtCarOrderId, string txtCarVIN, string txtCarHM, string DJRQFrom, string DJRQTo,
            string YDRQFrom, string YDRQTo, string txtCustomerName, string OrderTypeList,
            string CertTypeList, string StatusList, string YHJD, string XHJD, string Sales,
            int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("select * from View_OrderInfo where 1=1");
                if (!string.IsNullOrEmpty(txtCarOrderId))
                    strSQL.AppendFormat(" and OrderId like '%{0}%'", txtCarOrderId);
                if (!string.IsNullOrEmpty(txtCarVIN))
                    strSQL.AppendFormat(" and CarVIN like '%{0}%'", txtCarVIN);
                if (!string.IsNullOrEmpty(txtCarHM))
                    strSQL.AppendFormat(" and YCPHM like '%{0}%'", txtCarHM);
                if (!string.IsNullOrEmpty(DJRQFrom))
                    strSQL.AppendFormat(" and DJDate>='{0}'", DJRQFrom);
                if (!string.IsNullOrEmpty(DJRQTo))
                    strSQL.AppendFormat(" and DJDate<='{0}'", DJRQTo);
                if (!string.IsNullOrEmpty(YDRQFrom))
                    strSQL.AppendFormat(" and YDDate>='{0}'", YDRQFrom);
                if (!string.IsNullOrEmpty(YDRQTo))
                    strSQL.AppendFormat(" and YDDate<='{0}'", YDRQTo);
                if (!string.IsNullOrEmpty(txtCustomerName))
                    strSQL.AppendFormat(" and CustomerName like '%{0}%'", txtCustomerName);
                if (!string.IsNullOrEmpty(OrderTypeList))
                    strSQL.AppendFormat(" and OrderType='{0}'", OrderTypeList);
                if (!string.IsNullOrEmpty(CertTypeList))
                    strSQL.AppendFormat(" and CertType like '%{0}%'", CertTypeList);
                if (!string.IsNullOrEmpty(StatusList))
                    strSQL.AppendFormat(" and OrderStatus='{0}'", StatusList);
                if (!string.IsNullOrEmpty(YHJD) && YHJD != "请选择请选择")
                    strSQL.AppendFormat(" and YHJD like '%{0}%'", YHJD.Replace("请选择",""));
                if (!string.IsNullOrEmpty(XHJD) && XHJD != "请选择请选择")
                    strSQL.AppendFormat(" and XHJD like '%{0}%'", XHJD.Replace("请选择", ""));
                if (!string.IsNullOrEmpty(Sales))
                    strSQL.AppendFormat(" and Sales like '%{0}%'", Sales);
                strSQL.Append(" order by OrderAddDate desc");
                return OrderInfo.GetViewOrderInfoWithPage(strSQL.ToString(), pageSize, pageIndex, out pageCount, out totalCount);
            }
            catch
            {
                throw;
            }
        }
    }
}
