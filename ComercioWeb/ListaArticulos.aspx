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



    <asp:GridView ID="dgvArticulos" CssClass="table" 
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" DataKeyNames="Id"
        AutoGenerateColumns="false" runat="server">

        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />

            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Ver Detalle" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="EDITAR" />

        </Columns>



    </asp:GridView>

    <a href="AgregarArticulo.aspx" class="btn btn-primary" tabindex="-1" role="button" aria-disabled="true">Agregar Articulo</a>
</asp:Content>
