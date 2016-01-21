using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarDB;

namespace UsedCarSolution.Order
{
    public partial class WaitingOrderView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                        if (voi.OrderStatus == 1)
                        {
                            //提交，分单不显示
                            btnFendan.Visible = false;
                            btnSumbit.Visible = true;
                        }
                        else if (voi.OrderStatus == 2)
                        {
                            //分单
                            btnFendan.Visible = true;
                            btnSumbit.Visible = false;
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //跳转
            Response.Redirect("New_BuyOrder.aspx?Type=Edit&ID=" + hidID.Value + "", false);
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            //提交
            T_CarOrder  tco = new UsedCarBLL.Order.OrderManager().GetOrderInfo(hidID.Value);
            tco.OrderStatus = 2;
            tco.OrderProcessStatus += "#2";
            int returnValue = new UsedCarBLL.Order.OrderManager().UpdateCarOrder(tco);
            if (returnValue > 0)
            {
                UsedCarPublic.Tools.Alert("提交成功", "WaitingOrderList.aspx", this.Page);
            }
            else
            {
                UsedCarPublic.Tools.Alert("提交失败", this.Page);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //分单
            Response.Redirect("DistributionOrder.aspx?ID=" + hidID.Value + "", false);
        }

        protected void Img_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Img.ImageUrl, false);
        }
    }
}