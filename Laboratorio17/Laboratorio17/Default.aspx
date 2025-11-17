<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio17._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        <div class="row">
        <asp:GridView ID="MyGridView" DataSourceID="MyDataSource1"
            AllowSorting="true" AllowPaging="true"
            DataKeyNames="ProductID"
            AutoGenerateEditButton="true"
        Runat="Server" />
        

       <asp:SqlDataSource ID="MyDataSource1" runat="server"
            ConnectionString="data source=16MARLENI\SQLEXPRESS;initial catalog=northwind; persist security info=True; Integrated Security=SSPI;"
            ProviderName="System.Data.SqlClient"
            SelectCommand="SELECT ProductID, ProductName, UnitPrice FROM Products"
            UpdateCommand="UPDATE Products SET ProductName=@ProductName, UnitPrice=@UnitPrice WHERE ProductID=@ProductID">
       </asp:SqlDataSource>
  
       </div>

</asp:Content>
