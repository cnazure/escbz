<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarInfoAddorEdit.aspx.cs" Inherits="UsedCarSolution.Car.CarInfoAddorEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/Share.css" rel="stylesheet" type="text/css" />
    <link href="/css/default.css" rel="stylesheet" type="text/css" />
    <script src="../Control/My97DatePicker/WdatePicker.js"></script>
    <link href="/css/table.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/jqmain.js"></script>    
    <script type="text/javascript">
        var clientCarId = "";
        $(function () {
            clientCarId = '<%=CarId%>';
        })

        function openImg(img) {
            var jQueryImg = $("#" + img);
            if (jQueryImg.attr('src') != "")
                window.open(jQueryImg.attr('src'));
        }
    </script>
    <script type="text/javascript" src="/js/Car/addCarInfo.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_bg_title">
            <div class="weizi">
                <strong class="bg">当前位置：</strong> <span class="ce1">客户管理</span>—<span class="ce2">编辑-添加客户</span>
            </div>
            <div class="fanhui">
                <a href="javascript:void(0)"></a>
            </div>
        </div>
        <div class="mg_lrtb br_se">
            <div class="tjxx_cont">
                <a href="javascript:void(0)" class="closebtn"></a>
                <div class="tp">
                </div>
                <div class="searchcont">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_search">
                        <tr>
                            <th>车辆编号：</th>
                            <td>
                                <input id="txtCarId" readonly="readonly" type="text" maxlength="10" />
                            </td>
                        </tr>
                        <tr>
                            <th>车架号：
                            </th>
                            <td>
                                <input id="txtCarVIN" type="text" maxlength="8" />&nbsp&nbsp&nbsp&nbsp<span id="spVIN" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>品牌：
                            </th>
                            <td>
                                <select id="selCarBrand" name="selCarBrand"></select>
                                
                            </td>
                        </tr>
                        <tr>
                            <th>车型：
                            </th>
                            <td>
                                <input id="txtCarModel" type="text" maxlength="20" />&nbsp&nbsp&nbsp&nbsp<span id="spModel" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>初次登记日期：
                            </th>
                            <td>
                                <asp:TextBox ID="txtFirstOnCard" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" Width="80px"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp<span id="spPsw1" style="display: none; color: red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <th>照片类型：
                            </th>
                            <td>
                                <label>
                                    <input type="radio" name="ImgType" value="1" id="ImgType1" checked="checked"/>登记证书</label>
                                <label>
                                    <input type="radio" name="ImgType" value="2" id="ImgType2" />行驶证</label>
                                <label>
                                    <input type="radio" name="ImgType" value="3" id="ImgType3" />铭牌</label>
                                <label>
                                    <input type="radio" name="ImgType" value="4" id="ImgType4" />保单</label>                                                             
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="2"></th>
                            <td>
                                <input type="file" id="btnImg1" name="btnImg1" accept="image/*;capture=camera" onchange="ajaxFileUpload(this);" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="shangquan_img">
                                    <img id="imgImg1" width="100" height="100" onclick="openImg('imgImg1');"/>&nbsp&nbsp&nbsp&nbsp<span id="spImg" style="display: none; color: red;"></span>                           
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <span>
                    <input type="button" id="btnSub" class="btn_ok_big" value="确 认" />
                    <input id="btnBack" class="btn_white_big" type="button" value="返 回" onclick="window.location.href = 'CarInfoList.aspx'" />
                </span>
            </div>
            <input id="AddDate" type="hidden" />
            <!--弹出 增加信息_end----------->
        </div>
        <div class="tutorial">
            <span class="title">页面描述：</span>
            <p class="text">添加修改客户基本信息与联系方式</p>
        </div>
        <script src="../js/ajaxfileupload.js"></script>
    </form>
</body>
</html>


