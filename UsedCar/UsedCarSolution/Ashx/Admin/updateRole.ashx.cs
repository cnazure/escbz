using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsedCarBLL.Admin;
using UsedCarDB;
using UsedCarPublic;

namespace UsedCarSolution.Ashx.Admin
{
    /// <summary>
    /// updateRole 的摘要说明
    /// </summary>
    public class updateRole : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Form["mod"].ToString() == "update")
            {
                context.Response.Write(updateRoleName(context));
            }
            if (context.Request.Form["mod"].ToString() == "getData")
            {
                context.Response.Write(GetRole());
            }
            if (context.Request.Form["mod"].ToString() == "delete")
            {
                context.Response.Write(DelRole(context));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private int updateRoleName(HttpContext context)
        {
            Admin_RoleInfo roleInfo = new PermissionsManager().GetRoleInfoModel(Convert.ToInt32(context.Request.Form["roleId"]));
            roleInfo.RoleName = context.Request.Form["roleName"].ToString();
            return new PermissionsManager().UpdateRoleInfo(roleInfo);

        }

        private string GetRole()
        {
            List<Admin_RoleInfo> ls = new List<Admin_RoleInfo>();

            ls = new PermissionsManager().GetRoleInfo();

            return JosonHelper.ToJson(ls);
        }

        private string DelRole(HttpContext context)
        {
            int roleID = Convert.ToInt32(context.Request.Form["roleId"]);
            string result = "";
            try
            {
                UserManager userManager = new UserManager();
                List<Admin_UserInfoRole> ls = userManager.GetUserRoleByRoleID(roleID);
                //该角色下有用户，禁止删除
                if (ls.Count > 0)
                {
                    result = "0";
                }
                else
                {
                    PermissionsManager permissions = new PermissionsManager();

                    List<Admin_RolePoperdomInfo> ls_RolePoperdomInfo = new PermissionsManager().GetR_pModelByRoleID(roleID);
                    //删除角色-权限关系
                    permissions.DelRolePoperdomInfo(ls_RolePoperdomInfo);
                    //删除角色
                    int i = permissions.DelRoleInfo(roleID);
                    if (i > 0)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "2";
                    }
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
            return result;
        }
    }
}