using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarBLL.Car;
using UsedCarDB;

namespace UsedCarSolution.Order
{
    public partial class New_BuyOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取当前登陆人姓名
                LabUser.Text = HttpContext.Current.User.Identity.Name.ToString();
                //绑定省份
                BindProvince();
                //绑定客户名称
                BindCustomerList();
                //绑定车辆信息
                SearchResult();
                //设置车架号不可读
                txtCarVIN.Attributes.Add("readonly", "true");
                switch (Request.QueryString["Type"])
                {
                    case "Add"://添加
                        //生成订单编号
                        LabId.Text = new UsedCarBLL.Order.OrderManager().GetOrderId();
                        hidType.Value = "Add";
                        btnSave.Visible = true;
                        btnSub.Visible = false;
                        btnUpdate.Visible = false;
                        break;
                    case "Edit"://编辑
                        hidType.Value = "Edit";
                        btnSave.Visible = false;
                        btnSub.Visible = false;
                        btnUpdate.Visible = true;
                        hidID.Value = Request.QueryString["ID"];
                        break;
                    default:
                        hidType.Value = "Add";
                        btnSave.Visible = true;
                        btnSub.Visible = false;
                        btnUpdate.Visible = false;
                        break;
                }
                BindData();
            }
        }



        protected void BindData()
        {
            T_CarOrder orderInfo;
            if (hidType.Value == "Edit" && !string.IsNullOrEmpty(hidID.Value))
            {
                //载入
                string OrderId = hidID.Value;
                orderInfo = new UsedCarBLL.Order.OrderManager().GetOrderInfo(OrderId);
                if (orderInfo != null)
                {
                    LabId.Text = orderInfo.OrderId;
                    LabUser.Text = orderInfo.AddUser;
                    if (orderInfo.CertType.Contains(','))
                    {
                        UsedCarPublic.PublicMethods.SetChecked(CertType, orderInfo.CertType, ",");
                    }
                    else
                    {
                        CertType.SelectedValue = orderInfo.CertType;
                    }
                    txtTypeBei.Text = orderInfo.CertTypeOther;
                    hidCarId.Value = orderInfo.CarId;
                    txtCarVIN.Text = orderInfo.CarVIN;
                    if (orderInfo.KPPrice != 0 && orderInfo.KPPrice != null)
                    {
                        txtAmount.Text = Convert.ToDecimal(orderInfo.KPPrice).ToString("F");
                    }
                    CustomerList.SelectedItem.Text = orderInfo.CustomerName;
                    if (orderInfo.DJDate != null)
                    {
                        txtDJDate.Text = Convert.ToDateTime(orderInfo.DJDate).ToShortDateString();
                    }
                    if (!string.IsNullOrEmpty(orderInfo.YHJD))
                    {
                        string[] strYHJD = orderInfo.YHJD.Split('|');
                        //原户籍地
                        if (strYHJD.Length > 1)
                        {
                            DropProvince.SelectedItem.Text = strYHJD[0];
                            DropCity.SelectedItem.Text = strYHJD[1];
                        }
                    }
                    if (orderInfo.SHType != null && orderInfo.SHType != 0)
                    {
                        RadioBoxShanghai.SelectedValue = orderInfo.SHType.ToString();
                        RadioBoxShanghai.Style.Add("display", "block");
                    }
                    txtYCZXM.Text = orderInfo.YCZXM;
                    txtYCZDH.Text = orderInfo.YCZDH;
                    txtYCZCard.Text = orderInfo.YCPHM;
                    //原车主是否到场
                    if (orderInfo.YSFDC != null)
                    {
                        YCZRadio.SelectedValue = Convert.ToInt16(orderInfo.YSFDC).ToString();
                    }
                    //新户籍地
                    if (!string.IsNullOrEmpty(orderInfo.XHJD))
                    {
                        string[] strXHJD = orderInfo.XHJD.Split('|');
                        if (strXHJD.Length > 1)
                        {
                            DropProvince2.SelectedItem.Text = strXHJD[0];
                            DropCity2.SelectedItem.Text = strXHJD[1];
                        }
                    }
                    txtXCZXM.Text = orderInfo.XCZXM;
                    txtXCZDH.Text = orderInfo.XCZDH;
                    txtXCPHM.Text = orderInfo.XCPHM;
                    //新车主是否到场
                    if (orderInfo.XSFDC != null)
                    {
                        XCZRadio.SelectedValue = Convert.ToInt16(orderInfo.XSFDC).ToString();
                    }
                    txtTCDD.Text = orderInfo.TCDD;
                    txtLXR.Text = orderInfo.LXR;
                    txtLXRDH.Text = orderInfo.LXRDH;
                    if (orderInfo.YDDate != null)
                    {
                        txtYDDate.Text = Convert.ToDateTime(orderInfo.YDDate).ToShortDateString();
                    }
                }
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
                   new CarInfoManager().GetDataListWithPage(txtCar.Text, "", txtCarModel.Text, txtCarId.Text, "", "", AspnetPager.PageSize, AspnetPager.CurrentPageIndex, out pageCount, out rowCount);
                rpCarList.DataBind();
                AspnetPager.RecordCount = rowCount;
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        protected void AspnetPager_PageChanged(object sender, EventArgs e)
        {
            SearchResult();
            //控制显示层
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>$('.tjxx_cont').show();</script>");
        }
       

        protected void BindCustomerList()
        {
            CustomerList.Items.Clear();
            CustomerList.Items.Add(new ListItem("请选择", ""));
            List<T_Customer> cList = new UsedCarBLL.User.CustomerManager().GetAllCustomer();
            if (cList != null && cList.Count > 0)
                foreach (var item in cList)
                {
                    CustomerList.Items.Add(new ListItem(item.CName, item.CId));
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

        protected void DropProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropCity.Items.Clear();
                DropCity.Items.Add(new ListItem("请选择", ""));
                List<T_city> lsCity = new UsedCarBLL.Common.CityManager().GetListbyProvinceID(Convert.ToInt32(DropProvince.SelectedValue));
                foreach (var city in lsCity)
                {
                    DropCity.Items.Add(new ListItem(city.city, city.cityID.ToString()));
                }
                if (DropProvince.SelectedValue == "310000")
                {
                    RadioBoxShanghai.Style.Add("display", "block");
                }
                else
                {
                    RadioBoxShanghai.Style.Add("display", "none");
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
                List<T_city> lsCity = new UsedCarBLL.Common.CityManager().GetListbyProvinceID(Convert.ToInt32(DropProvince2.SelectedValue));
                foreach (var city in lsCity)
                {
                    DropCity2.Items.Add(new ListItem(city.city, city.cityID.ToString()));
                }
            }
            catch
            {

                throw;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            AspnetPager.CurrentPageIndex = 1;
            SearchResult();
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>$('.tjxx_cont').show();</script>");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //保存
                //商品类型
                if (string.IsNullOrEmpty(CertType.SelectedValue))
                {
                    UsedCarPublic.Tools.Alert("请选择办证项目", this.Page);
                    return;
                }
                else
                {
                    //验证选择办证项目
                    if (SumbitCheckType(CertType.SelectedValue))
                    {
                        //开始新增类型
                        T_CarOrder tco = new T_CarOrder();
                        tco.CarId = hidCarId.Value;
                        tco.CarVIN = txtCarVIN.Text;
                        tco.CertType = UsedCarPublic.PublicMethods.GetChecked(CertType, ",");
                        tco.CertTypeOther = txtTypeBei.Text;
                        if (CustomerList.SelectedItem.Text != "请选择")
                        {
                            tco.CustomerName = CustomerList.SelectedItem.Text;//客户名称
                        }
                        if (!string.IsNullOrEmpty(txtDJDate.Text))
                        {
                            tco.DJDate = Convert.ToDateTime(txtDJDate.Text);
                        }
                        if (!string.IsNullOrEmpty(txtAmount.Text))
                        {
                            tco.KPPrice = Convert.ToDecimal(txtAmount.Text);//开票金额
                        }
                        tco.LXR = txtLXR.Text;
                        tco.LXRDH = txtLXRDH.Text;
                        tco.OrderAdddate = DateTime.Now;
                        tco.OrderId = LabId.Text;
                        tco.OrderStatus = 1;
                        tco.OrderType = 1;//收购订单
                        tco.OrderProcessStatus += "#1";
                        tco.AddUser = LabUser.Text;
                        if (!string.IsNullOrEmpty(RadioBoxShanghai.SelectedValue))
                            tco.SHType = Convert.ToInt16(RadioBoxShanghai.SelectedValue);
                        tco.TCDD = txtTCDD.Text;
                        tco.XCPHM = txtXCPHM.Text;
                        tco.XCZDH = txtXCZDH.Text;
                        tco.XCZXM = txtXCZXM.Text;
                        if (!string.IsNullOrEmpty(DropCity2.SelectedValue))
                            tco.XHJD = DropProvince2.SelectedItem.Text + "|" + DropCity2.SelectedItem.Text;
                        if (XCZRadio.SelectedIndex != -1)
                            if (XCZRadio.SelectedValue == "1")
                                tco.XSFDC = true;
                            else
                                tco.XSFDC = false;
                        tco.YCPHM = txtYCZCard.Text;
                        tco.YCZDH = txtYCZDH.Text;
                        tco.YCZXM = txtYCZXM.Text;
                        if (!string.IsNullOrEmpty(txtYDDate.Text))
                        {
                            tco.YDDate = Convert.ToDateTime(txtYDDate.Text);
                        }
                        if (!string.IsNullOrEmpty(DropCity.SelectedValue))
                            tco.YHJD = DropProvince.SelectedItem.Text + "|" + DropCity.SelectedItem.Text;
                        if (YCZRadio.SelectedIndex != -1)
                            if (YCZRadio.SelectedValue == "1")
                                tco.YSFDC = true;
                            else
                                tco.YSFDC = false;
                        if (new UsedCarBLL.Order.OrderManager().AddCarOrder(tco) > 0)
                        {
                            UsedCarPublic.Tools.Alert("保存成功", "New_BuyOrder.aspx?Type=Add", this.Page);
                        }
                        else
                        {
                            UsedCarPublic.Tools.Alert("保存失败", "New_BuyOrder.aspx?Type=Add", this.Page);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            //保存
            //商品类型
            if (string.IsNullOrEmpty(CertType.SelectedValue))
            {
                UsedCarPublic.Tools.Alert("请选择办证项目", this.Page);
                return;
            }
            else
            {
                //验证选择办证项目
                if (SumbitCheckType(CertType.SelectedValue))
                {
                    //开始新增类型
                    T_CarOrder tco = new T_CarOrder();
                    tco.CarId = hidCarId.Value;
                    tco.CarVIN = txtCarVIN.Text;
                    tco.CertType = UsedCarPublic.PublicMethods.GetChecked(CertType, ",");
                    tco.CertTypeOther = txtTypeBei.Text;
                    if (CustomerList.SelectedItem.Text != "请选择")
                    {
                        tco.CustomerName = CustomerList.SelectedItem.Text;//客户名称
                    }
                    if (!string.IsNullOrEmpty(txtDJDate.Text))
                    {
                        tco.DJDate = Convert.ToDateTime(txtDJDate.Text);
                    }
                    if (!string.IsNullOrEmpty(txtAmount.Text))
                    {
                        tco.KPPrice = Convert.ToDecimal(txtAmount.Text);//开票金额
                    }
                    tco.LXR = txtLXR.Text;
                    tco.LXRDH = txtLXRDH.Text;
                    tco.OrderAdddate = DateTime.Now;
                    tco.OrderId = LabId.Text;
                    tco.OrderStatus = 2;//提交未分配
                    tco.OrderType = 1;//收购订单
                    tco.OrderProcessStatus += "#2";
                    tco.AddUser = LabUser.Text;
                    if (!string.IsNullOrEmpty(RadioBoxShanghai.SelectedValue))
                        tco.SHType = Convert.ToInt16(RadioBoxShanghai.SelectedValue);
                    tco.TCDD = txtTCDD.Text;
                    tco.XCPHM = txtXCPHM.Text;
                    tco.XCZDH = txtXCZDH.Text;
                    tco.XCZXM = txtXCZXM.Text;
                    if (!string.IsNullOrEmpty(DropCity2.SelectedValue))
                        tco.XHJD = DropProvince2.SelectedItem.Text + "|" + DropCity2.SelectedItem.Text;
                    if (!string.IsNullOrEmpty(XCZRadio.SelectedItem.Text))
                        if (XCZRadio.SelectedValue == "1")
                            tco.XSFDC = true;
                        else
                            tco.XSFDC = false;
                    tco.YCPHM = txtYCZCard.Text;
                    tco.YCZDH = txtYCZDH.Text;
                    tco.YCZXM = txtYCZXM.Text;
                    if (!string.IsNullOrEmpty(txtYDDate.Text))
                    {
                        tco.YDDate = Convert.ToDateTime(txtYDDate.Text);
                    }
                    if (!string.IsNullOrEmpty(DropCity.SelectedValue))
                        tco.YHJD = DropProvince.SelectedItem.Text + "|" + DropCity.SelectedItem.Text;
                    if (!string.IsNullOrEmpty(YCZRadio.SelectedItem.Text))
                        if (YCZRadio.SelectedValue == "1")
                            tco.YSFDC = true;
                        else
                            tco.YSFDC = false;
                    if (new UsedCarBLL.Order.OrderManager().AddCarOrder(tco) > 0)
                    {
                        UsedCarPublic.Tools.Alert("提交成功", "New_BuyOrder.aspx?Type=Add", this.Page);
                    }
                    else
                    {
                        UsedCarPublic.Tools.Alert("提交失败", "New_BuyOrder.aspx?Type=Add", this.Page);
                    }

                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //编辑
            try
            {
                //商品类型
                if (string.IsNullOrEmpty(CertType.SelectedValue))
                {
                    UsedCarPublic.Tools.Alert("请选择办证项目", this.Page);
                    return;
                }
                else
                {
                    //验证选择办证项目
                    if (SumbitCheckType(CertType.SelectedValue))
                    {
                        //开始新增类型
                        T_CarOrder tco = new UsedCarBLL.Order.OrderManager().GetOrderInfo(LabId.Text);
                        tco.CarId = hidCarId.Value;
                        tco.CarVIN = txtCarVIN.Text;
                        //办证类型
                        string CertTypeArray = string.Empty;
                        for (int i = 0; i < CertType.Items.Count; i++)
                        {
                            if (CertType.Items[i].Selected == true)
                                CertTypeArray += CertType.Items[i].Value + ",";
                        }
                        tco.CertType = CertTypeArray;
                        tco.CertTypeOther = txtTypeBei.Text;
                        if (CustomerList.SelectedItem.Text != "请选择")
                        {
                            tco.CustomerName = CustomerList.SelectedItem.Text;//客户名称
                        }
                        if (!string.IsNullOrEmpty(txtDJDate.Text))
                        {
                            tco.DJDate = Convert.ToDateTime(txtDJDate.Text);
                        }
                        if (!string.IsNullOrEmpty(txtAmount.Text))
                        {
                            tco.KPPrice = Convert.ToDecimal(txtAmount.Text);//开票金额
                        }
                        tco.LXR = txtLXR.Text;
                        tco.LXRDH = txtLXRDH.Text;
                        tco.OrderAdddate = DateTime.Now;
                        tco.OrderId = LabId.Text;
                        tco.AddUser = LabUser.Text;
                        if (!string.IsNullOrEmpty(RadioBoxShanghai.SelectedValue))
                            tco.SHType = Convert.ToInt16(RadioBoxShanghai.SelectedValue);
                        tco.TCDD = txtTCDD.Text;
                        tco.XCPHM = txtXCPHM.Text;
                        tco.XCZDH = txtXCZDH.Text;
                        tco.XCZXM = txtXCZXM.Text;
                        if (!string.IsNullOrEmpty(DropCity2.SelectedValue))
                            tco.XHJD = DropProvince2.SelectedItem.Text + "|" + DropCity2.SelectedItem.Text;
                        if (!string.IsNullOrEmpty(XCZRadio.SelectedItem.Text))
                            if (XCZRadio.SelectedValue == "1")
                                tco.XSFDC = true;
                            else
                                tco.XSFDC = false;
                        tco.YCPHM = txtYCZCard.Text;
                        tco.YCZDH = txtYCZDH.Text;
                        tco.YCZXM = txtYCZXM.Text;
                        if (!string.IsNullOrEmpty(txtYDDate.Text))
                        {
                            tco.YDDate = Convert.ToDateTime(txtYDDate.Text);
                        }
                        if (!string.IsNullOrEmpty(DropCity.SelectedValue))
                            tco.YHJD = DropProvince.SelectedItem.Text + "|" + DropCity.SelectedItem.Text;
                        if (!string.IsNullOrEmpty(YCZRadio.SelectedItem.Text))
                            if (YCZRadio.SelectedValue == "1")
                                tco.YSFDC = true;
                            else
                                tco.YSFDC = false;
                        if (new UsedCarBLL.Order.OrderManager().UpdateCarOrder(tco) > 0)
                        {
                            UsedCarPublic.Tools.Alert("编辑成功", "WaitingOrderList.aspx", this.Page);
                        }
                        else
                        {
                            UsedCarPublic.Tools.Alert("编辑失败", "WaitingOrderList.aspx", this.Page);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }



        /// <summary>
        /// 判断办证类型
        /// </summary>
        /// <param name="strType">办证类型</param>
        protected bool SumbitCheckType(string strType)
        {
            if (string.IsNullOrEmpty(txtCarVIN.Text))
            {
                UsedCarPublic.Tools.Alert("请填写车架号", this.Page);
                return false;
            }

            switch (strType)
            {
                case "1":
                    //提档
                    //原车牌号码、原户籍地、原车主是否到场、新户籍地、新车主是否到场、开票金额
                    if (string.IsNullOrEmpty(txtAmount.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写开票金额", this.Page);
                        txtAmount.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(DropCity.SelectedItem.Text) && DropCity.SelectedItem.Text != "请选择")
                    {
                        UsedCarPublic.Tools.Alert("请选择原户籍地", this.Page);
                        DropCity.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    else if (YCZRadio.SelectedItem == null)
                    {
                        UsedCarPublic.Tools.Alert("请选择原车主是否到场", this.Page);
                        YCZRadio.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(DropCity2.SelectedItem.Text) && DropCity2.SelectedItem.Text != "请选择")
                    {
                        UsedCarPublic.Tools.Alert("请选择新户籍地", this.Page);
                        DropCity2.Focus();
                        return false;
                    }
                    else if (XCZRadio.SelectedItem == null)
                    {
                        UsedCarPublic.Tools.Alert("请选择新车主是否到场", this.Page);
                        XCZRadio.Focus();
                        return false;
                    }
                    return true;
                case "2":
                    //过户
                    //原车牌号码、原户籍地、原车主是否到场、新户籍地、新车主电话、新车主是否到场、开票金额
                    if (string.IsNullOrEmpty(txtAmount.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写开票金额", this.Page);
                        txtAmount.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(DropCity.SelectedItem.Text) && DropCity.SelectedItem.Text != "请选择")
                    {
                        UsedCarPublic.Tools.Alert("请选择原户籍地", this.Page);
                        DropCity.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(YCZRadio.SelectedItem.Text))
                    {
                        UsedCarPublic.Tools.Alert("请选择原车主是否到场", this.Page);
                        YCZRadio.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(DropCity2.SelectedItem.Text) && DropCity2.SelectedItem.Text != "请选择")
                    {
                        UsedCarPublic.Tools.Alert("请选择新户籍地", this.Page);
                        DropCity2.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtXCZDH.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写新车主电话", this.Page);
                        txtXCZDH.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(XCZRadio.SelectedItem.Text))
                    {
                        UsedCarPublic.Tools.Alert("请选择新车主是否到场", this.Page);
                        XCZRadio.Focus();
                        return false;
                    }
                    return true;
                case "3":
                    //上牌
                    //原车主是否到场、新户籍地、车主电话、新车主是否到场
                    if (string.IsNullOrEmpty(YCZRadio.SelectedItem.Text))
                    {
                        UsedCarPublic.Tools.Alert("请选择原车主是否到场", this.Page);
                        YCZRadio.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(DropCity2.SelectedItem.Text) && DropCity2.SelectedItem.Text != "请选择")
                    {
                        UsedCarPublic.Tools.Alert("请选择新户籍地", this.Page);
                        DropCity2.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtXCZDH.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写新车主电话", this.Page);
                        txtXCZDH.Focus();
                        return false;
                    }
                    else if (string.IsNullOrEmpty(XCZRadio.SelectedItem.Text))
                    {
                        UsedCarPublic.Tools.Alert("请选择新车主是否到场", this.Page);
                        XCZRadio.Focus();
                        return false;
                    }
                    return true;
                case "4":
                    //正常委托
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "5":
                    //过期委托
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "6":
                    //正常年检
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "7":
                    //过期年检
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "8":
                    //商业险保险

                    return true;
                case "9":
                    //一年交强险
                    return true;
                case "10":
                    //一月交强险
                    return true;
                case "11":
                    //违章处理
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "12":
                    //变更车架号
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "13":
                    //变更发动机号
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "14":
                    //变更车主姓名
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "15":
                    //变更证件号码
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "16":
                    //变更车辆颜色
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "17":
                    //变更其他信息
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "18":
                    //补车辆登记证书
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "19":
                    //补车辆行驶证
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "20":
                    //补车辆牌照
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "21":
                    //补车辆保单
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "22":
                    //补车辆其他项目
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "23":
                    //抵押登记
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "24":
                    //解除抵押
                    //原车牌号码
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                case "25":
                    //其他
                    if (string.IsNullOrEmpty(txtYCZCard.Text))
                    {
                        UsedCarPublic.Tools.Alert("请填写原车牌号码", this.Page);
                        txtYCZCard.Focus();
                        return false;
                    }
                    return true;
                default:
                    return false;
            }
        }
    }
}