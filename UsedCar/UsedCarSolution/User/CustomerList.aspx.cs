using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarBLL.User;

namespace UsedCarSolution.User
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    SearchResult();
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        /// <summary>
        /// 绑定repeater
        /// </summary>
        private void SearchResult()
        {
            try
            {
                int pageCount = 0;
                int rowCount = 0;
                rpUserList.DataSource =
                   new CustomerManager().GetDataListWithPage(txtCId_cx.Text, txtCName_cx.Text, txtContacts_cx.Text, txtAddDateFrom_cx.Text, txtAddDateTo_cx.Text, AspnetPager.PageSize, AspnetPager.CurrentPageIndex, out pageCount, out rowCount);
                rpUserList.DataBind();
                AspnetPager.RecordCount = rowCount;
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            AspnetPager.CurrentPageIndex = 1;
            SearchResult();
        }

        protected void AspnetPager_PageChanged(object sender, EventArgs e)
        {
            SearchResult();
        }
    }
}