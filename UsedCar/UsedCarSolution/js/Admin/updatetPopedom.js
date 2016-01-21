var JsonData;
var firstStr="";
$(function () {
    ShowAll();
    //获取数据
    //alert($("#hdID").val());
    $.ajax({
        type: "post",
        url: "/ashx/Admin/AddRole.ashx?p="+ Math.random(),
        async: false,
        data: {
            id: $("#hdID").val(),
            roleName:$("#hdRoleName").val(),
            classType: "getdata"
        },
        success: function (Json) {
            //将json字符串转换为json对象
            var arr = Json.split('$');
            $("#name").html("<strong>角色的名字&nbsp;：&nbsp;&nbsp;" + arr[1] + "</strong>");
            //拥有权限列表
            var popedomHtml = "";
            var popedomList = eval('(' + arr[2].toString().replace(/\"/gi, "'") + ')');
            if (popedomList != null) {
                $.each(popedomList, function (index, item) {
                    popedomHtml += "<p>" + item.PopedomName + "</p>";
                });
            }
            $("#popedomList").html(popedomHtml);
            //数据绑定
            var Html = "";
            JsonData = eval('(' + arr[0].toString().replace(/\"/gi, "'") + ')');

            if (JsonData != "") {
                $.each(JsonData, function (index, item) {
                    //panretID==0
                    if (item.ParentID == 0) {
                        Html += "<tr> <td class='bbt' colspan='10' onclick='javascript:ShowOrHide(\"TrPepedomId" + item.PopedomId + "\")'><span class='tab-x'  title='展开按钮'></span>" + item.PopedomName + "</td></tr>";
                        Html += nextHtml(item.PopedomId);
                    }
                });
                $("#tab").append(Html);
                $("tr[id*=TrPepedomId]").show();
            }
            $(":checkbox").each(function () {
                var i = $(this).val();
                var isExist = false;
                $.each(popedomList, function (index, item) {
                    if (item.PopedomId == i) {
                        isExist = true;
                    }
                })
                if (isExist) {
                    $(this).attr("checked", "checked");
                }
            });
        }
    });

    //把当前已有的权限记录下来
    $.each($(":checked"), function () {
        firstStr += $(this).val() + ',';
    });
    firstStr = firstStr.substring(0, firstStr.length - 1);

    $("#btnCannel").click(function () {
        $.each($(":checked"), function () {
            $(this).checked = false;
        });
    });

    //提交表单
    $("#btnSubmit").click(function () {
        //        alert($("#hdID").val());
        // 判断用户名是否输入

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
            url: "/ashx/Admin/AddRole.ashx?p=" + Math.random(),
            data: {
                id: $("#hdID").val(),
                classType: "updatedata",
                listRole: str,
                firstStr: firstStr
            },
            success: function (data) {
                if (data == "1") {
                    alert("添加成功");
                    // window.location.href = "/Admin/AssignmentRole.aspx";
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
});

function nextHtml(PopedomId) {
    var nextHtm = "<tr id='TrPepedomId" + PopedomId + "' class='1'>";
    $.each(JsonData, function (index, item) {
        if (item.ParentID == PopedomId) {
            nextHtm += "<td><input type='checkbox' value='" + item.PopedomId + "' />" + item.PopedomName + "</td>";
        }
    });
    nextHtm += "</tr><tr> <td colspan='10'>&nbsp;</td></tr>";
    return nextHtm;
}
//控制tr的显示与隐藏
function ShowOrHide(PeopedomId) {
    if ($("#" + PeopedomId).attr("class") == "1") {//当前状态为隐藏，开始显示
        $("#" + PeopedomId).show();
        $("#" + PeopedomId).attr("class", "0");
        $(this).find("span").attr("class", "tab-y");
    } else {
        $("#" + PeopedomId).show();
        $("#" + PeopedomId).attr("class", "1");
        $(this).find("span").attr("class", "tab-x");
    }
}
//显示全部
function ShowAll() {
    $("tr[id*=TrPepedomId]").show();
    $("tr[id*=TrPepedomId]").attr("class", "0");
}
//折叠全部
function HideAll() {
    $("tr[id*=TrPepedomId]").hide();
    $("tr[id*=TrPepedomId]").attr("class", "1");
}