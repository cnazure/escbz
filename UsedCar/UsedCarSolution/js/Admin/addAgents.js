$(function () {
    //如果编辑用户信息
    if (clientAid != "") {
        //文本框
        //$("#txtUserName").attr('disabled', true);
        //获取该用户信息
        $.ajax({
            type: 'post',
            url: "/Ashx/User/Agents.ashx?p=" + Math.random(),
            async: false,
            data: { Aid: clientAid, mod: 'getModel' },
            success: function (Json) {
                var arr = Json.split('$');
                var Agent = eval('(' + arr[0].toString() + ')');
                $("#txtAid").val(Agent.Aid);
                $("#txtAgentsName").val(Agent.AName);
                $("#txtAgentsTel").val(Agent.ATel);
                $("#btnSub").val("编 辑");
            }
        });
    } else {
        $.ajax({
            type: 'post',
            url: "/ashx/User/Agents.ashx?p=" + Math.random(),
            async: false,
            data: { mod: 'getAgentsLastId' },
            success: function (Json) {
                var arr = Json.split('$');
                $("#txtAid").val(arr);
            }
        });
    }


    function checkUserName() {
        var res = false;
        if ($.trim($("#txtAgentsName").val()).length == 0) {
            $("#spAgentsName").show();
            $("#spAgentsName").html("请输入用户名");
            res = false;
        }
        else {
            var AgentsName = $.trim($("#txtAgentsName").val());
            $.ajax({
                type: 'post',
                url: "/ashx/User/Agents.ashx?p="+ Math.random(),
                async: false,
                data: { AName: AgentsName, mod: 'checkAgentsName' },
                success: function (data) {
                    if (data == 1) {
                        $("#spUserName").show();
                        $("#spUserName").html("该用户名已存在")
                        res = false;
                    }
                    else {
                        $("#spUserName").hide();
                        res = true;
                    }
                }
            })
        }
        return res;
    }

    //提交
    $("#btnSub").click(function () {

        //添加用户
        if (clientAid == "") {
            $.ajax({
                type: 'post',
                url: "/ashx/User/Agents.ashx?p="+ Math.random(),
                async: false,
                data: {
                    AId: $("#txtAid").val(),
                    AName: $("#txtAgentsName").val(),
                    ATel: $("#txtAgentsTel").val(),
                    mod: 'addAgents'
                },
                success: function (data) {
                    if (data == 1) {
                        alert("添加成功!");
                        window.location.href = "AgentsList.aspx";
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
                url: "/ashx/User/Agents.ashx?p="+ Math.random(),
                async: false,
                data: {
                    Aid: $("#txtAid").val(),
                    AName: $("#txtAgentsName").val(),
                    ATel: $("#txtAgentsTel").val(),
                    mod: 'updateAgents',
                    userID: clientAid
                },
                success: function (data) {
                    if (data > 0) {
                        alert("编辑成功!");
                        window.location.href = "AgentsList.aspx";
                    }
                    else {
                        alert("编辑失败，请重新编辑信息");
                    }
                }
            })
        }
    })
})