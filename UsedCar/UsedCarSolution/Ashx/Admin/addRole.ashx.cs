using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsedCarDB;
using UsedCarBLL.Admin;
using UsedCarPublic;
using UsedCarModle;

namespace UsedCarSolution.Ashx.Admin
{
    /// <summary>
    /// addRole 的摘要说明
    /// </summary>
    public class addRole : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["classType"] == "getdata" && context.Request["id"] == null)
            {
                context.Response.Write(GetAdminPopedomInfo());
                return;
            }
            if (context.Request["classType"] == "getdata" && context.Request["id"] != null)
            {
                int Id = Convert.ToInt32(context.Request["id"]);
                //取到管理员名字
                string name = context.Request["roleName"].ToString();

                List<RolePop_Pop> list = new List<RolePop_Pop>();
                //角色所拥有权限
                list = new PermissionsManager().GetRolePop_Pop(Id);

                string str = GetAdminPopedomInfo() + "$" + name + "$" + JosonHelper.ToJson(list);

                context.Response.Write(str);
                return;
            }
            //添加角色
            if (context.Request["classType"] == "senddata")
            {
                string roleName = context.Request["roleName"];
                string[] po = context.Request["listRole"].Split(',');
                PermissionsManager permissionsManager = new PermissionsManager();
                //添加
                Admin_RoleInfo role = new Admin_RoleInfo();
                role.RoleName = roleName;
                role.RoleCreateTime = DateTime.Now;
                permissionsManager.AddRole(role);
                //获取最新ID
                int roleID = permissionsManager.GetRoleInfoModelByRoleName(roleName).RoleID;
                bool isFlgs = false;

                //循环遍历得到的  权限
                for (int j = 0; j <= po.Length - 1; j++)
                {
                    UsedCarDB.Admin_RolePoperdomInfo rolePoperdomInfo = new Admin_RolePoperdomInfo();
                    rolePoperdomInfo.RoleID = roleID;
                    rolePoperdomInfo.PopedomId = Convert.ToInt32(po[j]);
                    //追条加入数据角色的权限
                    if (permissionsManager.AddRolePoperdomInfo(rolePoperdomInfo) > 0)
                    {
                        isFlgs = true;
                    }
                    else
                    {
                        isFlgs = false;
                    }
                }
                if (isFlgs)
                {
                    context.Response.Write("1");
                    return;
                }
                else
                {
                    context.Response.Write("2");
                    return;
                }
            }
            //修改权限提交
            if (context.Request["classType"] == "updatedata")
            {
                int Id = Convert.ToInt32(context.Request["id"]);

                string[] po = context.Request["listRole"].Split(',');
                string[] firstPo = context.Request["firstStr"].Split(',');
                PermissionsManager permissionsManager = new PermissionsManager();
                List<Admin_RolePoperdomInfo> ls = new List<Admin_RolePoperdomInfo>();
                //删除之前的
                if (firstPo.Length >0 && !string.IsNullOrEmpty(firstPo[0]))
                {
                    for (int j = 0; j <= firstPo.Length - 1; j++)
                    {
                        Admin_RolePoperdomInfo rp = permissionsManager.GetR_pModelByPopId(Convert.ToInt32(firstPo[j]), Id);
                        Admin_RolePoperdomInfo rolePoperdomInfo = new Admin_RolePoperdomInfo();
                        rolePoperdomInfo.RolePoerdomID = rp.RolePoerdomID;
                        ls.Add(rolePoperdomInfo);
                    }
                    int i = permissionsManager.DelRolePoperdomInfo(ls);
                    if (i > 0)
                    {
                        bool isFlg = false;
                        for (int j = 0; j <= po.Length - 1; j++)
                        {
                            Admin_RolePoperdomInfo rolePoperdomInfo = new Admin_RolePoperdomInfo();
                            rolePoperdomInfo.RoleID = Id;
                            rolePoperdomInfo.PopedomId = Convert.ToInt32(po[j]);
                            // 插入修改后的
                            if (permissionsManager.AddRolePoperdomInfo(rolePoperdomInfo) > 0)
                            {
                                isFlg = true;
                            }
                            else
                            {
                                isFlg = false;
                            }
                        }

                        if (isFlg)
                        {
                            context.Response.Write("1");
                            return;

                        }
                        else
                        {
                            context.Response.Write("2");
                            return;
                        }
                    }
                    else
                    {
                        bool isFlgs = false;
                        for (int j = 0; j <= po.Length - 1; j++)
                        {
                            Admin_RolePoperdomInfo rolePoperdomInfo = new Admin_RolePoperdomInfo();
                            rolePoperdomInfo.RoleID = Id;
                            rolePoperdomInfo.PopedomId = Convert.ToInt32(po[j]);
                            // 插入修改后的
                            if (permissionsManager.AddRolePoperdomInfo(rolePoperdomInfo) > 0)
                            {
                                isFlgs = true;
                            }
                            else
                            {
                                isFlgs = false;
                            }
                        }
                        if (isFlgs)
                        {
                            context.Response.Write("1");
                            return;

                        }
                        else
                        {
                            context.Response.Write("2");
                            return;
                        }
                    }
                }
                else 
                {
                    //如果没有选择权限
                    bool isFlg = false;
                    for (int j = 0; j <= po.Length - 1; j++)
                    {
                        Admin_RolePoperdomInfo rolePoperdomInfo = new Admin_RolePoperdomInfo();
                        rolePoperdomInfo.RoleID = Id;
                        rolePoperdomInfo.PopedomId = Convert.ToInt32(po[j]);
                        // 插入修改后的
                        if (permissionsManager.AddRolePoperdomInfo(rolePoperdomInfo) > 0)
                        {
                            isFlg = true;
                        }
                        else
                        {
                            isFlg = false;
                        }
                    }

                    if (isFlg)
                    {
                        context.Response.Write("1");
                        return;

                    }
                    else
                    {
                        context.Response.Write("2");
                        return;
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //获取权限列表
        private string GetAdminPopedomInfo()
        {
            List<Admin_PopedomInfo> admin_popedomInfo = new PermissionsManager().GetPopedomInfo();
            string jsonString = JosonHelper.ToJson(admin_popedomInfo);
            return jsonString;
        }
    }
}