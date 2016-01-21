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
    /// userOperate 的摘要说明
    /// </summary>
    public class userOperate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mod = context.Request.Form["mod"];
            switch (mod)
            {
                //验证用户名是否重复
                case "checkUserName": context.Response.Write(checkUserName(context));
                    break;
                //添加新用户
                case "addUser": context.Response.Write(AddUserName(context));
                    break;
                //删除用户
                case "Delete": context.Response.Write(DelUser(context));
                    break;
                //获取
                case "getModel": context.Response.Write(GetModel(context));
                    break;
                //更新用户
                case "updateUser": context.Response.Write(updateUser(context));
                    break;
                //重置密码
                case "resetPwd": context.Response.Write(resetPwd(context));
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// </summary>
        //判断用户名是否重复
        /// </summary>
        private string checkUserName(HttpContext context)
        {
            object obj = new UserManager().GetModel(context.Request.Form["userName"].ToString());
            string i = obj == null ? "0" : "1";
            return i;
        }

        /// </summary>
        //添加用户
        /// </summary>
        private string AddUserName(HttpContext context)
        {
            try
            {
                Admin_UserInfo userInfo = new Admin_UserInfo();
                PermissionsManager permissions = new PermissionsManager();
                UserManager userManager = new UserManager();
                userInfo.UserName = context.Request.Form["userName"].ToString().Trim();
                userInfo.UserPass = context.Request.Form["password"].ToString().Trim();
                userInfo.Phone = context.Request.Form["phone"].ToString().Trim();
                userInfo.Address = context.Request.Form["address"].ToString().Trim();
                string sex = context.Request.Form["sex"].ToString() == "1" ? "男" : "女";
                userInfo.Sex = sex;
                userInfo.TrueName = context.Request.Form["trueName"].ToString();
                userInfo.Time = DateTime.Now;
                userManager.Add(userInfo);
                int userID = permissions.GetUserbyUserNamePsd(userInfo.UserName, userInfo.UserPass).UserID;
                //增加用户-角色关系
                Admin_UserInfoRole userInfoRole = new Admin_UserInfoRole();
                userInfoRole.RoleId = Convert.ToInt32(context.Request.Form["roleID"]);
                userInfoRole.UserId = userID;
                int i = userManager.addUserRole(userInfoRole);
                return i.ToString();
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return string.Empty;
            }
        }

        /// </summary>
        //删除用户
        /// </summary>
        private string DelUser(HttpContext context)
        {
            int i = 0;
            try
            {
                UserManager userManager = new UserManager();
                //删除用户表
                Admin_UserInfo userInfo = new Admin_UserInfo();
                userInfo.UserID = Convert.ToInt32(context.Request.Form["ID"]);
                userManager.DelUser(userInfo);
                //删除用户角色表
                Admin_UserInfoRole userInfoRole = new Admin_UserInfoRole();

                //获取主键ID
                userInfoRole = userManager.GetUserRoleByUserID(Convert.ToInt32(context.Request.Form["ID"]));                
                i = userManager.DelUserRole(userInfoRole);
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
            }
            if (i > 0)
            {
                return "OK";
            }
            else
                return "problem";

        }

        /// </summary>
        //根据主键ID查询对象并获取用户角色
        /// </summary>
        private string GetModel(HttpContext context)
        {
            UserManager userManager = new UserManager();
            Admin_UserInfo userInfo = userManager.GetModel(Convert.ToInt32(context.Request.Form["userID"]));
            Admin_UserInfoRole userInfoRole = userManager.GetUserRoleByUserID(Convert.ToInt32(context.Request.Form["userID"]));
            return userInfoRole.RoleId + "$" + JosonHelper.ToJson(userInfo);
        }

        /// </summary>
        //修改用户信息
        /// </summary>
        private string updateUser(HttpContext context)
        {
            //修改用户基本信息
            UserManager userManager = new UserManager();
            Admin_UserInfo userInfo = userManager.GetModel(Convert.ToInt32(context.Request.Form["userID"]));
            userInfo.UserName = context.Request.Form["userName"].ToString().Trim();
            userInfo.UserPass = context.Request.Form["password"].ToString().Trim();
            userInfo.Phone = context.Request.Form["Phone"].ToString().Trim();
            userInfo.Address = context.Request.Form["Address"].ToString().Trim();
            userInfo.TrueName = context.Request.Form["TrueName"].ToString().Trim();
            userInfo.Sex = context.Request.Form["sex"].ToString() == "1" ? "男" : "女";
            userManager.UpdateUser(userInfo);
            //修改用户的角色
            Admin_UserInfoRole userInfoRole = userManager.GetUserRoleByUserID(Convert.ToInt32(context.Request.Form["userID"]));
            userInfoRole.RoleId = Convert.ToInt32(context.Request.Form["roleID"]);
            userInfoRole.UserId = Convert.ToInt32(context.Request.Form["userID"]);
            int i = userManager.UpdateUserInfoRole(userInfoRole);
            return i.ToString();
        }

        /// </summary>
        //重置密码
        /// </summary>
        private string resetPwd(HttpContext context)
        {
            string ret = "ERROR";
            string username = context.Request.Form["userName"];
            string pwd = context.Request.Form["password"];
            if (!string.IsNullOrEmpty(username))
            {
                UserManager userManager = new UserManager();
                Admin_UserInfo userInfo = userManager.GetModel(username);
                userInfo.UserPass = pwd.Trim();
                int i = userManager.UpdateUser(userInfo);
                if (i > 0)
                    ret = "OK";
            }
            return ret;
        }
    }
}