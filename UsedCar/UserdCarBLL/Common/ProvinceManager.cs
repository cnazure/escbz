using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDAL.Common;
using UsedCarDB;

namespace UsedCarBLL.Common
{
    public class ProvinceManager
    {
        /// <summary>
        /// 获取所有省或直辖市
        /// </summary>
        public List<T_province> GetAll()
        {
            try
            {
                return new ProvinceService().GetAll();
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
                return new ProvinceService().GetModelbyProvinceID(provinceID);
            }
            catch
            {

                throw;
            }

        }
    }
}
