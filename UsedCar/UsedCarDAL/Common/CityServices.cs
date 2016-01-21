using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.Common
{
    public class CityServices
    {
        /// <summary>
        /// 根据省名查询城市
        /// </summary>
        public List<T_city> GetListbyProvinceID(int fatherID)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_city where fatherID=@fatherID ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@fatherID",fatherID)
            };
                return Repository<T_city>.Instance().Query(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_city GetModelbyCityID(int cityID)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_city where cityID=@cityID ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@cityID",cityID)
            };
                return Repository<T_city>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_city GetModelbyCity(string city)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_city where city=@city ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@city",city)
            };
                return Repository<T_city>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }
    }
}
