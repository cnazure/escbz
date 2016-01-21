function DelRole(id) {
    if (confirm("确定要删除记录吗？")) {
        $.ajax({
            type: "post",
            url: "/ashx/Admin/updateRole.ashx?p="+ Math.random(),
            data: {
                mod: "delete",
                roleID: id
            },
            success: function (data) {
                if (data == "0") {
                    alert("该角色下有用户，禁止删除!");
                }
                else if (data == "1")
                {
                    alert("删除成功");
                    window.location.href = window.location.href;
                }
                else if (data == "2")
                {
                    alert("problem!");
                }
            }
        });
    }
}