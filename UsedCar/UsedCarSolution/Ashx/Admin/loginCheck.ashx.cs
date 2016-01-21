using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using UsedCarBLL.Admin;
using UsedCarDB;

namespace UsedCarSolution.Ashx.Admin
{
    /// <summary>
    /// loginCheck 的摘要说明
    /// </summary>
    public class loginCheck : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (string.IsNullOrEmpty(context.Request.Form["name"]) || string.IsNullOrEmpty(context.Request.Form["pass"]))
            {
                context.Response.Write("您输入的用户名或密码不能为空，请重新输入！");
                context.Response.End();
                return;
            }
            string name = context.Request.Form["name"].ToString();
            string pass = context.Request.Form["pass"].ToString();
            Admin_UserInfo user = new PermissionsManager().GetUserbyUserNamePsd(name, pass);
            if (user == null)
            {
                context.Response.Write("false");
            }
            else
            {

                FormsAuthentication.RedirectFromLoginPage(user.UserName.ToString(), false);

                //存入cookie
                HttpCookie cookie = new HttpCookie("userName");
                cookie.Value = context.Request.Form["name"].ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);

                context.Response.Clear();
                context.Response.Write("true");
                context.Response.End();
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