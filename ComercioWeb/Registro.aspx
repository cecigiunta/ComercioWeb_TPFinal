<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ComercioWeb.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>¿No tenés una cuenta? ¡Registrate!</h1>

    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox ID="txtEmailRegistro" runat="server" placeholder="ejemplo@gmail.com" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox ID="txtPasswordRegistro" runat="server" placeholder="********" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="TuNombre" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" placeholder="TuApellido" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Imagen</label>
            <asp:TextBox ID="txtImagenPerfil" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" CssClass="btn btn-primary" />
        <a href="/">Cancelar</a>

    </div>



</asp:Content>
