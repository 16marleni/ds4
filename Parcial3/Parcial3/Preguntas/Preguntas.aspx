<%@ Page Title="Gestión de Preguntas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Preguntas.aspx.cs" Inherits="Parcial3.Preguntas.Preguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-primary">Gestión de Preguntas</h2>
    <br />

    <div class="row">

        <!-- Panel del problema a resolver -->
        <div class="col-md-12 mb-4">
            <div class="card border-danger shadow-sm">
                <div class="card-header bg-danger text-white">
                    <strong>Problema a Resolver</strong>
                </div>
                <div class="card-body" style="max-height: 300px; overflow-y: auto; font-size: 0.95rem;">
                    Un bufete de abogados de tamaño mediano está enfrentando serios problemas para gestionar sus registros de casos legales. Actualmente, los abogados y el personal administrativo están utilizando hojas de cálculo y documentos de texto para llevar el control de los casos. Este sistema manual es ineficiente y propenso a errores, lo que ha ocasionado retrasos en la presentación de informes, dificultades en el seguimiento de los plazos y confusión en el manejo de información importante.
                    <br /><br />
                    Algunos de los problemas específicos que enfrenta el bufete son los siguientes:
                    <ul>
                        <li>Desorganización en el manejo de los detalles de los casos (fecha de inicio, fecha de vencimiento, abogado asignado, estado del caso, clientes, etc.).</li>
                        <li>Pérdida de información importante sobre reuniones, audiencias y vencimientos de plazos legales.</li>
                        <li>Confusión con los documentos asociados a los casos (documentos legales, evidencias, etc.), ya que no se encuentran fácilmente.</li>
                        <li>Difusión de la información: el acceso a la información del caso no es centralizado, lo que provoca que algunos abogados o asistentes no tengan acceso a los datos más actualizados.</li>
                        <li>Falta de seguimiento: muchos casos tienen plazos o fechas clave que se pasan por alto debido a la falta de un sistema de alertas o recordatorios.</li>
                    </ul>
                    <strong>Tu tarea:</strong> digitalizar y optimizar el proceso de gestión de los casos mediante una solución basada en una aplicación web que utilice C# y SQL Server.
                </div>
            </div>
        </div>

        <!-- GridView para mostrar preguntas (solo respuesta editable) -->
        <div class="col-md-12">
            <asp:GridView ID="gvPreguntas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" Width="100%"
                DataKeyNames="Id"
                OnRowEditing="gvPreguntas_RowEditing"
                OnRowUpdating="gvPreguntas_RowUpdating"
                OnRowCancelingEdit="gvPreguntas_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" ReadOnly="True" ItemStyle-Width="500px" />
                    <asp:TemplateField HeaderText="Respuesta" ItemStyle-Width="450px">
                        <ItemTemplate>
                            <asp:Label ID="lblRespuesta" runat="server" Text='<%# Eval("Respuesta") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtRespuesta" runat="server" Text='<%# Bind("Respuesta") %>' TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="True" ItemStyle-Width="150px" />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
