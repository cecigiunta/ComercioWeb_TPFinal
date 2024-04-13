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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                user.Email = txtEmailRegistro.Text;
                user.Pass = txtPasswordRegistro.Text;
                user.Nombre = txtNombre.Text; 
                user.Apellido = txtApellido.Text;
                user.ImagenPerfil = txtImagenPerfil.Text;

                int id = negocio.insertarUserNuevo(user);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}