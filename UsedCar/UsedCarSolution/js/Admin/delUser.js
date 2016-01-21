function DelUser(id) {
    if (confirm("确定要删除记录吗？")) {
        $.ajax({
            type: "post",
            url: "/ashx/Admin/userOperate.ashx?p="+ Math.random(),
            data: {
                mod: "Delete",
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