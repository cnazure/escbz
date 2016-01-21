<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="UsedCarSolution.Admin.resetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/dengluxinxi.css" rel="stylesheet" type="text/css" />
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
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
                <div style="margin-top: 40px;">
                    <a class="btn btn-warning btn-sm" href='javascript:void(0);' onclick="openDiv()">重置密码
                    </a>
                </div>
            </div>

        </div>
        <div class="copyright" style="display: none;">
            2011-2014 CH Group Co.,Ltd. Copyright 集团版权所有
        </div>
        <!--弹出 重置密码-->
        <div class="layer_blue layer_blue_1" id="div_message">
            <a href="#" onclick="closeDiv()" class="closebtn"></a>
            <div class="tp">
                请输入新密码
            </div>
            <div class="bd">
                <div class="searchcont">
                    <div class="inner_style">
                        <table width="100%" height="150px" border="0" cellpadding="0" cellspacing="0" class="table_search">
                            <tr>
                            <th>密 码：
                            </th>
                            <td>
                                <input id="txtPsw1" type="password" maxlength="20" style="border:inset"/>&nbsp&nbsp&nbsp&nbsp
                           <span id="spPsw1" style="display: none;color:red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>确认密码：
                            </th>
                            <td>
                                <input id="txtPsw2" type="password" maxlength="20" style="border:inset"/>&nbsp&nbsp&nbsp&nbsp
                            <span id="spPsw2" style="display: none;color:red;"></span>
                            </td>
                        </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <input class="btn_ok_big" type="button" value="确  定" onclick="javascript: resetPwd()" />
                                    <input class="btn_white_big" type="button" value="取　消" onclick="javascript: closeDiv()" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script>
        function openDiv(id) {
            $("#div_message").show();
        }
        function closeDiv() {
            $("#div_message").hide();
        }

        //验证密码
        function checkPad() {
            var reg = /^[\w]{6,12}$/;
            var psd1 = $.trim($("#txtPsw1").val());
            var psd2 = $.trim($("#txtPsw2").val());
            if (psd1.length == 0) {
                $("#spPsw1").show();
                $("#spPsw1").html("密码不能为空");
                return false;
            }
            else if (!reg.test(psd1) & psd1.length != 0) {
                $("#spPsw1").show();
                $("#spPsw1").html("密码的格式为6-12位，只能是字母、数字和下划线");
                return false;
            }
            else if (psd1 != psd2) {
                $("#spPsw1").hide();
                $("#spPsw2").show();
                $("#spPsw2").html("两次密码输入不一致");;
                return false;
            }
            else {
                $("#spPsw1").hide();
                $("#spPsw2").hide();
                return true;
            }
        }

        function resetPwd() {
            if (checkPad()) {
                $.ajax({
                    type: 'post',
                    url: "/ashx/Admin/userOperate.ashx?p="+ Math.random(),
                    async: false,
                    data: {
                        mod: "resetPwd",
                        userName: '<%=User.Identity.Name.ToString()%>',
                        password: $("#txtPsw1").val()
                    },
                    success: function (data) {
                        if (data == "OK") {
                            alert("操作成功!");
                            window.location.reload();
                        }
                        else {
                            alert("problem");
                        }
                    }
                })
            }
        }
    </script>
</body>
</html>

