<<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mascota.aspx.cs" Inherits="Mascota" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Registrar Mascota</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <div class="container">
        <h1>Registrar Mascota</h1>
        <form id="form1" runat="server">
            <label for="nombre">Nombre:</label>
            <input type="text" id="nombre" runat="server" />

            <label for="especie">Especie:</label>
            <input type="text" id="especie" runat="server" />

            <label for="raza">Raza:</label>
            <input type="text" id="raza" runat="server" />

            <label for="fechaNacimiento">Fecha de Nacimiento:</label>
            <input type="date" id="fechaNacimiento" runat="server" />

            <label for="color">Color:</label>
            <input type="text" id="color" runat="server" />

            <label for="peso">Peso:</label>
            <input type="number" step="0.01" id="peso" runat="server" />

            <label for="dueñoID">Dueño ID:</label>
            <input type="number" id="dueñoID" runat="server" />

            <button type="submit">Guardar</button>
        </form>
    </div>
</body>
</html>

