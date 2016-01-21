using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsedCarBLL.Order;
using UsedCarDB;

namespace UsedCarSolution.Ashx.Order
{
    /// <summary>
    /// OrderInfo 的摘要说明
    /// </summary>
    public class OrderInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mod = context.Request.Form["mod"];
            switch (mod)
            {

                //获取最新车辆编号
                case "getOrderId": context.Response.Write(GetCarId());
                    break;
                case "DelOrder": context.Response.Write(DelOrder(context));
                    break;
            }
        }

        /// <summary>
        /// 生成最新车辆编号
        /// </summary>
        /// <returns></returns>
        private string GetCarId()
        {
            try
            {
                return new UsedCarBLL.Order.OrderManager().GetOrderId();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DelOrder(HttpContext context)
        {
            try
            {
                int i = 0;
                //获取车辆信息
                T_CarOrder CarOrder = new UsedCarBLL.Order.OrderManager().GetOrderInfo(context.Request.Form["ID"].ToString());
                if (CarOrder != null)
                {
                    CarOrder.OrderStatus = 0;
                    CarOrder.OrderProcessStatus += "#0";
                    //禁用当前车辆
                    i = new OrderManager().UpdateCarOrder(CarOrder);
                    //if (i > 0)
                    //{
                    //    T_CarInfo_Log CarInfoLog = new T_CarInfo_Log();
                    //    CarInfoLog.CarId = CarInfo.CarId;
                    //    CarInfoLog.status = 2;//新增为0,修改为1，删除2
                    //    CarInfoLog.processStatus += "#2";//追加修改状态
                    //    CarInfoLog.statusRemark = "删除信息";
                    //    CarInfoLog.EditUser = HttpContext.Current.User.Identity.Name.ToString();//删除人;
                    //    CarInfoLog.EditDate = System.DateTime.Now;
                    //    CarInfoLogManager clm = new CarInfoLogManager();
                    //    int j = clm.Add(CarInfoLog);
                    //    if (j > 0)
                    //    {
                    //        return "OK";
                    //    }
                    //    else
                    //    {
                    //        return "problem";
                    //    }
                    if (i > 0)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "problem";
                    }
                }
                else 
                {
                    return "problem";
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}