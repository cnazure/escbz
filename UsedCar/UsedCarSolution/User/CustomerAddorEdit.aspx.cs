using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsedCarSolution.User
{
    public partial class CustomerAddorEdit : System.Web.UI.Page
    {
        public string CId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CId = Request.QueryString["CId"];
            }
        }
    }
}