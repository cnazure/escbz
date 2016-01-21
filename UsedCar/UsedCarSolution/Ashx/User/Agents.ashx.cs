using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsedCarBLL.User;
using UsedCarDB;
using UsedCarPublic;

namespace UsedCarSolution.Ashx.Admin
{
    /// <summary>
    /// Agents 的摘要说明
    /// </summary>
    public class Agents : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mod = context.Request.Form["mod"];
            switch (mod)
            {
                //验证用户名是否重复
                case "checkAgentsName": context.Response.Write(checkAgentsName(context));
                    break;
                //添加新用户
                case "addAgents": context.Response.Write(AddAgentsName(context));
                    break;
                //删除用户
                case "Delete": context.Response.Write(DelAgents(context));
                    break;
                //获取
                case "getModel": context.Response.Write(GetModel(context));
                    break;
                //获取最新用户编号
                case "getAgentsLastId": context.Response.Write(GetLastAgentsId());
                    break;
                //更新用户
                case "updateAgents": context.Response.Write(updateAgents(context));
                    break;
            }
        }

        /// </summary>
        //判断用户名是否重复
        /// </summary>
        private string checkAgentsName(HttpContext context)
        {
            try
            {
                object obj = new AgentsManager().GetModel(context.Request.Form["AName"].ToString());
                string i = obj == null ? "0" : "1";
                return i;
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        /// </summary>
        //添加用户
        /// </summary>
        private string AddAgentsName(HttpContext context)
        {
            try
            {
                T_Agents AgentsInfo = new T_Agents();
                AgentsInfo.Aid = context.Request.Form["AId"].ToString();
                AgentsInfo.AName = context.Request.Form["AName"].ToString();
                AgentsInfo.ATel = context.Request.Form["ATel"].ToString();
                AgentsInfo.AddDate = System.DateTime.Now;
                AgentsInfo.AddUser = HttpContext.Current.User.Identity.Name.ToString();//创建人;
                AgentsInfo.isUsing = true;
                int i = new AgentsManager().AddAgents(AgentsInfo);
                return i.ToString();
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
        }

        /// </summary>
        //删除代办人
        /// </summary>
        private string DelAgents(HttpContext context)
        {
            try
            {
                int i = 0;
                try
                {
                    //获取代办人信息
                    T_Agents AgentsInfo = new AgentsManager().GetModel(context.Request.Form["Aid"].ToString());
                    AgentsInfo.isUsing = false;
                    //禁用当前代办人
                    i = new AgentsManager().UpdateAgents(AgentsInfo);
                }
                catch (Exception ex)
                {
                    UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                }
                if (i > 0)
                {
                    return "OK";
                }
                else
                    return "problem";
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }

        }

        /// </summary>
        //根据主键ID查询对象并获取用户角色
        /// </summary>
        private string GetModel(HttpContext context)
        {
            try
            {
                T_Agents AgentsInfo = new AgentsManager().GetModel(context.Request.Form["Aid"].ToString());
                return JosonHelper.ToJson(AgentsInfo);
            }
            catch (Exception ex)
            {
                UsedCarPublic.Log.ExceptionLog.writeFile(ex);
                return "error";
            }
           
        }

        /// </summary>
        ///生成最新代理人编号
        /// </summary>
        private string GetLastAgentsId()
        {
            return new AgentsManager().GetLastAid();
        }

        /// </summary>
        //修改代办人信息
        /// </summary>
        private string updateAgents(HttpContext context)
        {
            try
            {
                //修改代办人基本信息            
                T_Agents AgentsInfo = new T_Agents();
                AgentsInfo.Aid = context.Request.Form["Aid"].ToString();
                AgentsInfo.AName = context.Request.Form["AName"].ToString();
                AgentsInfo.ATel = context.Request.Form["ATel"].ToString();
                AgentsInfo.AddDate = System.DateTime.Now;
                AgentsInfo.AddUser = HttpContext.Current.User.Identity.Name.ToString();//创建人;
                AgentsInfo.isUsing = true;
                int i = new AgentsManager().UpdateAgents(AgentsInfo);
                return i.ToString();
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