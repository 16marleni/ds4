<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Proyecto223.WebForm1" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web API Calculadora</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        #ListBox1 {
            font-family: 'Courier New', monospace;
        }
        .button-container {
            margin: 10px 0;
        }
        button, input[type="submit"] {
            margin: 5px;
            padding: 8px 15px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Proyecto 2 - Web API Calculadora</h2>

        <asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="600px"></asp:ListBox>
        <br />
        <br />

        <div class="button-container">
            <asp:Button ID="btnSumas" runat="server" Text="Sumas" OnClick="btnSumas_Click" />
            <asp:Button ID="btnRestas" runat="server" Text="Restas" OnClick="btnRestas_Click" />
            <asp:Button ID="btnMultiplicaciones" runat="server" Text="Multiplicaciones" OnClick="btnMultiplicaciones_Click" />
            <asp:Button ID="btnDivisiones" runat="server" Text="Divisiones" OnClick="btnDivisiones_Click" />
            <asp:Button ID="btnTodos" runat="server" Text="Todos" OnClick="btnTodos_Click" />
            <asp:Button ID="btnRecientes" runat="server" OnClick="btnRecientes_Click" Text="Recientes" />
        </div>
    </form>
</body>
</html>