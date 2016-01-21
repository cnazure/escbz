var JsonData;
JQ(function () {
    JQ.ajax({
        type: "post",
        url: "/ashx/Admin/leftNavigation.ashx",
        data: { t: Math.random() },
        success: function (Json) {
            var Html = ""; var HtmlS = "";
            ///将JSON字符串转换为JSON对象
            JsonData = eval('(' + Json.toString().replace(/\"/gi, "'") + ')');
            if (JsonData != "") {
                JQ.each(JsonData, function (index, item) {
                    //一级节点
                    if (item.ParentID == 0) {
                        var display = "display:block";
                        if (nextDirectory(item.PopedomId) != "") {
                            Html += "<h1 class='type' style=" + display + "><a href='javascript:void(0)' >" + item.PopedomName + "</a></h1>";
                            Html += nextDirectory(item.PopedomId);
                        }                     
                    }

                })
                JQ("#container0").append(Html);
                Starloding();
            }
        }
    })
})

function nextDirectory(PopedomId) {
    var DirectoryHtml = "<div class='content' >";
    DirectoryHtml += "<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td>";
    DirectoryHtml += "<img src='images/menu_topline.gif' width='182' height='5' /></td></tr></table>";
    DirectoryHtml += "<ul class='mm'>";

    var count = 0;
    JQ.each(JsonData, function (index, item) {
        if (item.ParentID == PopedomId) {
            count++;
            DirectoryHtml += "<li><a href=" + item.Url + " target='main'>" + item.PopedomName + "</a></li>";
        }
    })
    DirectoryHtml += "</ul>";
    DirectoryHtml += "</div>";

    if (count == 0) {
        DirectoryHtml = "";
    }
    return DirectoryHtml;
}
