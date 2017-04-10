// Write your Javascript code.
$(document).ready(function(){

  $("#ctext").draggable({
    stop: function(){
    var position = $(this).position();
    $("#posxInput").val(position.left);
    $("#posyInput").val(position.top);

    console.log("x:"+$("#posxInput").val()+"|y:"+$("#posyInput").val());
    }
  });
  
  $("#ctextInput").on("keyup paste", function() {
    $("#ctext").text($(this).val());
  });

  $("#fsizeInput").on("input", function(){
    var fsize = $(this).val();
    $("#ctext").css("font-size",fsize+"px")
  });

  $("#fcolorInput").change(function(){
    $("#ctext").css('color', $(this).val());
  });

  });
