using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsedCarBLL.Admin;
using UsedCarDB;
using UsedCarPublic;

namespace UsedCarSolution.Ashx.User
{
    /// <summary>
    /// updateCustomer 的摘要说明
    /// </summary>
    public class updateCustomer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //if (context.Request.Form["mod"].ToString() == "update")
            //{
            //    context.Response.Write(updateCustomerName(context));
            //}
            if (context.Request.Form["mod"].ToString() == "getData")
            {
                context.Response.Write(GetUsers());
            }
            //if (context.Request.Form["mod"].ToString() == "delete")
            //{
            //    context.Response.Write(DelCustomer(context));
            //}
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //private int updateCustomerName(HttpContext context)
        //{
        //    Admin_CustomerInfo CustomerInfo = new PermissionsManager().GetCustomerInfoModel(Convert.ToInt32(context.Request.Form["CustomerId"]));
        //    CustomerInfo.CustomerName = context.Request.Form["CustomerName"].ToString();
        //    return new PermissionsManager().UpdateCustomerInfo(CustomerInfo);

        //}

        /// <summary>
        /// 获取所有管理员账户
        /// </summary>
        /// <returns></returns>
        private string GetUsers()
        {
            try
            {
                List<Admin_UserInfo> ls = new List<Admin_UserInfo>();

                ls = new UserManager().GetAllUser();

                return JosonHelper.ToJson(ls);
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        private string DelCustomer(HttpContext context)
        {
            return string.Empty;
        }
    }
}