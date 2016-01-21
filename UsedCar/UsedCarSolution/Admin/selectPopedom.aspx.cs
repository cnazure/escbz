using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsedCarBLL.Admin;
using UsedCarPublic;
using UsedCarDB;
using UsedCarModle;

namespace UsedCarSolution.Admin
{
    public partial class selectPopedom : System.Web.UI.Page
    {
        PermissionsManager permissionsManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                permissionsManager = new PermissionsManager();
                BindRp();
            }

        }

        public string GetPopedomByUserId(int RoleID)
        {
            string message = "";
            try
            {
                List<RolePop_Pop> ls = permissionsManager.GetRolePop_Pop(RoleID);
                foreach (var item in ls)
                {
                    message += item.PopedomName + "、";
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
            return message;

        }

        public void BindRp()
        {
            try
            {
                List<Admin_RoleInfo> ls = permissionsManager.GetRoleInfo();
                rpUserList.DataSource = ls;
                rpUserList.DataBind();
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
        }
    }
}