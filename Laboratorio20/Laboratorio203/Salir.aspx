<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salir.aspx.cs" Inherits="Laboratorio203.Salir" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Salir</title>
</head>
<body>
    <form id="form1" runat="server"> <!--form1 es obligatorio para que los botones funcionen-->
        <h2>¡Gracias por usar la aplicación!</h2>
        <asp:Button ID="btnVolver" runat="server" Text="Volver al Inicio" OnClick="btnVolver_Click" />
    </form>
</body>
</html>
