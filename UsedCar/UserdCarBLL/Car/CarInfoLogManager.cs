using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDAL.Car;
using UsedCarDB;

namespace UsedCarBLL.Car
{
    public class CarInfoLogManager
    {
        /// <summary>
        /// 增加
        /// </summary>
        public int Add(T_CarInfo_Log orderlog)
        {
            try
            {
                return new CarInfoLogService().Add(orderlog);
            }
            catch
            {

                throw;
            }
        }
    }
}
