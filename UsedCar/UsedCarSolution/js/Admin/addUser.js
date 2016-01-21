
$(function () {
    bindSelRole();
    //如果编辑用户信息
    if (clientUserID != "") {
        //文本框
        $("#txtUserName").attr('disabled', true);
        //获取该用户信息
        $.ajax({
            type: 'post',
            url: "/ashx/Admin/userOperate.ashx?p=" + Math.random(),
            async: false,
            data: { userID: clientUserID, mod: 'getModel' },
            success: function (Json) {
                var arr = Json.split('$');
                $("#selRole").val(arr[0]);
                //changeSelRole();
                var user = eval('(' + arr[1].toString() + ')');
                $("#txtUserName").val(user.UserName);
                $("#txtPsw1").val(user.UserPass);
                $("#txtPsw2").val(user.UserPass);
                $("#txtPhone").val(user.Phone);
                $("#txtAddress").val(user.Address);
                $("#txtTrueName").val(user.TrueName);                
                if (user.Sex == '男')
                    $("input[name='sex'][value=1]").attr("checked", true);
                else
                    $("input[name='sex'][value=0]").attr("checked", true);
            }
        });
    }


    function checkUserName() {
        var res = false;
        if ($.trim($("#txtUserName").val()).length == 0) {
            $("#spUserName").show();
            $("#spUserName").html("请输入用户名");
            res = false;
        }
        else if (clientUserID == "")
        {
            var userName = $.trim($("#txtUserName").val());
            $.ajax({
                type: 'post',
                url: "/ashx/Admin/userOperate.ashx?p="+ Math.random(),
                async: false,
                data: { userName: userName, mod: 'checkUserName' },
                success: function (data) {
                    if (data == 1) {
                        $("#spUserName").show();
                        $("#spUserName").html("该用户名已存在")
                        res = false;
                    }
                    else {
                        $("#spUserName").hide();
                        res = true;
                    }
                }
            })
        }
        else {
            $("#spUserName").hide();
            res = true;
        }
        return res;
    }

    //检查用户名是否存在
    function checkIsUser() {
        var res = false;
        var userName = $.trim($("#txtUserName").val());
        $.ajax({
            type: 'post',
            url: "/ashx/Admin/userOperate.ashx?p="+ Math.random(),
            async: false,
            data: { userName: userName, mod: 'checkUserName' },
            success: function (data) {
                if (data == 1) {
                    $("#spUserName").show();
                    $("#spUserName").html("该用户名已存在")
                    res = false;
                }
                else {
                    $("#spUserName").hide();
                    res = true;
                }
            }
        })
        return res;
    }

    //提交
    $("#btnSub").click(function () {
        if (checkAddress() & checkRole() & checkTrueName() & checkPad() & checkUserName()) {
            //添加用户
            if (clientUserID == "") {
                $.ajax({
                    type: 'post',
                    url: "/ashx/Admin/userOperate.ashx?p="+ Math.random(),
                    async: false,
                    data: {
                        userName: $("#txtUserName").val(),
                        password: $("#txtPsw1").val(),
                        Phone: $("#txtPhone").val(),
                        Address: $("#txtAddress").val(),
                        TrueName: $("#txtTrueName").val(),
                        sex: $('input[name="sex"]:checked').val(),
                        roleID: $("#selRole").val(),
                        mod: 'addUser'
                    },
                    success: function (data) {
                        if (data == 1) {
                            alert("添加成功!");
                            window.location.href = "userList.aspx";
                        }
                        else {
                            alert("problem");
                        }
                    }
                })
            }
                //编辑用户
            else {
                $.ajax({
                    type: 'post',
                    url: "/ashx/Admin/userOperate.ashx?p="+ Math.random(),
                    async: false,
                    data: {
                        userName: $("#txtUserName").val(),
                        password: $("#txtPsw1").val(),
                        Phone: $("#txtPhone").val(),
                        Address: $("#txtAddress").val(),
                        TrueName: $("#txtTrueName").val(),
                        sex: $('input[name="sex"]:checked').val(),
                        roleID: $("#selRole").val(),
                        mod: 'updateUser',
                        userID: clientUserID
                    },
                    success: function (data) {
                        if (data > 0) {
                            alert("编辑成功!");
                        }
                        else {
                            alert("problem");
                        }
                    }
                })
            }
        }
        else {
            return;
        }
    })
})


//验证角色
function checkRole() {
    if ($("#selRole").val() == "0") {
        $("#spCharacter").show();
        return false;
    }
    else {
        $("#spCharacter").hide();
        return true;
    }
}

//验证地址
function checkAddress() {
    if ($.trim($("#txtAddress").val()).length == 0) {
        $("#spAddress").show();
        return false;
    }
    else {
        $("#spAddress").hide();
        return true;
    }
}

//验证真实姓名
function checkTrueName() {
    if ($.trim($("#txtTrueName").val()).length == 0) {
        $("#spTrueName").show();
        return false;
    }
    else {
        $("#spTrueName").hide();
        return true;
    }
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


//绑定角色列表下拉框
function bindSelRole() {
    $.ajax({
        type: 'post',
        url: "/ashx/Admin/updateRole.ashx?p="+ Math.random(),
        async: false,
        data: { mod: 'getData' },
        success: function (data) {
            JsonData = eval('(' + data.toString().replace(/\"/gi, "'") + ')');
            var sel = $("#selRole");
            if (JsonData != "") {
                $.each(JsonData, function (index, item) {
                    $("<option value='" + item.RoleID + "'>" + item.RoleName + "</option>").appendTo(sel);

                });
            }
        }
    })
}
