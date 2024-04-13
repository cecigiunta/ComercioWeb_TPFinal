using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioWeb
{
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> categoria = categoriaNegocio.listar();

                    ddlCategoria.DataSource = categoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();



                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> marca = marcaNegocio.listar();

                    ddlMarca.DataSource = marca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevoArticulo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevoArticulo.Nombre = txtNombre.Text;
                nuevoArticulo.Codigo = txtCodigo.Text;
                nuevoArticulo.Descripcion = txtDescripcion.Text;
                nuevoArticulo.ImagenUrl = txtImagenUrl.Text;
                nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text);

                //para marca y categoria
                nuevoArticulo.Marca = new Marca();
                nuevoArticulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevoArticulo.Categoria = new Categoria();
                nuevoArticulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                negocio.agregarConStored(nuevoArticulo);
                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {

        }

        protected void txtUrlImagenUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}