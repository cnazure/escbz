using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.Car
{
    public class CarInfoLogService
    {
        /// <summary>
        /// 增加历史记录
        /// </summary>
        public int Add(T_CarInfo_Log checklog)
        {
            try
            {
                return Repository<T_CarInfo_Log>.Instance().Add(checklog);
            }
            catch
            {

                throw;
            }
        }
    }
}
