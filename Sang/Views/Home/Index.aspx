<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SÄNG The nordik way of resting</title>
    <style>
        /* css for this page */body > h2
        {
            margin: 30px 0 15px;
            text-shadow: 1px 1px 0 white;
            border-bottom: 2px solid #000000;
            padding-bottom: 5px;
        }
        h1
        {
            text-align: center;
            margin-bottom: 30px;
            text-shadow: 0px 0px 0 white;
        }
        strong + p
        {
            margin-top: 0;
        }
        dt
        {
            font-weight: bold;
        }
        dd
        {
            margin: 0;
        }
        figure1
        {
            display: block;
            width: 100%;
            height: 100%;
            margin: 0;
        }
        figure
        {
            display: block;
            width: 100%;
            height: 100%;
            margin: 0;
        }
        figcaption
        {
            position: absolute;
            z-index: 3;
            color: white;
            -webkit-border-radius: 0px;
            -moz-border-radius: 0px;
            border-radius: 0px;
            padding-top: 1px;
            padding-right: 1px;
            padding-bottom: 1px;
            padding-left: 15px;
            left: 20px;
            top: 0px;
            right: 0px;
            bottom: 0px;
            margin-top: auto;
            margin-right: auto;
            margin-bottom: auto;
            margin-left: 18px;
        }
        fndbco
        {
            position: absolute;
            z-index: 3;
            background: white;
            background: rgba(0,0,0,0.7);
            color: white;
            -webkit-border-radius: 0px;
            -moz-border-radius: 0px;
            border-radius: 0px;
            padding-top: 10px;
            padding-right: 35px;
            padding-bottom: 10px;
            padding-left: 35px;
            left: 30px;
            top: 0px;
            right: 0px;
            bottom: 0px;
            margin-top: auto;
            margin-right: auto;
            margin-bottom: auto;
            margin-left: 50px;
        }
        #slideshow
        {
            width: 640px;
            height: 263px;
            background: transparent;
            position: relative;
            margin-top: 25px;
            margin-right: auto;
            margin-bottom: 0;
            margin-left: auto;
        }
        #slideshow #slidesContainer
        {
            margin: 0 auto;
            width: 500px;
            height: 263px;
            overflow: auto; /* allow scrollbar */
            position: relative;
        }
        #slideshow #slidesContainer .products
        {
            margin: 0 auto;
            width: 480px; /* reduce by 20 pixels of #slidesContainer to avoid horizontal scroll */
            height: 263px;
        }
        .products img
        {
            margin-top: 0;
            margin-right: 15px;
            margin-bottom: 0;
            margin-left: 35px;
        }
        /** 
 * Slideshow controls style rules.
 */.control
        {
            display: block;
            width: 39px;
            height: 263px;
            text-indent: -10000px;
            position: absolute;
            cursor: pointer;
        }
        #leftControl
        {
            top: 0;
            left: 0;
            background: transparent url(Content/img/control_left.png) no-repeat 0 0;
        }
        #rightControl
        {
            top: 0;
            right: 0;
            background: transparent url(Content/img/control_right.png) no-repeat 0 0;
        }
        /* Seccion SANG */#slideshow_sang
        {
            width: 720px;
            height: 263px;
            background: transparent;
            position: relative;
            margin-top: 25px;
            margin-right: auto;
            margin-bottom: 0;
            margin-left: auto;
        }
        #slideshow_sang #slidesContainer_sang
        {
            width: 680px;
            height: 263px;
            overflow: auto; /* allow scrollbar */
            position: relative;
            margin-top: 0px;
            margin-right: 20px;
            margin-bottom: 0px;
            margin-left: 20px;
        }
        #slideshow_sang #slidesContainer_sang .sang
        {
            margin: 0 auto;
            width: 660px; /* reduce by 20 pixels of #slidesContainer to avoid horizontal scroll */
            height: 263px;
        }
        .sang img
        {
            display: block;
            margin-top: 0;
            margin-right: 15px;
            margin-bottom: 0;
            margin-left: 15px;
        }
        /** 
 * Slideshow controls style rules.
 */.controles
        {
            display: block;
            width: 39px;
            height: 263px;
            text-indent: -10000px;
            position: absolute;
            cursor: pointer;
        }
        #leftControl_sang
        {
            top: 0;
            left: 0;
            background-color: transparent;
            background-image: url(Content/img/control_left_sang.png);
            background-repeat: no-repeat;
            background-position: 0 0;
        }
        #rightControl_sang
        {
            top: 0;
            right: 30px;
            background: transparent url(Content/img/control_right_sang.png) no-repeat 0 0;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="Content/css/style.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="Content/css/prettyPhoto.css" media="screen" />
    <link rel="stylesheet" href="Content/css/queryLoader.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/jScrollPane.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/jquery.lightbox1-0.5.css" type="text/css" />
    <link href="Content/css/jquery.fancybox-1.3.1.css" rel="stylesheet" type="text/css"
        media="screen" />
    <link href="Content/css/jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css" />
    <!-- liteAccordion css -->
    <link href="Content/css/liteaccordion.css" rel="stylesheet" />
    <!-- syntax highlighter -->
    <link href="http://alexgorbatchev.com.s3.amazonaws.com/pub/sh/3.0.83/styles/shCore.css"
        rel="stylesheet" />
    <link href="http://alexgorbatchev.com.s3.amazonaws.com/pub/sh/3.0.83/styles/shThemeDefault.css"
        rel="stylesheet" />
    <!-- jQuery -->
    <script type="text/javascript" src="Content/js/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <script>        document.createElement('nav'); document.createElement('section');</script>
    <script src="Content/js/jquery.mousewheel.js"></script>
    <script src="Content/js/jquery.jscrollpane.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/js/lightbox/themes/evolution-dark/jquery.lightbox.css" />
    <!--[if IE 6]>
		<link rel="stylesheet" type="text/css" href="js/lightbox/themes/default/jquery.lightbox.ie6.css" />
		<![endif]-->
    <script type="text/javascript" src="Content/js/lightbox/jquery.lightbox.min.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $('.lightbox').lightbox();
        });
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {

            $("#lbsingle").click(function () {
                $.lightbox("Content/images/galeria_imgGrandes/livet.jpg", {
                    'width': 700,
                    'height': 500,
                    'autoresize': false
                });
                return false;
            });

            $("#lbgallery").click(function () {
                $.lightbox(["Content/images/galeria_imgGrandes/livet.jpg", "Content/images/galeria_imgGrandes/esp_livet.jpg"]);
                return false;
            });

            $("#lbgallery1").click(function () {
                $.lightbox(["Content/images/galeria_imgGrandes/onskan.jpg", "Content/images/galeria_imgGrandes/esp_onskan.png"]);
                return false;
            });

        });
    </script>
    <!-- easing -->
    <script src="Content/js/jquery.easing.1.3.js"></script>
    <!-- liteAccordion js -->
    <script src="Content/js/liteaccordion.jquery.js"></script>
    <script type="text/javascript" src='Content/js/redirection_mobile.min.js'></script>
    <!--[if lt IE 9]>
            <script>
                document.createElement('figure');
                document.createElement('figcaption');           
            </script>
        <![endif]-->
    <!-- Tooltip -->
    <script type="text/javascript" src="Content/js/tooltip.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var currentPosition = 0;
            var slideWidth = 500;
            var slides = $('.products');
            var numberOfSlides = slides.length;

            // Remove scrollbar in JS
            $('#slidesContainer').css('overflow', 'hidden');

            // Wrap all .slides with #slideInner div
            slides
    .wrapAll('<div id="slideInner"></div>')
            // Float left to display horizontally, readjust .slides width
	.css({
	    'float': 'left',
	    'width': slideWidth
	});

            // Set #slideInner width equal to total width of all slides
            $('#slideInner').css('width', slideWidth * numberOfSlides);

            // Insert controls in the DOM
            $('#slideshow')
    .prepend('<span class="control" id="leftControl">Clicking moves left</span>')
    .append('<span class="control" id="rightControl">Clicking moves right</span>');

            // Hide left arrow control on first load
            manageControls(currentPosition);

            // Create event listeners for .controls clicks
            $('.control')
    .bind('click', function () {
        // Determine new position
        currentPosition = ($(this).attr('id') == 'rightControl') ? currentPosition + 1 : currentPosition - 1;

        // Hide / show controls
        manageControls(currentPosition);
        // Move slideInner using margin-left
        $('#slideInner').animate({
            'marginLeft': slideWidth * (-currentPosition)
        });
    });

            // manageControls: Hides and Shows controls depending on currentPosition
            function manageControls(position) {
                // Hide left arrow if position is first slide
                if (position == 0) { $('#leftControl').hide() } else { $('#leftControl').show() }
                // Hide right arrow if position is last slide
                if (position == numberOfSlides - 1) { $('#rightControl').hide() } else { $('#rightControl').show() }
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var currentPosition = 0;
            var slideWidth = 680;
            var slides = $('.sang');
            var numberOfSlides = slides.length;

            // Remove scrollbar in JS
            $('#slidesContainer_sang').css('overflow', 'hidden');

            // Wrap all .slides with #slideInner div
            slides
    .wrapAll('<div id="slideInner_sang"></div>')
            // Float left to display horizontally, readjust .slides width
	.css({
	    'float': 'left',
	    'width': slideWidth
	});

            // Set #slideInner width equal to total width of all slides
            $('#slideInner_sang').css('width', slideWidth * numberOfSlides);

            // Insert controls in the DOM
            $('#slideshow_sang')
    .prepend('<span class="controles" id="leftControl_sang">Clicking moves left</span>')
    .append('<span class="controles" id="rightControl_sang">Clicking moves right</span>');

            // Hide left arrow control on first load
            manageControls(currentPosition);

            // Create event listeners for .controls clicks
            $('.controles')
    .bind('click', function () {
        // Determine new position
        currentPosition = ($(this).attr('id') == 'rightControl_sang') ? currentPosition + 1 : currentPosition - 1;

        // Hide / show controls
        manageControls(currentPosition);
        // Move slideInner using margin-left
        $('#slideInner_sang').animate({
            'marginLeft': slideWidth * (-currentPosition)
        });
    });

            // manageControls: Hides and Shows controls depending on currentPosition
            function manageControls(position) {
                // Hide left arrow if position is first slide
                if (position == 0) { $('#leftControl_sang').hide() } else { $('#leftControl_sang').show() }
                // Hide right arrow if position is last slide
                if (position == numberOfSlides - 1) { $('#rightControl_sang').hide() } else { $('#rightControl_sang').show() }
            }
        });
        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }

        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }

        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }
        function MM_validateForm() { //v4.0
            if (document.getElementById) {
                var i, p, q, nm, test, num, min, max, errors = '', args = MM_validateForm.arguments;
                for (i = 0; i < (args.length - 2); i += 3) {
                    test = args[i + 2]; val = document.getElementById(args[i]);
                    if (val) {
                        nm = val.name; if ((val = val.value) != "") {
                            if (test.indexOf('isEmail') != -1) {
                                p = val.indexOf('@');
                                if (p < 1 || p == (val.length - 1)) errors += '- ' + nm + ' debe ser un correo válido.\n';
                            } else if (test != 'R') {
                                num = parseFloat(val);
                                if (isNaN(val)) errors += '- ' + nm + ' must contain a number.\n';
                                if (test.indexOf('inRange') != -1) {
                                    p = test.indexOf(':');
                                    min = test.substring(8, p); max = test.substring(p + 1);
                                    if (num < min || max < num) errors += '- ' + nm + ' must contain a number between ' + min + ' and ' + max + '.\n';
                                }
                            }
                        } else if (test.charAt(0) == 'R') errors += '- ' + nm + ' es requerido.\n';
                    }
                } if (errors) alert('Revisa los siguientes campos:\n' + errors);
                document.MM_returnValue = (errors == '');
            }
        }
    </script>
    <!-- this function validates the newsletter form -->
    <script type="text/javascript">
        function validateForm() {
            var x = document.forms["newsForm"]["fname"].value;
            var e = document.forms["newsForm"]["email"].value;
            if (x == null || x == "") {
                alert("Nombre requerido");
                return false;
            }
            if (e == null || e == "") {
                alert("Email requerido");
                return false;
            }
            var atpos = e.indexOf('@');
            var dotpos = e.lastIndexOf(".");
            if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= e.length) {
                alert("Email inválido");
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[type=button]").button(); $("#ejemplo1").hide();
            $("#garanty").click(function () {
                FindRegister();
            });
        }); //end-ready

        function FindRegister() {
            $("#ejemplo1").click(function () { return true; }).click();
        } //End-function

        function ValidaData() {
            var bflag = false; var strResultado = "Faltan los siguientes datos: \n";
            if ($("#nombre").val().length <= 0) {
                bflag = true;
                strResultado += "[ Nombre ]";
            } //end-if
            if ($("#apellidos").val().length <= 0) {
                bflag = true;
                strResultado += "[ Apellidos ]";
            } //end-if
            if ($("#email").val().length <= 0) {
                bflag = true;
                strResultado += "[ E-mail ]";
            } //end-if	

            if (bflag == true) {
                alert(strResultado);
            } else {
                $.post("sendmail.php", { nombre: $("#nombre").val(), apellidos: $("#apellidos").val(), email: $("#apellidos").val() }, function (data) { nada(data); }, "text");
            } //end-else

        } //End-function
        function nada(rs) {
            eval(rs);
        }
    </script>
    <script type="text/javascript" src="Content/js/xero.forms.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            xeroContactForm();
        });
    </script>
</head>
<body onload="MM_preloadImages('Content/img-demo/a/0-1.png','Content/img-demo/a/a_diseniadores.png','Content/img-demo/a/a_garantia.png','Content/img-demo/a/a_newsletter.png','Content/img-demo/a/a_productos.png','Content/img-demo/a/a_sang.png','Content/img-demo/a/a_colecciones.jpg')">
    <div id="wrapper">
        <div id="top">
        </div>
        <div id="contentWrap" class="full-width">
            <div id="content">
                <div class="one-third">
                    <img src="Content/img-demo/a/0-1.png" id="myimage" class=" visible" />
                </div>
                <div class="two-third">
                    <ol>
                        <li name="disenio">
                            <h2>
                                <a href="#disenio" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_diseniadores.png',1)">
                                    <img src="Content/img-demo/menu/menu_diseniadores.png" width="60" height="500" id="menusang"></a></h2>
                            <div>
                                <figure>
                            <img src="Content/img-demo/bg_images/disenadores.jpg" alt="image" width="800" />
                            <figcaption>
                            <br />
                            <br />
                            <img src="Content/img-demo/disenadores.png" width="200" height="41" style=" padding-top:5px; margin-left:28px">
                            <br />
                            
                            <div id="disenadores_sang">
    								<div id="disenadores_sangContainer">
                            
                            <table class="black_table1" style="margin:0px; padding:0px">
  								<tr>
    							<td width="310px" style="color:#575757; margin-top:0px; padding:0px;"></td>
                                <td style="color:#575757; margin-top:0px; padding-top:5px; font-size:14px; line-height:19px; word-spacing:-1px; text-align:justify;">
                                <p style="padding-left:147px; color: #575757; font-size: 14px; line-height: 19px; word-spacing: -1px;"><span class="dropcap_disenadores">N</span>ació el descanso de las grandes vidas. No es un colchón, es un sistema de descanso y como tal se tiene que ver. Antes de Säng la gente pensaba que los atributos del descanso eran suave o firme, grande o pequeño pero Säng acaba con esta percepción y le suma una nueva dimensión: el diseño.</p>
                                <p style="padding-left:147px; color: #575757; font-size: 14px; line-height: 19px; word-spacing: -1px;"><span class="dropcap_disenadores">L</span>os materiales de la mayor calidad, y la tecnología más avanzada, debían tener una piel diferente.</p>
                                <p style="padding-left:147px; color: #575757; font-size: 14px; line-height: 19px; word-spacing: -1px;"><span style="font-size:16px">Säng lo logró.</span></p>
                                </td>
  								</tr>
							</table>
                            
                            		</div>
                            </div>
                          </figcaption>
                      </figure>
                            </div>
                        </li>
                        <li name="garantia">
                            <h2>
                                <a href="#garantia" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_garantia.png',1)">
                                    <img src="Content/img-demo/menu/menu_garantia.png" width="60" height="500" id="menusang"></a></h2>
                            <div>
                                <figure><img src="Content/img-demo/bg_images/garantia.jpg" alt="image" width="800" />
                          <figcaption>
                            <br /><br /><br />
                            <img src="Content/img-demo/titulo_garantia.png" width="210" height="55" style=" padding-top:0px">
                            
                            <div id="custom_garantia"> 
                              <!--<input type="text" tabindex="1" size="22" class="txtfield_garantia" value="" id="garantia" name="garantia"/>-->
                              <%--<input type="text" tabindex="1" size="22" class="txtfield_garantia" value="" id="contactName" name="contactName"/>--%>
                              <% using (Html.BeginForm())
                                 { %>
    <table>
    <tr>
      <td colspan="2"><label for="contactName" class=""><span style="font-size:12px; float:left; color:#FFF">Introduzca su <strong style="font-size:16px">número de garantía</strong></span></label></td>
     </tr>
     <tr>
      <td><%= Html.TextBox("SearchString", null, new { style = "background-color:#3D3D3D; border:none; border-radius:3px; -webkit-border-radius: 3px; -moz-border-radius: 3px; opacity:0.8; filter:alpha(opacity=80); height:30px; color:white;" })%></td>
      <td><input type="image" src="../../Content/images/Boton.png" value="Verificar" /></td>
     </tr>
     <tr>
      <td colspan="2">
       Recomendaciones: <a href="javascript:void(0)"><span id="garanty>Recomendaciones</span></a>
       <a id="ejemplo1" href="Content/garantia/index.html?lightbox[iframe]=true&lightbox[width]=1150&lightbox[height]=600" class="lightbox"><img src="Content/img-demo/zoom_in.png" class="lupa" alt="" id="Img1" /></a>
      </td>
     </tr>
     <tr>
      <td colspan="2"><p style="color:Red;"><%= Html.Encode(ViewData["waranty"]) %></p></td>
     </tr>
    </table>


                                
                                
                                <% } %>
							</div>
                            
                            <table class="black_table1" style=" margin-top:230px; margin-left:10px">
                                <tr>
                                 <td><p>Si ya tiene una cuenta, <u><strong style="font-size:16px"><%: Html.ActionLink("inicie sesión", "LogOn","Account") %></strong></u></p></td>
                                <td align="right" style="font-size:12px"><p>Contacto <strong>01-800-7264000</strong></p></td>
                                <td style="font-size:16px"><p><a href="mailto:servicioalcliente@sang.mx">servicioalcliente@sang.mx</a></p></td>
                                </tr>
                            </table>
                             
                              
                            </figcaption>
                        </figure>
                            </div>
                        </li>
                        <li name="productos">
                            <h2>
                                <a href="#productos" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_productos.png',1)">
                                    <img src="Content/img-demo/menu/menu_productos.png" width="60" height="500" id="menusang"></a></h2>
                            <div>
                                <figure>
                            <img src="Content/img-demo/bg_images/productos.jpg" alt="image" width="800" />
                            <figcaption>
                            <br />
                            <img src="Content/img-demo/productos.png" width="200" height="46" style=" padding-top:20px">
                            
                            <!-- Slideshow HTML -->
  								<div id="slideshow">
    								<div id="slidesContainer">
      									<div class="products">
       										<a id="lbgallery" style="cursor:pointer"><img src="Content/img-demo/livet.png" alt="LIVET" width="408" height="260" /></a>
                                        
                                        </div>
                                        
                                  <div class="products">
       										<a id="lbgallery1" style="cursor:pointer"><img src="Content/img-demo/onskan.png" alt="ÖNSKAN" width="408" height="260" /></a>
                                      </div>
    								</div>
  								</div>
  							<!-- Slideshow HTML -->
                            </figcaption>
                        </figure>
                            </div>
                        </li>
                        <li name="news">
                            <h2>
                                <a href="#news" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_newsletter.png',1)">
                                    <img src="Content/img-demo/menu/6.png" width="60" height="400" id="menusang"></a></h2>
                            <div>
                                <figure>
                            <img src="Content/img-demo/bg_images/newsletter.jpg" alt="image" width="800" />
                          <figcaption>
                          
                          <br />
                            
                            <img src="Content/img-demo/newsletter.png" width="200" height="39" style="padding-top:20px; margin-left:33px">
                            <p style="font-size:12px; color:#4e5960; margin-left:65px">Si desea estar al tanto de la marca, recibir invitaciones y ofertas especiales, llene el siguiente formulario:</p>
                            <!-- Newsletter -->
                            <div class="newslettersang">
                            <br />
                            <% using (Html.BeginForm("NewsletterRegister", "Home", FormMethod.Post, new { name = "newsForm", onsubmit = "return validateForm()" }))
                               { %>
                               <%: Html.ValidationSummary(true) %>
    <table style="color:#000; margin:0 auto;">
     <tr>
      <td>Nombre completo:</td>
      <td><%= Html.TextBox("completeName", "",new { id="fname"})%></td>
     </tr>
     <tr>
      <td>Email:</td>
      <td><%= Html.TextBox("email", "", new {id="email" })%></td>
     </tr>
     <tr>
     <td></td>
      <td><input type="image" src="../../Content/img-demo/btn_enviarNl.png" value="Suscribirse" /></td>
     </tr>
    </table>

<% } %>
<br />
<br />
<p style="font-size:12px; color:#4e5960; text-align:center">He leído y acepto los términos del <a href="/#aviso" target="_self">Aviso de privacidad</a></p>
</div>
                          </figcaption>
                        </figure>
                            </div>
                        </li>
                        <li name="aviso">
                            <h2>
                                <a href="#aviso" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_newsletter.png',1)">
                                    <img src="Content/img-demo/menu/6.png" width="60" height="400" id="menusang"></a></h2>
                            <div>
                                <figure>
                            <img src="Content/img-demo/bg_images/newsletter.jpg" alt="image" width="800" />
                          <figcaption>
                          
                          <br />
                            <h2>Aviso de Privacidad</h2>
                            <%--<img src="Content/img-demo/newsletter.png" width="200" height="39" style="padding-top:20px; margin-left:33px">--%>
                            <div class="newslettersang">
                            
                            <p>
            Con fundamento en los artículos 15 y 16 de la Ley Federal de Protección de Datos
            Personales en Posesión de Particulares hacemos de su conocimiento que Sistemas de
            Descanso säng, S.A.P.I. de C.V., con domicilio en Av. Vasco de Quiroga 3900 Torre
            A, Piso 10B Col. Lomas de Santa Fe, México, D.F. 05300, México es responsable de
            recabar sus datos personales, del uso que se le dé a los mismos y de su protección.</p>
        <p>
            Su información personal será utilizada para las siguientes finalidades: proveer
            los servicios y productos que ha solicitado; notificarle sobre nuevos servicios
            o productos que tengan relación con los ya contratados o adquiridos; comunicarle
            sobre cambios en los mismos; elaborar estudios y programas que son necesarios para
            determinar hábitos de consumo; realizar evaluaciones periódicas de nuestros productos
            y servicios a efecto de mejorar la calidad de los mismos; evaluar la calidad del
            servicio que brindamos, y en general, para dar cumplimiento a las obligaciones que
            hemos contraído con usted. Para las finalidades antes mencionadas, requerimos obtener
            los siguientes datos personales:
        </p>
        <ul style="color:#4e5960">
            <li>Nombre completo;</li>
            <li>Dirección;</li>
            <li>Teléfono</li>
            <li>Correo electrónico;</li>
            <li>Edad;</li>
            <li>Información de descanso y sueño que incluye en forma nominativa mas no limitativa
                hábitos, estado de salud, comportamiento en ciertas situaciones y cualquier otra
                que nos permita proporcionar opciones de servicio.</li>
        </ul>
        <p>
            Acepta que los datos que proporcione respecto a la información de descanso y sueño
            podrán ser transferidos a prestadores de servicios de salud con los que Sistemas
            de Descanso säng, S.A.P.I. de C.V. tenga convenios.</p>
        <p>
            Es importante informarle que usted tiene derecho al Acceso, Rectificación y Cancelación
            de sus datos personales, a Oponerse al tratamiento de los mismos o a revocar el
            consentimiento que para dicho fin nos haya otorgado.</p>
        <p>
            Para ello, es necesario que envíe la solicitud en los términos que marca la Ley
            en su Art. 29 a Sistemas de Descanso säng, S.A.P.I. de C.V., a la atención de Mauricio
            Floresmeyer Llausás, responsable de nuestro Departamento de Protección de Datos
            Personales, ubicado en Av. Vasco de Quiroga 3900 Torre A, Piso 10B Col. Lomas de
            Santa Fe, México, D.F. 05300 o vía correo electrónico a mj.floresmeyer@sang.mx,
            el cual deberá recibir confirmación de nuestra parte vía correo electrónico, en
            caso de no recibirla deberá usar el otro medio disponible. En caso de que no desee
            de recibir mensajes promocionales de nuestra parte, puede enviarnos su solicitud
            por medio de la dirección electrónica: mj.floresmeyer@sang.mx.
        </p>
        <p>
            Importante: Cualquier modificación a este Aviso de Privacidad podrá consultarlo
            en <a href="http://www.sang.mx" target="_self">www.sang.mx</a>
        </p>
        <p>
            Fecha de última actualización: 03/12/2012</p>
                            </div>
                          </figcaption>
                        </figure>
                            </div>
                        </li>
                        <li name="coleccion">
                            <h2>
                                <a href="#coleccion" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_colecciones.jpg',1)">
                                    <img src="Content/img-demo/menu/menu_colecciones.png" width="60" height="400" id="menusang"></a></h2>
                            <div>
                                <figure>
                          <img src="Content/img-demo/bg_images/Colecciones.png" alt="image" width="800" />
                            
                            <figcaption>
                            <br /><br />
                            <img src="Content/img-demo/titulo_colecciones.png" width="228" height="43" style="padding-top:5px; padding-left:25px">
                            
                            <br />
                            
                            <table class="black_table1" style="margin-top:42px; margin-left:34px; padding:0px">
                            	
  								<tr style="padding:0px">
                                
                                <td width="21%" style="color:#2a2a2a; vertical-align:top; font-size:20px; font-weight:lighter; padding:0px;">
                                La única<br />colección<br />que reúne lujo<br /> y descanso.<br /><br /><br />
                                <img src="../../Content/img-demo/logo_lixresten.png" width="153" height="36" style="margin-top:45px; padding:0px;" />
                                </td>
                                
    							<td width="20%" style="color:#2a2a2a; vertical-align:top; font-size:20px; font-weight:lighter; padding:0px;">
                                Diseño especial<br />para un descanso<br />diferente.<br /><br /><br />
                                <img src="../../Content/img-demo/logo_elitenresten.png" width="181" height="29" style="margin-top:68px"/>
                                </td>
                                
    							<td width="28%" style="color:#2a2a2a; vertical-align:top; font-size:20px; font-weight:lighter; padding:0px;">
                                La primera<br />colección,<br />para el primer<br />gran descanso.<br /><br /><br />
                                <img src="../../Content/img-demo/logo_overdelresten.png" width="189" height="28" style="margin-top:45px"/>
                                </td>
  								
                                </tr>
                                
							</table>
                            
                          </figcaption>
                          
                        </figure>
                            </div>
                        </li>
                        <li name="sang">
                            <h2>
                                <a href="#sang" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_sang.png',1)">
                                    <img src="Content/img-demo/menu/menu_sang.png" width="60" height="400" id="menusang"></a></h2>
                            <div>
                                <figure>
                            <img src="Content/img-demo/bg_images/queEsSang.jpg" alt="image" width="800" />
                            <figcaption>
                            
                            <br /><br />
                            
                            <img src="Content/img-demo/queEsSang.png" width="200" height="99" style="text-align:center; margin-left:225px; margin-top:20px;">
							
                            <!-- Slideshow HTML -->
  								<div id="slideshow_sang">
    									<div id="slidesContainer_sang">
      										<div class="sang">
       										
                                            <table class="black_table1" style="margin-top:0px">
                            	
  								<tr>
    							<td style="color:#737373; vertical-align: text-top; text-align:justify;" width="50%"><span class="dropcap">S</span><span class="dropcap_sang">äng</span> <span style="font-weight:lighter;">está inspirado en el alto estándar de calidad de vida que se da en la región nórdica. Por sus condiciones geográficas y localización en la Europa Septentrional, esta región experimenta condiciones climáticas extremas que le han llevado a desarrollar soluciones en pro del bienestar de la persona, entre ellas sistemas para el perfecto descanso.</span></td>
                                
    							<td style="color:#737373; vertical-align: text-top; text-align:justify;" width="50%"><span style="font-weight:lighter;">La colección</span> <span class="dropcap">S</span><span class="dropcap_sang">äng</span> <span style="font-weight:lighter;">es un conjunto de piezas concebidas para los diferentes gustos y estilos de descanso. Son piezas pensadas para usted por que creemos que el confort es una noción muy personal. La audacia e imaginación son esencia  de cada colección rompiendo la monotonía del descanso en su funcionalidad y estética.</span></td>
  								</tr>
							</table>
                                        
                                        </div>
                                        
                                  <div class="sang">
       										<table class="black_table2" style="margin-top:0px;">
                            	
  								<tr>
    							<td style="color:#737373; font-weight:lighter; text-align:justify;">
                                Säng es la personalización en el diseño cuidando cada detalle, esmerándose en la excelencia del confort, en las formas, la cromática y los contrastes, las texturas y los acabados, todo ello combinado con estampados y tejidos de arte creados en exclusiva por un grupo de diseñadores. 
                                </td>
                                </tr>
                                
                                <tr>
    							<td style="color:#737373; font-weight:lighter;">
                                  <img src="Content/img-demo/queEsSANG-2.png" width="635" height="62" style="margin-left:0px" /></td>
  								</tr>
							</table>
                                      </div>
    								</div>
  								</div>
  							<!-- Slideshow HTML -->
                            </figcaption>
                        </figure>
                            </div>
                        </li>
                        <li name="iniciar">
                            <h2>
                                <a href="#iniciar" onclick="MM_swapImage('myimage','','Content/img-demo/a/0-1.png',1)">
                                    <img src="Content/img-demo/menu/00.png" width="60" height="400" id="menusang"></a></h2>
                            <div>
                                <figure>
                            <img src="Content/img-demo/bg_images/home.jpg" alt="image" width="800" style="margin-left:55px" />
                            <figcaption></figcaption>
                        </figure>
                            </div>
                        </li>
                    </ol>
                </div>
            </div>
            <!-- end content -->
            <div class="clearfix">
            </div>
            <p align="right">
                <span style="margin-right: 40px; font-size: 9px; color: #999;">© säng | Derechos Reservados</span></p>
        </div>
        <!-- end contentwrap -->
        <div id="custom_controls">
            <div class="menuizquierda">
                <a href="#iniciar" onclick="MM_swapImage('myimage','','Content/img-demo/a/0-1.png',1)">
                    Inicio</a></div>
            <div class="menus">
                <a href="#sang" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_sang.png',1)">
                    Säng</a></div>
            <div class="menus">
                <a href="#coleccion" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_colecciones.jpg',1)">
                    Colecciones</a></div>
            <div class="menus">
                <a href="#productos" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_productos.png',1)">
                    Productos</a></div>
            <div class="menus">
                <a href="#disenio" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_diseniadores.png',1)">
                    Diseñadores</a></div>
            <div class="menus">
                <a href="#garantia" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_garantia.png',1)">
                    Garantía</a></div>
            <div class="menus">
                <a href="#news" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_newsletter.png',1)">
                    Newsletter</a></div>
            <div class="menus">
                <a href="#aviso" onclick="MM_swapImage('myimage','','Content/img-demo/a/a_newsletter.png',1)">
                    Aviso de privacidad</a></div>
            <div class="menubtn">
                <a href="#">
                    <img src="../../Content/images/facebook_dark_small.png" class="ttip" width="20" height="20"
                        style="border: none; margin-left: 10px;" title="Síguenos en Facebook" /></a>
                <a href="#">
                    <%--<img src="Content/img-demo/twitter.png" class="ttip" width="20" height="20" style="border: none;
                                margin-left: 10px;" title="Síguenos en Twitter" /></a>--%>
            </div>
            <%--<div class="menubtn1">
                <a href="#">
                    <img src="Content/img-demo/play.png" width="20" height="20" style="border: none;" /></a>
                <a href="#">
                    <img src="Content/img-demo/pause.png" width="20" height="20" style="border: none;
                        margin-left: 10px; margin-right: 25px;" /></a></div>--%>
        </div>
        <div class="clearboth">
        </div>
    </div>
    <!-- liteAccordion demos -->
    <script>
        (function ($) {
            // demos
            $('.two-third').liteAccordion({
                onTriggerSlide: function () {
                    this.find('').fadeOut();
                },
                onSlideAnimComplete: function () {
                    this.find('figcaption').fadeIn();
                },

                autoPlay: false,
                pauseOnHover: false,
                theme: 'stitch',
                rounded: false,
                firstSlide: 8, //the number of the loaded slide
                linkable: true,
                enumerateSlides: false
            }).find('figcaption:first').show();



        })(jQuery);  
    </script>
    <!-- syntax highlighter -->
    <script src="http://nicolahibbert.com/demo/liteAccordion/js/shCore.js"></script>
    <script src="http://alexgorbatchev.com.s3.amazonaws.com/pub/sh/3.0.83/scripts/shBrushXml.js"></script>
    <script src="http://alexgorbatchev.com.s3.amazonaws.com/pub/sh/3.0.83/scripts/shBrushJScript.js"></script>
    <script>        SyntaxHighlighter.all();</script>
    <script>
        $(window).load(function () {
            mCustomScrollbars();
        });

        function mCustomScrollbars() {
            /* 
            malihu custom scrollbar function parameters: 
            1) scroll type (values: "vertical" or "horizontal")
            2) scroll easing amount (0 for no easing) 
            3) scroll easing type 
            4) extra bottom scrolling space for vertical scroll type only (minimum value: 1)
            5) scrollbar height/width adjustment (values: "auto" or "fixed")
            6) mouse-wheel support (values: "yes" or "no")
            7) scrolling via buttons support (values: "yes" or "no")
            8) buttons scrolling speed (values: 1-20, 1 being the slowest)
            */
            $("#mcs_container").mCustomScrollbar("vertical", 300, "easeOutCirc", 1.05, "auto", "yes", "yes", 15);
            $("#mcs2_container").mCustomScrollbar("vertical", 300, "easeOutCirc", 1.05, "auto", "yes", "yes", 15);
            $("#mcs3_container").mCustomScrollbar("vertical", 300, "easeOutCirc", 1.05, "auto", "yes", "yes", 15);
            $("#mcs4_container").mCustomScrollbar("vertical", 300, "easeOutCirc", 1.05, "auto", "yes", "yes", 15);
            $("#mcs5_container").mCustomScrollbar("vertical", 300, "easeOutCirc", 1.05, "auto", "yes", "yes", 15);
        }

        /* function to fix the -10000 pixel limit of jquery.animate */
        $.fx.prototype.cur = function () {
            if (this.elem[this.prop] != null && (!this.elem.style || this.elem.style[this.prop] == null)) {
                return this.elem[this.prop];
            }
            var r = parseFloat(jQuery.css(this.elem, this.prop));
            return typeof r == 'undefined' ? 0 : r;
        }

        /* function to load new content dynamically */
        function LoadNewContent(id, file) {
            $("#" + id + " .customScrollBox .content").load(file, function () {
                mCustomScrollbars();
            });
        }
    </script>
    <script src="Content/js/jquery.mCustomScrollbar.js"></script>
    <!-- Analytics -->
    <script type="text/javascript">

        var _gaq = _gaq || [];
        var pluginUrl = '//www.google-analytics.com/plugins/ga/inpage_linkid.js';
        _gaq.push(['_require', 'inpage_linkid', pluginUrl]);
        _gaq.push(['_setAccount', 'UA-36828589-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>
</body>
</html>
