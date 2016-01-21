<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaitingCertList.aspx.cs" Inherits="UsedCarSolution.Order.WaitingCertList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/Share.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <script src="../Control/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/jqmain.js"></script>
    <script type="text/javascript" src="js/js_AddOrder.js"></script>
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
                <strong class="bg">当前位置：</strong> <span class="ce1">订单管理</span>—<span class="ce2">未分配订单列表</span>
            </div>
            <div class="fanhui">
                <a href="#"></a>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_list_lf">
                <tr>
                    <th>订单编号：
                    </th>
                    <td>
                        <asp:TextBox ID="txtCarOrderId" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                    <th>车架号：
                    </th>
                    <td>
                        <asp:TextBox ID="txtCarVIN" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                    <th>车牌号码：
                    </th>
                    <td>
                        <asp:TextBox ID="txtCarHM" runat="server" MaxLength="11"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>登记日期：
                    </th>
                    <td>
                        <asp:TextBox ID="AddDJRQ" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>
                        - 
                        <asp:TextBox ID="EndDJRQ" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>
                    </td>
                    <th>预定日期：
                    </th>
                    <td>
                        <asp:TextBox ID="AddYDRQ" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>
                        - 
                        <asp:TextBox ID="EndYDRQ" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>
                    </td>
                    <th>客户名称：
                    </th>
                    <td>
                        <asp:TextBox ID="txtCustomerName" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>办证项目：
                    </th>
                    <td>
                        <asp:DropDownList ID="OrderTypeList" runat="server">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="1">收购</asp:ListItem>
                            <asp:ListItem Value="2">销售</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <th>办证类型：
                    </th>
                    <td>
                        <asp:DropDownList ID="CertTypeList" runat="server"></asp:DropDownList>
                    </td>
                    <th>新户籍地：</th>
                    <td>
                        <asp:ScriptManager ID="sm_test" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropProvince2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropProvince2_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="DropCity2" runat="server"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <th>原户籍地：
                    </th>
                    <td>
                        <asp:UpdatePanel runat="server" ID="up_test">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropProvince_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="DropCity" runat="server"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <div class="btm_btn_cont">
                <asp:Button ID="btnSearch" runat="server" Text="查询" class="btn_search_big" OnClick="btnSearch_Click" />
            </div>
        </div>
        <div class="mg_lrtb table_list">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_1 mg_top">
                <tr>
                    <th>订单编号
                    </th>
                    <th>客户名称
                    </th>
                    <th>品牌型号
                    </th>
                    <th>登记日期
                    </th>
                    <th>车架号
                    </th>
                    <th>原户籍地
                    </th>
                    <th>新户籍地
                    </th>
                    <th>办证项目
                    </th>
                    <th>预定办证日期
                    </th>
                    <th>当前状态
                    </th>
                    <th colspan="3">操作
                    </th>
                </tr>
                <asp:Repeater ID="rpCarList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("OrderId")%> 
                            </td>
                            <td>
                                <%#Eval("CustomerName")%> 
                            </td>
                            <td>
                                <%#Eval("CarModel")%> 
                            </td>
                            <td>
                                <%# Eval("DJDate") != null ?Convert.ToDateTime(Eval("DJDate")).ToShortDateString() : ""%> 
                            </td>
                            <td>
                                <%#Eval("CarVIN")%> 
                            </td>
                            <td>
                                <%#Eval("YHJD")%> 
                            </td>
                            <td>
                                <%#Eval("XHJD")%>
                            </td>
                            <td>
                                <%# new UsedCarPublic.OrderCommon().GetCertTypeName(Eval("CertType").ToString())%> 
                            </td>
                            <td>
                                <%# Eval("YDDate")!= null ? Convert.ToDateTime(Eval("YDDate")).ToShortDateString() :""%> 
                            </td>
                            <td>
                                <%# new UsedCarPublic.OrderCommon().GetOrderStatusName(Eval("OrderStatus").ToString())%> 
                            </td>
                            <td>
                                <a class="btn_xgxx chakan_btn" href='WaitingCertView.aspx?ID="<%#Eval("OrderId")%>"'>补全信息</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
            <webdiyer:AspNetPager ID="AspnetPager" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                HorizontalAlign="right" OnPageChanged="AspnetPager_PageChanged" PageSize="20"
                FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页">
            </webdiyer:AspNetPager>
        </div>

        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">
                业务员,只能查看分配给自己的已分配订单信息，点击补全信息将该对应记录的订单信息资料补充完整<br />
                如果订单信息已经补充完毕，订单状态为办证中，不在该列表中显示．需要在办证查询－－办证中选项中查看．
            </p>
        </div>
    </form>
</body>
</html>
