<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="UsedCarSolution.Admin.addUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/css/table.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/jqmain.js"></script>
    <script type="text/javascript">
        var clientUserID = "";
        $(function () {
            clientUserID = '<%=userID%>';
        })
    </script>
    <script src="../js/Admin/addUser.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">用户管理</span>—<span class="ce2">编辑-添加用户</span>
            </div>
            <div class="fanhui">
                <a href="javascript:void(0)"></a>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <!--弹出 增加信息----------->
            <div class="tjxx_cont">
                <a href="javascript:void(0)" class="closebtn"></a>
                <div class="tp">
                </div>
                <div class="searchcont">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_search">
                        <tr>
                            <th>用户名：
                            </th>
                            <td>
                                <input id="txtUserName" type="text" maxlength="20" />&nbsp&nbsp&nbsp&nbsp<span id="spUserName" style="display: none; color:red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>密 码：
                            </th>
                            <td>
                                <input id="txtPsw1" type="Password" maxlength="20" />&nbsp&nbsp&nbsp&nbsp
                           <span id="spPsw1" style="display: none;color:red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>确认密码：
                            </th>
                            <td>
                                <input id="txtPsw2" type="Password" maxlength="20" />&nbsp&nbsp&nbsp&nbsp
                            <span id="spPsw2" style="display: none;color:red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>真实姓名：
                            </th>
                            <td>
                                <input id="txtTrueName" type="text" maxlength="20" />&nbsp&nbsp&nbsp&nbsp
                            <span id="spTrueName" style="display: none; color:red;">请输入真实姓名</span>
                            </td>
                        </tr>
                        <tr>
                            <th>手机号码：
                            </th>
                            <td>
                                <input id="txtPhone" type="text" maxlength="20" />
                                &nbsp&nbsp&nbsp&nbsp
                            <span id="spPhone" style="display: none;color:red;">请输入正确的电话号码</span>
                            </td>
                        </tr>
                        <tr>
                            <th>地 址：
                            </th>
                            <td>
                                <input id="txtAddress" type="text" maxlength="20" />
                                &nbsp&nbsp&nbsp&nbsp
                           <span id="spAddress" style="display: none;color:red;">请输入地址</span>
                            </td>
                        </tr>
                        <tr>
                            <th>性 别：
                            </th>
                            <td>
                                <input type="radio" value="1" name="sex" checked="checked" />男
                            <input type="radio" value="0" name="sex" />女
                            </td>
                        </tr>
                        <tr>
                            <th>所属角色：
                            </th>
                            <td>
                                <%--<select id="selRole" name="selRole" onchange="changeSelRole()"></select>--%>
                                <select id="selRole" name="selRole"></select>
                                &nbsp&nbsp&nbsp&nbsp<span id="spCharacter" style="display: none;color:red;">请选择角色</span>
                            </td>
                        </tr>
                    </table>
                </div>
                <span>


                    <input type="button" id="btnSub" class="btn_ok_big" value="确 定" />


                    <input id="btnBack" class="btn_white_big" type="button" value="返回" onclick="window.location.href = 'userList.aspx'" />
                </span>
            </div>
            <!--弹出 增加信息_end----------->
        </div>
        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">添加用户是添加后台的管理者，添加成功后，该账号可以登录后台，并可以根据所属的角色进行后台的相应操作</p>
        </div>
    </form>
</body>
</html>
