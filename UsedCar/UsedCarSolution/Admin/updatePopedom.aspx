<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatePopedom.aspx.cs" Inherits="UsedCarSolution.Admin.updatePopedom" %>

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
    <script src="/js/Admin/updatetPopedom.js" type="text/javascript"></script>
</head>
<body>
     <form id="form1" runat="server">
    <%--  <div style="display:none;">
        角色名称： <asp:Literal ID="lblName" runat="server"></asp:Literal>
 
        <br />
    
        <span>
        <br />
        角色所拥有的权限：</span>
        
        <asp:Repeater ID="rptPopedom" runat="server">
        <ItemTemplate>
         <asp:Literal ID="libAss" runat="server" Text =  '<%# Eval("PopedomName")+" | " %>'></asp:Literal>
        </ItemTemplate>
        </asp:Repeater>
    
        <br />
    
        <br />
        <span>系统所有的权限：</span><br />
        <asp:CheckBoxList ID="ckbPopedom" runat="server">
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="btnSub" runat="server" Text="提交" onclick="btnSub_Click"/>
    
    </div>--%>
    <div class="right_bg_title">
        <div class="weizi">
            <strong class="bg">当前位置：</strong><span class="ce1">权限管理</span>—<span class="ce1">分配角色权限</span>—<span
                class="ce2">修改角色权限</span></div>
        <div class="fanhui">
           <a href="/Admin/selectPopedom.aspx">返回</a>
        </div>
    </div>
    <div class="mg_lrtb">
        <p style='padding-left: 10px; font-size: 14px' id="name">
        </p>
        <div class="tab_pack">
        </div>
        <div style="display: none;">
            所拥有权限：<div id="popedomList">
            </div>
        </div>
        <table width="100%" class="table_search mg_top" id="tab">
        </table>
    </div>
    <div class="cen_btn_cont">
        <input class="btn_ok_big" type="button" value="确 定" id="btnSubmit" />
        <input class="btn_white_big" type="reset" value="重 置" id="btnCannel" />
    </div>
    <input type="hidden" value="<%=Request.QueryString["id"] %>" id="hdID" />
    <input type="hidden" value="<%=Request.QueryString["roleName"] %>" id="hdRoleName" />
    <div class="tutorial">
        <span class="title">页面描述：</span>
        <p class="text">
            角色权限页面，修改该角色的权限，勾选为分配权限，不勾选为不分配该权限</p>
    </div>
    </form>
</body>
</html>

