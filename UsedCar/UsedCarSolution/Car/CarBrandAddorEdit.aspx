<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarBrandAddorEdit.aspx.cs" Inherits="UsedCarSolution.Car.CarBrandAddorEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/css/table.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tjxx_cont">
            <div class="bbt">车辆品牌</div>
            <div class="searchcont">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_detail">
                    <tr>
                        <th>品牌名称：
                        </th>
                        <td>
                            <asp:TextBox ID="txt_brandName" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>状态：
                        </th>
                        <td>
                            <asp:RadioButton ID="rad_isValid" runat="server" GroupName="isValid" Checked="true" Text="启用" />
                            <asp:RadioButton ID="rad_isValid1" runat="server" GroupName="isValid" Text="禁用" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hidType" runat="server" />
            <asp:HiddenField ID="hidID" runat="server" />
            <span>
                <asp:Button ID="btnAdd" runat="server" Text="确 定" class="btn_ok_big" OnClick="btnAdd_Click" />                
            </span>
        </div>
    </form>
</body>
</html>

