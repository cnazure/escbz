using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCarDAL.Admin;
using UsedCarModle;

namespace UsedCarBLL.Admin
{
    public class ModelManager
    {
        private readonly ModelService modelService = new ModelService();
        /// <summary>
        /// 获取用户-角色表 分页查询
        /// </summary>
        public List<User_Role> GetUser_RolelList(int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            return modelService.GetUser_RolelList(pageSize, pageIndex, out pageCount, out totalCount);
        }
    }
}
