<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="UsedCarSolution.main" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>--管理系统</title>
    <link href="css/Share.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .sdik {
            padding: 0 2px;
            FONT-FAMILY: Webdings;
            height: 100%;
            width: 6px;
            border: 1px solid #ccc;
            background: #dedede;
            text-align: center;
        }

        html, body {
            overflow: auto;
        }
    </style>
    <script>


        function DvMenuCls() {
            var MenuHides = new Array();
            this.Show = function (obj, depth) {
                var childNode = this.GetChildNode(obj);
                if (!childNode) { return; }
                if (typeof (MenuHides[depth]) == "object") {
                    this.closediv(MenuHides[depth]);
                    MenuHides[depth] = '';
                };
                if (depth > 0) {
                    if (childNode.parentNode.offsetWidth > 0) {
                        childNode.style.left = childNode.parentNode.offsetWidth + 'px';

                    } else {
                        childNode.style.left = '100px';
                    };

                    childNode.style.top = '-2px';
                };
                childNode.style.display = 'block';
                MenuHides[depth] = childNode;

            };
            this.closediv = function (obj) {
                if (typeof (obj) == "object") {
                    if (obj.style.display != 'none') {
                        obj.style.display = 'none';
                    }
                }
            }
            this.Hide = function (depth) {
                var i = 0;
                if (depth > 0) {
                    i = depth
                };
                while (MenuHides[i] != null && MenuHides[i] != '') {
                    this.closediv(MenuHides[i]);
                    MenuHides[i] = '';
                    i++;
                };

            };
            this.Clear = function () {
                for (var i = 0; i < MenuHides.length; i++) {
                    if (MenuHides[i] != null && MenuHides[i] != '') {
                        MenuHides[i].style.display = 'none';
                        MenuHides[i] = '';
                    }
                }
            }
            this.GetChildNode = function (submenu) {
                for (var i = 0; i < submenu.childNodes.length; i++) {
                    if (submenu.childNodes[i].nodeName.toLowerCase() == "div") {
                        var obj = submenu.childNodes[i];
                        break;
                    }
                }
                return obj;
            }

        }



        var status = 1;
        var Menus = new DvMenuCls;
        document.onclick = Menus.Clear;
        function switchSysBar() {
            if (1 == window.status) {
                window.status = 0;
                switchPoint.innerHTML = '<img src="images/main_55_1.gif">';
                document.all("frmTitle").style.display = "none"
            }
            else {
                window.status = 1;
                switchPoint.innerHTML = '<img src="images/main_55.gif";>';
                document.all("frmTitle").style.display = ""
            }
        }
    </script>
</head>
<body>
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="90" colspan="3">
                <iframe src="top.aspx" width="100%" height="100%" frameborder="0"></iframe>
            </td>
        </tr>
        <tr>
            <td height="100%" width="182" valign="top" bgcolor="#f5f5f5" id="frmTitle">
                <iframe src="left.aspx" width="100%" id="frmleft" name="frmleft" height="100%" frameborder="0"></iframe>
            </td>
            <td height="100%" width="6" valign="middle" onclick="switchSysBar()" class="sdik"><span title="关闭/打开左栏" id="switchPoint" class="navPoint">
                <img width="6" height="40" id="img1" name="img1" src="images/main_55.gif">
            </span></td>
            <td height="100%" valign="top">
                <iframe src="tab.aspx" name="main" width="100%" height="100%" frameborder="0"></iframe>
            </td>
        </tr>
    </table>

</body>
</html>
