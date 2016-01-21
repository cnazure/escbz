<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="UsedCarSolution.User.CustomerList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�ޱ����ĵ�</title>
    <link href="../css/Share.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <script src="../Control/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/jqmain.js"></script>
    <script type="text/javascript" src="/js/Admin/delCustomer.js"></script>
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
                <strong class="bg">��ǰλ�ã�</strong> <span class="ce1">�ͻ�����</span>��<span class="ce2">�ͻ���Ϣ�б�</span>
            </div>
            <div class="fanhui">
                <a href="#"></a>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_list_lf">
                <tr>
                    <th>�ͻ���ţ�
                    </th>
                    <td>
                        <asp:TextBox ID="txtCId_cx" runat="server" MaxLength="5"></asp:TextBox>
                    </td>
                    <th>�ͻ����ƣ�
                    </th>
                    <td>
                        <asp:TextBox ID="txtCName_cx" runat="server" MaxLength="6"></asp:TextBox>
                    </td>
                    <th>��ϵ�ˣ�
                    </th>
                    <td>
                        <asp:TextBox ID="txtContacts_cx" runat="server" MaxLength="6"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>������ڣ�
                    </th>
                    <td>
                        <asp:TextBox ID="txtAddDateFrom_cx" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>
                        - 
                        <asp:TextBox ID="txtAddDateTo_cx" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="btm_btn_cont">
                <asp:Button ID="btnSearch" runat="server" Text="��ѯ" class="btn_search_big" OnClick="btnSearch_Click" />
            </div>
        </div>
        <div class="mg_lrtb table_list">
            <input class="btn_add_big1 btn_tjxx" type="button" value="����¿ͻ�" onclick="window.location = 'CustomerAddorEdit.aspx';" />
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_1 mg_top">
                <tr>
                    <th>�ͻ����
                    </th>
                    <th>�ͻ�����
                    </th>
                    <th>��ϵ��
                    </th>
                    <th>��ϵ�绰
                    </th>
                    <th>������̨�û�
                    </th>
                    <th>���ʱ��
                    <th colspan="2">����
                    </th>
                </tr>
                <asp:Literal ID="ltNo" runat="server"></asp:Literal>
                <asp:Repeater ID="rpUserList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("CId")%> 
                            </td>
                            <td>
                                <%#Eval("CName")%> 
                            </td>
                            <td>
                                <%#Eval("Contacts")%> 
                            </td>
                            <td>
                                <%#Eval("CTel")%> 
                            </td>
                            <td>
                                <%#Eval("BelongUser")%> 
                            </td>
                            <td>
                                <%#Eval("AddDate")%> 
                            </td>
                            <td>
                                <a class="btn_xgxx bianji_btn" href='CustomerAddorEdit.aspx?CId=<%#Eval("CId") %>'>�༭</a>
                            </td>
                            <td>
                                <a class="shanchu_btn" href="javascript:void(0)" onclick="javascript:DelCustomer('<%#Eval("CId") %>')">ɾ��</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <br />
            <webdiyer:AspNetPager ID="AspnetPager" runat="server" CssClass="paginator" CurrentPageButtonClass="cpb"
                HorizontalAlign="right" OnPageChanged="AspnetPager_PageChanged" PageSize="20"
                FirstPageText="��ҳ" LastPageText="βҳ" PrevPageText="��ҳ" NextPageText="��ҳ">
            </webdiyer:AspNetPager>
            <input type="hidden" id="hidRoleId" value="" />
        </div>

        <div class="tutorial">
            <span class="title">ҳ��������</span>
            <p class="text">����ͻ���Ϣ���ͻ���Ϣ�б�鿴���޸�</p>
        </div>
    </form>
</body>
</html>

