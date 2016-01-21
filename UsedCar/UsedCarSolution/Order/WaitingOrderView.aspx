<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaitingOrderView.aspx.cs" Inherits="UsedCarSolution.Order.WaitingOrderView" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/css/table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">       
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">订单管理</span>—<span class="ce2">订单确认</span>
            </div>
            <div class="fanhui">
                <a href="javascript:void(0)"></a>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <div class="tjxx_cont">
                <div class="bbt">基本信息</div>
                <div class="searchcont">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_search">
                        <tr>
                            <th>订单编号：</th>
                            <td>
                                <asp:Label ID="LabId" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <th>创建人：
                            </th>
                            <td>
                                <asp:Label ID="LabUser" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>照片：
                            </th>
                            <td>
                                <asp:ImageButton ID="Img" runat="server" OnClick="Img_Click" Width="300"/>                                
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="bbt">订单信息</div>
                <div class="searchcont">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_search">
                        <tr>
                            <th>客户姓名：</th>
                            <td>
                                <asp:Label ID="LabCustomerName" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <th>品牌车型：
                            </th>
                            <td>
                                <asp:Label ID="LabCarModel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>车架号：
                            </th>
                            <td>
                                <asp:Label ID="LabVIN" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>原车牌号码：
                            </th>
                            <td>
                                <asp:Label ID="LabYCPHM" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>原户籍地：
                            </th>
                            <td>
                                <asp:Label ID="LabYHJD" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>原车主姓名：
                            </th>
                            <td>
                                <asp:Label ID="LabYCZXM" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>原车主电话：
                            </th>
                            <td>
                                <asp:Label ID="LabYCZDH" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>原车主到场：
                            </th>
                            <td>
                                <asp:Label ID="LabYCZDC" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>新户籍地：
                            </th>
                            <td>
                                <asp:Label ID="LabXHJD" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>新车主姓名：
                            </th>
                            <td>
                                <asp:Label ID="LabXCZXM" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>新车主电话：
                            </th>
                            <td>
                                <asp:Label ID="LabXCZDH" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>新车主到场：
                            </th>
                            <td>
                                <asp:Label ID="LabXCZDC" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>办证项目：
                            </th>
                            <td>
                                <asp:Label ID="LabCertType" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>提车地点：
                            </th>
                            <td>
                                <asp:Label ID="LabTCDD" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>联系人：
                            </th>
                            <td>
                                <asp:Label ID="LabLXR" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>联系电话：
                            </th>
                            <td>
                                <asp:Label ID="LabLXDH" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>办证类型：
                            </th>
                            <td>
                                <asp:Label ID="LabOrderType" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>登记日期：
                            </th>
                            <td>
                                <asp:Label ID="LabDJRQ" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>预定日期：
                            </th>
                            <td>
                                <asp:Label ID="LabYDRQ" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>开票金额：
                            </th>
                            <td>
                                <asp:Label ID="LabKPrice" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <span>
                    <asp:Button ID="btnFendan" runat="server" Text="分 单" CssClass="btn_ok_big" OnClick="btnSave_Click" />
                    <asp:Button ID="btnSumbit" runat="server" Text="提 交" CssClass="btn_ok_big" OnClick="btnSub_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="修改订单" CssClass="btn_ok_big" OnClick="btnUpdate_Click" />                    
                    <asp:HiddenField ID="hidID" runat="server" />                   
                </span>
            </div>
        </div>
        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">
                查看订单详情。
            </p>
        </div>
    </form>
</body>
</html>

