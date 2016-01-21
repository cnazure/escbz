using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using UsedCarPublic.Log;
using UsedCarPublic.UploadImg;
//using CarKeyPublic.UploadImg;

namespace UsedCarPublic
{
    public class PublicMethods
    {
        #region 客户端分页方法（输出分页样式）
        /// <summary>
        /// 客户端分页方法（输出分页样式，只有PAGE参数适用）
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <param name="query_string">Url参数</param>
        /// <returns></returns>
        public static string pagination(int total, int per, int page, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            next = page + 1;
            pre = page - 1;
            //中间页起始序号
            startcount = (page + 5) > allpage ? allpage - 7 : page - 4;///startcount = (page + 5) > allpage ? allpage - 9 : page - 4;
            //中间页终止序号
            endcount = page < 5 ? 7 : page + 2; ///endcount = page < 5 ? 10 : page + 5; 显示为每页10条
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            //获取 站点名+页面名+参数
            string RawUrl = System.Web.HttpContext.Current.Request.RawUrl;
            if (RawUrl.Contains("&"))
                RawUrl = RawUrl.Remove(RawUrl.IndexOf('&'));//取消多余参数
            string fh = RawUrl.IndexOf("?") < 0 ? "?" : "&";
            string qStr = RawUrl.IndexOf("page") < 0 ? RawUrl + fh + "page=1" : RawUrl;

            pagestr = "<div class='page'>";
            pagestr += "<span>共<strong>" + total + "</strong>个记录</span><span>当前<strong>" + page + "/" + allpage + "</strong>页</span>";

            /*判断首尾页状态*/
            if (page > 1)
            {
                pagestr += "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=1") + ">首页</a>";
            }
            else
            {
                pagestr += "<a href='javascript:void(0);' class='non'>首页</a>";
            }

            //获取 站点名+页面名+参数
            pagestr += page > 1 ? "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + pre + "") + ">上一页</a>" : "<a href='javascript:void(0);' class='non'>上一页</a>";
            var num = 0;
            for (int i = startcount; i <= endcount; i++)
            {
                pagestr += page == i ? "<a href='javascript:void(0)' class='set'>" + i + "</a>" : "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + i) + ">" + i + "</a>";
                num = i;
            }
            pagestr += page != allpage ? "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + next + "") + ">下一页</a>" : " <a href='javascript:void(0);' class='non'>下一页</a>";

            /*判断首尾页状态*/
            if (page != allpage)
            {
                pagestr += "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + allpage + "") + ">末页</a>";
            }
            else
            {
                pagestr += "<a href='javascript:void(0);' class='non'>末页</a>";
            }

            pagestr += "</div>";
            return pagestr;
        }

        /// <summary>
        /// 客户端分页方法（输出分页样式）+ 订单状态筛选
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <param name="strOrderState">订单状态</param>
        /// <param name="query_string">Url参数</param>
        /// <returns></returns>
        public static string pagination(int total, int per, int page, string strOrderState, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            next = page + 1;
            pre = page - 1;
            //中间页起始序号
            startcount = (page + 5) > allpage ? allpage - 7 : page - 4;///startcount = (page + 5) > allpage ? allpage - 9 : page - 4;
            //中间页终止序号
            endcount = page < 5 ? 7 : page + 2; ///endcount = page < 5 ? 10 : page + 5; 显示为每页10条
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            //获取 站点名+页面名+参数
            string RawUrl = System.Web.HttpContext.Current.Request.RawUrl;
            string fh = RawUrl.IndexOf("?") < 0 ? "?" : "&";
            string qStr = RawUrl.IndexOf("page") < 0 ? RawUrl + fh + "page=1&state=" + strOrderState + "" : RawUrl;

            pagestr = "<div class='page'>";
            pagestr += "<span>共<strong>" + total + "</strong>个记录</span><span>当前<strong>" + page + "/" + allpage + "</strong>页</span>";

            /*判断首尾页状态*/
            if (page > 1)
            {
                pagestr += "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+", "page=1&state=" + strOrderState + "") + ">首页</a>";
            }
            else
            {
                pagestr += "<a href='javascript:void(0);' class='non'>首页</a>";
            }

            //获取 站点名+页面名+参数
            pagestr += page > 1 ? "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+", "page=" + pre + "&state=" + strOrderState + "") + ">上一页</a>" : "<a href='javascript:void(0);' class='non'>上一页</a>";
            var num = 0;
            for (int i = startcount; i <= endcount; i++)
            {
                if (qStr.Contains("state"))
                {
                    pagestr += page == i ? "<a href='javascript:void(0)' class='set'>" + i + "</a>" : "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+", "page=" + i) + "&state=" + strOrderState + ">" + i + "</a>";
                    num = i;
                }
                else
                {
                    pagestr += page == i ? "<a href='javascript:void(0)' class='set'>" + i + "</a>" : "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + i) + "&state=" + strOrderState + ">" + i + "</a>";
                    num = i;
                }
            }



            /*判断首尾页状态*/
            if (page != allpage)
            {
                if (qStr.Contains("state"))
                {
                    pagestr += page != allpage ? "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+", "page=" + next + "") + "&state=" + strOrderState + ">下一页</a>" : " <a href='javascript:void(0);' class='non'>下一页</a>";
                    pagestr += "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+", "page=" + allpage + "") + "&state=" + strOrderState + ">末页</a>";
                }
                else
                {
                    pagestr += page != allpage ? "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + next + "") + "&state=" + strOrderState + ">下一页</a>" : " <a href='javascript:void(0);' class='non'>下一页</a>";
                    pagestr += "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + allpage + "") + "&state=" + strOrderState + ">末页</a>";
                }
            }
            else
            {
                pagestr += "<a href='javascript:void(0);' class='non'>末页</a>";
            }

            pagestr += "</div>";
            return pagestr;
        }

        /// <summary>
        /// 客户端分页方法（输出分页样式）+ 订单状态筛选
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <param name="strOrderState">订单状态</param>
        /// <param name="query_string">Url参数</param>
        /// <returns></returns>
        public static string pagination(int total, int per, int page, string strOrderState, string dateState, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            next = page + 1;
            pre = page - 1;
            //中间页起始序号
            startcount = (page + 5) > allpage ? allpage - 7 : page - 4;///startcount = (page + 5) > allpage ? allpage - 9 : page - 4;
            //中间页终止序号
            endcount = page < 5 ? 7 : page + 2; ///endcount = page < 5 ? 10 : page + 5; 显示为每页10条
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            //获取 站点名+页面名+参数
            string RawUrl = System.Web.HttpContext.Current.Request.RawUrl;
            string fh = RawUrl.IndexOf("?") < 0 ? "?" : "&";
            string qStr = RawUrl.IndexOf("page") < 0 ? RawUrl + fh + "page=1&state=" + strOrderState + "&dateState=" + dateState + "" : RawUrl;

            pagestr = "<div class='page'>";
            pagestr += "<span>共<strong>" + total + "</strong>个记录</span><span>当前<strong>" + page + "/" + allpage + "</strong>页</span>";

            /*判断首尾页状态*/
            if (page > 1)
            {
                pagestr += "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+&dateState=\d+", "page=1&state=" + strOrderState + "&dateState=" + dateState + "") + ">首页</a>";
            }
            else
            {
                pagestr += "<a href='javascript:void(0);' class='non'>首页</a>";
            }

            //获取 站点名+页面名+参数
            pagestr += page > 1 ? "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+&dateState=\d+", "page=" + pre + "&state=" + strOrderState + "&dateState=" + dateState + "") + ">上一页</a>" : "<a href='javascript:void(0);' class='non'>上一页</a>";
            var num = 0;
            for (int i = startcount; i <= endcount; i++)
            {
                if (qStr.Contains("state") && qStr.Contains("dateState"))
                {
                    pagestr += page == i ? "<a href='javascript:void(0)' class='set'>" + i + "</a>" : "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+&dateState=\d+", "page=" + i) + "&state=" + strOrderState + "&dateState=" + dateState + ">" + i + "</a>";
                    num = i;
                }
                else
                {
                    pagestr += page == i ? "<a href='javascript:void(0)' class='set'>" + i + "</a>" : "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+&dateState=\d+", "page=" + i) + "&state=" + strOrderState + "&dateState=" + dateState + ">" + i + "</a>";
                    num = i;
                }
            }



            /*判断首尾页状态*/
            if (page != allpage)
            {
                if (qStr.Contains("state"))
                {
                    pagestr += page != allpage ? "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+&dateState=\d+", "page=" + next + "") + "&state=" + strOrderState + "&dateState=" + dateState + ">下一页</a>" : " <a href='javascript:void(0);' class='non'>下一页</a>";
                    pagestr += "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+&dateState=\d+", "page=" + allpage + "") + "&state=" + strOrderState + "&dateState=" + dateState + ">末页</a>";
                }
                else
                {
                    pagestr += page != allpage ? "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+&dateState=\d+", "page=" + next + "") + "&state=" + strOrderState + "&dateState=" + dateState + ">下一页</a>" : " <a href='javascript:void(0);' class='non'>下一页</a>";
                    pagestr += "<a href=" + Regex.Replace(qStr, @"page=\d+&state=\d+&dateState=\d+", "page=" + allpage + "") + "&state=" + strOrderState + "&dateState=" + dateState + ">末页</a>";
                }
            }
            else
            {
                pagestr += "<a href='javascript:void(0);' class='non'>末页</a>";
            }

            pagestr += "</div>";
            return pagestr;
        }


        public static string PaginationSimplify(int total, int per, int page, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            next = page + 1;
            pre = page - 1;
            //中间页起始序号
            startcount = (page + 5) > allpage ? allpage - 8 : page - 4;///startcount = (page + 5) > allpage ? allpage - 9 : page - 4;
            //中间页终止序号
            endcount = page < 5 ? 9 : page + 4; ///endcount = page < 5 ? 10 : page + 5; 显示为每页10条
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            //获取 站点名+页面名+参数
            string RawUrl = System.Web.HttpContext.Current.Request.RawUrl;
            string fh = RawUrl.IndexOf("?") < 0 ? "?" : "&";
            string qStr = RawUrl.IndexOf("page") < 0 ? RawUrl + fh + "page=1" : RawUrl;

            pagestr = "<div class='page'>";
            //获取 站点名+页面名+参数
            pagestr += page > 1 ? "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + pre + "") + ">上一页</a>" : "<a href='javascript:void(0);' class='non'>上一页</a>";
            /*判断首尾页及上下翻页状态和url*/
            pagestr += page != allpage ? "<a href=" + Regex.Replace(qStr, @"page=\d+", "page=" + next + "") + ">下一页</a>" : " <a href='javascript:void(0);' class='non'>下一页</a>";
            pagestr += "</div>";
            return pagestr;
        }
        #endregion

        #region 前端分页方法

        /// <summary>
        /// 前端分页（输出分页样式）
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public static string UsedCarPagination(int total, int per, int page)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            next = page + 1;
            pre = page - 1;
            //中间页起始序号
            startcount = (page + 5) > allpage ? allpage - 7 : page - 4;///startcount = (page + 5) > allpage ? allpage - 9 : page - 4;
            //中间页终止序号
            endcount = page < 5 ? 7 : page + 2; ///endcount = page < 5 ? 10 : page + 5; 显示为每页10条
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            //生成分页，样张：
            //<span class="prev disabled" title="上一页">«</span>
            //<a href="#" class="current"><span>1</span></a>
            //<a href="#"><span>2</span></a>
            //<a href="#"><span>3</span></a>
            //<a href="#"><span>4</span></a>
            //<a href="#"><span>5</span></a>
            //<a href="#"><span>6</span></a>
            //<a href="#"><span>7</span></a>
            //<a href="#"><span>8</span></a>
            //<a href="#"><span>9</span></a>
            //<span class="next" title="下一页">»</span>
            pagestr += page > 1 ? "<span onclick='prePage()' class='prev' title='上一页'>«</span>" : "<span class='prev disabled' title='上一页'>«</span>";
            var num = 0;
            for (int i = startcount; i <= endcount; i++)
            {
                pagestr += "<a href='javascript:void(0)' onclick='changePage(this)' title='" + i + "'";
                if (page == i)
                    pagestr += " class='current'";
                pagestr += "><span>" + i + "</span></a>";
                num = i;
            }
            pagestr += page != allpage ? "<span onclick='nextPage()' class='next' title='下一页'>»</span>" : "<span class='next disabled' title='下一页'>»</span>";
            return pagestr;
        }

        #endregion

        #region 获取appSettings
        /// <summary>
        /// 获取AppSettings的值
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string GetAppSettings(string Key)
        {
            try
            {
                string result = ConfigurationManager.AppSettings[Key];
                if (string.IsNullOrEmpty(result))
                    result = "";
                return result;
            }
            catch
            {
                return "";
            }

        }
        #endregion

        #region 读取上传配置，创建上传文件的真正保存文件夹，并将临时文件Copy到创建文件夹下，远程上传
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="imagePath">图片上传名称（例：/123.jpg）</param>
        /// <param name="UpImgSmlByBool">是否生成缩略图</param>
        /// <param name="tempFolder">上传图片在本地保存的临时文件夹名</param>
        /// <param name="UploadFiles">上传图片在远程服务器保存的文件夹名</param>
        /// <param name="UpImgFile_Small">上传图片（缩略图）在远程服务器保存的文件夹名【注：UpImgSmlByBool为true时候必填，为false时传入空字符串】</param>
        public static void ServerUplodeImg(string imagePath, bool UpImgSmlByBool, string tempFolder, string UploadFiles, string UpImgFile_Small)
        {
            IUploadService service = UploadImgManager.GetUploadInstance();
            string Filename_Image = imagePath.Substring(imagePath.LastIndexOf("/") + 1);
            try
            {
                ///本地根目录
                string _root = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
                ///远程路径根目录
                string _rootRemote = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
                if (_root.IndexOf(@":\") == -1)
                {
                    _root = HttpContext.Current.Server.MapPath(_root);
                }
                ///本地临时路径节点
                string _tempFolder = tempFolder;
                ///远程大图保存路径节点
                string _UploadFiles = UploadFiles;

                ///本地保存路径
                string _folder = (DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day).Replace(@"\", "/");
                ///生成远程保存大图路径
                string _folder_Big = _rootRemote + "/" + _UploadFiles + "/" + (DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day).ToString();

                /*获取要上传文件的路径（临时图片）*/
                string _oldPath = Path.Combine(_root, _tempFolder, _folder, Filename_Image).Replace("/", @"\");
                /*开始上传*/
                service.UploadFile(File.ReadAllBytes(_oldPath), imagePath, _folder_Big);

                /*获取要上传文件的路径（小图）*/
                if (UpImgSmlByBool)
                {
                    ///远程小图保存路径节点
                    string _UpImgFile_Small = UpImgFile_Small;
                    ///生成远程保存小图路径
                    string _folder_Small = _rootRemote + "/" + _UpImgFile_Small + "/" + (DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day).ToString();
                    ///创建本地小图保存路径
                    string _savePath_Small = Path.Combine(Path.Combine(_root, _UpImgFile_Small), _folder).Replace("/", @"\");
                    if (!Directory.Exists(_savePath_Small))
                    {
                        Directory.CreateDirectory(_savePath_Small);
                    }
                    /*处理生成缩小像素的图片*/
                    string _newPath_Small = Path.Combine(_root, _UpImgFile_Small, _folder, Filename_Image).Replace("/", @"\");

                    /*处理图片大小并保存到本地*/
                    new ZoomImage().PicSized(_oldPath, _newPath_Small);

                    string _SmallnewPath = Path.Combine(_root, _UpImgFile_Small, _folder, Filename_Image).Replace("/", @"\");
                    /*开始上传*/
                    service.UploadFile(File.ReadAllBytes(_SmallnewPath), imagePath, _folder_Small);
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.writeFile(Convert.ToInt32(ExceptionLog.fileTypeStatus.fileTypeOne), ExceptionLog.logContent(ex, "图片上传异常"));
            }
        }
        /// <summary>
        /// 上传图片并返回完整上传路径
        /// </summary>
        /// <param name="imagePath">图片上传名称（例：123.jpg）</param>
        /// <param name="tempFolder">上传图片在本地保存的临时文件夹名</param>
        /// <param name="UploadFiles">上传图片在远程服务器保存的文件夹名</param>
        public static string ServerUplodeImg(string imagePath, string tempFolder, string UploadFiles)
        {
            IUploadService service = UploadImgManager.GetUploadInstance();
            string imagePathName = "/" + imagePath;
            try
            {
                ///本地根目录
                string _root = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
                ///远程路径根目录
                string _rootRemote = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();
                if (_root.IndexOf(@":\") == -1)
                {
                    _root = HttpContext.Current.Server.MapPath(_root);
                }
                ///本地临时路径节点
                string _tempFolder = tempFolder;
                ///远程大图保存路径节点
                string _UploadFiles = UploadFiles;

                ///本地保存路径
                string _folder = (DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day).Replace(@"\", "/");
                ///生成远程保存大图路径
                string _folder_Big = _rootRemote + "/" + _UploadFiles + "/" + (DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day).ToString();

                /*获取要上传文件的路径（临时图片）*/
                string _oldPath = Path.Combine(_root, _tempFolder, _folder, imagePath).Replace("/", @"\");
                /*开始上传*/
                service.UploadFile(File.ReadAllBytes(_oldPath), imagePathName, _folder_Big);

                string imageDomain = System.Configuration.ConfigurationManager.AppSettings["ImageDomainName"].ToString();
                return imageDomain + _folder_Big + imagePathName;
            }
            catch (Exception ex)
            {
                ExceptionLog.writeFile(Convert.ToInt32(ExceptionLog.fileTypeStatus.fileTypeOne), ExceptionLog.logContent(ex, "图片上传异常"));
                return "";
            }
        }
        #endregion

        #region 获取web客户端ip
        /// <summary>
        /// 获取web客户端ip
        /// </summary>
        /// <returns></returns>
        public static string GetWebClientIp()
        {

            string userIP = "未获取用户IP";

            try
            {
                if (System.Web.HttpContext.Current == null
            || System.Web.HttpContext.Current.Request == null
            || System.Web.HttpContext.Current.Request.ServerVariables == null)
                    return "";

                string CustomerIP = "";

                //CDN加速后取到的IP simone 090805
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                }

                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }

            return userIP;

        }
        #endregion

        #region 加密 解密
        /// <summary>
        /// MD5加密+自定义加密
        /// </summary>
        public static String getMd5(String str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            String md5Content = BitConverter.ToString(
                md5.ComputeHash(
                Encoding.Default.GetBytes(str))).Replace("-", "").ToLower();
            return md5Content;
        }

        /// <summary>
        /// MD5加密+自定义加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5EncryptDES(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            String md5Content = BitConverter.ToString(
                md5.ComputeHash(
                Encoding.Default.GetBytes(str))).Replace("-", "").ToLower();
            return EncryptDES(md5Content, GetAppSettings("encryptKey"));
        }

        /// <summary>
        /// 自定义加密
        /// </summary>
        /// <param name="encryptString">字符串</param>
        /// <param name="encryptKey">加密密钥</param>
        /// <returns></returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray()).Replace("+", "%2B");
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// 自定义解密
        /// </summary>
        /// <param name="decryptString">字符串</param>
        /// <param name="decryptKey">密钥</param>
        /// <returns></returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                //去除字符串中的%2B和空格
                decryptString = decryptString.Replace("%2B", "+").Replace(" ", "+");
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        #endregion

        #region 手机/邮箱 验证码
        /// <summary>
        /// 功能：生成手机验证码
        /// </summary>
        /// <param name="mobile">手机</param>
        /// <returns>返回Code</returns>
        public static string GetCodeToMobile(string mobile)
        {
            string code = GetCode(5);
            mobile = mobile.Substring(mobile.Length - 4, 4);
            int sum = Convert.ToInt32(mobile[0]) + Convert.ToInt32(mobile[1]) + Convert.ToInt32(mobile[2]) + Convert.ToInt32(mobile[3]);
            if (sum >= 10)
                sum = sum % 10;
            Random random = new Random(DateTime.Now.Millisecond);
            int index = sum / 2;
            code = code.Insert(index, sum.ToString());
            return code;
        }

        /// <summary>
        /// 生成邮箱验证码
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public static string GetCodeToEmail(string email)
        {
            string code = GetCode(5);
            int num = email.Length;
            num = num % 10;
            code = code.Insert(Convert.ToInt32(num > 5 ? num / 2 : num), num.ToString());
            return code;
        }
        #endregion

        #region 获取随机数字

        /// <summary>
        /// 获取随即数字
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetCode(int n)
        {
            string str = Guid.NewGuid().ToString("N");
            string num = "";
            foreach (char item in str)
            {
                if (item >= 48 && item <= 58)
                {
                    num += item;
                }
            }
            return num.Substring(0, n);
        }
        #endregion

        #region 获取随机数字（第一位不为0）
        /// <summary>
        ///  获取随即数字（第一位不为0）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetCodeFirstNotO(int n)
        {
            Random random = new Random();
            int firstNum = random.Next(1, 9);

            string str = Guid.NewGuid().ToString("N");
            string num = "";
            foreach (char item in str)
            {
                if (item >= 48 && item <= 58)
                {
                    num += item;
                }
            }
            return firstNum + num.Substring(0, n - 1);
        }
        #endregion

        /// <summary>
        /// 随机生成GUID
        /// </summary>
        /// <param name="n">长度</param>
        /// <returns>string</returns>
        public static string GetGuidCode(int n)
        {
            if (n >= 32) return null;
            return Guid.NewGuid().ToString().Substring(0, n).Replace("-", "");
        }

        #region 订单编号生成
        /// <summary>
        /// 订单编号生成
        /// </summary>
        /// <param name="n">订单随机数位数</param>
        /// <returns></returns>
        public static string CreateOrderId(int n)
        {
            string NumStr = DateTime.Now.ToString("yyyyMMdd").ToString();

            string GuidStr = Guid.NewGuid().ToString("N");
            string num = "";
            foreach (char item in GuidStr)
            {
                if (item >= 48 && item <= 58)
                {
                    num += item;
                }
            }
            return "DK" + NumStr + num.Substring(0, n) + RandomOrderNumber();
        }


        public static string CreateOrderId(int n, string mode)
        {
            string NumStr = DateTime.Now.ToString("yyyyMMdd").ToString();

            string GuidStr = Guid.NewGuid().ToString("N");
            string num = "";
            foreach (char item in GuidStr)
            {
                if (item >= 48 && item <= 58)
                {
                    num += item;
                }
            }
            return mode + NumStr + num.Substring(0, n) + RandomOrderNumber();
        }
        static Random randOrder = new Random();
        static string RandomOrderNumber()
        {
            string randNum = randOrder.Next(100).ToString();
            if (Convert.ToInt32(randNum) < 10)
            {
                randNum = randNum.ToString().PadLeft(2, '0');
            }
            return randNum;
        }

        #endregion

        #region DataTable序列化成List<T>
        public static List<T> ConvertToList<T>(DataTable dt) where T : new()
        {

            // 定义集合  
            List<T> ts = new List<T>();

            // 获得此模型的类型  
            Type type = typeof(T);
            //定义一个临时变量  
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行  
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性  
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性  
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量  
                    //检查DataTable是否包含此列（列名==对象的属性名）    
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter  
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出  
                        //取值  
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性  
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                //对象添加到泛型集合中  
                ts.Add(t);
            }

            return ts;

        }

        #endregion

        #region String数组转为DataTable 数组使用|分隔

        /// <summary>  
        /// 把一个一维数组转换为DataTable  
        /// </summary>  
        public static DataTable ConvertToDataTable(string columnName, string[] array)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(columnName, typeof(string));

            foreach (string t in array)
            {
                DataRow dr = dt.NewRow();
                dr[columnName] = t.ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion

        #region 获取图片地址

        public static string GetRealImgUrl(object imgUrl)
        {
            string root = GetAppSettings("UploadRoot");
            string uploadFile = GetAppSettings("UploadFiles");

            return root + "/" + uploadFile + "/" + imgUrl;
        }

        /// <summary>
        /// 获取图片路径保存至数据库值
        /// </summary>
        /// <param name="imgUrl">真实图片地址</param>
        /// <returns></returns>
        public static string GetShortImgUrl(string imgUrl)
        {
            string root = GetAppSettings("UploadRoot");
            string uploadFile = GetAppSettings("UploadFiles");
            return imgUrl.Replace(root + "/" + uploadFile + "/", "");
        }

        #endregion

        #region 时间戳

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion 时间戳

        ///<summary>返回两个经纬度坐标点的距离（单位：米） by Alex.Y</summary>
        ///<param name="Longtiude">来源坐标经度Y</param>
        ///<param name="Latitude">来源坐标经度X</param>
        ///<param name="Longtiude2">目标坐标经度Y</param>
        ///<param name="Latitude2">目标坐标经度X</param>
        ///<returns>返回距离（千米）</returns>
        public static double getMapDistance(double Longtiude, double Latitude, double Longtiude2, double Latitude2)
        {

            var lat1 = Latitude;
            var lon1 = Longtiude;
            var lat2 = Latitude2;
            var lon2 = Longtiude2;
            var earthRadius = 6371; //appxoximate radius in miles  6378.137

            var factor = Math.PI / 180.0;
            var dLat = (lat2 - lat1) * factor;
            var dLon = (lon2 - lon1) * factor;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1 * factor)
              * Math.Cos(lat2 * factor) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double d = earthRadius * c;

            return d;

        }

        #region 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
        /// <summary> 
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
        /// </summary> 
        /// <param name="CnChar">单个汉字</param> 
        /// <returns>单个小写字母</returns> 
        public static string GetCharSpellCode(string CnChar)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.GetEncoding("gb2312").GetBytes(CnChar);

            //如果是字母，则直接返回 
            if (ZW.Length == 1)
            {
                return CnChar.ToUpper();
            }
            else
            {
                // get the array of byte from the single char 
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }
            // iCnChar match the constant 
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }

            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return (CnChar.Substring(0, 1).ToUpper());//如果是英文字符串，取第一个字母大写
        }

        #endregion

        public static string SendSMS(string strNum, string Content)
        {
            Content = Content + "【魅子】";
            string username = "api",
            password = "key-d391dfffec9f5772e732a142c5e83c2d",
            url = "http://sms-api.luosimao.com/v1/send.json";

            byte[] byteArray = Encoding.UTF8.GetBytes("mobile=" + strNum + "&message=" + Content);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(username + ":" + password));
            webRequest.Headers.Add("Authorization", auth);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;

            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string Message = php.ReadToEnd();

            System.Console.Write(Message);
            System.Console.Read();

            return Message;
        }

        #region 控件操作

        #region CheckBoxList操作
        /// <summary>
        /// 初始化CheckBoxList中哪些是选中了的
        /// </summary>
        /// <param name="checkList">CheckBoxList</param>
        /// <param name="selval">选中了的值串例如："0,1,1,2,1"</param>
        /// <param name="separator">值串中使用的分割符例如"0,1,1,2,1"中的逗号</param>
        public static string SetChecked(CheckBoxList checkList, string selval, string separator)
        {
            selval = separator + selval + separator;        //例如："0,1,1,2,1"->",0,1,1,2,1,"
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                checkList.Items[i].Selected = false;
                string val = separator + checkList.Items[i].Value + separator;
                if (selval.IndexOf(val) != -1)
                {
                    checkList.Items[i].Selected = true;
                    selval = selval.Replace(val, separator);        //然后从原来的值串中删除已经选中了的
                    if (selval == separator)        //selval的最后一项也被选中的话，此时经过Replace后，只会剩下一个分隔符
                    {
                        selval += separator;        //添加一个分隔符
                    }
                }
            }
            selval = selval.Substring(1, selval.Length - 2);        //除去前后加的分割符号
            return selval;
        }

        ///// <summary>
        /// 得到CheckBoxList中选中了的值
        /// </summary>
        /// <param name="checkList">CheckBoxList</param>
        /// <param name="separator">分割符号</param>
        /// <returns>01,02,03</returns>
        public static string GetChecked(CheckBoxList checkList, string separator)
        {
            string selval = "";
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].Selected)
                {
                    selval += checkList.Items[i].Value + separator;
                }
            }
            if (selval.Length > 1)
            {
                selval = selval.Substring(0, selval.Length - 1);
            }
            return selval;
        }
        #endregion CheckBoxList操作

        #endregion
    }
}
