$(function () {
    $("#txt_username").blur(function () {
        checkUserName();
    });
    $("#txt_mobile").blur(function () {
        checkMobile();
        checkIsUser();
    });
    $("#txt_km").blur(function () {
        checkKm();
    });
    $("#txt_buyYear").blur(function () {
        checkBuyYear();
    });

    if (userID == null || userID == "")
        $("#btnResetPwd").hide();
    else
        $("#btnResetPwd").show();
})

//提交
function checkAll() {
    if (checkIsUser() && checkUserName() && checkMobile() && checkKm() && checkBuyYear() & checkUserName()) {
        return true;
    }
    else {
        return false;
    }
}



//检查用户名是否存在
function checkIsUser() {
    var res = false;
    if (userID == null || userID == "") {
        var userAccount = $.trim($("#txt_mobile").val());
        $.ajax({
            type: 'post',
            url: "/ashx/User/addVip.ashx?p="+ Math.random(),
            async: false,
            data: { userAccount: userAccount, mod: 'checkUserAccount' },
            success: function (data) {
                if (data == 1) {
                    alert("该用户名已存在");
                    res = false;
                }
                else {
                    res = true;
                }
            }
        })
    }
    else {
        res = true;
    }

    return res;
}

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

//验证真实姓名
function checkUserName() {
    var res = false;
    if ($.trim($("#txt_trueName").val()).length == 0) {
        $("#spTrueName").show();
        $("#spTrueName").html("请输入真实姓名");
        res = false;
    }
    else if (/^([\u4e00-\u9fa5a-zA-Z]){2,20}$/.test($("#txt_username").val()) == false) {
        $("#spTrueName").show();
        $("#spTrueName").html("格式不正确,输入2-20个中英文字符");
    }
    else {
        $("#spTrueName").hide();
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

//验证公里数
function checkKm() {
    var ret = false;

    var Km = $("#txt_km").val();
    var exp = /^(([1-9]\d{0,9})|0)(\.\d{1,2})?$/;
    if (Km.length == 0) {
        ret = true;//非必填字段
    }
    else if (exp.test(Km) == false) {
        $("#sp_Km").show();
        $("#sp_Km").html("格式不正确");
    }
    else {
        ret = true;
        $("#sp_Km").hide();
    }

    return ret;
}

//验证年份
function checkBuyYear() {
    var ret = false;

    var BuyYear = $("#txt_buyYear").val();
    var exp = /^\d{4}$/;
    if (BuyYear.length == 0) {
        ret = true;//非必填字段
    }
    else if (exp.test(BuyYear) == false) {
        $("#sp_BuyYear").show();
        $("#sp_BuyYear").html("格式不正确,请输入四位整数");
    }
    else {
        ret = true;
        $("#sp_BuyYear").hide();
    }

    return ret;
}

//检查手机号是否存在
function checkMobileIsExist() {
    var res = false;
    if (userID == null || userID == "") {
        var mobile = $.trim($("#txt_mobile").val());
        $.ajax({
            type: 'post',
            url: "/ashx/User/addVip.ashx?p="+ Math.random(),
            async: false,
            data: { mobile: mobile, mod: 'checkMobileIsExist' },
            success: function (data) {
                if (data == 1) {
                    res = false;
                }
                else {
                    res = true;
                }
            }
        })
    }
    else {
        res = true;
    }
    return res;
}

function resetUserPwd() {
    if (confirm("确认要重置密码？"))
        return true;
    else
        return false;
}