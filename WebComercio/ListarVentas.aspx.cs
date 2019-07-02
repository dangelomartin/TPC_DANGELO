using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using AccesoDatos;
using System.Data;

namespace WebComercio
{
    public partial class ListarVentas : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void cargartodo()
        {
            AccesoDatosMaster ac = new AccesoDatosMaster();
            DataSet ds = ac.dataSet("select d.idFactura as NumFactura, d.Fecha, c.nombre as Cliente, d.importe from DetalleVenta as d inner join CLIENTES as c on c.id=d.IdCliente");
            dlListaVentas.DataSource = ds.Tables[0];
            dlListaVentas.DataBind();
        }

        protected void dlListaVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            string desde = CalDesde.SelectedDate.ToShortDateString();
            string hasta = CalHasta.SelectedDate.AddDays(1).ToShortDateString();
            DetalleVentaNegocio dv = new DetalleVentaNegocio();
            AccesoDatosMaster ac = new AccesoDatosMaster();
            if(desde != "1/1/0001" && hasta != "2/1/0001")
            {
                DataSet ds = ac.dataSet("exec SP_FECHACLIENTE '" + desde + "','" + hasta+"','%"+ txtCliente.Text +"%'");
                dlListaVentas.DataSource = ds.Tables[0];
                dlListaVentas.DataBind();
            }
            else
            {
                DataSet ds = ac.dataSet("exec SP_NUMFACTU " + "-1");
                dlListaVentas.DataSource = ds.Tables[0];
                dlListaVentas.DataBind();
            }
            desde = null;
            hasta = null;
        }

        

        protected void btnTodo_Click(object sender, EventArgs e)
        {
            cargartodo();
        }

        protected void btnNumFact_Click(object sender, EventArgs e)
        {
            AccesoDatosMaster ac = new AccesoDatosMaster();
            if (txtNumFactura.Text !="")
            {
                DataSet ds = ac.dataSet("exec SP_NUMFACTU " + int.Parse(txtNumFactura.Text));
                dlListaVentas.DataSource = ds.Tables[0];
                dlListaVentas.DataBind();
            } else
            {
                DataSet ds = ac.dataSet("exec SP_NUMFACTU " + "-1");
                dlListaVentas.DataSource = ds.Tables[0];
                dlListaVentas.DataBind();
            }
            
        }
    }
}