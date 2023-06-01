<?php
session_start();

include "conexion.inc.php";
$sql = "select * from flujousuario ";
$sql .= "where usuario='" . $_SESSION["usuario"] . "' ";
$sql .= "and fechafin is not null ";
$resultado = mysqli_query($con, $sql);
?>
<html>
<head>
	<style>
		body {
			font-family: Arial, sans-serif;
			background-color: #f2f2f2;
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
	</style>
</head>
<body>
	<table>
		<tr>
			<th>Flujo</th>
			<th>Proceso</th>
			<th>Fecha inicio</th>
			<th>Fecha fin</th>
		</tr>
		<?php
		while ($registros = mysqli_fetch_array($resultado)) {
			echo "<tr>";
			echo "<td>" . $registros["flujo"] . "</td>";
			echo "<td>" . $registros["proceso"] . "</td>";
			echo "<td>" . $registros["fechainicio"] . "</td>";
			echo "<td>" . $registros["fechafin"] . "</td>";
			echo "</tr>";
		}
		?>
	</table>
	<br>
	<a href="bandejaE.php">Volver</a>
</body>
</html>
