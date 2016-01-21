using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDAL.Car;
using UsedCarDB;

namespace UsedCarBLL.Car
{
    public class CarBrandManager
    {
        /// <summary>
        /// 获取车辆品牌详细信息
        /// </summary>
        /// <param name="txtID">品牌编号</param>
        /// <param name="txtAddUser">添加用户</param>
        /// <param name="txtCarBrand">车辆品牌</param>
        /// <param name="pageSize">分页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageCount">当前第几页</param>
        /// <param name="totalCount">当前总数</param>        
        /// <returns></returns>
        public List<T_CAR_BRAND> GetDataListWithPage(string txtID, string txtAddUser, string txtCarBrand, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("select * from T_CAR_BRAND where 1=1");
                if (!string.IsNullOrEmpty(txtID))
                    strSQL.AppendFormat(" and ID like '%{0}%'", txtID);
                if (!string.IsNullOrEmpty(txtAddUser))
                    strSQL.AppendFormat(" and AddUser like '%{0}%'", txtAddUser);
                if (!string.IsNullOrEmpty(txtCarBrand))
                    strSQL.AppendFormat(" and brandName like '%{0}%'", txtCarBrand);
                strSQL.Append(" order by firstPY");
                return new CarBrandService().GetDataListWithPage(strSQL.ToString(), pageSize, pageIndex, out pageCount, out totalCount);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_CAR_BRAND GetModel(string brandId)
        {
            try
            {
                return new CarBrandService().GetModel(brandId);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改用户
        /// </summary>
        public int Update_(T_CAR_BRAND brand)
        {
            try
            {
                return new CarBrandService().Update_(brand);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 增加
        /// </summary>
        public int Add(T_CAR_BRAND brand)
        {
            try
            {
                return new CarBrandService().Add(brand);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int Del(T_CAR_BRAND brand)
        {
            try
            {
                return new CarBrandService().Del(brand);
            }
            catch
            {

                throw;
            }
        }
    }
}
