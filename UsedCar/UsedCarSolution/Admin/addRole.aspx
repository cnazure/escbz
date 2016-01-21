<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addRole.aspx.cs" Inherits="UsedCarSolution.Admin.addRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/css/table.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/jqmain.js"></script>
    <script src="/js/Admin/addRole.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="right_bg_title">
        <div class="weizi">
            <strong class="bg">当前位置：</strong> <span class="ce1">角色管理</span>—<span class="ce2">增加角色</span></div>
    </div>
    <div class="mg_lrtb">
        <p style='padding-left: 10px; font-size: 14px'>
            <strong>角色的名字</strong>：<input type="text" id="roleName" />
        </p>
        <table width="100%" class="table_search mg_top" id="tab">
        </table>
    </div>
    <div class="cen_btn_cont">
        <input class="btn_ok_big" type="button" value="确 定" id="btnSubmit" />
        <input class="btn_white_big" type="reset" value="重 置" id="btnCannel" />
    </div>
    <div class="tutorial">
        <span class="title">页面描述：</span>
        <p class="text">
            增加角色页面是增加新的操作后台的角色，并给该角色分配权限，只有分配了权限才能对后台进行相应的操作，例如，只有分配了查看工作用户的权限，才能查看工作用户页面</p>
    </div>
    </form>
</body>
</html>

