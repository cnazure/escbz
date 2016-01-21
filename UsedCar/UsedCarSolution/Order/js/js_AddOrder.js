//弹出预览窗口
$(function () {
    $('.yulan_btn').click(function () {
        $('#tan1').show();
        return false;
    });
    $('.closebtn').click(function () {
        $('#tan1').hide();
    });

});

//选择车辆
function selectCar(e, f) {
    if (e != null && e != "" && f != null && f != "") {
        $("#txtCarVIN").val(e);
        $("#hidCarId").val(f);
        $('#tan1').hide();
    }
};

function cancelOrder(id) {
    if (confirm("确定要删除订单吗？")) {
        alert(id);
        $.ajax({
            type: "post",
            url: "/Ashx/Order/OrderInfo.ashx?p=" + Math.random(),
            data: {
                mod: "DelOrder",
                ID: id
            },
            success: function (data) {
                if (data == "OK") {
                    alert("删除成功");
                    window.location.href = window.location.href;
                }
            }
        });
    }
}

//$(function () {
//    $.ajax({
//        type: 'post',
//        url: "/Ashx/Order/OrderInfo.ashx?p=" + Math.random(),
//        async: false,
//        data: { mod: 'getOrderId' },
//        success: function (Json) {
//            var arr = Json.split('$');
//            $("#LabId").html(arr + '');
//        }
//    });
//});