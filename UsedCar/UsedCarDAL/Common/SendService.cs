using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;
using UsedCarPublic;

namespace UsedCarDAL.Common
{
    public class SendService
    {
        /// <summary>
        /// 添加向用户发送的记录
        /// </summary>
        /// <param name="s">记录信息</param>
        /// <returns>是否成功</returns>
        public Constant.SendReturnType CreateSendRecord(T_SEND s)
        {
            try
            {
                int intRecord = Repository<T_SEND>.Instance().Add(s);
                if (intRecord > 0)
                {
                    return Constant.SendReturnType.Sussess;
                }
                else
                {
                    return Constant.SendReturnType.CreateFail;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
