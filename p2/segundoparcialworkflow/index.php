<html>
<head>
	<style>
		body {
			font-family: Arial, sans-serif;
			background-color: #f2f2f2;
		}
		
		form {
			width: 300px;
			margin: 0 auto;
			padding: 20px;
			background-color: #ffffff;
			border: 1px solid #ccc;
			border-radius: 5px;
		}
		
		input[type="text"],
		input[type="password"] {
			width: 100%;
			padding: 10px;
			margin-bottom: 10px;
			border: 1px solid #ccc;
			border-radius: 4px;
			box-sizing: border-box;
		}
		
		input[type="submit"] {
			width: 100%;
			padding: 10px;
			background-color: #4CAF50;
			color: white;
			border: none;
			border-radius: 4px;
			cursor: pointer;
		}
		
		input[type="submit"]:hover {
			background-color: #45a049;
		}
	</style>
</head>
<body>
	<form method="GET" action="control.php">
		Usuario
		<input type="text" name="usuario" value=""/>
		<br>
		Contraseña
		<input type="password" name="password" value=""/>
		<br>
		<input type="Submit" name="Ingresar" value="Ingresar"/>
	</form>
</body>
</html>
