using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarDB;
using UsedCarBLL.Admin;

namespace UsedCarSolution
{
    public partial class tab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    loadBind();
                    //RedirectByRoles();
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }

        //不同角色跳转至不同的任务页
        private void RedirectByRoles()
        {
            //switch (liteRoleName.Text)
            //{
            //    case "客服":
            //        Response.Redirect("tab_cs.aspx", false);
            //        break;
            //    case "销售员":
            //        Response.Redirect("tab_sales.aspx", false);
            //        break;
            //    case "检验员":
            //        Response.Redirect("tab_check.aspx", false);
            //        break;
            //    case "管理员":
            //    case "客服经理":
            //    case "销售经理":
            //        Response.Redirect("tab_manager.aspx", false);
            //        break;
            //}
        }

        private void loadBind()
        {
            try
            {
                string name = "";

                //判断用户是否获得了权限
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    name = HttpContext.Current.User.Identity.Name.ToString();
                else
                { Show("请退出重新登录", this); return; }

                int userID = new UsedCarBLL.Admin.PermissionsManager().GetUserIDbyUserName(name);
                int roleID = new UserManager().GetUserRoleByUserID(userID).RoleId;
                //角色名称
                Admin_RoleInfo roleInfo = new PermissionsManager().GetRoleInfoModel(roleID);
                if (roleInfo != null)
                    liteRoleName.Text = roleInfo.RoleName;
                //根据name获得对象            
                UsedCarDB.Admin_UserInfo model = new UsedCarBLL.Admin.PermissionsManager().GetAdminUserInfoByUserName(name);
                if (model != null)
                {
                    ltUserName.Text = model.UserName;
                    ltTrueName.Text = model.TrueName;

                    ltRegistTime.Text = DateTime.Parse(model.Time.ToString()).ToString("yyyy年MM月dd日 hh点mm分ss秒");
                }
            }
            catch
            {

                throw;
            }
        }

        public static void Show(string msg, System.Web.UI.Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

    }
}