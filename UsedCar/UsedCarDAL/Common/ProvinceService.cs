using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.Common
{
    public class ProvinceService
    {
        /// <summary>
        /// 获取所有省或直辖市
        /// </summary>
        public List<T_province> GetAll()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_province");
                return Repository<T_province>.Instance().Query(strSql.ToString());
            }
            catch
            {

                throw;
            }

        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_province GetModelbyProvinceID(int provinceID)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_province where provinceID=@provinceID ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@provinceID",provinceID)
            };
                return Repository<T_province>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }
    }
}
