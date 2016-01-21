using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.Car
{
    public class CarBrandService
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="pageSize">分页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageCount">当前第几页</param>
        /// <param name="totalCount">当前总数</param>
        /// <returns></returns>
        public List<T_CAR_BRAND> GetDataListWithPage(string strSQL, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                int totalpage, totalcount = 0;
                bool iRet = Repository<T_CAR_BRAND>.Instance().QueryBySqlOfPage(strSQL, pageSize, out totalpage, out totalcount);
                List<T_CAR_BRAND> ls = Repository<T_CAR_BRAND>.Instance().QueryBySql(strSQL, pageSize, pageIndex);
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
        /// 查询单条数据
        /// </summary>
        public T_CAR_BRAND GetModel(string brandId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_CAR_BRAND where ID=@brandId ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@brandId",brandId)
            };
                return Repository<T_CAR_BRAND>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改品牌
        /// </summary>
        public int Update_(T_CAR_BRAND brand)
        {
            try
            {
                int i = Repository<T_CAR_BRAND>.Instance().Update(brand);
                return i;
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
                return Repository<T_CAR_BRAND>.Instance().Add(brand);
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
                return Repository<T_CAR_BRAND>.Instance().Delete(brand);
            }
            catch
            {

                throw;
            }
        }
    }
}
