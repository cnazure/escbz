<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="UsedCarSolution.left" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>管理页面</title>
<link href="css/Share.css" rel="stylesheet" type="text/css" />
     <script src="js/jquery.js" type="text/javascript"></script> 
    <script src="js/Admin/Cookies.js" type="text/javascript"></script>

         <script type='text/javascript'>
             JQ = $;  //rename $ function
             $ = 'hi'; //将$赋无意义值

             JQ("#container0").append('a');
</script> 
<script type="text/javascript">
    function disp(n) {
        for (var i = 0; i < 2; i++) {
            if (!JQ("#container" + i)) {
                return;
            }
            else {
                JQ("#container" + i).attr("style", "display:none");
            }
        }
        JQ("#container" + n).attr("style", "display:block");

        if (n == 0) {
            JQ("#navs1").attr("class", "");
            JQ(".bodis").html("&nbsp;&nbsp;E-commerce platform");
        }
        if (n == 1) {
            JQ("#navs0").attr("class", "");
            JQ(".bodis").html("&nbsp;&nbsp;ServiceCenter Manager");
        }
        JQ("#navs" + n).attr("class", "on");
    }
</script>
 <script src="js/Admin/leftNavigation.js" type="text/javascript"></script>
<script src="js/prototype.lite.js" type="text/javascript"></script>
<script src="js/moo.fx.js" type="text/javascript"></script>
<script src="js/moo.fx.pack.js" type="text/javascript"></script>
<style>
#container {
	width: 182px;
}
h1 {
	font-size: 12px;
	margin: 0px;
	width: 182px;
	cursor: pointer;
	height: 30px;
	line-height: 20px;
}
h1 a:link {
	display: block;
	width: 182px;
	color: #000;
	height: 30px;
	text-decoration: none;
	moz-outline-style: none;
	background-image: url(images/menu_bgs.gif);
	background-repeat: no-repeat;
	line-height: 30px;
	text-align: center;
	margin: 0px;
	padding: 0px;
}
.content {
	width: 182px;
	height: 26px;
}
.mm ul {
	list-style-type: none;
	margin: 0px;
	padding: 0px;
	display: block;
}
.mm li {
	font-family: "宋体";
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	list-style-type: none;
	display: block;
	text-decoration: none;
	height: 26px;
	width: 182px;
	padding-left: 0px;
}
.mm {
	width: 182px;
	margin: 0px;
	padding: 0px;
	left: 0px;
	top: 0px;
	right: 0px;
	bottom: 0px;
	clip: rect(0px,0px,0px,0px);
}
.mm a:link {
	font-family: "宋体";
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	height: 26px;
	width: 182px;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	overflow: hidden;
	text-decoration: none;
}
.mm a:visited {
	font-family: "宋体";
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	height: 26px;
	width: 182px;
	text-decoration: none;
}
.mm a:active {
	font-family: "宋体";
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	height: 26px;
	width: 182px;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	overflow: hidden;
	text-decoration: none;
}
.mm a:hover {
	font-family: "宋体";
	font-size: 12px;
	line-height: 26px;
	font-weight: bold;
	color: #da251c;
	background-image: url(images/menu_bg2.gif);
	background-repeat: no-repeat;
	text-align: center;
	display: block;
	margin: 0px;
	padding: 0px;
	height: 26px;
	width: 182px;
	text-decoration: none;
}

.tab{
	width:182px;
	}
.tab ul.navs{
	height:30px;
	}
.tab ul.navs li{
	float:left;
	text-align:center;
	line-height:30px;
	}
.tab ul.navs li a{
	width:180px;
	height:30px;
	display:inline-block;
	background:url(images/nav_bg.gif) no-repeat;
	}
.tab ul.navs li.on a{
	background:url(images/nav_bg1.png) no-repeat;
	}
.bodis{
	margin-bottom:1px;
	height:30px;
	line-height:30px;
	text-indent:16px;
	border-left:1px solid #ccc;
	border-right:1px solid #ccc;
	background:url(images/nav_blck.png) bottom no-repeat;
	}	
</style>
</head>
<body>
<div class="tab">	
    <div class="bodis">
    易过户管理系统
    </div>
</div>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="">
          <tr>
            <td width="182" valign="top">

                <div id="container0">
 
   
                 </div>


                <script type="text/javascript">

                    function Starloding() {
                        var contents = document.getElementsByClassName('content');
                        var toggles = document.getElementsByClassName('type');

                        var myAccordion = new fx.Accordion(
                             toggles, contents, { opacity: true, duration: 400 }
		                );
                        myAccordion.showThisHideOpen(contents[0]);
                    }
                </script>
            </td>
        </tr>
  
</table>
  

</body>
</html>
