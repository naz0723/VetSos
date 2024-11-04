<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dueño.aspx.cs" Inherits="Dueño" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Registrar Dueño</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <div class="container">
        <h1>Registrar Dueño</h1>
        <form id="form1" runat="server">
            <label for="nombre">Nombre:</label>
            <input type="text" id="nombre" runat="server" />
            
            <label for="apellido">Apellido:</label>
            <input type="text" id="apellido" runat="server" />
            
            <label for="direccion">Dirección:</label>
            <input type="text" id="direccion" runat="server" />
            
            <label for="telefono">Teléfono:</label>
            <input type="text" id="telefono" runat="server" />
            
            <label for="email">Email:</label>
            <input type="email" id="email" runat="server" />
            
            <label for="identificacion">Identificación:</label>
            <input type="text" id="identificacion" runat="server" />
            
            <button type="submit">Guardar</button>
        </form>
    </div>
</body>
</html>

