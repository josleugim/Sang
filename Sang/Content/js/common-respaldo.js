// PLUGINS //

// Initialize jScrollPane Plugin in All Pages //
$(function() {
	$('.scroll-pane').show().jScrollPane({reinitialiseOnImageLoad:true, scrollbarMargin:15});
});

// Initialize Lightbox Plugin in All Pages //
$(function() {
	$('a.lightbox').lightBox({overlayBgColor: '#1a1b1d'});
});
//---//


// If screen resolution is 1024px wide or less //
$(function()
	{function detectResolution() {if (screen.width < 1072) {$('#folio-col-left').css('margin-left', '2%');}}
	detectResolution();
});



// SLOGAN EFFECT //

$(function() {

	$('#logo-container') .mouseover(function() {
		$('.slogan') .stop() .animate({'opacity' : '1', 'marginTop' : '5px'}, 100);
		$('.slogan') .css('display', 'block');
	});
	$('#logo-container') .mouseout(function() {
		$('.slogan') .stop() .animate({'opacity' : '0', 'marginTop' : '0px'}, 300);
	});
});



// MAIN MENU //

$(function() {

	$('#mmenu li') .hover(function() {
		$(this) .stop() .animate({marginLeft: "10px"}, 250);
	},
	function() {
		$(this) .stop() .animate({marginLeft: "0px"}, 250);
	});
	
	$('li.parnt') .hover(function() {
		$(this) .stop() .animate({marginLeft: "10px"}, 200, function() {
							$(this) .css('height', 'auto');
						});
	},
	function() {
		$(this) .stop() .animate({'marginLeft' : '0px'}, 250) .animate({'height' : '11px'}, 250);
	});
});



// SLIDER - HOME PAGE //

$(function() {

	listNumber = $('#slide-container div.slider-item') .length;
	i = 1;
	
	$('#slide-container div.slider-item:first') .addClass('first');
	$('#slide-container div.slider-item:last') .addClass('last');
	$('#slide-container div.slider-item:not(:first)') .css('display', 'none');
	$('#slide-container div.slider-item') .css({'position' : 'absolute', 'top' : '0px'});
	$('#slide-container') .css('overflow', 'hidden');
	$curr = $('#slide-container div.slider-item:visible');
	
	$('span.all-item-num') .append(listNumber);
	$('#meta-pagination span.curr-item-num') .append(i);
	
	// Auto Rotator //
	var $autoR = $curr;
	setInterval(function() {
			if (autoRotate) {
				if ($autoR .hasClass('last')) {
					$autoR = $('#slide-container div.slider-item:first');
					i = 1;
				} else {
					$autoR = $autoR.next();
					i++;
				}
				$('span.curr-item-num').replaceWith("<span class=\"curr-item-num\">"+i+"</span>");
				$('#slide-container div.slider-item:visible') .slideUp(400);
				$autoR .slideDown(800);
			}
	}, 6000);
	//---//

	$('#nextarr') .click(function() {
		autoRotate=0;
		$curr = $('#slide-container div.slider-item:visible');
		
		if ($curr .hasClass('last')) {
			$curr = $('#slide-container div.slider-item:first');
			i = 1;
		} else {
			$curr = $curr.next();
			i++;
		}
				
		$('span.curr-item-num').replaceWith("<span class=\"curr-item-num\">"+i+"</span>");
		$('#slide-container div.slider-item:visible') .slideUp(400);
		$curr .slideDown(800);
	});
	
	
	$('#prevarr') .click(function() {
		autoRotate=0;
		$curr = $('#slide-container div.slider-item:visible');
		
		if ($curr .hasClass('first')) {
			$curr = $('#slide-container div.slider-item:last');
			i = listNumber;
		} else {
			$curr = $curr.prev();
			i--;
		}
		
		$('span.curr-item-num').replaceWith("<span class=\"curr-item-num\">"+i+"</span>");
		$('#slide-container div.slider-item:visible') .slideUp(400);
		$curr .slideDown(800);
	});
});



// SLIDER - SERVICES PAGE //

$(function() {

	$('#meta-pagination-s span.curr-item-num') .append(i);
	
	if ($('#slide-container div.slider-item:first') .find('img.service-img') .length == 1 ) {
		$('#meta-pagination-s') .css('top', '182px');
		$('span#nextarr-s, span#prevarr-s') .css('top', '176px');
	}
	
	$('#nextarr-s') .click(function() {
		$curr = $('#slide-container div.slider-item:visible');
		
		if ($curr .hasClass('last')) {
			$curr = $('#slide-container div.slider-item:first');
			i = 1;
		} else {
			$curr = $curr.next();
			i++;
		}
		
		$('span.curr-item-num').replaceWith("<span class=\"curr-item-num\">"+i+"</span>");
		$('#slide-container div.slider-item:visible') .slideUp(400);
		$curr .slideDown(800);
		
		if ($curr .find('img.service-img') .length == 1 ) {
			$('#meta-pagination-s, span#nextarr-s, span#prevarr-s') .hide();
			$('#meta-pagination-s') .css('top', '182px') .fadeIn('slow');
			$('span#nextarr-s, span#prevarr-s') .css('top', '176px') .fadeIn('slow');
		} else {
			$('#meta-pagination-s, span#nextarr-s, span#prevarr-s') .hide();
			$('#meta-pagination-s') .css('top', '20px') .fadeIn('slow');
			$('span#nextarr-s, span#prevarr-s') .css('top', '14px') .fadeIn('slow');
		}
	});
	
	$('#prevarr-s') .click(function() {
		$curr = $('#slide-container div.slider-item:visible');
		
		if ($curr .hasClass('first')) {
			$curr = $('#slide-container div.slider-item:last');
			i = listNumber;
		} else {
			$curr = $curr.prev();
			i--;
		}
		
		$('span.curr-item-num').replaceWith("<span class=\"curr-item-num\">"+i+"</span>");
		$('#slide-container div.slider-item:visible') .slideUp(400);
		$curr .slideDown(800);
		
		if ($curr .find('img.service-img') .length == 1 ) {
			$('#meta-pagination-s, span#nextarr-s, span#prevarr-s') .hide();
			$('#meta-pagination-s') .css('top', '182px') .fadeIn('slow');
			$('span#nextarr-s, span#prevarr-s') .css('top', '176px') .fadeIn('slow');
		} else {
			$('#meta-pagination-s, span#nextarr-s, span#prevarr-s') .hide();
			$('#meta-pagination-s') .css('top', '20px') .fadeIn('slow');
			$('span#nextarr-s, span#prevarr-s') .css('top', '14px') .fadeIn('slow');
		}
	});
});



// SWITCH TO SINGLE NEWS/STAFF ITEM //

$(function() {
	
	// Add read-more arrow-button depending on letters count //
	var itemDivs = $('.items div.item');
	jQuery.each(itemDivs, function() {
		var itemText = $(this) .find('.scrollable-news-parag') .text() .length;
		if(itemText > 200) {
			$(this) .addClass('has-more');
		}
	});
	//---//
	
	// If read-more arrow was added, enable it.
	function moreArrPresent() {
		$('.items div.has-more') .find('div.more-arr') .css('visibility', 'visible');
	}
	// Add hover effect to read-more arrow-button.
	function moreArrH() {
		$('.items div.item') .hover(function() {
			$(this) .find('div.more-arr') .addClass('more-arr-hover');	
		},
		function() {
			$(this) .find('div.more-arr') .removeClass('more-arr-hover');
		});
	}
	moreArrPresent();
	moreArrH();
	
	//Grab the item html and saves it into a veriable when mouse hovers on it.
	var $itemContents;
	$('.items div.item') .hover(function() {
		$itemContents = $(this) .html();
	},
	function() {
		$itemContents = null;
	});
	
	// When read-more arrow-button is clicked //
	function arrClick() {
	$('.items div.has-more') .find('div.more-arr') .click(function() {
		$('span.close') .show();
		$('#actions') .hide();
		$('.news-pagination') .hide();
		$('div#more-container') .empty() .prepend($itemContents) .fadeIn('normal');
		$('div#more-container .scroll-fix') .css('height', '500px');
		$('div#more-container .scrollable-news-parag') .css('height', '460px') .addClass('scroll-pane');
		$('div#more-container div.item-info') .css('height', '500px');
		$('div#more-container div.more-arr') .hide();
		$('div.mail-tooltip') .remove();
		emailTooltip();
		// re-initialize plugins for the newly emplemented data.
		if (navigator.appName != 'Microsoft Internet Explorer') {
		Cufon.replace('h4');
		}
		$('.scroll-pane').show().jScrollPane({reinitialiseOnImageLoad:true, scrollbarMargin:15});
		$('a.lightbox').lightBox({overlayBgColor: '#1a1b1d'});
		
	});
	}
	arrClick();
	//---//
	
	// When close icon is clicked //
	$('span.close') .click(function() {
		$(this) .hide();
		$('#actions') .show();
		$('.news-pagination') .show();
		$('div#more-container') .empty() .slideUp(300);
		
		moreArrH();
		arrClick();
	});
});



// PORTFOLIO //

$(function() {

	$('.portfolio-item:not(:first)') .hide();
	$('#folio-thumbs img') .addClass('in-active');
	$('#folio-thumbs img:not(:first)') .fadeTo('500', 0.4);
	$('#folio-thumbs img.in-active') .hover(function() {
		$(this) .stop() .fadeTo('500', 1);
	},
	function() {		
		$('#folio-thumbs img.in-active') .stop() .fadeTo('500', 0.4);
	});
	
	var folioItemsNum = $('.portfolio-item') .length;
	$('#folio-counter span') .append(folioItemsNum);
	
	$('#folio-thumbs img') .click(function() {
			var imgAlt = $(this) .attr('alt');
			$('#folio-thumbs img') .addClass('in-active');
			$(this) .removeClass('in-active') .fadeTo('500', 1) .css('cursor', 'default');
			$('#folio-thumbs img.in-active') .fadeTo('500', 0.4) .css('cursor', 'pointer');
			$('.portfolio-item:visible') .slideUp(500);
			$(".portfolio-item img[alt='"+imgAlt+"']") .parent() .parent() .slideDown(500);
		});
	
	$('.info-toggle') .click(function() {
		$(this) .prev() .find('.imginfo') .slideToggle(250);
		$(this) .find('span') .toggle();
	});

});



// CONTACT FORM //

$(function() {
	
	var textAreaVal;
	$("#contact-form textarea[name='comments']") .hover(function() {
		textAreaVal = $(this) .text();
	},
	function() {
	});
	
	$("#contact-form textarea[name='comments']") .focus(function() {
		if (textAreaVal == 'Message') {
			$(this) .empty();
		}
	});
	
	$("#contact-form input[name='send']") .click(function() {
        $('#contact-form .form-loader') .show();

        var name = $("#contact-form input[name='name']") .val();
        var email = $("#contact-form input[name='email']") .val();
        var comments = $("#contact-form textarea[name='comments']") .val();

        $.ajax({
            type: 'post',
            url: 'sendEmail.php',
            data: 'name=' + name + '&email=' + email + '&comments=' + comments,

            success: function(results) {
                $('#contact-form .form-loader') .fadeOut('fast');
                $('ul#response') .hide() .html(results) .slideDown(250);
            }
        });
    });
});



// EMAIL ICON TOOLTIP //

function emailTooltip() {
	$('img.mail') .hover(function(e) {
		mX = e.clientX + 25;
		mY = e.clientY - 10;
		$(this) .parent() .after('<div class="mail-tooltip"></div>');
		Rname = $(this) .parent() .prev() .text();
		Rname = "Send Email To: " + Rname;
		$('div.mail-tooltip') .empty() .append(Rname);
		$('div.mail-tooltip') .css({'top' : mY, 'left' : mX}) .stop() .show();
	},
	function() {
		$('div.mail-tooltip') .slideUp(100, function() {
			$(this) .remove();
		});
	});
}
$(function() { emailTooltip(); });



// FOOTER SOCIAL-ICONS TOOLTIPS //

$(function() {
	
	$('#footer li img') .hover(function() {
		var tip = $(this) .attr('alt');
		$('#footer .tip') .empty() .append(tip) .show();
	},
	function() {
		$('#footer .tip') .hide();
	});
});






