using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace UsedCarPublic.Log
{
    public class ExceptionLog
    {
        public enum fileTypeStatus
        {
            fileTypeOne = 1,  //1错误日志
            fileTypeTwo = 2,  //2工作日志
            fileTypeThree = 3, //3为临时日志
            fileTypeFour = 4     //金钱日志
        }

        #region 写文本文件
        /// <summary>
        /// 写文本文件
        /// </summary>
        /// <param name="fileType">文件类型（1错误日志，2工作日志，3为临时日志）</param>
        /// <param name="content">文件内容</param>
        public static void writeFile(int fileType, string content)
        {
            //GameTradingByPublic.ExceptionLog.writeFile(fileType, content);
            //return;
            string exceLogs = "{0}ExceptionLogs_{1}.txt";
            string taskLogs = "{0}TaskLogs_{1}.txt";
            string TempLogs = "{0}TempLogs_{1}.txt";
            string path;
            string fileName;

            if (fileType == 1)
            {

                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\ExceptionLogs\";
                fileName = string.Format(exceLogs, path, DateTime.Now.ToString("yyMMdd"));
            }
            else if (fileType == 2)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\TaskLogs\";
                fileName = string.Format(taskLogs, path, DateTime.Now.ToString("yyMMdd"));
            }
            else if (fileType == 3)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\TempLogs\";
                fileName = string.Format(TempLogs, path, DateTime.Now.ToString("yyMMdd"));
            }
            else
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\MoneyLogs\";
                fileName = string.Format(TempLogs, path, DateTime.Now.ToString("yyMMdd"));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString());

            sb.Append(string.Format("\r\n用户Agent信息：{0}", (GetUserAgent == null ? "" : GetUserAgent.ToString())));
            sb.Append(string.Format("\r\n客户端IP：{0}", (GetUserIp == null ? "" : GetUserIp.ToString())));
            sb.Append(string.Format("\r\n服务端IP：{0}", (GetServerIp == null ? "" : GetServerIp.ToString())));
            sb.Append(string.Format("\r\n详细信息：{0}", content));

            if (!Directory.Exists(path)) // 目录不存在则建立
                Directory.CreateDirectory(path);

            File.AppendAllText(fileName, sb.ToString());
        }
        #endregion


        #region 写文本文件(捕获错误变量）
        /// <summary>
        /// 写文本文件
        /// </summary>
        /// <param name="fileType">文件类型（1错误日志，2工作日志，3为临时日志）</param>
        /// <param name="content">文件内容</param>
        public static void writeFile(Exception ex)
        {
            //GameTradingByPublic.ExceptionLog.writeFile(ex);
            //return;
            int fileType = 1;
            string content = logContent(ex, "-1");
            string exceLogs = "{0}ExceptionLogs_{1}.txt";
            string taskLogs = "{0}TaskLogs_{1}.txt";
            string TempLogs = "{0}TempLogs_{1}.txt";
            string path;
            string fileName;

            if (fileType == 1)
            {

                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\ExceptionLogs\";
                fileName = string.Format(exceLogs, path, DateTime.Now.ToString("yyMMdd"));
            }
            else if (fileType == 2)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\TaskLogs\";
                fileName = string.Format(taskLogs, path, DateTime.Now.ToString("yyMMdd"));
            }
            else if (fileType == 3)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\TempLogs\";
                fileName = string.Format(TempLogs, path, DateTime.Now.ToString("yyMMdd"));
            }
            else
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\MoneyLogs\";
                fileName = string.Format(TempLogs, path, DateTime.Now.ToString("yyMMdd"));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString());

            sb.Append(string.Format("\r\n用户Agent信息：{0}", (GetUserAgent == null ? "" : GetUserAgent.ToString())));
            sb.Append(string.Format("\r\n客户端IP：{0}", (GetUserIp == null ? "" : GetUserIp.ToString())));
            sb.Append(string.Format("\r\n服务端IP：{0}", (GetServerIp == null ? "" : GetServerIp.ToString())));
            sb.Append(string.Format("\r\n详细信息：{0}", content));

            if (!Directory.Exists(path)) // 目录不存在则建立
                Directory.CreateDirectory(path);

            File.AppendAllText(fileName, sb.ToString());
        }
        #endregion

        #region 用于错误日志记录
        /// <summary>
        /// 用于错误日志记录
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string logContent(Exception ex, string errorId)
        {
            //return GameTradingByPublic.ExceptionLog.logContent(ex, errorId);

            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n=================================");
            sb.Append("\r\nWebService 发生错误 事件记录");
            if (HttpContext.Current != null)
                sb.AppendFormat("\r\n错误入口:{0}", HttpContext.Current.Request.Url.ToString());
            sb.AppendFormat("\r\n错误Id:{0}", errorId);
            sb.AppendFormat("\r\n错误信息:{0}", ex.Message.ToString());
            sb.AppendFormat("\r\n堆栈追踪:{0}", ex.StackTrace.ToString());
            sb.Append("\r\n=================================\r\n\r\n");
            return sb.ToString();
        }
        #endregion

        #region 获取客户端IP
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        public static string GetUserIp
        {
            get
            {
                string userIP = "未获取用户IP";

                try
                {
                    userIP = HttpContext.Current.Request.UserHostAddress;
                }
                catch { }

                return userIP;
            }
        }
        #endregion

        #region 获取服务端IP
        /// <summary>
        /// 获取服务端IP
        /// </summary>
        public static string GetServerIp
        {
            get
            {
                string serverIP = "未获取服务器IP";
                try
                {
                    serverIP = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
                }
                catch { }

                return serverIP;
            }
        }
        #endregion

        #region 获取用户Agent
        public static string GetUserAgent
        {
            get
            {
                string userAgent = "未获取用户Agent";
                try
                {
                    userAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
                }
                catch { }

                return userAgent;
            }
        }
        #endregion

        public static void SetLoginLog(string userName)
        {

            string logName = "userLog.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\UserLog\";


            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("-----------------------------------------------------------------\r\n");
            strBuilder.Append("登录时间:");
            strBuilder.Append(System.DateTime.Now.ToString());
            strBuilder.Append("\r\n");
            strBuilder.Append("登录名:");
            strBuilder.Append(userName);
            strBuilder.Append("\r\n");
            strBuilder.Append("登陆IP：");
            strBuilder.Append(ExceptionLog.GetUserIp);
            strBuilder.Append(" \r\n");
            strBuilder.Append("-----------------------------------------------------------------\r\n");
            strBuilder.Append("\r\n");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            File.AppendAllText(path + logName, strBuilder.ToString(), Encoding.UTF8);
        }
    }
}
