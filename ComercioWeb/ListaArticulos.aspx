<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="ComercioWeb.ListaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista Articulos</h1>

    <asp:GridView ID="dgvArticulos" CssClass="table" AutoGenerateColumns="false" runat="server">






    </asp:GridView>



</asp:Content>
