using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarDB;
using UsedCarPublic;

namespace UsedCarSolution.Car
{
    public partial class CarBrandAddorEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    switch (Request.QueryString["Type"])
                    {
                        case "Add"://添加
                            hidType.Value = "Add";
                            break;
                        case "Edit"://编辑
                            {
                                hidType.Value = "Edit";
                                hidID.Value = Request.QueryString["ID"];
                                GetInfo(hidID.Value);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_brandName.Text.Trim()))
                {
                    UsedCarPublic.Tools.Alert("品牌不能为空!", this);
                    return;
                }

                int i = 0;
                if (hidType.Value == "Edit" && hidID.Value != "")//编辑
                {
                    T_CAR_BRAND brand = new UsedCarBLL.Car.CarBrandManager().GetModel(hidID.Value);
                    brand.brandName = txt_brandName.Text.Trim();
                    brand.firstPY = UsedCarPublic.PublicMethods.GetCharSpellCode(brand.brandName);                    
                    if (rad_isValid.Checked)
                    {
                        brand.isValid = 1;
                    }
                    if (rad_isValid1.Checked)
                    {
                        brand.isValid = 2;
                    }
                    i = new UsedCarBLL.Car.CarBrandManager().Update_(brand);
                }
                else
                {
                    T_CAR_BRAND brand = new T_CAR_BRAND();
                    brand.brandName = txt_brandName.Text.Trim();
                    brand.firstPY = UsedCarPublic.PublicMethods.GetCharSpellCode(brand.brandName);                    
                    brand.operateUser = HttpContext.Current.User.Identity.Name.ToString();//创建人
                    brand.createDate = DateTime.Now;
                    if (rad_isValid.Checked)
                    {
                        brand.isValid = 1;
                    }
                    if (rad_isValid1.Checked)
                    {
                        brand.isValid = 2;
                    }

                    i = new UsedCarBLL.Car.CarBrandManager().Add(brand);
                }
                if (i > 0)
                {
                    Tools.Alert("操作成功!", "CarBrandList.aspx", this);
                }
                else
                {
                    Tools.Alert("操作失败!", this);
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        protected void GetInfo(string brandID)
        {
            try
            {
                T_CAR_BRAND brand = new UsedCarBLL.Car.CarBrandManager().GetModel(brandID);                
                txt_brandName.Text = brand.brandName;
                switch (brand.isValid)
                {
                    case 1:
                        rad_isValid.Checked = true;
                        break;
                    case 2:
                        rad_isValid1.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            catch
            {

                throw;
            }
        }
    }
}