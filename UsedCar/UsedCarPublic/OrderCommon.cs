using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsedCarPublic
{
    public class OrderCommon
    {
        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetCertTypeList()
        {
            Dictionary<int, string> strResult = new Dictionary<int, string>();
            strResult.Add((int)Constant.CertType.提档, "提档");
            strResult.Add((int)Constant.CertType.过户, "过户");
            strResult.Add((int)Constant.CertType.上牌, "上牌");
            strResult.Add((int)Constant.CertType.正常委托, "正常委托");
            strResult.Add((int)Constant.CertType.过期委托, "过期委托");
            strResult.Add((int)Constant.CertType.正常年检, "正常年检");
            strResult.Add((int)Constant.CertType.过期年检, "过期年检");
            strResult.Add((int)Constant.CertType.商业险保险, "商业险保险");
            strResult.Add((int)Constant.CertType.一年交强险, "一年交强险");
            strResult.Add((int)Constant.CertType.一月交强险, "一月交强险");
            strResult.Add((int)Constant.CertType.违章处理, "违章处理");
            strResult.Add((int)Constant.CertType.变更车架号, "变更车架号");
            strResult.Add((int)Constant.CertType.变更发动机号, "变更发动机号");
            strResult.Add((int)Constant.CertType.变更车主姓名, "变更车主姓名");
            strResult.Add((int)Constant.CertType.变更证件号码, "变更证件号码");
            strResult.Add((int)Constant.CertType.变更车辆颜色, "变更车辆颜色");
            strResult.Add((int)Constant.CertType.变更其他信息, "变更其他信息");
            strResult.Add((int)Constant.CertType.补车辆登记证书, "补车辆登记证书");
            strResult.Add((int)Constant.CertType.补车辆行驶证, "补车辆行驶证");
            strResult.Add((int)Constant.CertType.补车辆牌照, "补车辆牌照");
            strResult.Add((int)Constant.CertType.补车辆保单, "补车辆保单");
            strResult.Add((int)Constant.CertType.补车辆其他项目, "补车辆其他项目");
            strResult.Add((int)Constant.CertType.抵押登记, "抵押登记");
            strResult.Add((int)Constant.CertType.解除抵押, "解除抵押");
            strResult.Add((int)Constant.CertType.其他, "其他");
            return strResult;
        }

        /// <summary>
        /// 获取当前办证类型名称
        /// </summary>
        /// <param name="strType">办证类型编号</param>
        /// <returns></returns>
        public string GetCertTypeName(string strType)
        {
            if (!strType.Contains(','))
            {
                return GetCertTypeNameS(strType);
            }
            else
            {
                string strTypeReturn = string.Empty;
                string[] strTypeList = strType.Split(',');
                for (int i = 0; i < strTypeList.Length; i++)
                {
                    strTypeReturn += GetCertTypeNameS(strTypeList[i]) + ",";
                }
                return strTypeReturn.Remove(strTypeReturn.Length - 1, 1);
            }
        }

        public string GetCertTypeNameS(string strType)
        {
            switch (strType)
            {
                case "1":
                    return "提档";
                case "2":
                    return "过户";
                case "3":
                    return "上牌";
                case "4":
                    return "正常委托";
                case "5":
                    return "过期委托";
                case "6":
                    return "正常年检";
                case "7":
                    return "过期年检";
                case "8":
                    return "商业险保险";
                case "9":
                    return "一年交强险";
                case "10":
                    return "一月交强险";
                case "11":
                    return "违章处理";
                case "12":
                    return "变更车架号";
                case "13":
                    return "变更发动机号";
                case "14":
                    return "变更车主姓名";
                case "15":
                    return "变更证件号码";
                case "16":
                    return "变更车辆颜色";
                case "17":
                    return "变更其他信息";
                case "18":
                    return "补车辆登记证书";
                case "19":
                    return "补车辆行驶证";
                case "20":
                    return "补车辆牌照";
                case "21":
                    return "补车辆保单";
                case "22":
                    return "补车辆其他项目";
                case "23":
                    return "抵押登记";
                case "24":
                    return "解除抵押";
                case "25":
                    return "其他";
                default:
                    return "";

            }
        }

        /// <summary>
        /// 获取订单类型
        /// </summary>
        /// <param name="strOrderType">订单类型</param>
        /// <returns></returns>
        public string GetOrderType(string strOrderType)
        {
            switch (strOrderType)
            {
                case "1":
                    return "收购";
                case "2":
                    return "销售";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 获取当前订单状态
        /// </summary>
        /// <param name="strOrderStatus">状态编号</param>
        /// <returns></returns>
        public string GetOrderStatusName(string strOrderStatus)
        {
            switch (strOrderStatus)
            {
                case "1":
                    return "未补全";
                case "2":
                    return "未分配";
                case "3":
                    return "已分配";
                case "4":
                    return "办证中";
                case "5":
                    return "办证完成";
                case "6":
                    return "金额未补全";
                case "7":
                    return "金额未确认";
                case "8":
                    return "金额已确认";
                case "9":
                    return "已关闭";
                case "0":
                    return "已取消";
                case "-1":
                    return "已删除";
                default:
                    return "";

            }
        }

    }
}
