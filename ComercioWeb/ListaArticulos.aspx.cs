using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace ComercioWeb
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //validacion ADMIN
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Se requiere permisos de Administrador para poder acceder");

                Response.Redirect("Error.aspx", false);
            }


            filtroAvanzado = chkAvanzado.Checked;

            if (!IsPostBack)
            {
                filtroAvanzado = false;
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConStored());

                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarArticulo.aspx?id=" + id);
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtFiltroRapido.Text.ToLower()));

            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chkAvanzado.Checked;
            txtFiltroRapido.Enabled = !filtroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }

        }

        protected void btnBuscarFiltroAv_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrarConDB(
                                                ddlCampo.SelectedItem.ToString(),
                                                ddlCriterio.SelectedItem.ToString(),
                                                txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}