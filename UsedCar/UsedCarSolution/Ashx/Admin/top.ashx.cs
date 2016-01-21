using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsedCarSolution.Ashx.Admin
{
    /// <summary>
    /// top 的摘要说明
    /// </summary>
    public class top : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mod = context.Request["mod"];
            switch (mod)
            {
                //case "getCount":
                //    String cookieName = FormsAuthentication.FormsCookieName;
                //    context.Response.Write(isVisit(context.Request.Cookies[cookieName]));
                //    break;
                default:
                    break;
            }
        }

        //private string isVisit(HttpCookie authCookie)
        //{
        //    if (authCookie != null)
        //    {
        //        string name = "";
        //        //判断用户是否获得了权限
        //        if (HttpContext.Current.User.Identity.IsAuthenticated)
        //        {
        //            name = HttpContext.Current.User.Identity.Name.ToString();
        //        }
        //        string RoleName = new CarKeyBLL.Admin.PermissionsManager().GetRoleNameByUsername(name);

        //        if (RoleName == "管理员")
        //            return new UpkeepCouponAppointManage().GetCountNoUse() + "_" + new OrderManager().GetCountByPaySuccess() + "_" + new RepairAppointManager().GetCountByAppoint() + "_" + new RepairAppointManager().GetCountByUploadImg();

        //        else
        //            return "FALSE";

        //    }
        //    else
        //        return "FALSE";
        //}


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}