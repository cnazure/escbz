$(function () {
    bindSelCarBrand();
    //如果编辑用户信息
    if (clientCarId != "") {
        //文本框        
        $.ajax({
            type: 'post',
            url: "/Ashx/Car/CarInfo.ashx?p=" + Math.random(),
            async: false,
            data: { CarId: clientCarId, mod: 'getModel' },
            success: function (Json) {
                var arr = Json.split('$');
                var CarInfo = eval('(' + arr[0].toString() + ')');
                $("#txtCarId").val(CarInfo.CarId),
                $("#txtCarVIN").val(CarInfo.CarVIN),
                $("#selCarBrand").val(CarInfo.CarModel.substr(0, CarInfo.CarModel.indexOf("|"))),
                $("#txtCarModel").val(CarInfo.CarModel.substr(CarInfo.CarModel.indexOf("|") + 1, CarInfo.CarModel.length)),
                $("#txtFirstOnCard").val(getLocalTime(CarInfo.FirstOnCard)),
                $("#AddDate").val(getLocalTime(CarInfo.AddDate)),
                $('input:radio[name=ImgType]')[CarInfo.ImgType - 1].checked = true;
                $("#imgImg1").attr("src", CarInfo.ImgUrl),
                $("#btnSub").val("编 辑");
            }
        });
    } else {
        $.ajax({
            type: 'post',
            url: "/ashx/Car/CarInfo.ashx?p=" + Math.random(),
            async: false,
            data: { mod: 'getCarInfoId' },
            success: function (Json) {
                var arr = Json.split('$');
                $("#txtCarId").val(arr);
            }
        });
    }

    //提交
    $("#btnSub").click(function () {

        //添加用户
        if (clientCarId == "") {
            $.ajax({
                type: 'post',
                url: "/ashx/Car/CarInfo.ashx?p=" + Math.random(),
                async: false,
                data: {
                    CarId: $("#txtCarId").val(),
                    CarVIN: $("#txtCarVIN").val(),
                    CarModel: $("#selCarBrand").val() + '|' + $("#txtCarModel").val(),
                    FirstOnCard: $("#txtFirstOnCard").val(),
                    ImgType: $('input:radio:checked').val(),
                    ImgUrl: $("#imgImg1").attr("src"),
                    mod: 'addCarInfo'
                },
                success: function (data) {
                    if (data == 1) {
                        alert("添加成功!");
                        window.location.href = "CarInfoList.aspx";
                    }
                    else if (data == -1) {
                        alert("错误的车辆编号");
                    }
                    else if (data == -2) {
                        alert("请输入车架号");
                    }
                    else if (data == -3) {
                        alert("请输入车辆品牌");
                    }
                    else if (data == -4) {
                        alert("请输入首次上牌日期");
                    }
                    else if (data == -5) {
                        alert("请选择照片类型");
                    }
                    else if (data == -6) {
                        alert("请上传图片信息");
                    }
                    else if (data == -7) {
                        alert("有重复的车架号");
                    }
                    else if (data == -8) {
                        alert("车架号需要大于6-8位");
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
                url: "/ashx/Car/CarInfo.ashx?p=" + Math.random(),
                async: false,
                data: {
                    CarId: $("#txtCarId").val(),
                    CarVIN: $("#txtCarVIN").val(),
                    CarModel: $("#selCarBrand").val() + '|' + $("#txtCarModel").val(),
                    FirstOnCard: $("#txtFirstOnCard").val(),
                    ImgType: $('input:radio:checked').val(),
                    ImgUrl: $("#imgImg1").attr("src"),
                    AddDate: $("#AddDate").val(),
                    mod: 'updateCarInfo'
                },
                success: function (data) {
                    if (data == 1) {
                        alert("编辑成功!");
                        window.location.href = "CarInfoList.aspx";
                    }
                    else if (data == -1) {
                        alert("错误的车辆编号");
                    }
                    else if (data == -2) {
                        alert("请输入车架号");
                    }
                    else if (data == -3) {
                        alert("请输入车辆品牌");
                    }
                    else if (data == -4) {
                        alert("请输入首次上牌日期");
                    }
                    else if (data == -5) {
                        alert("请选择照片类型");
                    }
                    else if (data == -6) {
                        alert("请上传图片信息");
                    }
                    else if (data == -7) {
                        alert("有重复的车架号");
                    }
                    else if (data == -8) {
                        alert("车架号需要大于6-8位");
                    }
                    else {
                        alert("编辑失败，请重新编辑信息");
                    }
                }
            })

        }
    })
})

//上传照片
function ajaxFileUpload(sender) {
    var id = $(sender).attr("id");
    $.ajaxFileUpload
    (
        {
            url: '/ashx/Common/UploadImageHandler.ashx', //用于文件上传的服务器端请求地址
            secureuri: false, //一般设置为false
            fileElementId: id, //文件上传空间的id属性  <input type="file" id="file" name="file" />
            dataType: 'json', //返回值类型 一般设置为json
            success: function (data, status)  //服务器成功响应处理函数
            {
                if (typeof (data.error) != 'undefined') {
                    if (data.error == 'ERROR') {
                        alert(data.msg);
                    }
                    else {
                        $("#img" + id.substr(3)).attr("src", data.msg);
                        //清空上传控件
                        var obj = document.getElementById(id);
                        //alert(obj.outerHTML);
                        obj.outerHTML = obj.outerHTML;
                    }
                }
            },
            error: function (data, status, e)//服务器响应失败处理函数
            {
                alert(e);
            }
        }
    )
    return false;
}

//绑定车辆品牌列表下拉框
function bindSelCarBrand() {
    $.ajax({
        type: 'post',
        url: "/ashx/Car/CarInfo.ashx?p=" + Math.random(),
        async: false,
        data: { mod: 'getCarBrand' },
        success: function (data) {
            JsonData = eval('(' + data.toString().replace(/\"/gi, "'") + ')');
            var sel = $("#selCarBrand");
            if (JsonData != "") {
                $.each(JsonData, function (index, item) {
                    $("<option value='" + item.brandName + "'>" + item.firstPY + "-" + item.brandName + "</option>").appendTo(sel);

                });
            }
        }
    })
}

function getLocalTime(nS) {
    var timestamp3 = nS.replace("/Date(", "").replace(")/", "");
    return formatDate(timestamp3);
}
function formatDate(now) {
    var mydate = new Date(parseInt(now));
    var today = '';
    today += mydate.getFullYear() + '-';   //返回年份
    today += mydate.getMonth() + 1 + '-';    //返回月份，因为返回值是0开始，表示1月，所以做+1处理
    today += mydate.getDate();	//返回日期    
    return today;
}


