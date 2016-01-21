<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="UsedCarSolution.top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>无标题文档</title>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        function tick() {
            var hours, minutes, seconds, xfile;
            var intHours, intMinutes, intSeconds;
            var today;
            today = new Date();
            intHours = today.getHours();
            intMinutes = today.getMinutes();
            intSeconds = today.getSeconds();
            if (intHours == 0) {
                hours = "12:";
                xfile = "Midnight "; //午夜
            } else if (intHours < 12) {
                hours = intHours + ":";
                xfile = "PM "; //上午
            } else if (intHours == 12) {
                hours = "12:";
                xfile = "Noon "; //正午
            } else {
                intHours = intHours - 12
                hours = intHours + ":";
                xfile = "PM "; //下午
            }
            if (intMinutes < 10) {
                minutes = "0" + intMinutes + ":";
            } else {
                minutes = intMinutes + ":";
            }
            if (intSeconds < 10) {
                seconds = "0" + intSeconds + " ";
            } else {
                seconds = intSeconds + " ";
            }
            timeString = xfile + hours + minutes + seconds;
            $("#Clock").html(timeString);
            window.setTimeout("tick();", 100);
        }
        window.onload = tick;
    </script>
    <link href="css/Share.css" rel="stylesheet" type="text/css" />
    <style>
        .top_bg {
            padding: 10px;
            overflow: hidden;
            zoom: 1;
            border-top: 2px solid #6d2222;
            background: #eee;
        }

        .logo {
            width: 238px;
        }

        .nav ul li {
            line-height: 40px;
            margin: 0 10px;
            float: right;
        }

        img.tuichu_pic {
            width: 79px;
            height: 23px;
            background: url(images/tuichu_pic_s.png) no-repeat;
            display: inline-block;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_bg" >
            <div class="logo">
                <a href="tab.aspx" target='main'>
                    <img  width="238" height="36" src="images/logo.jpg"/></a>
            </div>
        </div>
        <div class="">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr height="32">
                    <td width="28" background="images/bg2.gif" style="padding-left: 30px;"></td>
                    <td valign="middle" background="images/bg2.gif">系统登录成功： <span style="color: red;"><span id="lblLonigName">【<asp:Literal ID="liteName" runat="server"></asp:Literal>】</span>&nbsp;&nbsp;你好! 欢迎登录易过户管理系统</span> <span style="padding-left: 60px;">您的登录IP为：<span id="lblIp"><asp:Literal ID="liteIp" runat="server"></asp:Literal></span></span><span style="color: #c00;" id="loginIp"></span> <span style="padding-left: 30px;">现在时间：</span><span style="color: red;" id="Clock"></span></td>
                    <td width="150px" background="images/bg2.gif" style="text-align: right; color: #135294;">
                        <asp:ImageButton ID="imgBtn" runat="server" ImageUrl="~/images/tuichu_pic_S.png" OnClick="imgBtn_Click" />
                        &nbsp; </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
