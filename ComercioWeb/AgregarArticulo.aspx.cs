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

                    // MODIFICAR UN ARTÍCULO
                    if (Request.QueryString["id"] != null && !IsPostBack)  //si viene el querystring con un id..
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        List<Articulo> lista = negocio.listar(Request.QueryString["id"].ToString());
                        Articulo seleccionado = lista[0];

                        // Pre carga de los datos en el Form:
                        txtId.Text = Request.QueryString["id"];
                        txtNombre.Text = seleccionado.Nombre;
                        txtCodigo.Text = seleccionado.Codigo;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtPrecio.Text = seleccionado.Precio.ToString();
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        txtUrlImagenUrl_TextChanged(sender, e);
                        txtUrlImagenUrl.Text = seleccionado.ImagenUrl;
                    }
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

                if (Request.QueryString["id"] != null)
                {
                    nuevoArticulo.Id = int.Parse(txtId.Text);
                    negocio.modificarConStored(nuevoArticulo);
                }
                else
                {
                    negocio.agregarConStored(nuevoArticulo);
                }
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
            imgArticulo.ImageUrl = txtUrlImagenUrl.Text;
        }
    }
}