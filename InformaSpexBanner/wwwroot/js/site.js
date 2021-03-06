﻿﻿// Write your Javascript code.
$(document).ready(function(){
/* Edit Banner View */
    //initaillise UI		
  {
    $("#ctext").text($("#ctextInput").val());
    $("#ctext").css("font-size",$("#fsizeInput").val()+"px");
    $("#ctext").css('color', $("#fcolorInput").val());
    $("#ctext").css("font-family", $("#fontTypeInput").val());

    var imagePos = $("#bimage").position();
    if(imagePos){
      if($("#posyInput").val()!=0||$("#posxInput").val()!=0){
    	//text position is previously set
    	var posy = +imagePos.top + +$("#posyInput").val();
    	var posx = +imagePos.left + +$("#posxInput").val();
        
    	$("#ctext").css({top: posy + "px", left: posx + "px"});
      }
      else {
    	//first time setting the text position
    	$("#ctext").css({top: imagePos.top, left:imagePos.left});
      } 
    }
  }


    $("#ctext").draggable({
    	stop: function(){
      	var textPos = $(this).position();
    	var imagePos = $("#bimage").position();
    	$("#posxInput").val(textPos.left - imagePos.left+2); //2 is the padding
    	$("#posyInput").val(textPos.top - imagePos.top+2);
    	}
    });
  
    $("#ctextInput").on("keyup paste", function() {
    	$("#ctext").text($(this).val() + "XYZ");
    });

    $("#fsizeInput").on("input", function(){
    	var fsize = $(this).val();
    	$("#ctext").css("font-size",fsize+"px");
    });

    $("#fcolorInput").change(function(){
    	$("#ctext").css('color', $(this).val());
    });

    $("#fontTypeInput").on("change", function(){
    	$("#ctext").css("font-family", $(this).val());
    });

/* Exhibition Details View */
    $(".ibanner").each(function(){
        var modalId = $(this).attr("data-target");
    	var image = new Image();
    	image.src = $(modalId).find(".thumbnail").attr("src");
    	$(this).find(".imgWidth").text("Width: "+image.width+"px");
    	$(this).find(".imgHeight").text("Height: "+image.height+"px");
    });

/* Banner Download View */
    $(".ilbanner").each(function(){
        var modalId = $(this).find(".preview").attr("data-target");
        var image = new Image();
        image.src = $(modalId).find(".thumbnail").attr("src");

        $(this).find(".imgWidth").text("Width: "+image.width+"px");
        $(this).find(".imgHeight").text("Height: "+image.height+"px");
    }); 
  });
