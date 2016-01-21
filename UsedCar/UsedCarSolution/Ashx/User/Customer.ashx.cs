using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsedCarBLL.User;
using UsedCarDB;
using UsedCarPublic;

namespace UsedCarSolution.Ashx.User
{
    /// <summary>
    /// Customer 的摘要说明
    /// </summary>
    public class Customer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mod = context.Request.Form["mod"];
            switch (mod)
            {                
                //添加新用户
                case "addCustomer": context.Response.Write(AddCustomerName(context));
                    break;
                //删除用户
                case "Delete": context.Response.Write(DelCustomer(context));
                    break;
                //获取
                case "getModel": context.Response.Write(GetModel(context));
                    break;
                //获取最新用户编号
                case "getCustomerLastId": context.Response.Write(GetLastCustomerId());
                    break;
                //更新用户
                case "updateCustomer": context.Response.Write(updateCustomer(context));
                    break;
            }
        }

      

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddCustomerName(HttpContext context)
        {
            try
            {
                T_Customer CustomerInfo = new T_Customer();
                CustomerInfo.CId = context.Request.Form["CId"].ToString();
                CustomerInfo.CName = context.Request.Form["CName"].ToString();
                CustomerInfo.Contacts = context.Request.Form["Contacts"].ToString();
                CustomerInfo.CTel = context.Request.Form["CTel"].ToString();
                CustomerInfo.CAddress = context.Request.Form["CAddress"].ToString();
                CustomerInfo.BelongUser = context.Request.Form["BelongUser"].ToString();
                CustomerInfo.AddDate = System.DateTime.Now;
                CustomerInfo.AddUser = HttpContext.Current.User.Identity.Name.ToString();//创建人;
                CustomerInfo.isUsing = true;
                int i = new CustomerManager().AddCustomer(CustomerInfo);
                return i.ToString();
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DelCustomer(HttpContext context)
        {
            int i = 0;
            try
            {
                //获取客户信息
                T_Customer CustomerInfo = new CustomerManager().GetModel(context.Request.Form["CId"].ToString());
                CustomerInfo.isUsing = false;
                //禁用当前客户
                i = new CustomerManager().UpdateCustomer(CustomerInfo);
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
            if (i > 0)
            {
                return "OK";
            }
            else
                return "problem";

        }

        /// <summary>
        /// 根据主键ID查询对象并获取用户角色
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetModel(HttpContext context)
        {
            try
            {
                T_Customer CustomerInfo = new CustomerManager().GetModel(context.Request.Form["CId"].ToString());
                return JosonHelper.ToJson(CustomerInfo);
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }

        }

        /// <summary>
        /// 生成最新客户编号
        /// </summary>
        /// <returns></returns>
        private string GetLastCustomerId()
        {
            try
            {
                return new CustomerManager().GetLastCid();
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string updateCustomer(HttpContext context)
        {
            try
            {
                //修改客户基本信息            
                T_Customer CustomerInfo = new T_Customer();
                CustomerInfo.CId = context.Request.Form["CId"].ToString();
                CustomerInfo.CName = context.Request.Form["CName"].ToString();
                CustomerInfo.Contacts = context.Request.Form["Contacts"].ToString();
                CustomerInfo.CTel = context.Request.Form["CTel"].ToString();
                CustomerInfo.CAddress = context.Request.Form["CAddress"].ToString();
                CustomerInfo.BelongUser = context.Request.Form["BelongUser"].ToString();
                CustomerInfo.AddDate = System.DateTime.Now;
                CustomerInfo.AddUser = HttpContext.Current.User.Identity.Name.ToString();//创建人;
                CustomerInfo.isUsing = true;
                int i = new CustomerManager().UpdateCustomer(CustomerInfo);
                return i.ToString();
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