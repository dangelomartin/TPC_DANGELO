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
            Sesion.Sesion.cambiarEstado(false);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio user = new UsuarioNegocio();
            Usuarios login = new Usuarios
            {
                user = txtUsuario.Text,
                pass = txtPass.Text
            };
            UsuarioNegocio nego = new UsuarioNegocio();
            int num = nego.Datos(login,2);
            if (num == 0)
            {
                Sesion.Sesion.cambiarEstado(true);
                Response.Write("<script>alert('USUARIO CORRECTO')</script>");
                Response.Redirect("PanelGeneral.aspx");
            }
            else if (num == 1)
            {
                Response.Write("<script>alert('USUARIO O CONTRASEÑA INCORRECTOS')</script>");
            }
            else if (num == 2)
            {
                Response.Write("<script>alert('USUARIO BLOQUEADO')</script>");
            }
            else
            {
                Response.Write("<script>alert('USUARIO INEXISTENTE')</script>");
            }

        }
    }
}