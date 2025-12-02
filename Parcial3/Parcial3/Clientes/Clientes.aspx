<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Parcial3.Clientes.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-primary">Gestión de Clientes</h2>
    <br />

    <div class="row">
        <div class="col-md-6">
            <asp:HiddenField ID="hfClienteId" runat="server" />

            <div class="mb-3">
                <label>Nombre del Cliente:</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Teléfono:</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Dirección:</label>
                <asp:TextBox ID="txtDireccion" CssClass="form-control" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Observaciones:</label>
                <asp:TextBox ID="txtObservaciones" CssClass="form-control" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success me-2" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
        </div>

        <div class="col-md-6">
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped"
                OnRowCommand="gvClientes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ClienteId" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton Text="Editar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("ClienteId") %>' CssClass="btn btn-sm btn-warning"></asp:LinkButton>
                            <asp:LinkButton Text="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("ClienteId") %>' CssClass="btn btn-sm btn-danger"
                                OnClientClick="return confirm('¿Seguro que deseas eliminar este cliente?');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>