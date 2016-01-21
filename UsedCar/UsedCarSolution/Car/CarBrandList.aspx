<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarBrandList.aspx.cs" Inherits="UsedCarSolution.Car.CarBrandList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        function Del(id) {
            if (confirm("确定要删除记录吗？")) {
                $.ajax({
                    type: "post",
                    url: "/ashx/Car/CarInfo.ashx?p="+ Math.random(),
                    data: {
                        mod: "DelBrand",
                        ID: id
                    },
                    success: function (data) {
                        if (data == "OK") {
                            window.location.href = window.location.href;
                        }
                    }
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong><span class="ce1">车辆信息</span>—<span class="ce2">车辆品牌管理</span>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_list_lf">
                <tr>
                    <th>品牌编号：
                    </th>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" MaxLength="10"></asp:TextBox>
                    </td>                    
                    <th>录入人：
                    </th>
                    <td>
                        <asp:TextBox ID="txtAddUser" runat="server" MaxLength="11"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>品牌车型：
                    </th>
                    <td>
                        <asp:TextBox ID="txtCarBrand" runat="server" MaxLength="20"></asp:TextBox>
                    </td>                    
                </tr>
            </table>
            <div class="btm_btn_cont">
                <asp:Button ID="btnSearch" runat="server" Text="查询" class="btn_search_big" OnClick="btnSearch_Click" />
            </div>
        </div>
        <div class="mg_lrtb table_list">
            <input class="btn_add_big1 btn_tjxx" type="button" value="添加新品牌" onclick="window.location = 'CarBrandAddorEdit.aspx?type=Add';" />
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_1 mg_top">
                <tr>
                    <th>品牌编号
                    </th>
                    <th>品牌名称
                    </th>                    
                    <th>创建时间
                    </th>
                    <th>创建人
                    </th>
                    <th>状态
                    </th>
                    <th colspan="2">操作
                    </th>
                </tr>
                <asp:Repeater ID="rpUserList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("ID")%> 
                            </td>
                            <td>
                                <%#Eval("firstPY")%>-<%#Eval("brandName")%> 
                            </td>                           
                            <td>
                                <%#Eval("createDate")%> 
                            </td>
                            <td>
                                <%#Eval("operateUser")%> 
                            </td>
                            <td>
                                <%#getState(Eval("isValid"))%> 
                            </td>
                            <td>
                                <a class="btn_xgxx bianji_btn" href='CarBrandAddorEdit.aspx?ID=<%#Eval("ID") %>&type=Edit'>编辑</a>
                            </td>
                            <td>
                                <a class="shanchu_btn" href="javascript:void(0)" onclick="javascript:Del(<%#Eval("ID") %>)">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="ltNo" runat="server"></asp:Literal>
            </table>
            <br />
            <webdiyer:AspNetPager ID="AspnetPager" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                HorizontalAlign="right" OnPageChanged="AspnetPager_PageChanged" PageSize="15"
                FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页">
            </webdiyer:AspNetPager>
        </div>

        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">管理汽车品牌</p>
        </div>
    </form>
</body>
</html>
