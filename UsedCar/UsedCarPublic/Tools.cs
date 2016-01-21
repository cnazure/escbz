using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace UsedCarPublic
{
    public class Tools
    {
        private Hashtable _currentPersons = new Hashtable();

        #region//从服务器代码弹出框
        public static void Alert(string strMessage, System.Web.UI.Page page)
        {
            strMessage = strMessage.Replace("'", ",");

            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script>alert('" + strMessage + "');</script>");
        }

        public static void Alert(string msg, string url, Page page)
        {
            msg = msg.Replace("'", ",");

            if (msg == "")
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "Alert", "<script>location.href='" + url + "'</script>");
            }
            else if (url == "")
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "Alert", "<script>alert('" + msg + "');</script>");
            }
            else
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "Alert", "<script>alert('" + msg + "');location.href='" + url + "'</script>");
            }
        }


        public static void ReturnErrorPage(Page page, string strMsg)
        {
            if (page.TemplateSourceDirectory != "/")
            {
                string Path_str = page.TemplateSourceDirectory;

                char[] tmp_char = Path_str.ToCharArray();
                int count = 0;
                for (int a = 0; a < tmp_char.Length; a++)
                {
                    if (tmp_char[a] == '/')
                    {
                        count++;
                    }
                }
                string errURL_str = "";
                for (int a = 0; a < count; a++)
                {
                    errURL_str += "../";
                }
                errURL_str += "UiComm/DeskTop.aspx?strMsg=" + strMsg;
                page.Response.Redirect(errURL_str);
            }
            else
            {
                page.Response.Redirect("UiComm/DeskTop.aspx?strMsg=" + strMsg);
            }
        }

        public static void ReturnErrorPage(Page page, string strMsg, string url)
        {
            if (page.TemplateSourceDirectory != "/")
            {
                string Path_str = page.TemplateSourceDirectory;

                char[] tmp_char = Path_str.ToCharArray();
                int count = 0;
                for (int a = 0; a < tmp_char.Length; a++)
                {
                    if (tmp_char[a] == '/')
                    {
                        count++;
                    }
                }
                string errURL_str = "";
                for (int a = 0; a < count; a++)
                {
                    errURL_str += "../";
                }
                errURL_str += url;
                // page.Response.Redirect(errURL_str);
                Tools.Alert(strMsg, errURL_str, page);
            }
            else
            {
                //page.Response.Redirect(url);
                Tools.Alert(strMsg, url, page);
            }
        }
        #endregion
      
    }
}
