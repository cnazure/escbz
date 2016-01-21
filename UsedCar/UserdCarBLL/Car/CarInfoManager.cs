using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDAL.Car;
using UsedCarDB;

namespace UsedCarBLL.Car
{
    public class CarInfoManager
    {
        private readonly CarInfoService Car = new CarInfoService();
        /// <summary>
        /// 增加车辆信息
        /// </summary>
        public int AddCarInfo(T_CarInfo CarInfo)
        {
            try
            {
                //判断是否有重复信息
                if (Car.GetVIN(CarInfo.CarVIN) == null)
                {
                    return Car.AddCarInfo(CarInfo);
                }
                else
                {
                    return 0;
                }
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
                return Car.UpdateCarInfo(CarInfo);
            }
            catch
            {

                throw;
            }
        }



        /// <summary>
        /// 查询单条数据
        /// </summary>
        public T_CarInfo GetModel(string Aid)
        {
            try
            {
                return Car.GetModel(Aid);
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
                return Car.GetCarId();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 获取车辆详细信息
        /// </summary>
        /// <param name="txtCarVIN">车架号</param>
        /// <param name="txtAddUser">录入人</param>
        /// <param name="txtCarModel">车辆品牌</param>
        /// <param name="txtCarId">车辆编号</param>
        /// <param name="AddDateFrom">开始日期</param>
        /// <param name="AddDateTo">结束日期</param>        
        /// <param name="pageSize">分页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageCount">当前第几页</param>
        /// <param name="totalCount">当前总数</param>        
        /// <returns></returns>
        public List<T_CarInfo> GetDataListWithPage(string txtCarVIN, string txtAddUser, string txtCarModel, string txtCarId, string AddDateFrom, string AddDateTo, int pageSize, int pageIndex, out int pageCount, out int totalCount)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("select * from T_CarInfo where isUsing=1");
                if (!string.IsNullOrEmpty(txtCarVIN))
                    strSQL.AppendFormat(" and CarVIN like '%{0}%'", txtCarVIN);
                if (!string.IsNullOrEmpty(txtAddUser))
                    strSQL.AppendFormat(" and AddUser like '%{0}%'", txtAddUser);
                if (!string.IsNullOrEmpty(txtCarModel))
                    strSQL.AppendFormat(" and CarModel like '%{0}%'", txtCarModel);
                if (!string.IsNullOrEmpty(txtCarId))
                    strSQL.AppendFormat(" and CarId like '%{0}%'", txtCarId);
                if (!string.IsNullOrEmpty(AddDateFrom))
                    strSQL.AppendFormat(" and AddDate>='{0}'", AddDateFrom);
                if (!string.IsNullOrEmpty(AddDateTo))
                    strSQL.AppendFormat(" and AddDate<='{0}'", AddDateTo);
                strSQL.Append(" order by CarId desc");
                return new CarInfoService().GetDataListWithPage(strSQL.ToString(), pageSize, pageIndex, out pageCount, out totalCount);
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
                return Car.GetAllCarInfo();
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
                return Car.GetAllCarBRAND();
            }
            catch 
            {   
                throw;
            }
        }
    }
}
