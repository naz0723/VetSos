<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistorialClinico.aspx.cs" Inherits="HistorialClinico" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Historial Clínico</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <div class="container">
        <h1>Historial Clínico</h1>
        <form id="form1" runat="server">
            <label for="fechaVisita">Fecha de Visita:</label>
            <input type="date" id="fechaVisita" runat="server" />

            <label for="sintomas">Síntomas:</label>
            <textarea id="sintomas" runat="server"></textarea>

            <label for="diagnostico">Diagnóstico:</label>
            <textarea id="diagnostico" runat="server"></textarea>

            <label for="tratamiento">Tratamiento:</label>
            <textarea id="tratamiento" runat="server"></textarea>

            <label for="veterinario">Veterinario:</label>
            <input type="text" id="veterinario" runat="server" />

            <button type="submit">Guardar</button>
        </form>
    </div>
</body>
</html>
