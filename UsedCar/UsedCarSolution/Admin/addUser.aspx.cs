using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsedCarSolution.Admin
{
    public partial class addUser : System.Web.UI.Page
    {
        public string userID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userID = Request.QueryString["UserID"];
            }
        }
    }
}