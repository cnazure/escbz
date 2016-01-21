<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentsAddorEdit.aspx.cs" Inherits="UsedCarSolution.User.AgentsAddorEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/css/table.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/jqmain.js"></script>    
    <script type="text/javascript">
        var clientAid = "";
        $(function () {
            clientAid = '<%=Aid%>';
        })
    </script>    
    <script type="text/javascript" src="/js/Admin/addAgents.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">客户管理</span>—<span class="ce2">编辑-添加代理人</span>
            </div>
            <div class="fanhui">
                <a href="javascript:void(0)"></a>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <!--弹出 增加信息----------->
            <div class="tjxx_cont">
                <a href="javascript:void(0)" class="closebtn"></a>
                <div class="tp">
                </div>
                <div class="searchcont">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_search">
                        <tr>
                            <th>代办人编号：</th>
                            <td>
                                <input id="txtAid" readonly="readonly" type="text" maxlength="10" />
                            </td>
                        </tr>
                        <tr>
                            <th>代办人姓名：
                            </th>
                            <td>
                                <input id="txtAgentsName" type="text" maxlength="10" />&nbsp&nbsp&nbsp&nbsp<span id="spAgentsName" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>代办人电话：
                            </th>
                            <td>
                                <input id="txtAgentsTel" type="text" maxlength="11" />&nbsp&nbsp&nbsp&nbsp
                           <span id="spPsw1" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <span>
                    <input type="button" id="btnSub" class="btn_ok_big" value="新 增" />
                    <input id="btnBack" class="btn_white_big" type="button" value="返 回" onclick="window.location.href = 'AgentsList.aspx'" />
                </span>
            </div>
            <!--弹出 增加信息_end----------->
        </div>
        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">添加修改代办人基本信息与联系方式</p>
        </div>
    </form>
</body>
</html>
