<%@ Page Title="Gestión de Casos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Casos.aspx.cs" Inherits="Parcial3.Casos.Casos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-primary">Gestión de Casos</h2>
    <br />

    <asp:HiddenField ID="hfCasoId" runat="server" />

    <div class="row">
        <div class="col-md-6">

            <div class="mb-3">
                <label>Código de Caso:</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Título:</label>
                <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Descripción:</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Fecha Inicio:</label>
                <asp:TextBox ID="txtFechaInicio" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Fecha Vencimiento:</label>
                <asp:TextBox ID="txtFechaVenc" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Estado:</label>
                <asp:DropDownList ID="ddlEstado" CssClass="form-select" runat="server">
                    <asp:ListItem Text="Abierto" Value="Abierto"></asp:ListItem>
                    <asp:ListItem Text="En Proceso" Value="En Proceso"></asp:ListItem>
                    <asp:ListItem Text="Cerrado" Value="Cerrado"></asp:ListItem>
                    <asp:ListItem Text="Archivado" Value="Archivado"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label>Cliente Relacionado:</label>
                <asp:DropDownList ID="ddlCliente" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success me-2" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />

        </div>

        <div class="col-md-6">
            <asp:GridView ID="gvCasos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped"
                OnRowCommand="gvCasos_RowCommand">
                <Columns>

                    <asp:BoundField DataField="CasoId" HeaderText="ID" Visible="false" />

                    <asp:BoundField DataField="CodigoCaso" HeaderText="Código" />
                    <asp:BoundField DataField="Titulo" HeaderText="Título" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Inicio" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton Text="Editar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("CasoId") %>' CssClass="btn btn-sm btn-warning"></asp:LinkButton>
                            <asp:LinkButton Text="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("CasoId") %>' CssClass="btn btn-sm btn-danger"
                                OnClientClick="return confirm('¿Seguro que deseas eliminar este caso?');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
