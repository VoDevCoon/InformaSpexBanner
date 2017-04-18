// Write your Javascript code.
$(document).ready(function(){


   $("#ctext").text($("#ctextInput").val());
   $("#ctext").css("font-size",$("#fsizeInput").val()+"px");
   $("#ctext").css('color', $("#fcolorInput").val());
   $("#ctext").css("font-family", $("#fontTypeInput").val());
   $("#ctext").css({top: $("#posyInput").val()+"px", left: $("#posxInput").val()+"px"});


  $("#ctext").draggable({
    stop: function(){
    var position = $(this).position();
    $("#posxInput").val(position.left);
    $("#posyInput").val(position.top);

    }
  });
  
  $("#ctextInput").on("keyup paste", function() {
    $("#ctext").text($(this).val());
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

  });
