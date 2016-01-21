using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsedCarSolution.Car
{
    public partial class CarInfoAddorEdit : System.Web.UI.Page
    {
        public string CarId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarId = Request.QueryString["CarId"];
            }
        }
    }
}