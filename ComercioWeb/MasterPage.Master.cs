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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            imgAvatar.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Default_pfp.svg";

            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
                if (!(Seguridad.sessionActiva(Session["usuario"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else  //Si HAY una session
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    lblUser.Text = usuario.Email;
                    if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                    {
                        imgAvatar.ImageUrl = "~/Images/" + ((Usuario)Session["usuario"]).ImagenPerfil;
                    }

                }

            }
        }

    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");

    }
}
}