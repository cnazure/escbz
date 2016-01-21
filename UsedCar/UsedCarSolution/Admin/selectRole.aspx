<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectRole.aspx.cs" Inherits="UsedCarSolution.Admin.selectRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/Share.css" rel="stylesheet" type="text/css" />
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../css/table.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jqmain.js"></script>
    <script src="/js/Admin/delRole.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.btn_tjxx').click(function () {
                window.location = "/Admin/addRole.aspx";
                return false;
            });
        })

        function show(id, RoleName) {
            //--弹出 修改信息--//
            $("#hidRoleId").val(id);
            $("#iptRoleName").val(RoleName);
            $('.xgxx_cont').show();
            $("#iptRoleName").attr("disabled", "");
            return false;
        }
        $(function () {
            $('.closebtn').click(function () {
                $('.xgxx_cont').hide();
            });
            $('.btn_white_big').click(function () {
                $('.xgxx_cont').hide();
            });

            $('.btn_ok_big').click(function () {
                var id = $("#hidRoleId").val();
                var name = $("#iptRoleName").val();

                if ($.trim(name).length == 0) {
                    alert('请输入角色名称');
                    return;
                }
                $.ajax({
                    type: "post",
                    url: "/ashx/Admin/updateRole.ashx",
                    data: { roleId: id, roleName: name, mod: "update", t: Math.random() },
                    success: function (result) {
                        if (result > 0) {
                            window.location = "/Admin/selectRole.aspx";
                        } else {
                            alert("更新失败");
                        }
                    }
                })


            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">角色管理</span>—<span class="ce2">查看角色</span>
            </div>
            <div class="fanhui">
                <a href="#"></a>
            </div>
        </div>
        <div class="mg_lrtb table_list">
            <input class="btn_add_big1 btn_tjxx" type="button" value="添加角色" onclick="window.location = 'addRole.aspx';" />
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_1 mg_top">
                <tr>
                    <th>序号
                    </th>
                    <th>角色名称
                    </th>
                    <th>添加日期
                    </th>
                    <th colspan="2">操作
                    </th>
                </tr>
                <asp:Repeater ID="rpRoleList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("RoleID")%> 
                            </td>
                            <td>
                                <%#Eval("RoleName")%> 
                            </td>
                            <td>
                                <%#Eval("RoleCreateTime")%> 
                            </td>
                            <td>
                                <a class="bianji_btn" href="javascript:void(0)" onclick="show('<%#Eval("RoleID")%>','<%#Eval("RoleName")%>')">编辑</a>
                            </td>
                            <td>
                                <a class="shanchu_btn" href="javascript:void(0)" onclick="javascript:DelRole(<%#Eval("RoleID") %>)">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <input type="hidden" id="hidRoleId" value="" />
        </div>


        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">查看角色是查看操作后台的角色信息</p>
        </div>
        <!--弹出 修改信息----------->
        <div class="layer_blue xgxx_cont">
            <a href="#" class="closebtn"></a>
            <div class="tp">修改角色名称</div>
            <div class="bd">
                <div class="searchcont">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_search">
                        <tr>
                            <th>角色名称：</th>
                            <td>
                                <input type="text" size="30" id="iptRoleName" /></td>
                        </tr>
                    </table>
                </div>
                <div class="mg_top">
                    <input class="btn_ok_big" type="button" value="确　认" />
                    <input class="btn_white_big" type="button" value="取　消" />
                </div>
            </div>
        </div>
        <!--弹出 修改信息_end----------->
    </form>
</body>
</html>
