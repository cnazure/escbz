using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UsedCarPublic
{
    public class StringHelper
    {
        /// <summary>
        /// 过滤敏感字符（防SQL注入）
        /// 作者：卢亚东
        /// 时间：2012-4-14
        /// </summary>
        /// <param name="value">用户输入的文本信息</param>
        /// <returns>过滤后的字符</returns>
        public static string FilterStr(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            value = Regex.Replace(value, "[\\s]{2,{", " ");
            value = Regex.Replace(value, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            value = Regex.Replace(value, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            value = Regex.Replace(value, "<(.|\\n)*?>", string.Empty);	//any other tags
            value = Regex.Replace(value, "=", "");
            value = Regex.Replace(value, "%", "");
            value = Regex.Replace(value, "'", "");
            value = Regex.Replace(value, "declare", "");
            value = Regex.Replace(value, "truncate", "");
            value = Regex.Replace(value, "*", "");
            value = Regex.Replace(value, "#", "");
            value = Regex.Replace(value, "%", "");
            value = Regex.Replace(value, "chr", "");
            value = Regex.Replace(value, "mid", "");
            value = Regex.Replace(value, "select", "");
            value = Regex.Replace(value, "insert", "");
            value = Regex.Replace(value, "delete", "");
            value = Regex.Replace(value, "or", "");
            value = Regex.Replace(value, "exec", "");
            value = Regex.Replace(value, "--", "");
            value = Regex.Replace(value, "and", "");
            value = Regex.Replace(value, "where", "");
            value = Regex.Replace(value, "update", "");
            value = Regex.Replace(value, "script", "");
            value = Regex.Replace(value, "iframe", "");
            value = Regex.Replace(value, "master", "");
            value = Regex.Replace(value, "exec", "");
            value = Regex.Replace(value, "<", "");
            value = Regex.Replace(value, ">", "");
            value = Regex.Replace(value, "\r\n", "");
            value = Regex.Replace(value, "(", "");
            value = Regex.Replace(value, ")", "");
            value = Regex.Replace(value, "\"", "");
            value = Regex.Replace(value, "join", "");
            value = Regex.Replace(value, "char", "");
            return value;
        }

        public static List<string> GetStrArray(string str, char speater, bool toLower)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(speater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != speater.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }
        public static string[] GetStrArray(string str)
        {
            return str.Split(new char[',']);
        }
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }


        #region 删除最后一个字符之后的字符

        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }

        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }

        #endregion

        /// <summary>
        /// 设置获取指定长度字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string getLenstr(string str, int len)
        {
            if (str.Length > len)
            {
                return str.Substring(0, len) + "...";
            }
            return str;
        }


        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        public static List<string> GetSubStringList(string o_str, char sepeater)
        {
            List<string> list = new List<string>();
            string[] ss = o_str.Split(sepeater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != sepeater.ToString())
                {
                    list.Add(s);
                }
            }
            return list;
        }


        #region 将字符串样式转换为纯字符串
        public static string GetCleanStyle(string StrList, string SplitString)
        {
            string RetrunValue = "";
            //如果为空，返回空值
            if (StrList == null)
            {
                RetrunValue = "";
            }
            else
            {
                //返回去掉分隔符
                string NewString = "";
                NewString = StrList.Replace(SplitString, "");
                RetrunValue = NewString;
            }
            return RetrunValue;
        }
        #endregion

        #region 将字符串转换为新样式
        public static string GetNewStyle(string StrList, string NewStyle, string SplitString, out string Error)
        {
            string ReturnValue = "";
            //如果输入空值，返回空，并给出错误提示
            if (StrList == null)
            {
                ReturnValue = "";
                Error = "请输入需要划分格式的字符串";
            }
            else
            {
                //检查传入的字符串长度和样式是否匹配,如果不匹配，则说明使用错误。给出错误信息并返回空值
                int strListLength = StrList.Length;
                int NewStyleLength = GetCleanStyle(NewStyle, SplitString).Length;
                if (strListLength != NewStyleLength)
                {
                    ReturnValue = "";
                    Error = "样式格式的长度与输入的字符长度不符，请重新输入";
                }
                else
                {
                    //检查新样式中分隔符的位置
                    string Lengstr = "";
                    for (int i = 0; i < NewStyle.Length; i++)
                    {
                        if (NewStyle.Substring(i, 1) == SplitString)
                        {
                            Lengstr = Lengstr + "," + i;
                        }
                    }
                    if (Lengstr != "")
                    {
                        Lengstr = Lengstr.Substring(1);
                    }
                    //将分隔符放在新样式中的位置
                    string[] str = Lengstr.Split(',');
                    foreach (string bb in str)
                    {
                        StrList = StrList.Insert(int.Parse(bb), SplitString);
                    }
                    //给出最后的结果
                    ReturnValue = StrList;
                    //因为是正常的输出，没有错误
                    Error = "";
                }
            }
            return ReturnValue;
        }
        #endregion

        /// <summary>
        /// 转换成时间格式的字符串
        /// 作者：卢亚东
        /// 时间：2012-4-25
        /// </summary>
        /// <param name="str">用户传过来的值</param>
        /// <param name="formattype">要显示的时间格式（如：yyyy-mm-dd或者yyyy/mm/dd）</param>
        /// <returns>返回字符串的空或者正确的时间格式</returns>
        //public static string ToDataTimeString(object str, string formattype)
        //{
        //    string result = Input.SetString(str);
        //    if (result != "")
        //        result = Convert.ToDateTime(result).ToString(formattype);
        //    return result;
        //}
        /// <summary>
        /// 分割字符串，变成'123','333'类型
        /// 作者：卢亚东
        /// 时间：2012-4-26
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SplitString(string str)
        {
            string result = string.Empty;
            if (str.IndexOf(",") > 0)
            {
                str = str.Replace("'", "");
                string[] array = str.Split(',');
                foreach (var each in array)
                {
                    if (result != string.Empty)
                        result += ",";
                    result += string.Format("'{0}'", each);
                }
            }
            else
                result = string.Format("'{0}'", str);
            return result;
        }

        public static string SetString(object o)
        {
            return Convert.ToString("" + o);
        }
        /// <summary>
        /// 转化成int类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int SetInt(object str)
        {
            int result = 0;
            if (str != null)
            {
                try
                {
                    result = int.Parse("0" + str);
                }
                catch
                {
                    result = 0;
                }
            }
            return result;
        }
        /// <summary>
        /// 转换成decimal类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal SetDecimal(object str)
        {
            Regex RegAllNumber = new Regex("^[0-9]+[.]?[0-9]+|[0-9]+$");
            Match m = RegAllNumber.Match(SetString(str));
            if (m.Success)
                return Convert.ToDecimal(str);
            else
                return 0;
        }
    }
}
