<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio154.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;SUMATORIA DE DOS NÚMEROS</div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Primer Número:"></asp:Label>
            <asp:TextBox ID="txtBNumero1" runat="server" style="margin-left: 58px" Width="75px"></asp:TextBox>
        </p>
        <asp:Label ID="Label2" runat="server" Text="Segundo Número:"></asp:Label>
        <asp:TextBox ID="txtBNumero2" runat="server" style="margin-left: 45px" Width="74px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSumar" runat="server" Height="26px" OnClick="btnSumar_Click" Text="SUMAR" Width="236px" />
        <p>
            <asp:Label ID="Label3" runat="server" Text="Resultado:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblResultado" runat="server" BackColor="#CCCCCC"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
