<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarInfoList.aspx.cs" Inherits="UsedCarSolution.Car.CarInfoList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>无标题文档</title>
    <link href="../css/Share.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <script src="../Control/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/jqmain.js"></script>
    <script type="text/javascript" src="/js/Car/delCarInfo.js"></script>
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

        function openImg(img) {
            var jQueryImg = $("#" + img);
            if (jQueryImg.attr('src') != "")
                window.open(jQueryImg.attr('src'));
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">车辆信息</span>—<span class="ce2">车辆信息列表查询</span>
            </div>
            <div class="fanhui">
                <a href="#"></a>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_list_lf">
                <tr>
                    <th>车架号：
                    </th>
                    <td>
                        <asp:TextBox ID="txtCarVIN" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                    <th>车辆录入日期：
                    </th>
                    <td>
                        <asp:TextBox ID="txtAddDateBefore" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>
                        - 
                        <asp:TextBox ID="txtAddDateEnd" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>
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
                        <asp:TextBox ID="txtCarModel" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                    <th>车辆编号：
                    </th>
                    <td>
                        <asp:TextBox ID="txtCarId" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="btm_btn_cont">
                <asp:Button ID="btnSearch" runat="server" Text="查询" class="btn_search_big" OnClick="btnSearch_Click" />
            </div>
        </div>
        <div class="mg_lrtb table_list">
            <input class="btn_add_big1 btn_tjxx" type="button" value="添加车辆信息" onclick="window.location = 'CarInfoAddorEdit.aspx';" />
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_1 mg_top">
                <tr>
                    <th>车辆编号
                    </th>
                    <th>车架号
                    </th>
                    <th>品牌型号
                    </th>
                    <th>首次上牌日期
                    </th>
                    <th>录入日期
                    </th>
                    <th>录入人
                    </th>
                    <th>
                        图片信息
                    </th>
                    <th colspan="2">操作
                    </th>
                    <th colspan="2">新增订单
                    </th>
                </tr>
                <asp:Literal ID="ltNo" runat="server"></asp:Literal>
                <asp:Repeater ID="rpCarList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("CarId")%> 
                            </td>
                            <td>
                                <%#Eval("CarVIN")%> 
                            </td>
                            <td>
                                <%#Eval("CarModel")%> 
                            </td>
                            <td>
                                <%#Convert.ToDateTime(Eval("FirstOnCard")).ToShortDateString()%> 
                            </td>
                            <td>
                                <%# Convert.ToDateTime(Eval("AddDate")).ToShortDateString()%> 
                            </td>
                            <td>
                                <%#Eval("AddUser")%> 
                            </td>
                             <td>
                                 <img id="img<%#Eval("CarId")%>" width="100" height="100" onclick="openImg('img<%#Eval("CarId")%>');" src="<%#Eval("ImgUrl")%>"/>
                            </td>
                            <td>
                                <a class="btn_xgxx bianji_btn" href='CarInfoAddorEdit.aspx?CarId=<%#Eval("CarId") %>'>编辑</a>
                            </td>
                            <td>
                                <a class="shanchu_btn" href="javascript:void(0)" onclick="javascript:DelCarInfo('<%#Eval("CarId") %>')">删除</a>
                            </td>
                            <td>
                                <a class="buycar_btn btn btn-default btn-xs" href="javascript:void(0)">新增收购订单</a>
                            </td>
                            <td>
                                <a class="buycar_btn btn btn-default btn-xs" href="javascript:void(0)">新增销售订单</a>
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
        </div>

        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">车辆信息查看列表，用户筛选查看车辆的基本信息，可以进行编辑、删除操作，可以快捷新增订单类型。</p>
        </div>
    </form>
</body>
</html>
