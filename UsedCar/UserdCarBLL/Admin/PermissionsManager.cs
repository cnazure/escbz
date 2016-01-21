using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCarDAL.Admin;
using UsedCarDB;
using UsedCarModle;

namespace UsedCarBLL.Admin
{
    public class PermissionsManager
    {
        private readonly PermissionsServices permissions = new PermissionsServices();

        /// <summary>
        /// 查看角色列表
        /// </summary>
        public List<Admin_RoleInfo> GetRoleInfo()
        {
            try
            {
                return permissions.GetRoleInfo();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改角色信息
        /// </summary>
        public int UpdateRoleInfo(Admin_RoleInfo roleInfo)
        {
            try
            {
                return permissions.UpdateRoleInfo(roleInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        public int DelRoleInfo(int roleID)
        {
            try
            {
                return permissions.DelRoleInfo(roleID);
            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// 查询权限列表
        /// </summary>
        public List<Admin_PopedomInfo> GetPopedomInfo()
        {
            try
            {
                return permissions.GetPopedomInfo();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 新增角色权限
        /// </summary>
        public int AddRolePoperdomInfo(Admin_RolePoperdomInfo rolePoperdomInfo)
        {
            try
            {
                return permissions.AddRolePoperdomInfo(rolePoperdomInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 删除该角色所有权限
        /// </summary>
        public int DelRolePoperdomInfo(List<Admin_RolePoperdomInfo> ls)
        {
            try
            {
                return permissions.DelRolePoperdomInfo(ls);
            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// 查询单条角色信息
        /// </summary>
        public Admin_RoleInfo GetRoleInfoModel(int Id)
        {
            try
            {
                return permissions.GetRoleInfoModel(Id);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据角色名查询角色对象
        /// </summary>
        public Admin_RoleInfo GetRoleInfoModelByRoleName(string roleName)
        {
            return permissions.GetRoleInfoModelByRoleName(roleName);
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        public int AddRole(Admin_RoleInfo roleInfo)
        {
            try
            {
                return permissions.AddRole(roleInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 新增角色并获取最新ID
        /// </summary>
        public int AddRoleInfo(string roleName)
        {
            try
            {
                return permissions.AddRoleInfo(roleName);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据用户名查询角色名
        /// </summary>
        public string GetRoleNameByUsername(string username)
        {
            try
            {
                return permissions.GetRoleNameByUsername(username);
            }
            catch
            {

                throw;
            }
        }

        ///// <summary>
        ///// 查询角色拥有的权限
        ///// </summary>
        //public List<RolePoperdomModel> GetRolePoperdomModel()
        //{
        //    return permissions.GetRolePoperdomModel();
        //}

        /// <summary>
        /// 根据角色ID查询所有拥有的权限
        /// </summary>
        public List<RolePop_Pop> GetRolePop_Pop(int roleID)
        {
            try
            {
                return permissions.GetRolePop_Pop(roleID);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据权限ID查询权限角色关系表的一条数据
        /// </summary>
        public Admin_RolePoperdomInfo GetR_pModelByPopId(int popID, int roleID)
        {
            try
            {
                return permissions.GetR_pModelByPopId(popID, roleID);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据用户名查询用户的userID
        /// </summary>
        public int GetUserIDbyUserName(string UserName)
        {
            return permissions.GetUserIDbyUserName(UserName);
        }
        /// <summary>
        /// 根据用userName查询指定对象
        /// </summary>
        public Admin_UserInfo GetAdminUserInfoByUserName(string UserName)
        {
            return permissions.GetAdminUserInfoByUserName(UserName);
        }


        /// <summary>
        /// 根据角色ID查询该角色下所有权限
        /// </summary>
        public List<Admin_RolePoperdomInfo> GetR_pModelByRoleID(int roleId)
        {
            try
            {
                return permissions.GetR_pModelByRoleID(roleId);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据userName获取该用户的所有权限
        /// </summary>
        public List<Admin_PopedomInfo> GetPopByUserName(string userName)
        {
            try
            {
                return permissions.GetPopByUserName(userName);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 后台登陆验证用户名密码
        /// </summary>
        public Admin_UserInfo GetUserbyUserNamePsd(string name, string pass)
        {
            try
            {
                return permissions.GetUserbyUserNamePsd(name, pass);
            }
            catch
            {

                throw;
            }
        }

    }
}
