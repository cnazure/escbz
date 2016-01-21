//遍历外观未修复的总数
function isOuterBad() {
    var badCount = 0;
    $('input[id^="rblOuter_"][id$="2"]').each(function () {
        //alert($(this).is(":checked"));
        if ($(this).is(":checked"))
            badCount++;
    });
    $('#txtUsage_RepairOuter_Count').val(badCount);    
}


$(function () {
    //如果是事故车，则显示上传照片和描述
    showDesc('IsIncident', 'True');
    $('input[name="rblIsIncident"]').change(function () {
        showDesc('IsIncident', 'True');
    });

    //外观
    hideDesc('Outer_isOK_Top_Head', '1');
    $('input[name="rblOuter_isOK_Top_Head"]').change(function () {
        hideDesc('Outer_isOK_Top_Head', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Top_Center', '1');
    $('input[name="rblOuter_isOK_Top_Center"]').change(function () {
        hideDesc('Outer_isOK_Top_Center', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Top_Rear', '1');
    $('input[name="rblOuter_isOK_Top_Rear"]').change(function () {
        hideDesc('Outer_isOK_Top_Rear', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Right_Head', '1');
    $('input[name="rblOuter_isOK_Right_Head"]').change(function () {
        hideDesc('Outer_isOK_Right_Head', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Right_Door_Head', '1');
    $('input[name="rblOuter_isOK_Right_Door_Head"]').change(function () {
        hideDesc('Outer_isOK_Right_Door_Head', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Right_Door_Rear', '1');
    $('input[name="rblOuter_isOK_Right_Door_Rear"]').change(function () {
        hideDesc('Outer_isOK_Right_Door_Rear', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Right_Rear', '1');
    $('input[name="rblOuter_isOK_Right_Rear"]').change(function () {
        hideDesc('Outer_isOK_Right_Rear', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Right_Bottom', '1');
    $('input[name="rblOuter_isOK_Right_Bottom"]').change(function () {
        hideDesc('Outer_isOK_Right_Bottom', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOk_Right_Wheel_Head', '1');
    $('input[name="rblOuter_isOk_Right_Wheel_Head"]').change(function () {
        hideDesc('Outer_isOk_Right_Wheel_Head', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOk_Right_Wheel_Rear', '1');
    $('input[name="rblOuter_isOk_Right_Wheel_Rear"]').change(function () {
        hideDesc('Outer_isOk_Right_Wheel_Rear', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Left_Head', '1');
    $('input[name="rblOuter_isOK_Left_Head"]').change(function () {
        hideDesc('Outer_isOK_Left_Head', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Left_Door_Head', '1');
    $('input[name="rblOuter_isOK_Left_Door_Head"]').change(function () {
        hideDesc('Outer_isOK_Left_Door_Head', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Left_Door_Rear', '1');
    $('input[name="rblOuter_isOK_Left_Door_Rear"]').change(function () {
        hideDesc('Outer_isOK_Left_Door_Rear', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Left_Rear', '1');
    $('input[name="rblOuter_isOK_Left_Rear"]').change(function () {
        hideDesc('Outer_isOK_Left_Rear', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Left_Bottom', '1');
    $('input[name="rblOuter_isOK_Left_Bottom"]').change(function () {
        hideDesc('Outer_isOK_Left_Bottom', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOk_Left_Wheel_Head', '1');
    $('input[name="rblOuter_isOk_Left_Wheel_Head"]').change(function () {
        hideDesc('Outer_isOk_Left_Wheel_Head', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOk_Left_Wheel_Rear', '1');
    $('input[name="rblOuter_isOk_Left_Wheel_Rear"]').change(function () {
        hideDesc('Outer_isOk_Left_Wheel_Rear', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Head_Right', '1');
    $('input[name="rblOuter_isOK_Head_Right"]').change(function () {
        hideDesc('Outer_isOK_Head_Right', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Head_Center', '1');
    $('input[name="rblOuter_isOK_Head_Center"]').change(function () {
        hideDesc('Outer_isOK_Head_Center', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Head_Left', '1');
    $('input[name="rblOuter_isOK_Head_Left"]').change(function () {
        hideDesc('Outer_isOK_Head_Left', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Rear_Right', '1');
    $('input[name="rblOuter_isOK_Rear_Right"]').change(function () {
        hideDesc('Outer_isOK_Rear_Right', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Rear_Center', '1');
    $('input[name="rblOuter_isOK_Rear_Center"]').change(function () {
        hideDesc('Outer_isOK_Rear_Center', '1');
        isOuterBad();
    });
    hideDesc('Outer_isOK_Rear_Left', '1');
    $('input[name="rblOuter_isOK_Rear_Left"]').change(function () {
        hideDesc('Outer_isOK_Rear_Left', '1');
        isOuterBad();
    });

    //内饰
    showDesc('Inner_isOK_GlassButton', 'False');
    $('input[name="rblInner_isOK_GlassButton"]').change(function () {
        showDesc('Inner_isOK_GlassButton', 'False');
    });
    showDesc('Inner_isOK_Bottom_Head', 'False');
    $('input[name="rblInner_isOK_Bottom_Head"]').change(function () {
        showDesc('Inner_isOK_Bottom_Head', 'False');
    });

    showDesc('Inner_isOK_Bottom_Rear', '2');
    $('input[name="rblInner_isOK_Bottom_Rear"]').change(function () {
        showDesc('Inner_isOK_Bottom_Rear', '2');
    });
    showDesc('Inner_isOK_Shift', 'False');
    $('input[name="rblInner_isOK_Shift"]').change(function () {
        showDesc('Inner_isOK_Shift', 'False');
    });
    showDesc('Inner_isOK_Air', 'False');
    $('input[name="rblInner_isOK_Air"]').change(function () {
        showDesc('Inner_isOK_Air', 'False');
    });
    showDesc('Inner_isOK_DoorOpen', 'False');
    $('input[name="rblInner_isOK_DoorOpen"]').change(function () {
        showDesc('Inner_isOK_DoorOpen', 'False');
    });

    showDesc('Inner_isOK_Air_Rear', '2');
    $('input[name="rblInner_isOK_Air_Rear"]').change(function () {
        showDesc('Inner_isOK_Air_Rear', '2');
    });
    showDesc('Inner_isOK_DoorOpen_Rear', '2');
    $('input[name="rblInner_isOK_DoorOpen_Rear"]').change(function () {
        showDesc('Inner_isOK_DoorOpen_Rear', '2');
    });
    showDesc('Inner_isOK_Seat_Driver', 'False');
    $('input[name="rblInner_isOK_Seat_Driver"]').change(function () {
        showDesc('Inner_isOK_Seat_Driver', 'False');
    });
    showDesc('Inner_isOK_Seat_Side', 'False');
    $('input[name="rblInner_isOK_Seat_Side"]').change(function () {
        showDesc('Inner_isOK_Seat_Side', 'False');
    });

    showDesc('Inner_isOK_Seat_Rear', '2');
    $('input[name="rblInner_isOK_Seat_Rear"]').change(function () {
        showDesc('Inner_isOK_Seat_Rear', '2');
    });
    showDesc('Inner_isOK_Safe', '2');
    $('input[name="rblInner_isOK_Safe"]').change(function () {
        showDesc('Inner_isOK_Safe', '2');
    });
    showDesc('Inner_isOK_Top', 'False');
    $('input[name="rblInner_isOK_Top"]').change(function () {
        showDesc('Inner_isOK_Top', 'False');
    });
    showDesc('Inner_isOk_Display', 'False');
    $('input[name="rblInner_isOk_Display"]').change(function () {
        showDesc('Inner_isOk_Display', 'False');
    });
    showDesc('Inner_isOk_Dashboard', 'False');
    $('input[name="rblInner_isOk_Dashboard"]').change(function () {
        showDesc('Inner_isOk_Dashboard', 'False');
    });
    showDesc('Inner_isOK_Turner', 'False');
    $('input[name="rblInner_isOK_Turner"]').change(function () {
        showDesc('Inner_isOK_Turner', 'False');
    });
    showDesc('Inner_isOK_CenterControl', 'False');
    $('input[name="rblInner_isOK_CenterControl"]').change(function () {
        showDesc('Inner_isOK_CenterControl', 'False');
    });
    showDesc('Inner_isOK_Storage', 'False');
    $('input[name="rblInner_isOK_Storage"]').change(function () {
        showDesc('Inner_isOK_Storage', 'False');
    });
    showDesc('Inner_hasAddition', 'True');
    $('input[name="rblInner_hasAddition"]').change(function () {
        showDesc('Inner_hasAddition', 'True');
    });

    //电子设备
    showDesc('Electric_isOK_Start', '2');
    $('input[name="rblElectric_isOK_Start"]').change(function () {
        showDesc('Electric_isOK_Start', '2');
    });
    showDesc('Electric_isOK_Light_Dashboard', '2');
    $('input[name="rblElectric_isOK_Light_Dashboard"]').change(function () {
        showDesc('Electric_isOK_Light_Dashboard', '2');
    });
    showDesc('Electric_isOK_DriverInfo', '2');
    $('input[name="rblElectric_isOK_DriverInfo"]').change(function () {
        showDesc('Electric_isOK_DriverInfo', '2');
    });
    showDesc('Electric_isOK_TurnLight', '2');
    $('input[name="rblElectric_isOK_TurnLight"]').change(function () {
        showDesc('Electric_isOK_TurnLight', '2');
    });
    showDesc('Electric_isOK_Radio', '2');
    $('input[name="rblElectric_isOK_Radio"]').change(function () {
        showDesc('Electric_isOK_Radio', '2');
    });
    showDesc('Electric_isOK_LightControl', '2');
    $('input[name="rblElectric_isOK_LightControl"]').change(function () {
        showDesc('Electric_isOK_LightControl', '2');
    });
    showDesc('Electric_isOK_Media', '2');
    $('input[name="rblElectric_isOK_Media"]').change(function () {
        showDesc('Electric_isOK_Media', '2');
    });
    showDesc('Electric_isOK_Mirror', '2');
    $('input[name="rblElectric_isOK_Mirror"]').change(function () {
        showDesc('Electric_isOK_Mirror', '2');
    });
    showDesc('Electric_isOK_SeatControl', '2');
    $('input[name="rblElectric_isOK_SeatControl"]').change(function () {
        showDesc('Electric_isOK_SeatControl', '2');
    });
    showDesc('Electric_isOK_SeatHeat', '2');
    $('input[name="rblElectric_isOK_SeatHeat"]').change(function () {
        showDesc('Electric_isOK_SeatHeat', '2');
    });
    showDesc('Electric_isOK_Air', '2');
    $('input[name="rblElectric_isOK_Air"]').change(function () {
        showDesc('Electric_isOK_Air', '2');
    });
    showDesc('Electric_isOK_Glass', '2');
    $('input[name="rblElectric_isOK_Glass"]').change(function () {
        showDesc('Electric_isOK_Glass', '2');
    });
    showDesc('Electric_isOK_Rainbrush', '2');
    $('input[name="rblElectric_isOK_Rainbrush"]').change(function () {
        showDesc('Electric_isOK_Rainbrush', '2');
    });
    showDesc('Electric_isOK_CenterControl', '2');
    $('input[name="rblElectric_isOK_CenterControl"]').change(function () {
        showDesc('Electric_isOK_CenterControl', '2');
    });
    showDesc('Electric_isOK_Navi', '2');
    $('input[name="rblElectric_isOK_Navi"]').change(function () {
        showDesc('Electric_isOK_Navi', '2');
    });
    showDesc('Electric_isOK_Speed', '2');
    $('input[name="rblElectric_isOK_Speed"]').change(function () {
        showDesc('Electric_isOK_Speed', '2');
    });
    showDesc('Electric_isOK_Stable', '2');
    $('input[name="rblElectric_isOK_Stable"]').change(function () {
        showDesc('Electric_isOK_Stable', '2');
    });
    showDesc('Electric_isOK_Key', '2');
    $('input[name="rblElectric_isOK_Key"]').change(function () {
        showDesc('Electric_isOK_Key', '2');
    });
    showDesc('Electric_isOK_Turner', '2');
    $('input[name="rblElectric_isOK_Turner"]').change(function () {
        showDesc('Electric_isOK_Turner', '2');
    });
    showDesc('Electric_isOK_Radar', '2');
    $('input[name="rblElectric_isOK_Radar"]').change(function () {
        showDesc('Electric_isOK_Radar', '2');
    });
    showDesc('Electric_isOK_Convertible', '2');
    $('input[name="rblElectric_isOK_Convertible"]').change(function () {
        showDesc('Electric_isOK_Convertible', '2');
    });
    showDesc('Electric_isOK_Raisehead', '2');
    $('input[name="rblElectric_isOK_Raisehead"]').change(function () {
        showDesc('Electric_isOK_Raisehead', '2');
    });
    showDesc('Electric_isOK_Entertainment', '2');
    $('input[name="rblElectric_isOK_Entertainment"]').change(function () {
        showDesc('Electric_isOK_Entertainment', '2');
    });
    showDesc('Electric_isOK_SuckDoor', '2');
    $('input[name="rblElectric_isOK_SuckDoor"]').change(function () {
        showDesc('Electric_isOK_SuckDoor', '2');
    });

    //路试
    showDesc('Test_isOK_Start', 'False');
    $('input[name="rblTest_isOK_Start"]').change(function () {
        showDesc('Test_isOK_Start', 'False');
    });
    showDesc('Test_isOK_Idle', 'False');
    $('input[name="rblTest_isOK_Idle"]').change(function () {
        showDesc('Test_isOK_Idle', 'False');
    });
    showDesc('Test_isOK_Accelerate', 'False');
    $('input[name="rblTest_isOK_Accelerate"]').change(function () {
        showDesc('Test_isOK_Accelerate', 'False');
    });
    showDesc('Test_isOK_Brake', 'False');
    $('input[name="rblTest_isOK_Brake"]').change(function () {
        showDesc('Test_isOK_Brake', 'False');
    });
    showDesc('Test_isOK_Turn', 'False');
    $('input[name="rblTest_isOK_Turn"]').change(function () {
        showDesc('Test_isOK_Turn', 'False');
    });
    showDesc('Test_isOK_Sound', 'False');
    $('input[name="rblTest_isOK_Sound"]').change(function () {
        showDesc('Test_isOK_Sound', 'False');
    });
    showDesc('Test_isOK_Shift', 'False');
    $('input[name="rblTest_isOK_Shift"]').change(function () {
        showDesc('Test_isOK_Shift', 'False');
    });
    showDesc('Test_isOK_TransMission', 'False');
    $('input[name="rblTest_isOK_TransMission"]').change(function () {
        showDesc('Test_isOK_TransMission', 'False');
    });
    showDesc('Test_isOK_Smooth', 'False');
    $('input[name="rblTest_isOK_Smooth"]').change(function () {
        showDesc('Test_isOK_Smooth', 'False');
    });
    showDesc('Test_isOK_Straight', 'False');
    $('input[name="rblTest_isOK_Straight"]').change(function () {
        showDesc('Test_isOK_Straight', 'False');
    });
    showDesc('Test_isOK_Homing', 'False');
    $('input[name="rblTest_isOK_Homing"]').change(function () {
        showDesc('Test_isOK_Homing', 'False');
    });
    showDesc('Test_isOK_Dashboard', 'False');
    $('input[name="rblTest_isOK_Dashboard"]').change(function () {
        showDesc('Test_isOK_Dashboard', 'False');
    });
    showDesc('Test_isOK_DriverInfo', 'False');
    $('input[name="rblTest_isOK_DriverInfo"]').change(function () {
        showDesc('Test_isOK_DriverInfo', 'False');
    });
    //手动\自动拍档
    showDesc('Test_isOK_Manual', '0');
    $('input[name="rblTest_isOK_Manual"]').change(function () {
        showDesc('Test_isOK_Manual', '0');
        //选择"自动"
        if ($('input[name="rblTest_isOK_Manual"]:checked').val() != "0") {
            $('input[name="rblTest_isOK_Manual_Shift_Change"]').eq(0).attr("checked", true);
            showDesc('Test_isOK_Manual_Shift_Change', 'False');
            $('input[name="rblTest_isOK_Manual_Shift_Clear"]').eq(0).attr("checked", true);
            showDesc('Test_isOK_Manual_Shift_Clear', 'False');
            $('input[name="rblTest_isOK_Clutch"]').eq(0).attr("checked", true);
            showDesc('Test_isOK_Clutch', 'False');
        }
    });
    showDesc('Test_isOK_Manual_Shift_Change', 'False');
    $('input[name="rblTest_isOK_Manual_Shift_Change"]').change(function () {
        showDesc('Test_isOK_Manual_Shift_Change', 'False');
    });
    showDesc('Test_isOK_Manual_Shift_Clear', 'False');
    $('input[name="rblTest_isOK_Manual_Shift_Clear"]').change(function () {
        showDesc('Test_isOK_Manual_Shift_Clear', 'False');
    });
    showDesc('Test_isOK_Clutch', 'False');
    $('input[name="rblTest_isOK_Clutch"]').change(function () {
        showDesc('Test_isOK_Clutch', 'False');
    });


    $("#tabs").tabs({
        beforeLoad: function (event, ui) {
            ui.jqXHR.error(function () {
                ui.panel.html("面板切换失败，请尝试重新操作");
            });
        }
    });

    //removeTabs('<=denyGrants>');

    //$("#txtCheckID").blur(function () {
    //    $.ajax({
    //        type: "post",
    //        url: "/ashx/Order/ReportHandler.ashx?p="+ Math.random(),
    //        data: {
    //            mod: "IsExistCheckID",
    //            ID: $("#txtCheckID").val()
    //        },
    //        success: function (data) {
    //            if (data != "OK") {
    //                alert("检测单号不正确");
    //            }
    //        }
    //    });
    //});
});

//name-元素名称，为selection需填写备注
function showDesc(name, selection) {
    if ($('input[name="rbl' + name + '"]:checked').val() == selection)
        $('.tr' + name + '_Desc').show();
    else
        $('.tr' + name + '_Desc').hide();
}
//与上相反：不为selection需填写备注
function hideDesc(name, selection) {
    if ($('input[name="rbl' + name + '"]:checked').val() == selection || $('input[name="rbl' + name + '"]:checked').val() == undefined)
        $('.tr' + name + '_Desc').hide();
    else
        $('.tr' + name + '_Desc').show();
}

function removeTabs(tabs) {
    if (tabs != "") {
        var arrTabs = tabs.split(';');
        if (arrTabs != null && arrTabs.length > 0) {
            for (i = 0; i < arrTabs.length; i++) {
                $("#tabs").tabs('remove', arrTabs[i] - i);//报告权限-执行次数
            }
        }
    }
}

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
                        $("#hid" + id.substr(3)).val(data.msg);                        
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

function calcKM(e) {
    //公式：6000/8*depth四舍五入到千位=【(7500*depth/1000)取整】*1000=【7.5*depth】取整*1000
    var depth = parseFloat($(e).val());
    var result = parseInt(7.5 * depth) * 1000;
    $("#txtUsage_KMtoChangeWheel").val(result);
}