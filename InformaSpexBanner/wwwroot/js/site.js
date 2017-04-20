// Write your Javascript code.
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
    	$("#posxInput").val(textPos.left - imagePos.left);
    	$("#posyInput").val(textPos.top - imagePos.top);
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

/* Client Download View */
    $(".download").click(function(){
    	var img = $(this).attr("data-filename");
    	var imgsrc = $(img).find(".thumbnail").attr("src");

	    // atob to base64_decode the data-URI
	    var image_data = atob(imgsrc.split(',')[1]);
	    // Use typed arrays to convert the binary data to a Blob
	    var arraybuffer = new ArrayBuffer(image_data.length);
	    var view = new Uint8Array(arraybuffer);
	    for (var i=0; i<image_data.length; i++) {
	        view[i] = image_data.charCodeAt(i) & 0xff;
	    }
	    try {
	        // This is the recommended method:
	        var blob = new Blob([arraybuffer], {type: 'application/octet-stream'});
	    } catch (e) {
	        // The BlobBuilder API has been deprecated in favour of Blob, but older
	        // browsers don't know about the Blob constructor
	        // IE10 also supports BlobBuilder, but since the `Blob` constructor
	        //  also works, there's no need to add `MSBlobBuilder`.
	        var bb = new (window.WebKitBlobBuilder || window.MozBlobBuilder);
	        bb.append(arraybuffer);
	        var blob = bb.getBlob('application/octet-stream'); // <-- Here's the Blob
	    }

	    // Use the URL object to create a temporary URL
	    var url = (window.webkitURL || window.URL).createObjectURL(blob);
	    location.href = url; // <-- Download!
    });
  });
