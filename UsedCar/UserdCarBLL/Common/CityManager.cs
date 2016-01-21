using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDAL.Common;
using UsedCarDB;

namespace UsedCarBLL.Common
{
    public class CityManager
    {
        /// <summary>
        /// 根据省名查询城市
        /// </summary>
        public List<T_city> GetListbyProvinceID(int fatherID)
        {
            try
            {
                return new CityServices().GetListbyProvinceID(fatherID);
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
                return new CityServices().GetModelbyCityID(cityID);
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
                return new CityServices().GetModelbyCity(city);
            }
            catch
            {

                throw;
            }
        }
    }
}
