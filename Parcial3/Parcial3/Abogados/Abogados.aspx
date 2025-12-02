<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Abogados.aspx.cs" Inherits="Parcial3.Abogados.Abogados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-primary">Gestión de Abogados</h2>
    <br />

    <div class="row">
        <div class="col-md-6">
            <asp:HiddenField ID="hfAbogadoId" runat="server" />

            <div class="mb-3">
                <label>Nombre del Abogado:</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Especialidad:</label>
                <asp:TextBox ID="txtEspecialidad" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Teléfono:</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success me-2" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
        </div>

        <div class="col-md-6">
            <asp:GridView ID="gvAbogados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped"
                OnRowCommand="gvAbogados_RowCommand">
                <Columns>
                    <asp:BoundField DataField="AbogadoId" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton Text="Editar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("AbogadoId") %>' CssClass="btn btn-sm btn-warning"></asp:LinkButton>
                            <asp:LinkButton Text="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("AbogadoId") %>' CssClass="btn btn-sm btn-danger"
                                OnClientClick="return confirm('¿Seguro que deseas eliminar este abogado?');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
