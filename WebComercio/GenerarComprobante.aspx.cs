
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
        
    protected void Page_Load(object sender, EventArgs e)
        {
        
        }
        [WebMethod]
        public static List<ArticuloWeb> ListarArticulo()
        {
            List<ArticuloWeb> Lista = null;
            try
            {
            DetalleVentaNegocio negocio = new DetalleVentaNegocio();
                Lista = negocio.ArticulosXComprobante(3);
            }
            catch (Exception ex)
            {
                Lista = new List<ArticuloWeb>();
            }
            return Lista;
        }

    }
}