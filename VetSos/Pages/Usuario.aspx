<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Usuario.aspx.cs" Inherits="Usuario" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Registrar Usuario</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <div class="container">
        <h1>Registrar Usuario</h1>
        <form id="form1" runat="server">
            <label for="nombre">Nombre:</label>
            <input type="text" id="nombre" runat="server" />

            <label for="apellido">Apellido:</label>
            <input type="text" id="apellido" runat="server" />

            <label for="email">Email:</label>
            <input type="email" id="email" runat="server" />

            <label for="nombreUsuario">Nombre de Usuario:</label>
            <input type="text" id="nombreUsuario" runat="server" />

            <label for="contraseña">Contraseña:</label>
            <input type="password" id="contraseña" runat="server" />

            <label for="rol">Rol:</label>
            <input type="text" id="rol" runat="server" />

            <button type="submit">Guardar</button>
        </form>
    </div>
</body>
</html>
