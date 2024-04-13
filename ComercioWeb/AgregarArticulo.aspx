<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="ComercioWeb.AgregarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">

        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
               <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Button ID="btn_Aceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btn_Aceptar_Click" />
                <a href="ListaArticulos.aspx">Cancelar</a>

            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <asp:UpdatePanel ID="UpdatePanelArticulos" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Label ID="txtImagenUrl" runat="server" Text="Imagen"></asp:Label>
                            <asp:TextBox ID="txtUrlImagenUrl" runat="server" AutoPostBack="true"
                                OnTextChanged="txtUrlImagenUrl_TextChanged" CssClass="form-control">

                            </asp:TextBox>
                        </div>

                        <asp:Image ImageUrl="https://st3.depositphotos.com/6723736/12729/v/950/depositphotos_127297230-stock-illustration-download-sign-load-icon-load.jpg" ID="imgArticulo" runat="server" Width="60%" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
