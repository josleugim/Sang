function xeroClearFieldValue(){	

	// Credits: CSS Globe (cssglobe.com)
	// CSS class names
	// put any class name you want
	// define this in external css (example provided)
	var inactive = "inactive";
	var active = "active";
	var focused = "focused";
	
	// function
	$("label.auto_clear").each(function(){		
		obj = document.getElementById($(this).attr("for"));
		if(($(obj).attr("type") == "text") || (obj.tagName.toLowerCase() == "textarea")){			
			$(obj).addClass(inactive);			
			var text = $(this).text();
			$(this).css("display","none");			
			$(obj).val(text);
			$(obj).focus(function(){	
				$(this).addClass(focused);
				$(this).removeClass(inactive);
				$(this).removeClass(active);								  
				if($(this).val() == text) $(this).val("");
			});	
			$(obj).blur(function(){	
				$(this).removeClass(focused);													 
				if($(this).val() == "") {
					$(this).val(text);
					$(this).addClass(inactive);
				} else {
					$(this).addClass(active);		
				};				
			});				
		};	
	});		
};

function xeroContactForm(){
	$('#contact_form').submit(function(){
		$('.required', this).removeClass('error')
		$('em.error').remove();
		
		var error = false;
		
		$('.required', this).each(function() {	
			var fieldName = $(this).attr('name');
			var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
				
			if( $.trim($(this).val()) == '' ) {
				$(this).parent().append('');
				$(this).addClass('error');
				error = true;
			} else if( $(this).hasClass('email') ) {	
				if(!emailReg.test(jQuery.trim($(this).val()))) {
					$(this).parent().append('');
					$(this).addClass('error');
					error = true;
				}
			}
		});
						
		if(!error){
			$("li #submit", this).after('<span id="form_loading"></span>');
			var formValues = $(this).serialize();
			
			$.post($(this).attr('action'), formValues, function(data){
				$("#contact_form").before(data);
				$("#form_loading").fadeOut(400, function(){
					$(this).remove()
				});
				$("#contact_form").fadeOut(900, function(){
					$(this).remove()
				});
			});
		}
		return false
	});	
}

$(document).ready(function(){
	// for auto clreaing field value
	xeroClearFieldValue();
});