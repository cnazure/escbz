using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace UsedCarPublic
{
    public class JosonHelper
    {
        /// <summary>
        /// 。net对象序列化为Json对象
        /// </summary>
        /// <typeparam name="T">。net对象类型</typeparam>
        /// <param name="obj">需要序列化的。net对象</param>
        /// <returns>Json对象</returns>
        public static string ToJson<T>(T obj)
        {
            System.Web.Script.Serialization.JavaScriptSerializer script = new System.Web.Script.Serialization.JavaScriptSerializer();
            return script.Serialize(obj);
        }

        /// <summary>
        /// 反序列化Json对象
        /// </summary>
        /// <typeparam name="T">需要转换成的对象</typeparam>
        /// <param name="sJson">Json串</param>
        /// <returns>。net对象</returns>
        public static T Deserialize<T>(string sJson) where T : class
        {
            System.Web.Script.Serialization.JavaScriptSerializer script = new System.Web.Script.Serialization.JavaScriptSerializer();
            return script.Deserialize<T>(sJson);
        }

        /// <summary>
        /// List数组对象序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">List对象值</param>
        /// <returns>Json串</returns>
        public static String ToString<T>(List<T> obj)
        {
            string str = string.Empty;

            foreach (object o in obj)
            {
                str = str + o.ToString() + "\r\n";
            }


            return str;
        }
        // 将datatable转换为json  
        public static string Dtb2Json(DataTable dtb)
        {
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            foreach (DataRow dr in dtb.Rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dtb.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);

            }
            //序列化  
            return jss.Serialize(dic);
        }
        /// <summary>
        /// Model 转换为Json
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="obj">数据对象</param>
        /// <returns></returns>
        public static string ObjectToJson<T>(T o)
        {
            StringBuilder Json = new StringBuilder();
            T obj = Activator.CreateInstance<T>();
            Type type = obj.GetType();
            PropertyInfo[] Pi = type.GetProperties();
            Json.Append("{");
            for (int i = 0; i < Pi.Length; i++)
            {
                Json.Append("\"" + Pi[i].Name.ToString() + "\":\"" + ChangeString(StringHelper.SetString(Pi[i].GetValue(o, null))) + "\"");
                if (i < Pi.Length - 1)
                {
                    Json.Append(",");
                }
            }
            Json.Append("}");
            return Json.ToString();
        }
        /// <summary>
        /// 把含有html标签的元素进行转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string ChangeString(string str)
        {
            //str含有HTML标签的文本
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("\n", "<br>");
            str = str.Replace("&", "&amp;");
            return str;
        }

        /// <summary>

        /// List转成json

        /// </summary>

        /// <typeparam name="T"></typeparam>

        /// <param name="jsonName"></param>

        /// <param name="list"></param>

        /// <returns></returns>

        public static string ListToJson<T>(IList<T> list, string jsonName)
        {
            try
            {

                StringBuilder Json = new StringBuilder();

                if (string.IsNullOrEmpty(jsonName))

                    jsonName = list[0].GetType().Name;

                Json.Append("{\"" + jsonName + "\":");
                if (list != null && list.Count > 0)
                    Json.Append(ToJson(list));
                else
                    Json.Append("[]");
                Json.Append("}");
                //Json.Append("{\"" + jsonName + "\":[");

                //if (list.Count > 0)
                //{

                //    for (int i = 0; i < list.Count; i++)
                //    {

                //        T obj = Activator.CreateInstance<T>();

                //        PropertyInfo[] pi = obj.GetType().GetProperties();

                //        Json.Append("{");

                //        for (int j = 0; j < pi.Length; j++)
                //        {

                //            Type type = pi[j].GetValue(list[i], null).GetType();

                //            Json.Append("\"" + pi[j].Name.ToString() + "\":" + StringFormat(pi[j].GetValue(list[i], null).ToString(), type));



                //            if (j < pi.Length - 1)
                //            {

                //                Json.Append(",");

                //            }

                //        }

                //        Json.Append("}");

                //        if (i < list.Count - 1)
                //        {

                //            Json.Append(",");

                //        }

                //    }

                //}

                //Json.Append("]}");

                return Json.ToString();
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "";
            }

        }



        /// <summary>

        /// List转成json

        /// </summary>

        /// <typeparam name="T"></typeparam>

        /// <param name="list"></param>

        /// <returns></returns>

        public static string ListToJson<T>(IList<T> list)
        {

            object obj = list[0];

            return ListToJson<T>(list, obj.GetType().Name);

        }


        /// <summary>

        /// 格式化字符型、日期型、布尔型

        /// </summary>

        /// <param name="str"></param>

        /// <param name="type"></param>

        /// <returns></returns>

        private static string StringFormat(string str, Type type)
        {

            if (type != typeof(string) && string.IsNullOrEmpty(str))
            {

                str = "\"" + str + "\"";

            }

            else if (type == typeof(string))
            {

                str = String2Json(str);

                str = "\"" + str + "\"";

            }

            else if (type == typeof(DateTime))
            {

                str = "\"" + str.Split(' ')[0] + "\"";

            }

            else if (type == typeof(bool))
            {

                str = str.ToLower();

            }



            return str;

        }

        /// <summary>

        /// 过滤特殊字符

        /// </summary>

        /// <param name="s"></param>

        /// <returns></returns>

        private static string String2Json(String s)
        {

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {

                char c = s.ToCharArray()[i];

                switch (c)
                {

                    case '\"':

                        sb.Append("\\\""); break;

                    case '\\':

                        sb.Append("\\\\"); break;


                    default:

                        sb.Append(c); break;

                }

            }

            return sb.ToString();

        }
    }
}
