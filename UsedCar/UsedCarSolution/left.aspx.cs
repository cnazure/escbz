using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarPublic.Log;

namespace UsedCarSolution
{
    public partial class left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = string.Empty;
                //判断用户是否获得了权限
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    name = HttpContext.Current.User.Identity.Name.ToString();
                ExceptionLog.SetLoginLog(name);
            }
        }
    }
}