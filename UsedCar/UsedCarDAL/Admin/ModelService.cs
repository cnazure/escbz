using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCarDB.RepositoryImpl;
using UsedCarModle;

namespace UsedCarDAL.Admin
{
    public class ModelService
    {
        /// <summary>
        /// 获取用户-角色表 分页查询
        /// </summary>
        public List<User_Role> GetUser_RolelList(int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                int totalpage, totalcount = 0;

                bool iRet = Repository<User_Role>.Instance().QueryBySqlOfPage("select top 1000 * from Admin_UserInfo u,Admin_UserInfoRole ur,Admin_RoleInfo r where u.UserID=ur.UserId and ur.RoleId=r.RoleId order by u.UserID", pageSize, out totalpage, out totalcount);

                List<User_Role> ls = Repository<User_Role>.Instance().QueryBySql("select top 1000 * from Admin_UserInfo u,Admin_UserInfoRole ur,Admin_RoleInfo r where u.UserID=ur.UserId and ur.RoleId=r.RoleId order by u.UserID", pageSize, pageIndex);

                pageCount = totalpage;
                totalCount = totalcount;
                return ls;
            }
            catch
            {

                throw;
            }
        }
    }
}
