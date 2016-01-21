var JsonData;
$(function () {
    //获取数据
    $.ajax({
        type: "post",
        url: "/ashx/Admin/addRole.ashx?p="+ Math.random(),
        async: false,
        data: {
            classType: "getdata"
        },
        success: function (Json) {
            var Html = "";

            //将json字符串转换为json对象
            JsonData = eval('(' + Json.toString().replace(/\"/gi, "'") + ')');
            
            if (JsonData != "") {
                $.each(JsonData, function (index, item) {
                    //panretID==0
                    if (item.ParentID == 0) {
                        Html += "<tr> <td class='bbt' colspan='10'>" + item.PopedomName + "</td></tr>";
                        Html += nextHtml(item.PopedomId);
                    }
                });
                $("#tab").append(Html);
            }
        }
    });

    $("#btnCannel").click(function () {
        $.each($(":checked"), function () {
            $(this).checked = false;
        });
    });

    //提交表单
    $("#btnSubmit").click(function () {
        // 判断用户名是否输入
        if ($.trim($("#roleName").val()).length == 0) {
            alert("请输入角色名称");
            return;
        }
        //判断checkbox是否处于选中状态
        var str = '';
        if ($(":checked").length == 0) {
            alert("请选择角色权限");
            return;
        }
        $.each($(":checked"), function () {
            str += $(this).val() + ',';
        });
        str = str.substring(0, str.length - 1)
        $.ajax({
            type: "post",
            url: "/ashx/Admin/addRole.ashx?p="+ Math.random(),
            data: {
                roleName: $("#roleName").val(),
                classType: "senddata",
                listRole: str
            },
            success: function (data) {
                if (data == "1") {
                    alert("添加成功");
                    window.location.href = "/Admin/selectRole.aspx";
                }
                else if (data == "2") {
                    alert("添加失败");
                }
                else {
                    alert("problem");
                }
            }
        });
    });



})

function nextHtml(PopedomId) {
    var nextHtm = "<tr>";
    $.each(JsonData, function (index, item) {
        if (item.ParentID == PopedomId) {
            nextHtm += "<td><input type='checkbox' value='" + item.PopedomId + "' />" + item.PopedomName + "</td>";
        }
    });
    nextHtm += "</tr><tr> <td colspan='10'>&nbsp;</td></tr>";
    return nextHtm;
}