function DelCustomer(CId) {
    if (confirm("确定要删除记录吗？")) {
        $.ajax({
            type: "post",
            url: "/ashx/User/Customer.ashx?p="+ Math.random(),
            data: {
                mod: "Delete",
                CId: CId
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