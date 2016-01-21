using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsedCarDB;
using UsedCarBLL.Admin;
using UsedCarPublic;

namespace UsedCarSolution.Ashx.Admin
{
    /// <summary>
    /// leftNavigation 的摘要说明
    /// </summary>
    public class leftNavigation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string name = string.Empty;

            ////判断用户是否获得了权限
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                name = HttpContext.Current.User.Identity.Name.ToString();
            }

            List<Admin_PopedomInfo> listCategory = new List<Admin_PopedomInfo>();

            listCategory = new PermissionsManager().GetPopByUserName(name);

            context.Response.Write(JosonHelper.ToJson(listCategory));
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