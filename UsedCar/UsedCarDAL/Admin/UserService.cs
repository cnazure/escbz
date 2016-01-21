using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.Admin
{
    public class UserService
    {
        /// <summary>
        /// 增加用户
        /// </summary>
        public int AddUser(Admin_UserInfo userInfo)
        {
            try
            {
                return Repository<Admin_UserInfo>.Instance().Add(userInfo);
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
                return Repository<Admin_UserInfo>.Instance().Update(userInfo);
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
                int i = Repository<Admin_UserInfoRole>.Instance().Update(userInfoRole);
                return i;
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
                return Repository<Admin_UserInfo>.Instance().Delete(userInfo);
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
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Admin_UserInfo where UserName=@UserName ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@UserName",userName)
            };
                return Repository<Admin_UserInfo>.Instance().QueryBySql(strSql.ToString(), parameters);
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
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Admin_UserInfo where UserID=@UserID ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@UserID",userID)
            };
                return Repository<Admin_UserInfo>.Instance().QueryBySql(strSql.ToString(), parameters);
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
                return Repository<Admin_UserInfoRole>.Instance().Add(userInfoRole);
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
                return Repository<Admin_UserInfoRole>.Instance().Delete(userInfoRole);
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
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Admin_UserInfoRole where UserId=@UserId ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@UserId",userID)
            };
                return Repository<Admin_UserInfoRole>.Instance().QueryBySql(strSql.ToString(), parameters);
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
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Admin_UserInfoRole where RoleID=@RoleID ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@RoleID",roleID)
            };
                return Repository<Admin_UserInfoRole>.Instance().Query(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        public List<Admin_UserInfo> GetDataListWithPage(int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                int totalpage, totalcount = 0;

                bool iRet = Repository<Admin_UserInfo>.Instance().QueryBySqlOfPage("select top 1000 * from Admin_UserInfo order by Time desc", pageSize, out totalpage, out totalcount);

                List<Admin_UserInfo> ls = Repository<Admin_UserInfo>.Instance().QueryBySql("select top 1000 * from Admin_UserInfo order by Time desc", pageSize, pageIndex);

                pageCount = totalpage;
                totalCount = totalcount;
                return ls;
            }
            catch
            {

                throw;
            }

        }

        /// <summary>
        /// 根据角色名称获取所有账号
        /// </summary>
        public List<string> GetAllUserNamebyRoleName(string RoleName)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"SELECT     Admin_UserInfo.UserName
FROM         Admin_RoleInfo INNER JOIN
                      Admin_UserInfoRole ON Admin_RoleInfo.RoleID = Admin_UserInfoRole.RoleId INNER JOIN
                      Admin_UserInfo ON Admin_UserInfoRole.UserId = Admin_UserInfo.UserID
WHERE     Admin_RoleInfo.RoleName = @RoleName");

                SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@RoleName",RoleName)
                };
                return Repository<string>.Instance().Query(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }

        }

        /// <summary>
        /// 根据角色名称获取所有账号
        /// </summary>
        public List<Admin_UserInfo> GetAllUserModelbyRoleName(string RoleName)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"SELECT     Admin_UserInfo.*
FROM         Admin_RoleInfo INNER JOIN
                      Admin_UserInfoRole ON Admin_RoleInfo.RoleID = Admin_UserInfoRole.RoleId INNER JOIN
                      Admin_UserInfo ON Admin_UserInfoRole.UserId = Admin_UserInfo.UserID
WHERE     Admin_RoleInfo.RoleName = @RoleName");

                SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@RoleName",RoleName)
                };
                return Repository<Admin_UserInfo>.Instance().Query(strSql.ToString(), parameters);
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
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"SELECT  * FROM  Admin_UserInfo");
                return Repository<Admin_UserInfo>.Instance().Query(strSql.ToString());
            }
            catch
            {

                throw;
            }

        }
    }
}
