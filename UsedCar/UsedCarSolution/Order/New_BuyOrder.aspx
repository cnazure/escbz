<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_BuyOrder.aspx.cs" Inherits="UsedCarSolution.Order.New_BuyOrder" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <script src="../Control/My97DatePicker/WdatePicker.js"></script>
    <link href="/css/table.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/Order/js/js_AddOrder.js"></script>
</head>
<body>
    <form id="form2" runat="server">
        <!--弹出 添加信息----------->
        <div class="layer_blue layer_blue_2 tjxx_cont" id="tan1">
            <a href="javascript:void(0)" class="closebtn"></a>
            <div class="tp">
                选择车辆
            </div>
            <div class="bd">
                <div class="mg_lrtb br_se">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_list_lf">
                        <tr>
                            <th>车架号：
                            </th>
                            <td>
                                <asp:TextBox ID="txtCar" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                            <th>品牌车型：
                            </th>
                            <td>
                                <asp:TextBox ID="txtCarModel" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>

                            <th>车辆编号：
                            </th>
                            <td>
                                <asp:TextBox ID="txtCarId" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="查询" class="btn_search_big" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
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
                        <th>操作
                        </th>

                    </tr>
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
                                    <a id="selectCar" href='javascript:;' onclick="selectCar('<%#Eval("CarVIN")%>','<%#Eval("CarId")%>')">选择</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <br />
                <webdiyer:AspNetPager ID="AspnetPager" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                    HorizontalAlign="right" OnPageChanged="AspnetPager_PageChanged" PageSize="10"
                    FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页">
                </webdiyer:AspNetPager>
            </div>
        </div>
        <!--弹出 添加信息_end----------->
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">订单管理</span>—<span class="ce2">收购办证订单</span>
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
                    </table>
                </div>
                <div class="bbt">收购订单信息</div>
                <div class="searchcont">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_search">
                        <tr class="trInner_hasAddition_Desc">
                            <th>办证项目：
                            </th>
                            <td colspan="3">
                                <div class="inner_style">
                                    <asp:CheckBoxList ID="CertType" runat="server" RepeatDirection="Horizontal" RepeatColumns="5" >
                                        <asp:ListItem Value="1" Text="提档"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="过户"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="上牌"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="正常委托"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="过期委托"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="正常年检"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="过期年检"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="商业险保险"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="一年交强险"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="一月交强险"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="违章处理"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="变更车架号"></asp:ListItem>
                                        <asp:ListItem Value="13" Text="变更发动机号"></asp:ListItem>
                                        <asp:ListItem Value="14" Text="变更车主姓名"></asp:ListItem>
                                        <asp:ListItem Value="15" Text="变更证件号码"></asp:ListItem>
                                        <asp:ListItem Value="16" Text="变更车辆颜色"></asp:ListItem>
                                        <asp:ListItem Value="17" Text="变更其他信息"></asp:ListItem>
                                        <asp:ListItem Value="18" Text="补车辆登记证书"></asp:ListItem>
                                        <asp:ListItem Value="19" Text="补车辆行驶证"></asp:ListItem>
                                        <asp:ListItem Value="20" Text="补车辆牌照"></asp:ListItem>
                                        <asp:ListItem Value="21" Text="补车辆保单"></asp:ListItem>
                                        <asp:ListItem Value="22" Text="补车辆其他项目"></asp:ListItem>
                                        <asp:ListItem Value="23" Text="抵押登记"></asp:ListItem>
                                        <asp:ListItem Value="24" Text="解除抵押"></asp:ListItem>
                                        <asp:ListItem Value="25" Text="其他"></asp:ListItem>
                                    </asp:CheckBoxList>
                                    <asp:Label ID="Label3" runat="server" Text="其他备注："></asp:Label>
                                    <asp:TextBox ID="txtTypeBei" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th>车架号：
                            </th>
                            <td>
                                <asp:TextBox ID="txtCarVIN" runat="server"></asp:TextBox>&nbsp&nbsp
                                <a class="btn_xgxx yulan_btn" href="javascript:void(0)">预览</a>
                            </td>
                        </tr>
                        <tr>
                            <th>开票金额：
                            </th>
                            <td>
                                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="spAmount" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>客户名称：
                            </th>
                            <td>
                                <asp:DropDownList ID="CustomerList" runat="server"></asp:DropDownList>&nbsp&nbsp&nbsp&nbsp<span id="spPsw1" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>登记日期：
                            </th>
                            <td>
                                <asp:TextBox ID="txtDJDate" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>原户籍地：
                            </th>
                            <td>
                                <asp:ScriptManager ID="sm_test" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel runat="server" ID="up_test">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropProvince_SelectedIndexChanged"></asp:DropDownList>&nbsp&nbsp&nbsp&nbsp<span id="Span1" style="display: none; color: red;"></span>
                                        <asp:DropDownList ID="DropCity" runat="server"></asp:DropDownList>&nbsp&nbsp&nbsp&nbsp<span id="Span2" style="display: none; color: red;"></span>
                                        <asp:RadioButtonList ID="RadioBoxShanghai" runat="server" RepeatDirection="Horizontal" Style="display: none">
                                            <asp:ListItem Value="1" Text="沪A牌退牌上沪A牌"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="沪A牌退牌上沪C牌"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="沪C牌上沪A牌"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="沪C牌上沪C牌"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <th>原车主姓名：
                            </th>
                            <td>
                                <asp:TextBox ID="txtYCZXM" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span3" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>原车主电话：
                            </th>
                            <td>
                                <asp:TextBox ID="txtYCZDH" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span6" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>原车牌号码：
                            </th>
                            <td>
                                <asp:TextBox ID="txtYCZCard" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span4" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>原车主到场：
                            </th>
                            <td>
                                <asp:RadioButtonList ID="YCZRadio" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th>新户籍地：
                            </th>
                            <td>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropProvince2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropProvince2_SelectedIndexChanged"></asp:DropDownList>&nbsp&nbsp&nbsp&nbsp<span id="Span5" style="display: none; color: red;"></span>
                                        <asp:DropDownList ID="DropCity2" runat="server"></asp:DropDownList>&nbsp&nbsp&nbsp&nbsp<span id="Span7" style="display: none; color: red;"></span>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <th>新车主姓名：
                            </th>
                            <td>
                                <asp:TextBox ID="txtXCZXM" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span8" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>新车主电话：
                            </th>
                            <td>
                                <asp:TextBox ID="txtXCZDH" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span9" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>新车牌号码：
                            </th>
                            <td>
                                <asp:TextBox ID="txtXCPHM" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span10" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>新车主到场：
                            </th>
                            <td>
                                <asp:RadioButtonList ID="XCZRadio" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th>提车地点：
                            </th>
                            <td>
                                <asp:TextBox ID="txtTCDD" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span11" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>联系人：
                            </th>
                            <td>
                                <asp:TextBox ID="txtLXR" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span12" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>电话：
                            </th>
                            <td>
                                <asp:TextBox ID="txtLXRDH" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span13" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>预定日期：
                            </th>
                            <td>
                                <asp:TextBox ID="txtYDDate" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="Span14" runat="server" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <span>
                    <asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="btn_ok_big" OnClick="btnSave_Click" />
                    <asp:Button ID="btnSub" runat="server" Text="提 交" CssClass="btn_ok_big" OnClick="btnSub_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="编 辑" CssClass="btn_ok_big" OnClick="btnUpdate_Click" />
                    <input id="Button2" class="btn_white_big" type="button" value="返 回" onclick="window.location.href = 'CarInfoList.aspx'" />
                    <asp:HiddenField ID="hidType" runat="server" />
                    <asp:HiddenField ID="hidID" runat="server" />
                    <asp:HiddenField ID="hidCarId" runat="server" />
                </span>
            </div>
            <input id="AddDate" type="hidden" />
        </div>
        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">
                订单预录入功能，需要录入员填写订单基本信息，分单功能由管理员B进行分配。录入员无分配权限。录入员联系预约好客户确认时间后，短信息发送给客户，告知客户已经接单，并通知预定日期。
            </p>
        </div>
    </form>
</body>
</html>
