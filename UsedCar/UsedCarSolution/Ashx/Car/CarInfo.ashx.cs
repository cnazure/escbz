using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsedCarBLL.Car;
using UsedCarDB;
using UsedCarPublic;

namespace UsedCarSolution.Ashx.Car
{
    /// <summary>
    /// CarInfo 的摘要说明
    /// </summary>
    public class CarInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mod = context.Request.Form["mod"];
            switch (mod)
            {
                //添加车辆信息
                case "addCarInfo": context.Response.Write(AddCarInfoName(context));
                    break;
                //删除用户
                case "Delete": context.Response.Write(DelCarInfo(context));
                    break;
                case "DelBrand": context.Response.Write(DelBrand(context));
                    break;
                //获取
                case "getModel": context.Response.Write(GetModel(context));
                    break;
                //获取最新车辆编号
                case "getCarInfoId": context.Response.Write(GetCarId());
                    break;
                //更新用户
                case "updateCarInfo": context.Response.Write(updateCarInfo(context));
                    break;
                case "getCarBrand": context.Response.Write(GetCarBrand());
                    break;
            }
        }



        /// <summary>
        /// 添加车辆
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddCarInfoName(HttpContext context)
        {
            try
            {
                T_CarInfo CarInfo = new T_CarInfo();
                if (!string.IsNullOrEmpty(context.Request.Form["CarId"]))
                {
                    CarInfo.CarId = context.Request.Form["CarId"].ToString();
                }
                else
                {
                    return "-1";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["CarVIN"]))
                {
                    CarInfo.CarVIN = context.Request.Form["CarVIN"].ToString();
                    if (CarInfo.CarVIN.Trim().Length < 6)
                    {
                        return "-8";
                    }
                }
                else
                {
                    return "-2";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["CarModel"]))
                {
                    string[] str = context.Request.Form["CarModel"].ToString().Split('|');
                    if (!string.IsNullOrEmpty(str[1]))
                    {
                        CarInfo.CarModel = context.Request.Form["CarModel"].ToString();
                    }
                    else
                    {
                        return "-3";
                    }
                }
                else
                {
                    return "-3";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["FirstOnCard"]))
                {
                    CarInfo.FirstOnCard = Convert.ToDateTime(context.Request.Form["FirstOnCard"]);
                }
                else
                {
                    return "-4";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["ImgType"]))
                {
                    CarInfo.ImgType = Convert.ToInt16(context.Request.Form["ImgType"]);
                }
                else
                {
                    return "-5";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["ImgUrl"]))
                {
                    CarInfo.ImgUrl = context.Request.Form["ImgUrl"].ToString();
                }
                else
                {
                    return "-6";
                }
                CarInfo.AddDate = System.DateTime.Now;
                CarInfo.AddUser = HttpContext.Current.User.Identity.Name.ToString();//创建人;
                CarInfo.isUsing = true;                
                int i = new CarInfoManager().AddCarInfo(CarInfo);
                if (i > 0)
                {
                    T_CarInfo_Log CarInfoLog = new T_CarInfo_Log();
                    CarInfoLog.CarId = CarInfo.CarId;
                    CarInfoLog.status = 0;//新增为0,修改为1，删除2
                    CarInfoLog.processStatus += "#0";//追加修改状态
                    CarInfoLog.statusRemark = "新增信息";
                    CarInfoLog.EditUser = HttpContext.Current.User.Identity.Name.ToString();//操作人;
                    CarInfoLog.EditDate = System.DateTime.Now;
                    CarInfoLogManager clm = new CarInfoLogManager();
                    int j = clm.Add(CarInfoLog);
                    if (j > 0)
                    {
                        return j.ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    //有重复车架号
                    return "-7";
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        /// <summary>
        /// 删除车辆
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DelCarInfo(HttpContext context)
        {
            try
            {
                int i = 0;
                //获取车辆信息
                T_CarInfo CarInfo = new CarInfoManager().GetModel(context.Request.Form["CarId"].ToString());
                CarInfo.isUsing = false;
                //禁用当前车辆
                i = new CarInfoManager().UpdateCarInfo(CarInfo);
                if (i > 0)
                {
                    T_CarInfo_Log CarInfoLog = new T_CarInfo_Log();
                    CarInfoLog.CarId = CarInfo.CarId;
                    CarInfoLog.status = 2;//新增为0,修改为1，删除2
                    CarInfoLog.processStatus += "#2";//追加修改状态
                    CarInfoLog.statusRemark = "删除信息";
                    CarInfoLog.EditUser = HttpContext.Current.User.Identity.Name.ToString();//删除人;
                    CarInfoLog.EditDate = System.DateTime.Now;
                    CarInfoLogManager clm = new CarInfoLogManager();
                    int j = clm.Add(CarInfoLog);
                    if (j > 0)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "problem";
                    }
                }
                else
                {
                    return "problem";
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        private string DelBrand(HttpContext context)
        {
            try
            {
                string ID = context.Request["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    T_CAR_BRAND brand = new CarBrandManager().GetModel(ID);
                    int i = new CarBrandManager().Del(brand);
                    if (i > 0)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "ERROR";
                    }
                }
                else
                    return "ERROR";
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }


        /// <summary>
        /// 根据主键ID查询对象并获取用户角色
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetModel(HttpContext context)
        {
            try
            {
                T_CarInfo CarInfo = new CarInfoManager().GetModel(context.Request.Form["CarId"].ToString());
                return JosonHelper.ToJson(CarInfo);
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }

        }

        /// <summary>
        /// 生成最新车辆编号
        /// </summary>
        /// <returns></returns>
        private string GetCarId()
        {
            try
            {
                return new CarInfoManager().GetCarId();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string updateCarInfo(HttpContext context)
        {
            try
            {
                //修改车辆基本信息            
                T_CarInfo CarInfo = new T_CarInfo();
                if (!string.IsNullOrEmpty(context.Request.Form["CarId"]))
                {
                    CarInfo.CarId = context.Request.Form["CarId"].ToString();
                }
                else
                {
                    return "-1";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["CarVIN"]))
                {
                    CarInfo.CarVIN = context.Request.Form["CarVIN"].ToString();
                    if (CarInfo.CarVIN.Trim().Length < 6)
                    {
                        return "-8";
                    }
                }
                else
                {
                    return "-2";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["CarModel"]))
                {
                    string[] str = context.Request.Form["CarModel"].ToString().Split('|');
                    if (!string.IsNullOrEmpty(str[1]))
                    {
                        CarInfo.CarModel = context.Request.Form["CarModel"].ToString();
                    }
                    else
                    {
                        return "-3";
                    }
                }
                else
                {
                    return "-3";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["FirstOnCard"]))
                {
                    CarInfo.FirstOnCard = Convert.ToDateTime(context.Request.Form["FirstOnCard"]);
                }
                else
                {
                    return "-4";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["ImgType"]))
                {
                    CarInfo.ImgType = Convert.ToInt16(context.Request.Form["ImgType"]);
                }
                else
                {
                    return "-5";
                }
                if (!string.IsNullOrEmpty(context.Request.Form["ImgUrl"]) && context.Request.Form["ImgUrl"].ToString() != "null")
                {
                    CarInfo.ImgUrl = context.Request.Form["ImgUrl"].ToString();
                }
                else
                {
                    return "-6";
                }
                CarInfo.AddDate = DateTime.Now;
                CarInfo.AddUser = HttpContext.Current.User.Identity.Name.ToString();//创建人;
                CarInfo.isUsing = true;
                int i = new CarInfoManager().UpdateCarInfo(CarInfo);
                if (i > 0)
                {
                    T_CarInfo_Log CarInfoLog = new T_CarInfo_Log();
                    CarInfoLog.CarId = CarInfo.CarId;
                    CarInfoLog.status = 1;//新增为0，修改为1，删除2
                    CarInfoLog.processStatus += "#1";//追加修改状态
                    CarInfoLog.statusRemark = "编辑信息";
                    CarInfoLog.EditUser = HttpContext.Current.User.Identity.Name.ToString();//编辑人;
                    CarInfoLog.EditDate = System.DateTime.Now;
                    CarInfoLogManager clm = new CarInfoLogManager();
                    int j = clm.Add(CarInfoLog);
                    if (j > 0)
                    {
                        return i.ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        /// <summary>
        /// 获取所有管理员账户
        /// </summary>
        /// <returns></returns>
        private string GetCarBrand()
        {
            try
            {
                List<T_CAR_BRAND> ls = new List<T_CAR_BRAND>();

                ls = new CarInfoManager().GetAllCarBRAND();

                return JosonHelper.ToJson(ls);
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}