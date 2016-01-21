<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UsedCarSolution.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>易过户管理系统</title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <link href="css/dengluxinxi.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" type="text/javascript">
        $(function () {
            if (window != top)
                top.location.href = location.href;
        })
    </script>



    <script type="text/javascript">
        function SubmitKeyClick(event) {
            if (event.keyCode == 13) {
                document.getElementById("btn").click();
            }
        }
        function clickChecklogin() {
            var username = $("#userName").val();
            var pwd = $("#passWord").val();
            if ($.trim(username) == "" || $.trim(pwd) == "") {
                $(".don").attr("style", "display:inline-block");
                $(".don").html(" <img src='images/ico_red.png' />用户名或密码不能为空");
            } else {
                $(".don").attr("style", "display:none");
                $(".don").text("");
                $.ajax({
                    type: "post",
                    url: "/ashx/Admin/loginCheck.ashx",
                    data: { name: username, pass: pwd, t: Math.random() },
                    success: function (result) {
                        if (result == "false") {
                            $(".don").attr("style", "display:inline-block");
                            $(".don").html("<img src='images/ico_red.png' />用户名或密码不正确");
                        } else {
                            window.location = "/main.aspx";
                        }
                    }
                })
            }
        }
    </script>
</head>
<body onkeydown="SubmitKeyClick(event);" class="bodybg">
    <form id="form1" runat="server">
        <div class="bg_auto">
            <div class="top_bg">
                <img src="/images/logo_bg.jpg" />
            </div>
            <div class="bottom_bg">
                <div class="mgs">
                    <p class="p1">
                        <input class="inbox" id="userName" type="text" maxlength="20" />
                    </p>
                    <p class="p2">
                        <input class="inbox" type="password" id="passWord" maxlength="20" />
                    </p>
                </div>
                <p>
                    <input class="buts" type="button" onclick="clickChecklogin()" id="btn" />
                </p>
                <div class="don" style="display: none"></div>
            </div>
        </div>
        <div class="copyright">
            2015  ESCBZ Group Co.,Ltd.  Copyright 易过户版权所有 沪ICP备15055538号-1
        </div>

    </form>

</body>
</html>

