<?php
session_start();

include "conexion.inc.php";
$sql = "select * from flujousuario ";
$sql .= "where usuario='" . $_SESSION["usuario"] . "' ";
$sql .= "and fechafin is null ";
$resultado = mysqli_query($con, $sql);
?>
<html>
<head>
	<style>
		body {
			font-family: Arial, sans-serif;
			background-color: #f2f2f2;
			margin: 0;
      		padding: 0;
		}
		.logout {
		      float: right;
	      margin: 10px;
	      text-decoration: none;
	      color: #333;
		}
		
		table {
			width: 100%;
			border-collapse: collapse;
			margin-bottom: 20px;
		}
		
		table th, table td {
			padding: 8px;
			border: 1px solid #ccc;
		}
		
		table th {
			background-color: #f2f2f2;
			font-weight: bold;
		}
		
		table tr:nth-child(even) {
			background-color: #f9f9f9;
		}
		
		table tr:hover {
			background-color: #e5e5e5;
		}
		
		a {
			color: #0000ff;
			text-decoration: none;
		}
		
		a:hover {
			text-decoration: underline;
		}
		.button {
	        display: inline-block;
	        padding: 10px 20px;
	        background-color: #4CAF50;
	        color: white;
	        text-decoration: none;
	        border-radius: 4px;
	        border: none;
	        cursor: pointer;
	        margin: 10px;
	    }
	</style>
</head>
<body>
	<a href="cerrar.php" class="logout">Cerrar sesión</a>
	<table>
		<tr>
			<th>Flujo</th>
			<th>Proceso</th>
			<th>Operacion</th>
		</tr>
		<?php
		while ($registros = mysqli_fetch_array($resultado)) {
		    echo "<tr>";
		    echo "<td>" . $registros["flujo"] . "</td>";
		    echo "<td>" . $registros["proceso"] . "</td>";
		    echo "<td>";
		    echo "<a href='mflujo.php?flujo=" . $registros["flujo"] . "&proceso=" . $registros["proceso"] . "'>";
		    echo "Ir</a></td>";
		    echo "</tr>";

		    // Guardar la variable local en una sesión
		    $_SESSION['codtramite'] = $registros["numerotramite"];
		}
		?>
	</table>
	<br>
	<a href="nuevoflujo.php" class="button">Nuevo</a><br>
	<a href="bandejaS.php" class="button">Ver bandeja de salida</a><br>
	
</body>
</html>
