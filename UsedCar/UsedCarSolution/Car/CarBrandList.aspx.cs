using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsedCarSolution.Car
{
    public partial class CarBrandList : System.Web.UI.Page
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
                   new UsedCarBLL.Car.CarBrandManager().GetDataListWithPage(txtID.Text, txtAddUser.Text, txtCarBrand.Text, AspnetPager.PageSize, AspnetPager.CurrentPageIndex, out pageCount, out rowCount);
                rpUserList.DataBind();
                if (rpUserList.Items.Count == 0)
                {
                    ltNo.Text = "<tr><td colspan='9'>暂无数据</td></tr>";
                }
                else
                {
                    ltNo.Text = "";
                }
                AspnetPager.RecordCount = rowCount;
            }
            catch
            {

                throw;
            }
        }

        protected void AspnetPager_PageChanged(object sender, EventArgs e)
        {
            SearchResult();
        }

        public string getState(object isValid)
        {
            try
            {
                if (isValid != null)
                {
                    if (isValid.ToString() == "1")
                        return "启用";
                    else if (isValid.ToString() == "2")
                        return "禁用";
                    else
                        return "未知";
                }
                else
                    return "未知";
            }
            catch
            {

                throw;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }
    }
}