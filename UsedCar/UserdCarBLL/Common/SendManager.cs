using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsedCarDB;
using UsedCarPublic;

namespace UsedCarBLL.Common
{
    public class SendManager
    {
        //订单分单
        /// <summary>
        /// 订单分单短信发送
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <param name="strOrderId">订单编号</param>
        /// <param name="strCarModel">车辆型号</param>
        /// <param name="strVIN">车架号</param>
        /// <param name="strCPH">车牌号</param>
        /// <param name="strCertType">办证类型</param>
        /// <param name="strTCDD">提车地点</param>
        /// <param name="strLXRXM">联系人姓名</param>
        /// <param name="strLXRDH">联系人电话</param>
        /// <param name="YDdate">预定日期</param>
        /// <param name="strMobile">联系人短信</param>
        /// <returns></returns>
        public bool SendDistributionOrder(int userID, string strOrderId, string strCarModel, string strVIN, string strCPH, string strCertType,
            string strTCDD,string strLXRXM,string strLXRDH,string YDdate, string strMobile)
        {
            //保存发送记录
            UsedCarDB.T_SEND ts = new UsedCarDB.T_SEND();
            ts.UserId = userID;
            ts.CreateTime = DateTime.Now;
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("你有新的订单，订单编号:" + strOrderId + "");
            strBuilder.Append("，办证类型:" + strCertType + "");
            if (!string.IsNullOrEmpty(strCarModel)) 
            {
                strBuilder.Append(",车辆型号:" + strCarModel + "");
            }
            if (!string.IsNullOrEmpty(strVIN)) 
            {
                strBuilder.Append(",车架号:" + strVIN + "");
            }
            if(!string.IsNullOrEmpty(strCPH))
            {
                strBuilder.Append(",车牌号:" + strCPH + "");
            }
            if (!string.IsNullOrEmpty(strCPH))
            {
                strBuilder.Append(",提车地点:" + strTCDD + "");
            }
            if (!string.IsNullOrEmpty(strLXRXM))
            {
                strBuilder.Append(",联系人姓名:" + strLXRXM + "");
            }
            if (!string.IsNullOrEmpty(strLXRDH))
            {
                strBuilder.Append(",联系人电话:" + strLXRDH + "");
            }
            if (!string.IsNullOrEmpty(YDdate))
            {
                strBuilder.Append(",预定日期:" + YDdate + "");
            }
            strBuilder.Append(",请尽快联系用户。");
            //订单编号，车辆品牌，车架号，车牌号，办证项目，提车地点，联系人姓名与联系电话，预定时间。
            ts.EquipContent = strBuilder.ToString();
            ts.SendCode = strMobile;
            ts.SendFunction = UsedCarPublic.Constant.SendFunction.DistributionOrder.ToString();
            ts.SendNum = strMobile;
            ts.SendType = Convert.ToInt16(UsedCarPublic.Constant.SendType.Mobile);
            ts.State = false;

            UsedCarPublic.Constant.SendReturnType ReturnType = new UsedCarDAL.Common.SendService().CreateSendRecord(ts);

            if (ReturnType.ToString() == "Sussess")
            {
                //发送短信开始
                ReturnType = this.SendMobile(ts);
                if (ReturnType.ToString() == "Sussess")
                {
                    //发送短信成功
                    UsedCarPublic.Log.ExceptionLog.writeFile(2, "分单发送短信成功:" + strMobile + ts.EquipContent);
                    return true;
                }
                else
                {
                    //发送短信失败
                    UsedCarPublic.Log.ExceptionLog.writeFile(2, "分单短信失败：错误码为：" + ReturnType.ToString());
                    return false;
                }

            }
            else
            {
                //保存到数据表失败
                UsedCarPublic.Log.ExceptionLog.writeFile(2, "分单短信失败：错误码为：" + ReturnType.ToString());
                return false;
            }
        }

        #region 发送

        /// <summary>
        /// 向用户手机发送信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns>返回枚举类型</returns>

        public Constant.SendReturnType SendMobile(T_SEND s)
        {
            /*如过 没有手机号 或 没有发送的内容 返回错误*/
            if (string.IsNullOrEmpty(s.SendNum) || string.IsNullOrEmpty(s.EquipContent))
                return Constant.SendReturnType.Other;//没有手机号码或内容返回失败999             

            string strResult = PublicMethods.SendSMS(s.SendNum, s.EquipContent);
            UsedCarModle.SMSReturnJson json = JosonHelper.Deserialize<UsedCarModle.SMSReturnJson>(strResult);
            if (json != null)/*建立通道成功*/
            {
                if (json.msg == "ok")
                    return Constant.SendReturnType.Sussess;
                else
                    return (Constant.SendReturnType)json.error;
            }
            else
                return Constant.SendReturnType.ConnectFail;
        }

        #endregion
    }
}
