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
    public partial class WaitingCertList : System.Web.UI.Page
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
                //判断当前用户类型
                string strRoleName = new UsedCarBLL.Admin.PermissionsManager().GetRoleNameByUsername(Context.User.Identity.Name);
                if (strRoleName == "销售员")
                {
                    rpCarList.DataSource =
                       new UsedCarBLL.Order.OrderManager().GetViewOrderInfoWithPage(
                       txtCarOrderId.Text, txtCarVIN.Text, txtCarHM.Text, AddDJRQ.Text, EndDJRQ.Text,
                       AddYDRQ.Text, EndYDRQ.Text, txtCustomerName.Text, OrderTypeList.SelectedValue,
                       CertTypeList.SelectedValue, ((int)Enum.Parse(typeof(UsedCarPublic.Constant.OrderStatus), "已分配")).ToString(),
                       DropProvince.SelectedItem.Text + DropCity.SelectedItem.Text,
                       DropProvince2.SelectedItem.Text + DropCity2.SelectedItem.Text, Context.User.Identity.Name,
                       AspnetPager.PageSize, AspnetPager.CurrentPageIndex, out pageCount, out rowCount);
                    rpCarList.DataBind();
                    AspnetPager.RecordCount = rowCount;
                }
                else
                {
                    rpCarList.DataSource =
                       new UsedCarBLL.Order.OrderManager().GetViewOrderInfoWithPage(
                       txtCarOrderId.Text, txtCarVIN.Text, txtCarHM.Text, AddDJRQ.Text, EndDJRQ.Text,
                       AddYDRQ.Text, EndYDRQ.Text, txtCustomerName.Text, OrderTypeList.SelectedValue,
                       CertTypeList.SelectedValue, ((int)Enum.Parse(typeof(UsedCarPublic.Constant.OrderStatus), "已分配")).ToString(),
                       DropProvince.SelectedItem.Text + DropCity.SelectedItem.Text,
                       DropProvince2.SelectedItem.Text + DropCity2.SelectedItem.Text, "",
                       AspnetPager.PageSize, AspnetPager.CurrentPageIndex, out pageCount, out rowCount);
                    rpCarList.DataBind();
                    AspnetPager.RecordCount = rowCount;
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }
    }
}