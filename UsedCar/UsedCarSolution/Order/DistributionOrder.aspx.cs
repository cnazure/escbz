using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarDB;

namespace UsedCarSolution.Order
{
    public partial class DistributionOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //获取传递内容
                hidID.Value = Request.QueryString["ID"];
                //赋值
                if (!string.IsNullOrEmpty(hidID.Value))
                {
                    View_OrderInfo voi = new UsedCarBLL.Order.OrderManager().GetViewOrderInfoWithId(hidID.Value);
                    if (voi != null)
                    {
                        LabId.Text = voi.OrderId;
                        LabUser.Text = voi.AddUser;
                        Img.ImageUrl = voi.ImgUrl;
                        LabCustomerName.Text = voi.CustomerName;
                        LabCarModel.Text = voi.CarModel;
                        LabVIN.Text = voi.CarVIN;
                        LabYCPHM.Text = voi.YCPHM;
                        LabYHJD.Text = voi.YHJD;
                        LabYCZXM.Text = voi.YCZXM;
                        LabYCZDH.Text = voi.YCZDH;
                        if (Convert.ToBoolean(voi.YSFDC))
                        {
                            LabYCZDC.Text = "是";
                        }
                        else
                        {
                            LabYCZDC.Text = "否";
                        }
                        LabXHJD.Text = voi.XHJD;
                        LabXCZXM.Text = voi.XCZXM;
                        LabXCZDH.Text = voi.XCZDH;
                        if (Convert.ToBoolean(voi.XSFDC))
                        {
                            LabXCZDC.Text = "是";
                        }
                        else
                        {
                            LabXCZDC.Text = "否";
                        }
                        LabCertType.Text = new UsedCarPublic.OrderCommon().GetCertTypeName(voi.CertType);
                        LabTCDD.Text = voi.TCDD;
                        LabLXR.Text = voi.LXR;
                        LabLXDH.Text = voi.LXRDH;
                        LabOrderType.Text = new UsedCarPublic.OrderCommon().GetOrderType(voi.OrderType.ToString());
                        LabDJRQ.Text = Convert.ToDateTime(voi.DJDate).ToShortDateString();
                        LabYDRQ.Text = Convert.ToDateTime(voi.YDDate).ToShortDateString();
                        LabKPrice.Text = Convert.ToDecimal(voi.KPPrice).ToString("F");
                        DropSales.DataSource = new UsedCarBLL.Admin.UserManager().GetAllUserModelbyRoleName("销售员");
                        DropSales.DataTextField = "UserName";
                        DropSales.DataValueField = "UserId";
                        DropSales.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //分配
                T_CarOrder tco = new UsedCarBLL.Order.OrderManager().GetOrderInfo(hidID.Value);
                string strSalesPhone = string.Empty;
                tco.OrderStatus = 3;
                tco.OrderProcessStatus += "#3";
                if (DropSales.SelectedValue != "")
                {
                    tco.Sales = DropSales.SelectedValue;
                    //获取联系人电话
                    Admin_UserInfo au = new UsedCarBLL.Admin.UserManager().GetModel(Convert.ToInt16(DropSales.SelectedValue));
                    if (au != null)
                    {
                        strSalesPhone = au.Phone;
                    }
                    else
                    {
                        UsedCarPublic.Tools.Alert("该销售员未配置电话号码，无法完成分单", this.Page);
                    }
                }
                else
                {
                    UsedCarPublic.Tools.Alert("请选择销售员", this.Page);
                }
                int returnValue = new UsedCarBLL.Order.OrderManager().UpdateCarOrder(tco);
                if (returnValue > 0)
                {
                    //发送短信
                    bool b = new UsedCarBLL.Common.SendManager().SendDistributionOrder(Convert.ToInt16(DropSales.SelectedValue), hidID.Value, LabCarModel.Text,
                        LabVIN.Text, LabYCPHM.Text, LabCertType.Text, LabTCDD.Text, LabLXR.Text, LabLXDH.Text, LabYDRQ.Text, strSalesPhone);

                    if (b)
                    {
                        UsedCarPublic.Tools.Alert("分单成功", "WaitingOrderList.aspx", this.Page);
                    }
                    else
                    {
                        UsedCarPublic.Tools.Alert("分单成功，发送短信失败。请检查短信接口信息", "WaitingOrderList.aspx", this.Page);
                    }
                }
                else
                {
                    UsedCarPublic.Tools.Alert("分单失败", this.Page);
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        protected void Img_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Img.ImageUrl, false);
        }
    }
}