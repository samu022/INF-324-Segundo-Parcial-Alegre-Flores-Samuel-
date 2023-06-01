<?php
/*
http://localhost/segundoparcialworkflow/mflujo.php?flujo=F1&proceso=P1
*/
include "conexion.inc.php";
$flujo=$_GET["flujo"];
$proceso=$_GET["proceso"];
 
session_start();


$sql="SELECT * FROM flujo ";
$sql.="WHERE flujo='$flujo' and proceso='$proceso'";
$resultado=mysqli_query($con,$sql);
$registros=mysqli_fetch_array($resultado);
$pantalla=$registros["pantalla"];

?>

<html>
<head>
	<title>Proceso de inscripción a materias</title>
	<style>
		body {
			font-family: Arial, sans-serif;
			background-color: #f0f0f0;
		}

		form {
			background-color: #fff;
			border: 1px solid #ccc;
			padding: 20px;
			width: 600px;
			margin: 0 auto;
			margin-top: 50px;
			text-align: center;
		}

		h1 {
			color: blue;
			font-size: 24px;
			margin-bottom: 10px;
		}

		input[type="submit"] {
			background-color: #4CAF50;
			color: #fff;
			border: none;
			padding: 10px 20px;
			cursor: pointer;
			font-size: 16px;
			margin: 10px;
		}

		input[type="submit"]:hover {
			background-color: #45a049;
		}

		input[type="hidden"] {
			display: none;
		}
		
	</style>
</head>
<body>
	
	<form action="motor.php" method="GET"> 
		<?php include $pantalla.".php"; ?><br/>
		<input type="hidden" name="pantalla" value="<?php echo $pantalla; ?>">
		<input type="hidden" name="flujo" value="<?php echo $flujo; ?>">
		<input type="hidden" name="proceso" value="<?php echo $proceso; ?>">
		<input type="submit" value="Anterior" name="Anterior">
		<input type="submit" value="Siguiente" name="Siguiente">
	</form>
</body>
</html>
