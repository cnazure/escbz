<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tab.aspx.cs" Inherits="UsedCarSolution.tab" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/dengluxinxi.css" rel="stylesheet" type="text/css" />
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .table_list {
            margin: 28px 0 0 240px;
            width: 800px;
            height: 200px;
        }

            .table_list .title_bg {
                overflow: hidden;
                zoom: 1;
                height: 20px;
                padding-top: 20px;
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
        <body>
            <div class="mg">
                <%--<div class="log_bgd"></div>--%>
                <div class="mg_trbls">
                    <p>
                        <asp:Literal ID="ltUserName" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="ltTrueName" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="liteRoleName" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="ltRegistTime" runat="server"></asp:Literal>
                    </p>
                </div>

            </div>
            <div class="copyright" style="display: none;">
                2015 易过户 Group Co.,Ltd. Copyright 版权所有
            </div>

        </body>

    </form>
</body>
</html>

