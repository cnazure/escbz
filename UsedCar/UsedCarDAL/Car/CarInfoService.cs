using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarDB.RepositoryImpl;

namespace UsedCarDAL.Car
{
    public class CarInfoService
    {
        /// <summary>
        /// 增加车辆信息
        /// </summary>
        public int AddCarInfo(T_CarInfo CarInfo)
        {
            try
            {
                return Repository<T_CarInfo>.Instance().Add(CarInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 更改车辆信息
        /// </summary>
        public int UpdateCarInfo(T_CarInfo CarInfo)
        {
            try
            {
                return Repository<T_CarInfo>.Instance().Update(CarInfo);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 根据车架号查询车辆
        /// </summary>
        /// <param name="strVIN">车架号</param>
        /// <returns></returns>
        public T_CarInfo GetVIN(string strVIN)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_CarInfo where CarVIN=@CarVIN ");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@CarVIN",strVIN)
            };
                return Repository<T_CarInfo>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_CarInfo GetModel(string CarId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_CarInfo where CarId=@CarId order by CarId desc");
                SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@CarId",CarId)
            };
                return Repository<T_CarInfo>.Instance().QueryBySql(strSql.ToString(), parameters);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 获取生成后的最终车辆编号
        /// </summary>
        /// <returns></returns>
        public string GetCarId()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 * from T_CarInfo order by CarId desc");
                object obj = Repository<T_CarInfo>.Instance().ExecSql(strSql.ToString(), null);
                if (obj != null)
                {
                    string strLastCarId = obj.ToString();
                    DateTime dt = DateTime.Now.Date;
                    string dt2 = strLastCarId.Substring(0, 6).ToString();
                    string dt1 = dt.ToString("yyMMdd");
                    if (dt1 == dt2)
                    {
                        return DateTime.Now.ToString("yyMMdd") + (Convert.ToInt32(strLastCarId.Remove(0, 6)) + 1).ToString("0");
                    }
                    else
                    {
                        return DateTime.Now.ToString("yyMMdd") + "01";
                    }
                }
                else
                {
                    return DateTime.Now.ToString("yyMMdd") + "01";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="pageSize">分页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageCount">当前第几页</param>
        /// <param name="totalCount">当前总数</param>
        /// <returns></returns>
        public List<T_CarInfo> GetDataListWithPage(string strSQL, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                int totalpage, totalcount = 0;
                bool iRet = Repository<T_CarInfo>.Instance().QueryBySqlOfPage(strSQL, pageSize, out totalpage, out totalcount);
                List<T_CarInfo> ls = Repository<T_CarInfo>.Instance().QueryBySql(strSQL, pageSize, pageIndex);
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
        /// 获取所有车辆
        /// </summary>
        public List<T_CarInfo> GetAllCarInfo()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"SELECT  * FROM  T_CarInfo order by CarId desc");
                return Repository<T_CarInfo>.Instance().Query(strSql.ToString());
            }
            catch
            {

                throw;
            }

        }

        /// <summary>
        /// 获取所有车辆品牌
        /// </summary>
        public List<T_CAR_BRAND> GetAllCarBRAND()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"SELECT  * FROM  T_CAR_BRAND where isValid = 1 order by firstPY");
                return Repository<T_CAR_BRAND>.Instance().Query(strSql.ToString());
            }
            catch
            {

                throw;
            }

        }
    }
}
