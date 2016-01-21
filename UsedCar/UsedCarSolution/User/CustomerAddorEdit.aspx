<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAddorEdit.aspx.cs" Inherits="UsedCarSolution.User.CustomerAddorEdit" %>

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
        var clientCId = "";
        $(function () {
            clientCId = '<%=CId%>';
        })
    </script>
    <script type="text/javascript" src="/js/Admin/addCustomer.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">客户管理</span>—<span class="ce2">编辑-添加客户</span>
            </div>
            <div class="fanhui">
                <a href="javascript:void(0)"></a>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <div class="tjxx_cont">
                <a href="javascript:void(0)" class="closebtn"></a>
                <div class="tp">
                </div>
                <div class="searchcont">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_search">
                        <tr>
                            <th>客户编号：</th>
                            <td>
                                <input id="txtCId" readonly="readonly" type="text" maxlength="10" />
                            </td>
                        </tr>
                        <tr>
                            <th>客户名称：
                            </th>
                            <td>
                                <input id="txtCustomerName" type="text" maxlength="10" />&nbsp&nbsp&nbsp&nbsp<span id="spCustomerName" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>联系人：
                            </th>
                            <td>
                                <input id="txtContacts" type="text" maxlength="10" />&nbsp&nbsp&nbsp&nbsp<span id="Span1" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>联系电话：
                            </th>
                            <td>
                                <input id="txtCustomerTel" type="text" maxlength="11" />&nbsp&nbsp&nbsp&nbsp
                           <span id="spPsw1" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>联系地址：
                            </th>
                            <td>
                                <input id="txtAddress" type="text" maxlength="100" />&nbsp&nbsp&nbsp&nbsp
                           <span id="Span2" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>所属用户：
                            </th>
                            <td>
                                <select id="selUser" name="selUser"></select>
                                &nbsp&nbsp&nbsp&nbsp<span id="spCharacter" style="display: none;color:red;">请选择用户</span>
                            </td>
                        </tr>
                    </table>
                </div>
                <span>
                    <input type="button" id="btnSub" class="btn_ok_big" value="确 认" />
                    <input id="btnBack" class="btn_white_big" type="button" value="返 回" onclick="window.location.href = 'CustomerList.aspx'" />
                </span>
            </div>
            <!--弹出 增加信息_end----------->
        </div>
        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">添加修改客户基本信息与联系方式</p>
        </div>
    </form>
</body>
</html>

