
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebComercio
{

    public partial class GenerarComprobante : System.Web.UI.Page
    {
        public static int comprobante = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Sesion.Sesion.estaActivo)
            {
                Response.Redirect("Login.aspx");
            }
            comprobante = Convert.ToInt32(Request["comprobante"]);
        }

        [WebMethod]
        public static List<ArticuloWeb> ListarArticulo()
        {
            List<ArticuloWeb> Lista = null;
            try
            {
                DetalleVentaNegocio negocio = new DetalleVentaNegocio();
                Lista = negocio.ArticulosXComprobante(comprobante);
            }
            catch (Exception ex)
            {
                Lista = new List<ArticuloWeb>();
            }
            return Lista;
        }

    }
}