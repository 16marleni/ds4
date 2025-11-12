<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio153.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Introduzca un Texto</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="171px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" style="margin-left: 13px" Text="Enviar Saludo!" Width="135px" />
        </p>
    </form>
</body>
</html>
