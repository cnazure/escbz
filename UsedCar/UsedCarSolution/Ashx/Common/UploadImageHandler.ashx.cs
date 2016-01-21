using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace UsedCarSolution.Ashx.Common
{
    /// <summary>
    /// UploadImageHandler 的摘要说明
    /// </summary>
    public class UploadImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string msg = "";
            string error = "ERROR";
            string ret = "{error:'" + error + "',msg:'" + msg + "'}";
            if (context.Request.Files != null && context.Request.Files.Count > 0)
            {
                HttpPostedFile file = context.Request.Files[0];
               
                bool fileOk = false;
                string _root = System.Configuration.ConfigurationManager.AppSettings["UploadRoot"].ToString();  //本地根目录
                string _rootHotGame = System.Configuration.ConfigurationManager.AppSettings["UploadFiles"].ToString();

                string path = context.Server.MapPath("~/" + _root + "/" + _rootHotGame + "/") + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string pathOnDB = (_root + "/" + _rootHotGame + "/") + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                string path2 = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString("000") + "_" + file.FileName;
                string pathOn = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + path2;
                string path3 = path + "\\" + path2;         //最终的保存路径                
                //取得文件的扩展名,并转换成小写
                string s = System.IO.Path.GetExtension(file.FileName);
                if (s != null)
                {
                    string fileExtension = s.ToLower();
                    //限定只能上传jpg和gif图片
                    string[] allowExtension = { ".jpg", ".gif", ".png", ".jpeg" };
                    //对上传的文件的类型进行一个个匹对
                    for (int i = 0; i < allowExtension.Length; i++)
                    {
                        if (fileExtension == allowExtension[i])
                        {
                            fileOk = true;
                            break;
                        }
                    }
                }
                if (file.FileName.Length > 100)
                    msg = "文件名过长";
                if (!fileOk)
                    msg = "要上传的文件类型不对！";
                //对上传文件的大小进行检测，限定文件最大不超过4M
                if (file.ContentLength > 4096000)
                {
                    fileOk = false;
                    msg = "文件类型或者文件大小超出4M或者文件类型不对";
                }
                //最后的结果
                if (fileOk)
                {
                    try
                    {
                        file.SaveAs(path3);

                        //上传压缩
                        int w = UsedCarPublic.PublicMethods.GetAppSettings("ImgWidth") == null ? 694 : Convert.ToInt16(UsedCarPublic.PublicMethods.GetAppSettings("ImgWidth"));
                        int h = UsedCarPublic.PublicMethods.GetAppSettings("ImgHeight") == null ? 514 : Convert.ToInt16(UsedCarPublic.PublicMethods.GetAppSettings("ImgHeight"));
                        Koumi.Tools.PhotoFactory.Photo.CreateSmallPhoto(path3, w, h, path3.Replace(s, "_0" + s), false);
                        Koumi.Tools.PhotoFactory.Photo.CompressPhoto(path3.Replace(s, "_0" + s), 200);

                        if (File.Exists(path3))
                        {
                            FileInfo fi = new FileInfo(path3);
                            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                                fi.Attributes = FileAttributes.Normal;
                            File.Delete(path3);
                        }
                        msg = pathOnDB + "/" + path2.Replace(s, "_0" + s);
                        fileOk = true;
                        error = "SUCCESS";
                    }
                    catch (Exception ex)
                    {
                        UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                        fileOk = false;
                    }
                }
            }
            ret = "{error:'" + error + "',msg:'" + msg + "'}";
            context.Response.ContentType = "text/html;charset=UTF-8";
            context.Response.Write(ret);
            context.Response.End();

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