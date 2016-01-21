<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectPopedom.aspx.cs" Inherits="UsedCarSolution.Admin.selectPopedom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/Share.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css"/>
    <link href="../css/table.css" rel="stylesheet" type="text/css"/>
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jqmain.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="right_bg_title">
        <div class="weizi">
            <strong class="bg">当前位置：</strong><span class="ce1">权限管理</span>—<span class="ce2">查看角色分配</span></div>
        <div class="fanhui">
            <a href="#"> </a></div>
    </div>
    <div class="mg_lrtb table_list">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_1 mg_top">
            <tr>
                <th>
                    ID
                </th>
                <th>
                    角色
                </th>
                <th>
                    所拥有的权限
                </th>
                   <th >
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rpUserList" runat="server">
                <ItemTemplate>
                    <tr>
                       <td>
                           <%#Eval("RoleID")%> 
                        </td>
                        <td>
                         <%#Eval("RoleName")%>
                        </td>
                        <td style="width:70%">
                           <%#GetPopedomByUserId(Convert.ToInt32(Eval("RoleID")))%>  
                        </td>
                        <td>
                         <a  class="bianji_btn edit_roles" href="updatePopedom.aspx?id=<%#Eval("RoleID")%>&roleName=<%#Eval("RoleName")%> "></a> 
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

       <div class="tutorial">
  	<span class="title">页面描述：</span>
  	 <p class="text">查看角色权限是查看所有的后台角色的角色名，和某角色所拥有的权限 </p> 
  </div>
    </form>
</body>
</html>
