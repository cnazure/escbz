using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarBLL.Admin;

namespace UsedCarSolution.Admin
{
    public partial class selectRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rpRoleList.DataSource = new PermissionsManager().GetRoleInfo();
                this.rpRoleList.DataBind();
            }
        }
    }
}