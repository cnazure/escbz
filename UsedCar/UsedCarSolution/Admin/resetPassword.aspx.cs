using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarDB;
using UsedCarBLL.Admin;

namespace UsedCarSolution.Admin
{
    public partial class resetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                loadBind();
        }

        private void loadBind()
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

        public static void Show(string msg, System.Web.UI.Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
    }
}