using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsedCarSolution
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            liteName.Text = "Hello, <a href='/Admin/resetPassword.aspx' target='main'>" + Context.User.Identity.Name + "</a>";
            liteIp.Text = UsedCarPublic.PublicMethods.GetWebClientIp();
        }

        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Write(" <script   language=javascript> parent.location.href= '/Login.aspx '; </script> ");
        }
    }
}