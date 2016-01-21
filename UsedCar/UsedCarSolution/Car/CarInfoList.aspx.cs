using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarBLL.Car;

namespace UsedCarSolution.Car
{
    public partial class CarInfoList : System.Web.UI.Page
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
                rpCarList.DataSource =
                   new CarInfoManager().GetDataListWithPage(txtCarVIN.Text, txtAddUser.Text, txtCarModel.Text, txtCarId.Text, 
                   txtAddDateBefore.Text, txtAddDateEnd.Text, AspnetPager.PageSize, AspnetPager.CurrentPageIndex, out pageCount, out rowCount);
                rpCarList.DataBind();
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