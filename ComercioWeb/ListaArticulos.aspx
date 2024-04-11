<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="ComercioWeb.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista Articulos</h1>

    <%--FILTRO--%>
    <div>
        <asp:Label ID="lblFiltroRapido" runat="server" Text="Filtrar"></asp:Label>
        <asp:TextBox ID="txtFiltroRapido" runat="server"></asp:TextBox>
    </div>



    <asp:GridView ID="dgvArticulos" CssClass="table" AutoGenerateColumns="false" runat="server">

        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />

            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="EDITAR" />

        </Columns>



    </asp:GridView>

    <asp:Button ID="btnAgregarProducto" CssClass="btn btn-primary" runat="server" Text="Agregar Producto" />


</asp:Content>
