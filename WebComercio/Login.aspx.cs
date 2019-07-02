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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio user = new UsuarioNegocio();
            Usuarios login = new Usuarios();
            login.user = txtUsuario.Text;
            login.pass = txtPass.Text;
            if (user.ValidarUsuario(login))
            {
                Response.Write("<script>alert('USUARIO CORRECTO')</script>");
                Response.Redirect("PanelGeneral.aspx");
            }
            else
            {
                Response.Write("<script>alert('USUARIO O CONTRASEÑA INCORRECTOS')</script>");
            }
               
        }
    }
}