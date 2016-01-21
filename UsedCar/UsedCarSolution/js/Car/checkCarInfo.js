$(function () {
    $("#txt_carmodelName").blur(function () {
        checkModelName();
    });
    $("#txtPrice").blur(function () {
        checkPrice();
    });
    $("#txtMaxPower").blur(function () {
        checkMaxPower();
    });
    $("#txtMaxSpeed").blur(function () {
        checkMaxSpeed();
    });
    $("#txtMaxTorsion").blur(function () {
        checkMaxTorsion();
    });
    $("#txtWheelBase").blur(function () {
        checkWheelBase();
    });
    $("#txtSize").blur(function () {
        checkSize();
    });
    $("#txtOilConsump").blur(function () {
        checkOilConsump();
    });
})

function checkall() {
    var ret = false;
    if (checkModelName() && checkPrice() && checkMaxPower() && checkMaxSpeed() && checkMaxTorsion() && checkWheelBase() && checkSize() && checkOilConsump()) {
        ret = true;
    }
    return ret;
}

function checkModelName() {
    var ret = false;

    if ($("#txt_carmodelName").val() == "")
    {
        $("#spcarmodelName").show();
        $("#spcarmodelName").html("车型不能为空");
    }
    else {
        ret = true;
        $("#spcarmodelName").hide();
    }

    return ret;
}

function checkPrice() {
    var ret = false;

    var price = $("#txtPrice").val();
    var exp = /^(([1-9]\d{0,9})|0)(\.\d{1,2})?$/;
    if (price.length == 0) {
        $("#spPrice").show();
        $("#spPrice").html("请输入官方价");
    }
    else if (exp.test(price) == false) {
        $("#spPrice").show();
        $("#spPrice").html("格式不正确");
    }
    else {
        ret = true;
        $("#spPrice").hide();
    }

    return ret;
}

function checkMaxPower() {
    var ret = false;

    var MaxPower = $("#txtMaxPower").val();
    var exp = /^(([1-9]\d{0,3})(\.\d{1,2})?)|-$/;;
    if (MaxPower.length == 0) {
        $("#spMaxPower").show();
        $("#spMaxPower").html("请输入最大马力");
    }
    else if (exp.test(MaxPower) == false) {
        $("#spMaxPower").show();
        $("#spMaxPower").html("格式不正确");
    }
    else {
        ret = true;
        $("#spMaxPower").hide();
    }

    return ret;
}

function checkMaxSpeed() {
    var ret = false;

    var MaxSpeed = $("#txtMaxSpeed").val();
    var exp = /^(([1-9]\d{0,3})(\.\d{1,2})?)|-$/;
    if (MaxSpeed.length == 0) {
        $("#spMaxSpeed").show();
        $("#spMaxSpeed").html("请输入最高速度");
    }
    else if (exp.test(MaxSpeed) == false) {
        $("#spMaxSpeed").show();
        $("#spMaxSpeed").html("格式不正确");
    }
    else {
        ret = true;
        $("#spMaxSpeed").hide();
    }

    return ret;
}

function checkMaxTorsion() {
    var ret = false;

    var MaxTorsion = $("#txtMaxTorsion").val();
    var exp = /^(([1-9]\d{0,3})(\.\d{1,2})?)|-$/;
    if (MaxTorsion.length == 0) {
        $("#spMaxTorsion").show();
        $("#spMaxTorsion").html("请输入最大扭矩");
    }
    else if (exp.test(MaxTorsion) == false) {
        $("#spMaxTorsion").show();
        $("#spMaxTorsion").html("格式不正确");
    }
    else {
        ret = true;
        $("#spMaxTorsion").hide();
    }

    return ret;
}

function checkWheelBase() {
    var ret = false;

    var WheelBase = $("#txtWheelBase").val();
    var exp = /^(([1-9]\d{0,3})(\.\d{1,2})?)|-$/;
    if (WheelBase.length == 0) {
        $("#spWheelBase").show();
        $("#spWheelBase").html("请输入车身轴距");
    }
    else if (exp.test(WheelBase) == false) {
        $("#spWheelBase").show();
        $("#spWheelBase").html("格式不正确");
    }
    else {
        ret = true;
        $("#spWheelBase").hide();
    }

    return ret;
}

function checkSize() {
    var ret = false;

    var Size = $("#txtSize").val();
    var exp = /^(([1-9]\d{0,3})x([1-9]\d{0,3})x([1-9]\d{0,3}))|-$/;
    if (Size.length == 0) {
        $("#spSize").show();
        $("#spSize").html("请输入车身尺寸");
    }
    else if (exp.test(Size) == false) {
        $("#spSize").show();
        $("#spSize").html("格式不正确，格式为：长x宽x高");
    }
    else {
        ret = true;
        $("#spSize").hide();
    }

    return ret;
}

function checkOilConsump() {
    var ret = false;

    var OilConsump = $("#txtOilConsump").val();
    var exp = /^((([1-9]\d{0,9})|0)(\.\d{1,2})?)|-$/;
    if (OilConsump.length == 0) {
        $("#spOilConsump").show();
        $("#spOilConsump").html("请输入综合油耗");
    }
    else if (exp.test(OilConsump) == false) {
        $("#spOilConsump").show();
        $("#spOilConsump").html("格式不正确");
    }
    else {
        ret = true;
        $("#spOilConsump").hide();
    }

    return ret;
}