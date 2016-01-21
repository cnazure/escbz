using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarDB;

namespace UsedCarSolution.Order
{
    public partial class WaitingOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定省份
                BindProvince();
                //绑定类型
                BindOrderTypeList();
                //绑定信息
                SearchResult();

            }
        }

        /// <summary>
        /// 绑定省列表
        /// </summary>
        protected void BindProvince()
        {
            try
            {
                DropProvince.Items.Clear();
                DropProvince.Items.Add(new ListItem("请选择", ""));
                DropProvince2.Items.Clear();
                DropProvince2.Items.Add(new ListItem("请选择", ""));
                DropCity.Items.Clear();
                DropCity.Items.Add(new ListItem("请选择", ""));
                DropCity2.Items.Clear();
                DropCity2.Items.Add(new ListItem("请选择", ""));
                List<T_province> lsProvince = new UsedCarBLL.Common.ProvinceManager().GetAll();
                if (lsProvince != null && lsProvince.Count > 0)
                    foreach (var item in lsProvince)
                    {
                        DropProvince.Items.Add(new ListItem(item.province, item.provinceID.ToString()));
                        DropProvince2.Items.Add(new ListItem(item.province, item.provinceID.ToString()));
                    }
            }
            catch
            {

                throw;
            }
        }

        protected void BindOrderTypeList()
        {
            CertTypeList.Items.Add(new ListItem("请选择", ""));
            Dictionary<int, string> dicResult = new UsedCarPublic.OrderCommon().GetCertTypeList();
            foreach (KeyValuePair<int, string> item in dicResult)
            {
                CertTypeList.Items.Add(new ListItem(item.Value, item.Key.ToString()));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }

        protected void DropProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropCity.Items.Clear();
                DropCity.Items.Add(new ListItem("请选择", ""));
                if (DropProvince.SelectedValue != "")
                {
                    List<T_city> lsCity = new UsedCarBLL.Common.CityManager().GetListbyProvinceID(Convert.ToInt32(DropProvince.SelectedValue));
                    foreach (var city in lsCity)
                    {
                        DropCity.Items.Add(new ListItem(city.city, city.cityID.ToString()));
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        protected void DropProvince2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropCity2.Items.Clear();
                DropCity2.Items.Add(new ListItem("请选择", ""));
                if (DropProvince2.SelectedValue != "")
                {
                    List<T_city> lsCity = new UsedCarBLL.Common.CityManager().GetListbyProvinceID(Convert.ToInt32(DropProvince2.SelectedValue));
                    foreach (var city in lsCity)
                    {
                        DropCity2.Items.Add(new ListItem(city.city, city.cityID.ToString()));
                    }
                }
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
                   new UsedCarBLL.Order.OrderManager().GetViewOrderInfoWithPage(
                   txtCarOrderId.Text, txtCarVIN.Text, txtCarHM.Text, AddDJRQ.Text, EndDJRQ.Text,
                   AddYDRQ.Text, EndYDRQ.Text, txtCustomerName.Text, OrderTypeList.SelectedValue,
                   CertTypeList.SelectedValue, StatusList.SelectedValue,
                   DropProvince.SelectedItem.Text + DropCity.SelectedItem.Text,
                   DropProvince2.SelectedItem.Text + DropCity2.SelectedItem.Text,"",
                   AspnetPager.PageSize, AspnetPager.CurrentPageIndex, out pageCount, out rowCount);
                rpCarList.DataBind();
                AspnetPager.RecordCount = rowCount;
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        public string GetEditStr(string strOrderId, string strOrderStatus, string strOrderType)
        {
            StringBuilder strHtml = new StringBuilder();
            switch (GetRole())
            {
                case "管理员":
                    //判断当前订单状态
                    //可以查看，编辑，分单，取消订单       
                    if (strOrderStatus != "0")
                    {
                        if (strOrderStatus == "1")
                        {
                            strHtml.Append("<a class=\"btn_xgxx chakan_btn\" href=\'WaitingOrderView.aspx?ID=" + strOrderId + "'>查看</a>");
                        }
                        if (strOrderType == "1")
                            strHtml.Append("<a class=\"btn_xgxx bianji_btn\" href=\'New_BuyOrder.aspx?Type=Edit&ID=" + strOrderId + "'>编辑</a>");
                        if (strOrderType == "2")
                            strHtml.Append("<a class=\"btn_xgxx bianji_btn\" href=\'New_SellOrder.aspx?Type=Edit&ID=" + strOrderId + "'>编辑</a>");
                        if (strOrderStatus == "2")
                        {
                            strHtml.Append("<a class=\"btn_xgxx edit_roles\" href=\'DistributionOrder.aspx?ID=" + strOrderId + "'>分单</a>");
                        }
                        strHtml.Append("<a class=\"btn_xgxx qixiao-didan\" onclick=\"cancelOrder('" + strOrderId + "')\" href=\'javascript:;'>取消</a>");
                    }
                    return strHtml.ToString();
                case "录入员":
                    //判断当前订单状态
                    //可以查看，编辑，分单
                    if (strOrderStatus != "0")
                    {
                        if (strOrderStatus == "1")
                        {
                            strHtml.Append("<a class=\"btn_xgxx chakan_btn\" href=\'WaitingOrderView.aspx?ID=" + strOrderId + "'>查看</a>");
                        }

                        if (strOrderType == "1")
                            strHtml.Append("<a class=\"btn_xgxx bianji_btn\" href=\'New_BuyOrder.aspx?Type=Edit&ID=" + strOrderId + "'>编辑</a>");
                        if (strOrderType == "2")
                            strHtml.Append("<a class=\"btn_xgxx bianji_btn\" href=\'New_SellOrder.aspx?Type=Edit&ID=" + strOrderId + "'>编辑</a>");
                        if (strOrderStatus == "2")
                        {
                            strHtml.Append("<a class=\"btn_xgxx edit_roles\" href=\'DistributionOrder.aspx?ID=" + strOrderId + "'>分单</a>");
                        }
                    }
                    return strHtml.ToString();
                default:
                    //可以查看
                    strHtml.Append("<a class=\"btn_xgxx chakan_btn\" href=\'WaitingOrderView.aspx?ID=" + strOrderId + "'>查看</a>");
                    return strHtml.ToString();
            }
        }

        /// <summary>
        /// 获取当前管理员
        /// </summary>
        /// <returns></returns>
        public string GetRole()
        {
            //判断用户是否获得了权限
            string name = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                name = HttpContext.Current.User.Identity.Name.ToString();
            }
            string RoleName = new UsedCarBLL.Admin.PermissionsManager().GetRoleNameByUsername(name);
            return RoleName;
        }
    }
}