using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCarDAL.Admin;
using UsedCarDB;

namespace UsedCarBLL.Admin
{
    public class UserManager
    {
        private readonly UserService userService = new UserService();
        /// <summary>
        /// 增加用户
        /// </summary>
        public int Add(Admin_UserInfo userInfo)
        {
            try
            {
                return userService.AddUser(userInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改
        /// </summary>
        public int UpdateUser(Admin_UserInfo userInfo)
        {
            try
            {
                return userService.UpdateUser(userInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改用户-角色
        /// </summary>
        public int UpdateUserInfoRole(Admin_UserInfoRole userInfoRole)
        {
            try
            {
                return userService.UpdateUserInfoRole(userInfoRole);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DelUser(Admin_UserInfo userInfo)
        {
            try
            {
                return userService.DelUser(userInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        public Admin_UserInfo GetModel(string userName)
        {
            try
            {
                return userService.GetModel(userName);
            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// 查询单条数据
        /// </summary>
        public Admin_UserInfo GetModel(int userID)
        {
            try
            {
                return userService.GetModel(userID);
            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// 新增用户角色
        /// </summary>
        public int addUserRole(Admin_UserInfoRole userInfoRole)
        {
            try
            {
                return userService.addUserRole(userInfoRole);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 删除用户角色
        /// </summary>
        public int DelUserRole(Admin_UserInfoRole userInfoRole)
        {
            try
            {
                return userService.DelUserRole(userInfoRole);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        ///根据用户ID查询用户角色的数据
        /// </summary>
        public Admin_UserInfoRole GetUserRoleByUserID(int userID)
        {
            try
            {
                return userService.GetUserRoleByUserID(userID);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        ///根据角色ID查询用户角色的数据
        /// </summary>
        public List<Admin_UserInfoRole> GetUserRoleByRoleID(int roleID)
        {
            try
            {
                return userService.GetUserRoleByRoleID(roleID);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="pageCount"></param>
        /// <param name="pageSize"></param> 
        /// <returns></returns>
        public List<Admin_UserInfo> GetDataListWithPage(int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                return userService.GetDataListWithPage(pageSize, pageIndex, out pageCount, out totalCount);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据角色名称获取所有账号
        /// </summary>
        public List<string> GetAllUserNamebyRoleName(string rolename)
        {
            try
            {
                return userService.GetAllUserNamebyRoleName(rolename);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据角色名称获取所有账号
        /// </summary>
        public List<Admin_UserInfo> GetAllUserModelbyRoleName(string rolename)
        {
            try
            {
                return userService.GetAllUserModelbyRoleName(rolename);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 获取所有账号
        /// </summary>
        public List<Admin_UserInfo> GetAllUser()
        {
            try
            {
                return userService.GetAllUser();
            }
            catch
            {

                throw;
            }
        }
    }
}
