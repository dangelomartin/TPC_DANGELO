using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using AccesoDatos;

namespace WebComercio
{
    public partial class EditarUsuario : System.Web.UI.Page
    {

        public static string usuario=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Sesion.Sesion.estaActivo)
            {
                Response.Redirect("Login.aspx");
            }
            usuario = Request["usuario"];

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuarios usuariolocal = new Usuarios();
            usuariolocal = usuarioNegocio.BuscarUsuario(usuario);

            lblUsuario.Text = usuariolocal.user;
            txtPass.Text = usuariolocal.pass.ToString();
            txtIntentos.Text = usuariolocal.intentos.ToString();
        }
    }
}