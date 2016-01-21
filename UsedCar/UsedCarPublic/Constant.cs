using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsedCarPublic
{
    public class Constant
    {
        #region 订单类型
        public enum OrderType
        {
            /// <summary>
            /// 收购订单
            /// </summary>
            收购 = 1,
            /// <summary>
            /// 销售订单
            /// </summary>
            销售 = 2
        }
        #endregion 订单类型

        #region 订单状态
        public enum OrderStatus
        {
            未补全 = 1,
            未分配 = 2,
            已分配 = 3,
            办证中 = 4,
            办证完成 = 5,
            金额未补全 = 6,
            金额未确认 = 7,
            金额已确认 = 8,
            已关闭 = 9,
            已取消 = 0,
            已删除 = -1
        }
        #endregion 订单状态

        #region 办证类型
        public enum CertType
        {
            提档 = 1,
            过户 = 2,
            上牌 = 3,
            正常委托 = 4,
            过期委托 = 5,
            正常年检 = 6,
            过期年检 = 7,
            商业险保险 = 8,
            一年交强险 = 9,
            一月交强险 = 10,
            违章处理 = 11,
            变更车架号 = 12,
            变更发动机号 = 13,
            变更车主姓名 = 14,
            变更证件号码 = 15,
            变更车辆颜色 = 16,
            变更其他信息 = 17,
            补车辆登记证书 = 18,
            补车辆行驶证 = 19,
            补车辆牌照 = 20,
            补车辆保单 = 21,
            补车辆其他项目 = 22,
            抵押登记 = 23,
            解除抵押 = 24,
            其他 = 25
        }
        #endregion 办证类型

        #region 短信返回类型
        /// <summary>
        /// 返回类型
        /// </summary>
        public enum SendReturnType
        {
            /// <summary>
            /// 成功
            /// </summary>
            Sussess = 0,
            /// <summary>
            /// 验证信息失败
            /// </summary>
            SendNewInfo = -10,
            /// <summary>
            /// 短信余额不足
            /// </summary>
            DiffItems = -20,
            /// <summary>
            /// 短信内容为空
            /// </summary>
            ConnectFail = -30,
            /// <summary>
            /// 短信内容存在敏感词
            /// </summary>
            SendFail = -31,
            /// <summary>
            /// 短信内容缺少签名信息
            /// </summary>
            Empty = -32,
            /// <summary>
            /// 错误的手机号
            /// </summary>
            CreateFail = -40,
            /// <summary>
            ///  	号码在黑名单中
            /// </summary>
            ClippingTime = -41,
            /// <summary>
            /// 验证码类短信发送频率过快
            /// </summary>
            TooFast = -42,
            /// <summary>
            /// 请求发送IP不在白名单内
            /// </summary>
            NotPermited = -50,
            /// <summary>
            /// 未知错误
            /// </summary>
            Other = -999

        }
        #endregion 短信返回类型

        #region  发送短信类型
        /// <summary>
        /// 发送短信类型Function
        /// </summary>
        public enum SendFunction
        {
            /// <summary>
            /// 分单
            /// </summary>
            DistributionOrder = 1,
            /// <summary>
            /// 错误
            /// </summary>            
            Other = 999

        }

        /// <summary>
        /// 向用户发送信息的方式
        /// </summary>
        public enum SendType
        {
            /// <summary>
            /// Mobile 手机
            /// </summary>
            Mobile = 1,
            /// <summary>
            /// Email 邮箱
            /// </summary>
            Email = 2
        }
        #endregion
    }
}
