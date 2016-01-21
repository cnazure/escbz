
$(function () {
    //如果是事故车，则显示上传照片和描述
    showDesc('IsIncident', 'True');

    //外观
    hideDesc('Outer_isOK_Top_Head', '1');

    hideDesc('Outer_isOK_Top_Center', '1');

    hideDesc('Outer_isOK_Top_Rear', '1');

    hideDesc('Outer_isOK_Right_Head', '1');

    hideDesc('Outer_isOK_Right_Door_Head', '1');

    hideDesc('Outer_isOK_Right_Door_Rear', '1');

    hideDesc('Outer_isOK_Right_Rear', '1');

    hideDesc('Outer_isOK_Right_Bottom', '1');

    hideDesc('Outer_isOk_Right_Wheel_Head', '1');

    hideDesc('Outer_isOk_Right_Wheel_Rear', '1');

    hideDesc('Outer_isOK_Left_Head', '1');

    hideDesc('Outer_isOK_Left_Door_Head', '1');

    hideDesc('Outer_isOK_Left_Door_Rear', '1');

    hideDesc('Outer_isOK_Left_Rear', '1');

    hideDesc('Outer_isOK_Left_Bottom', '1');

    hideDesc('Outer_isOk_Left_Wheel_Head', '1');

    hideDesc('Outer_isOk_Left_Wheel_Rear', '1');

    hideDesc('Outer_isOK_Head_Right', '1');

    hideDesc('Outer_isOK_Head_Center', '1');

    hideDesc('Outer_isOK_Head_Left', '1');

    hideDesc('Outer_isOK_Rear_Right', '1');

    hideDesc('Outer_isOK_Rear_Center', '1');

    hideDesc('Outer_isOK_Rear_Left', '1');

    //内饰
    showDesc('Inner_isOK_GlassButton', 'False');

    showDesc('Inner_isOK_Bottom_Head', 'False');

    showDesc('Inner_isOK_Bottom_Rear', '2');

    showDesc('Inner_isOK_Shift', 'False');

    showDesc('Inner_isOK_Air', 'False');

    showDesc('Inner_isOK_DoorOpen', 'False');

    showDesc('Inner_isOK_Air_Rear', '2');

    showDesc('Inner_isOK_DoorOpen_Rear', '2');

    showDesc('Inner_isOK_Seat_Driver', 'False');

    showDesc('Inner_isOK_Seat_Side', 'False');

    showDesc('Inner_isOK_Seat_Rear', '2');

    showDesc('Inner_isOK_Safe', '2');

    showDesc('Inner_isOK_Top', 'False');

    showDesc('Inner_isOk_Display', 'False');

    showDesc('Inner_isOk_Dashboard', 'False');

    showDesc('Inner_isOK_Turner', 'False');

    showDesc('Inner_isOK_CenterControl', 'False');

    showDesc('Inner_isOK_Storage', 'False');

    //showDesc('Inner_hasAdditon', 'True');

    //电子设备
    showDesc('Electric_isOK_Start', '2');

    showDesc('Electric_isOK_Light_Dashboard', '2');

    showDesc('Electric_isOK_DriverInfo', '2');

    showDesc('Electric_isOK_TurnLight', '2');

    showDesc('Electric_isOK_Radio', '2');

    showDesc('Electric_isOK_LightControl', '2');

    showDesc('Electric_isOK_Media', '2');

    showDesc('Electric_isOK_Mirror', '2');

    showDesc('Electric_isOK_SeatControl', '2');

    showDesc('Electric_isOK_SeatHeat', '2');

    showDesc('Electric_isOK_Air', '2');

    showDesc('Electric_isOK_Glass', '2');

    showDesc('Electric_isOK_Rainbrush', '2');

    showDesc('Electric_isOK_CenterControl', '2');

    showDesc('Electric_isOK_Navi', '2');

    showDesc('Electric_isOK_Speed', '2');

    showDesc('Electric_isOK_Stable', '2');

    showDesc('Electric_isOK_Key', '2');

    showDesc('Electric_isOK_Turner', '2');

    showDesc('Electric_isOK_Radar', '2');

    showDesc('Electric_isOK_Convertible', '2');

    showDesc('Electric_isOK_Raisehead', '2');

    showDesc('Electric_isOK_Entertainment', '2');

    showDesc('Electric_isOK_SuckDoor', '2');

    //路试
    showDesc('Test_isOK_Start', 'False');

    showDesc('Test_isOK_Idle', 'False');

    showDesc('Test_isOK_Accelerate', 'False');

    showDesc('Test_isOK_Brake', 'False');

    showDesc('Test_isOK_Turn', 'False');

    showDesc('Test_isOK_Sound', 'False');

    showDesc('Test_isOK_Shift', 'False');

    showDesc('Test_isOK_TransMission', 'False');

    showDesc('Test_isOK_Smooth', 'False');

    showDesc('Test_isOK_Straight', 'False');

    showDesc('Test_isOK_Homing', 'False');

    showDesc('Test_isOK_Dashboard', 'False');

    showDesc('Test_isOK_DriverInfo', 'False');

    //手动\自动拍档
    showDesc('Test_isOK_Manual', '0');

    showDesc('Test_isOK_Manual_Shift_Change', 'False');

    showDesc('Test_isOK_Manual_Shift_Clear', 'False');

    showDesc('Test_isOK_Clutch', 'False');


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
