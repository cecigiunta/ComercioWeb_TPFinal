<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="ComercioWeb.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <h1>Lista Articulos</h1>

    <%--FILTRO--%>
    <div>
        <asp:Label ID="lblFiltroRapido" runat="server" Text="Filtrar"></asp:Label>
        <asp:TextBox ID="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" runat="server"></asp:TextBox>
    </div>

    <%--FILTRO AVANZADO--%>
    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:Label runat="server" Text="Filtro Avanzado"></asp:Label>
            <asp:CheckBox ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
        </div>
    </div>

      <% if (chkAvanzado.Checked)
        {     %>

    <div class="row">

        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Campo"></asp:Label>
                <asp:DropDownList ID="ddlCampo" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoría" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Criterio"></asp:Label>
                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Filtro"></asp:Label>
                <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button ID="btnBuscarFiltroAv" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBuscarFiltroAv_Click" />
                </div>
            </div>
        </div>

        <% } %>
    </div>




    <asp:UpdatePanel ID="UPLista" runat="server">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>

    <a href="AgregarArticulo.aspx" class="btn btn-primary" tabindex="-1" role="button" aria-disabled="true">Agregar Articulo</a>
</asp:Content>
