// JavaScript Document

//-----------切换
 $(function(){
     var $menu_li = $(".navs_lists ul li");
      $menu_li.mousedown(function(){
         $menu_li.css({cursor:"pointer"});    
         $(this).addClass("on").siblings().removeClass("on");        
            var index = $menu_li.index(this);
            $("div.one_cont_y > div").siblings().hide().eq(index).show();
            $("div.one_cont_y > div");
			
			});
	});	 
	 
 


//table隔行换色 
$(document).ready(function() { 
$('.table_1 tr').addClass('odd'); 
$('.table_1 tr:even').addClass('even'); //奇偶变色，添加样式 
}); 
 
 
 //table鼠标经过换色 
$(function(){  //文档加载 
 $(".table_1 tr,.table_bg_7 tr").hover( 
  function(){ 
    $(this).addClass("td_hover");    //鼠标经过添加hover样式 
  }, 
  function(){ 
    $(this).removeClass("td_hover");   //鼠标离开移除hover样式 
  } 
); 
}); 


/*勾选后可编辑*/
$(function(){
	$(".table_2box :checkbox").click(function(){
			if($(this).attr("checked")=="")
			{
				$(this).parents("tr").next("tr").find(".zhecont div").attr("class","zheceng");
			}else{
				$(this).parents("tr").next("tr").find(".zhecont div").attr("class","edtceng");	
			}
		})
	})
	
/*点击按钮后不可编辑---*/
$(function(){
	$(".table_2box :button").click(function(){
			if($(this).parent("p").next("div").attr("class")=="edtceng")
			{
				var indexs=$(".table_2box :button").index($(this));				
				$(".table_2box :checkbox").eq(indexs).click();
				$(this).parent("p").next("div").attr("class","zheceng");
			}
		})
	})



/*点击按钮后去掉遮罩层---*/
$(function(){
	$("#ctrlnext").click(function(){
			
				$(".bigzhe").attr("style","display:none");
			
		})
	})




//---------左面-收起-展开 
$(function(){
	$(".li_nav_bg dt").toggle(function(){
	var $self = $(this);
	$self.next().slideToggle(350,function(){
	$("span",$self).css({"background-position":"0px -15px"});
					});
			 },function(){
	var $self = $(this);
	$self.next().slideToggle(350,function(){
    $("span",$self).css({"background-position":"0px 0px"});
					});
		 });
});






