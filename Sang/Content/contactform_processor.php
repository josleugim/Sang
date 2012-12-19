<?php
$email_to = "e.espino@sang.mx";
$success_message = "Mensaje enviado correctamente!";
$site_name = "S�NG The nordik way of resting <e.espino@sang.mx>";

$nombre = trim($_POST['nombre']);
$email = trim($_POST['email']);
$apellidos = trim($_POST['apellidos']);
$direccion = trim($_POST['direccion']);
$codigopostal = trim($_POST['codigopostal']);
$delegacion = trim($_POST['delegacion']);
$pais = trim($_POST['pais']);
$idioma = trim($_POST['idioma']);
$colpreferida = trim($_POST['colpreferida']);
$clientedesang = trim($_POST['clientedesang']);
$recibirinfo = trim($_POST['recibirinfo']);
$submitted = $_POST['submitted'];
	
if(isset($error)){
		echo '<span class="error_notice"><ul>';
		if($nombre_empty){
			echo '<li>Por favor escribe tu nombre</li>';
		} elseif ($email_empty) {
			echo '<li>Por favor escribe tu email</li>';
		} elseif ($email_unvalid) {
			echo '<li>Por favor escribe un email v�lido</li>';
		} elseif ($mensaje_empty) {
			echo '<li>Por favor escribe tu mensaje</li>';
		} else {
			echo '<li>Ocurri&oacute; un error intentando enviar tu mensaje. Por favor, intenta nuevamente.</li>';
		}
		echo "</ul></span>";
	}
	
	if(!isset($error)){
		$subject = 'Formulario de contacto enviado por '.$nombre;
		$body = "Nombre: $nombre \n\nApellidos: $apellidos \n\nE-mail: $email \n\nDirecci�n: $direccion \n\nC�digo Postal: $codigopostal \n\nDelegaci�n, Municipio o Ciudad: $delegacion \n\nPa�s: $pais \n\nIdioma: $idioma \n\nColecci�n: $colpreferida \n\nCliente de s�ng: $clientedesang \n\nRecibir newsletter: $recibirinfo";
		$headers = 'From: ' . $site_name . ' <' . $emailTo . '> ' . "\r\n" . 'Reply-To: ' . $email;
		mail($email_to, $subject, $body, $headers);
		
		echo '<span class="success_notice">' . $success_message . '</span>';
	}
?>