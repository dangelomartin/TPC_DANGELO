using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebComercio
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargartodo();
        }

        public void cargartodo()
        {
            AccesoDatosMaster ac = new AccesoDatosMaster();
            DataSet ds = ac.dataSet("select usuario, pass, intentos, tipo from Users");
            dlUsuarios.DataSource = ds.Tables[0];
            dlUsuarios.DataBind();

            //if (null != this.dlUsuarios.HeaderRow)
            //    this.dlUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }
}