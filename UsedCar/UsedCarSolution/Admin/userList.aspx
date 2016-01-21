<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userList.aspx.cs" Inherits="UsedCarSolution.Admin.userList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>无标题文档</title>
    <link href="../css/Share.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/jqmain.js"></script>
    <script type="text/javascript" src="/js/Admin/delUser.js"></script>
    <style type="text/css">
        .table_list .title_bg {
            overflow: hidden;
            zoom: 1;
            height: 20px;
            padding-top: 10px;
            background: url(images/tittlebg.gif) top repeat-x;
            border: 1px solid #ccc;
            border-bottom: none;
        }

            .table_list .title_bg ul li {
                margin: 0 6px;
                float: left;
                padding-left: 20px;
            }

                .table_list .title_bg ul li.bg2 {
                    background: url(../images/22.gif) left top no-repeat;
                }

                .table_list .title_bg ul li.bg3 {
                    background: url(../images/33.gif) left top no-repeat;
                }

                .table_list .title_bg ul li.bg4 {
                    background: url(../images/44.gif) left top no-repeat;
                }
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">用户管理</span>
            </div>
            <div class="fanhui">
                <a href="#"></a>
            </div>
        </div>
        <div class="mg_lrtb table_list">
            <input class="btn_add_big1 btn_tjxx" type="button" value="添加新用户" onclick="window.location = 'addUser.aspx';"/>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_1 mg_top">
                <tr>
                    <th>序号
                    </th>
                    <th>用户名
                    </th>
                    <th>用户密码
                    </th>
                    <th>性别
                    </th>
                    <th>电话
                    </th>
                    <th>地址
                    </th>
                    <th>真实姓名
                    </th>
                    <th>角色
                    </th>
                    <th>创建时间
                    </th>
                    <th colspan="2">操作
                    </th>
                </tr>
                <asp:Literal ID="ltNo" runat="server"></asp:Literal>
                <asp:Repeater ID="rpUserList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("UserID")%> 
                            </td>
                            <td>
                                <%#Eval("UserName")%> 
                            </td>
                            <td>
                                <%#Eval("UserPass")%> 
                            </td>
                            <td>
                                <%#Eval("Sex")%> 
                            </td>
                            <td>
                                <%#Eval("Phone")%> 
                            </td>
                            <td>
                                <%#Eval("Address")%> 
                            </td>
                            <td>
                                <%#Eval("TrueName")%> 
                            </td>
                            <td>
                                <%#Eval("RoleName")%> 
                            </td>
                            <td>
                                <%#Eval("Time")%> 
                            </td>
                            <td>
                                <a class="btn_xgxx bianji_btn" href='addUser.aspx?UserID=<%#Eval("UserID") %>'>编辑</a>
                            </td>
                            <td>
                                <a class="shanchu_btn" href="javascript:void(0)" onclick="javascript:DelUser(<%#Eval("UserID") %>)">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
              <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <br />
                <webdiyer:AspNetPager ID="AspnetPager" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                    HorizontalAlign="right" OnPageChanged="AspnetPager_PageChanged" PageSize="20"
                    FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页">
                </webdiyer:AspNetPager>
            <input type="hidden" id="hidRoleId" value="" />
        </div>

        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">管理后台的用户信息</p>
        </div>
    </form>
</body>
</html>
