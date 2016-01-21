using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCarDB;
using UsedCarPublic.Log;
using UsedCarDB.RepositoryImpl;
using UsedCarModle;

namespace UsedCarDAL.Admin
{
    public class PermissionsServices
    {
        /// <summary>
        /// 查看角色列表
        /// </summary>
        public List<Admin_RoleInfo> GetRoleInfo()
        {
            try
            {
                List<Admin_RoleInfo> ls = Repository<Admin_RoleInfo>.Instance().Query("select * from Admin_RoleInfo");
                return ls;
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
                int i = Repository<Admin_RoleInfo>.Instance().Update(roleInfo);
                return i;
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
                Admin_RoleInfo roleInfo = new Admin_RoleInfo();
                roleInfo.RoleID = roleID;
                int i = Repository<Admin_RoleInfo>.Instance().Delete(roleInfo);
                return i;
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
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Admin_RoleInfo where RoleID=@RoleID ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@RoleID",Id)
            };
                return Repository<Admin_RoleInfo>.Instance().QueryBySql(strSql.ToString(), parameters);
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
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Admin_RoleInfo where RoleName=@RoleName ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@RoleName",roleName)
            };
                return Repository<Admin_RoleInfo>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// 新增角色
        /// </summary>
        public int AddRole(Admin_RoleInfo roleInfo)
        {
            try
            {
                return Repository<Admin_RoleInfo>.Instance().Add(roleInfo);
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

                string SqlIng = "insert into Admin_RoleInfo(RoleName,RoleCreateTime) values(@RoleName,@RoleCreateTime) select @@identity as 'id'";
                SqlParameter[] parameter = {
                                   new SqlParameter("@RoleName",roleName),
                                   new SqlParameter("@RoleCreateTime",DateTime.Now) };
                return Convert.ToInt32(Repository<Admin_RoleInfo>.Instance().ExecSql(SqlIng.ToString(), parameter));
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 查看权限列表
        /// </summary>
        public List<Admin_PopedomInfo> GetPopedomInfo()
        {
            try
            {
                List<Admin_PopedomInfo> ls = Repository<Admin_PopedomInfo>.Instance().Query("select * from Admin_PopedomInfo");
                return ls;
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
                return Repository<Admin_RolePoperdomInfo>.Instance().Add(rolePoperdomInfo);
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
                return Repository<Admin_RolePoperdomInfo>.Instance().Delete(ls);
            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// 根据用户名查询角色ID
        /// </summary>
        public int GetRoleByUsername(string username)
        {
            try
            {
                string sqlstr = "select Admin_UserInfoRole.RoleId from Admin_UserInfoRole,Admin_UserInfo where Admin_UserInfoRole.UserId=Admin_UserInfo.UserID and Admin_UserInfo.UserName=@UserName";
                SqlParameter[] parameter = {
                                   new SqlParameter("@UserName",username)};
                return Convert.ToInt32(Repository<Admin_RoleInfo>.Instance().ExecSql(sqlstr.ToString(), parameter));
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
                string sqlstr = "select RoleName from Admin_RoleInfo where RoleID=(select RoleID from Admin_UserInfoRole where UserId=(select UserID from Admin_UserInfo where UserName=@Username))";
                SqlParameter[] parameter = {
                                   new SqlParameter("@UserName",username)};
                return Repository<Admin_RoleInfo>.Instance().ExecSql(sqlstr.ToString(), parameter).ToString();
            }
            catch
            {

                throw;
            }
        }



        /// <summary>
        /// 根据角色ID查询所有拥有的权限
        /// </summary>

        public List<RolePop_Pop> GetRolePop_Pop(int roleID)
        {
            try
            {
                string sqlstr = "select  pop.PopedomName,rd.RoleID,pop.PopedomId from Admin_PopedomInfo pop,Admin_RolePoperdomInfo rd  where pop.PopedomId=rd.PopedomId and rd.RoleID=@RoleID";
                SqlParameter[] parameter = {
                                   new SqlParameter("@RoleID",roleID)
                                    };
                List<RolePop_Pop> ls = Repository<RolePop_Pop>.Instance().Query(sqlstr, parameter);
                return ls;
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据权限ID,角色ID查询权限角色关系表的一条数据
        /// </summary>
        public Admin_RolePoperdomInfo GetR_pModelByPopId(int popId, int roleId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Admin_RolePoperdomInfo where PopedomId=@PopedomId and RoleID=@RoleID");
                SqlParameter[] parameters = new SqlParameter[]{
                            new SqlParameter("@PopedomId",popId),
                            new SqlParameter("@RoleID",roleId)
                                            };
                return Repository<Admin_RolePoperdomInfo>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据用户名查询用户userID
        /// </summary>
        public int GetUserIDbyUserName(string UserName)
        {
            string sql = "select * from Admin_UserInfo where UserName=@UserName";
            SqlParameter[] parameters = new SqlParameter[]{
                            new SqlParameter("@UserName",UserName)
                                            };
            int userID = 0;
            try
            {
                List<Admin_UserInfo> userinfolist = Repository<Admin_UserInfo>.Instance().Query(sql.ToString(), parameters);
                userID = userinfolist[0].UserID;
            }
            catch
            {
                throw;
            }
            return userID;

        }

        /// <summary>
        /// 根据用户名查询此条用户数据
        /// </summary>
        public Admin_UserInfo GetAdminUserInfoByUserName(string UserName)
        {
            string sql = "select uinfo.*,roleinfo.RoleName from Admin_UserInfo uinfo,Admin_UserInfoRole urole,Admin_RoleInfo roleinfo where UserName=@UserName and uinfo.UserID=urole.UserId and urole.RoleId=roleinfo.RoleID";
            SqlParameter[] parameters = new SqlParameter[]{
                            new SqlParameter("@UserName",UserName)
                                            };
            try
            {
                return Repository<Admin_UserInfo>.Instance().QueryBySql(sql.ToString(), parameters);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 根据角色ID查询该角色下所有权限
        /// </summary>
        public List<Admin_RolePoperdomInfo> GetR_pModelByRoleID(int roleId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from Admin_RolePoperdomInfo where  RoleID=@RoleID");
                SqlParameter[] parameters = new SqlParameter[]{
                            new SqlParameter("@RoleID",roleId)
                                            };
                return Repository<Admin_RolePoperdomInfo>.Instance().Query(strSql.ToString(), parameters);
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
                StringBuilder sBuilderSql = new StringBuilder();
                sBuilderSql.Append("select * from Admin_PopedomInfo where Admin_PopedomInfo.ParentID = 0 or Admin_PopedomInfo.PopedomId in (select PopedomId from  Admin_RolePoperdomInfo where RoleID in ");
                sBuilderSql.Append("(select RoleId from Admin_UserInfoRole urole,Admin_UserInfo info where urole.UserId = info.UserID and  info.UserName =@username )) order by sortId asc");
                string SqlIng = sBuilderSql.ToString();
                SqlParameter[] parameter = new SqlParameter[] { 
                      new SqlParameter("@username",userName) 
                                                 };
                return Repository<Admin_PopedomInfo>.Instance().Query(SqlIng.ToString(), parameter);
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
                string sql = "select * from Admin_UserInfo where UserName = @UserName and UserPass = @UserPass";
                SqlParameter[] param = {
                                   new SqlParameter("@UserName",name),
                                   new SqlParameter("@UserPass",pass)};
                return Repository<Admin_UserInfo>.Instance().QueryBySql(sql.ToString(), param);
            }
            catch (Exception ex)
            {
                ExceptionLog.writeFile(Convert.ToInt32(ExceptionLog.fileTypeStatus.fileTypeOne), ExceptionLog.logContent(ex, "后台登陆验证用户名密码"));
                //ExceptionLog.writeFile(1, ex.InnerException.Message + " 222");
                return null;
            }
        }

    }
}
