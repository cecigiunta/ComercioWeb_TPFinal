<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ComercioWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>DEFAULT PAGE!</h2>

    <div class="container text-center">
        <div class="row">



            <% foreach (dominio.Articulo item in listaArticulos)
                {  %>

            <div class="card m-3" style="width: 18rem;">
                <img src="<%: item.ImagenUrl  %>" class="card-img-top" alt="imagen articulo">
                <div class="card-body">
                    <h5 class="card-title"><%: item.Nombre  %></h5>
                    <p class="card-text">"<%: item.Descripcion  %>".</p>
                </div>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item text-bold">$ <%: item.Precio  %></li>
                </ul>
                <div class="card-body">
                    <a href="DetalleArticulo.aspx" class="card-link">Ver Detalle</a>
                    <asp:Button ID="btnFavorito" CssClass="btn btn-danger" runat="server" Text="Agregar a Favoritos" />
                </div>
            </div>

            <% }  %>
        </div>

    </div>
</asp:Content>
