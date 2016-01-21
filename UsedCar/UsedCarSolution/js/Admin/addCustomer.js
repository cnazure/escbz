$(function () {
    bindSelCustomer();
    //如果编辑用户信息
    if (clientCId != "") {
        //文本框        
        $.ajax({
            type: 'post',
            url: "/Ashx/User/Customer.ashx?p=" + Math.random(),
            async: false,
            data: { CId: clientCId, mod: 'getModel' },
            success: function (Json) {
                var arr = Json.split('$');
                var Customer = eval('(' + arr[0].toString() + ')');
                $("#txtCId").val(Customer.CId);
                $("#txtCustomerName").val(Customer.CName);
                $("#txtContacts").val(Customer.Contacts);
                $("#txtCustomerTel").val(Customer.CTel);
                $("#txtAddress").val(Customer.CAddress);
                $("#selUser").val(Customer.BelongUser);
                $("#btnSub").val("编 辑");
            }
        });
    } else {
        $.ajax({
            type: 'post',
            url: "/ashx/User/Customer.ashx?p=" + Math.random(),
            async: false,
            data: { mod: 'getCustomerLastId' },
            success: function (Json) {
                var arr = Json.split('$');
                $("#txtCId").val(arr);
            }
        });
    }

    //提交
    $("#btnSub").click(function () {

        //添加用户
        if (clientCId == "") {
            $.ajax({
                type: 'post',
                url: "/ashx/User/Customer.ashx?p="+ Math.random(),
                async: false,
                data: {
                    CId: $("#txtCId").val(),
                    CName: $("#txtCustomerName").val(),
                    Contacts: $("#txtContacts").val(),
                    CTel: $("#txtCustomerTel").val(),
                    CAddress: $("#txtAddress").val(),
                    BelongUser: $("#selUser").val(),
                    mod: 'addCustomer'
                },
                success: function (data) {
                    if (data == 1) {
                        alert("添加成功!");
                        window.location.href = "CustomerList.aspx";
                    }
                    else {
                        alert("添加失败，请重新添加信息");
                    }
                }
            })
        }
            //编辑用户
        else {
            $.ajax({
                type: 'post',
                url: "/ashx/User/Customer.ashx?p="+ Math.random(),
                async: false,
                data: {
                    CId: $("#txtCId").val(),
                    CName: $("#txtCustomerName").val(),
                    Contacts: $("#txtContacts").val(),
                    CTel: $("#txtCustomerTel").val(),
                    CAddress: $("#txtAddress").val(),
                    BelongUser: $("#selUser").val(),
                    mod: 'updateCustomer',
                    userID: clientCId
                },
                success: function (data) {
                    if (data > 0) {
                        alert("编辑成功!");
                        window.location.href = "CustomerList.aspx";
                    }
                    else {
                        alert("编辑失败，请重新编辑信息");
                    }
                }
            })
        }
    })
})


//验证用户姓名
function checkUserName() {
    var res = false;
    if ($.trim($("#txt_username").val()).length == 0) {
        $("#spUserName").show();
        $("#spUserName").html("请输入用户名");
        res = false;
    }
    else if (/^([\u4e00-\u9fa5a-zA-Z]){2,20}$/.test($("#txt_username").val()) == false) {
        $("#spUserName").show();
        $("#spUserName").html("格式不正确,输入2-20个中英文字符");
    }
    else {
        $("#spUserName").hide();
        res = true;
    }

    return res;
}

//验证手机号
function checkMobile() {
    var ret = false;

    var Mobile = $("#txt_mobile").val();
    var exp = /^\d{11}$/;
    if (Mobile.length == 0) {
        $("#spMobile").show();
        $("#spMobile").html("请输入手机号码");
    }
    else if (exp.test(Mobile) == false) {
        $("#spMobile").show();
        $("#spMobile").html("格式不正确");
    }
    else {
        if (checkMobileIsExist()) {
            ret = true;
            $("#spMobile").hide();
        }
        else {
            $("#spMobile").show();
            $("#spMobile").html("该手机号已存在");
        }
    }

    return ret;
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

//绑定角色列表下拉框
function bindSelCustomer() {
    $.ajax({
        type: 'post',
        url: "/ashx/User/updateCustomer.ashx?p="+ Math.random(),
        async: false,
        data: { mod: 'getData' },
        success: function (data) {
            JsonData = eval('(' + data.toString().replace(/\"/gi, "'") + ')');
            var sel = $("#selUser");
            if (JsonData != "") {
                $.each(JsonData, function (index, item) {
                    $("<option value='" + item.UserName + "'>" + item.UserName + "</option>").appendTo(sel);

                });
            }
        }
    })
}
