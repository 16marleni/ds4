<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Laboratorio203.Productos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="content-type" content="text/html"; charset="utf-8" />
    <title></title>
</head>
<body style="height: 26px">
    <form id="form1" runat="server">
        <div id="tslBuscar" aria-setsize="20px">
            PRODUCTOS<br />
            <br />
            <asp:ImageButton ID="ImgBtnNuevo" runat="server" Height="20px" Width="20px"
                ImageUrl="~/img/nuevo.png" OnClick="ImgBtnNuevo_Click" />

            &nbsp;<asp:ImageButton ID="ImgBtnGuardar" runat="server" Height="20px" Width="20px"
                ImageUrl="~/img/guardar.png" OnClick="ImgBtnGuardar_Click" />

            &nbsp;<asp:ImageButton ID="ImgBtnCancelar" runat="server" Height="20px" Width="20px"
                ImageUrl="~/img/cancelar.png" OnClick="ImgBtnCancelar_Click" />

            &nbsp;<asp:ImageButton ID="ImgBtnEliminar" runat="server" Height="20px" Width="20px"
                ImageUrl="~/img/eliminar.png" OnClick="ImgBtnEliminar_Click" />

&nbsp;Buscar por id:&nbsp;

            <asp:TextBox ID="tstId" runat="server"></asp:TextBox>

            <asp:ImageButton ID="ImgBtnBuscar" runat="server" Height="20px" Width="20px"
                ImageUrl="~/img/buscar.png" OnClick="ImgBtnBuscar_Click" />
        </div>
        <br />
&nbsp; Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nombre<br />
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombre" runat="server" Width="295px"></asp:TextBox>
        <br />
        <br />
&nbsp; Precio&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Stock<br />
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSalir" runat="server" Text="Salir" Width="91px"
            OnClick="btnSalir_Click" />
    </form>
</body>
</html>
