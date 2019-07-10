using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace ComercioWIN
{
    public partial class Reimprimir : Form
    {
        public Reimprimir()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNumFact.Text != "")
            {
                DetalleVentaNegocio negocio = new DetalleVentaNegocio();

                if (negocio.ValidarFactura(int.Parse(txtNumFact.Text)))
                {
                    AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
                    DataSet ds = accesoDatos.dataSet("exec reporte " + txtNumFact.Text);
                    Report rp = new Report();
                    rp.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];
                    rp.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("EL COMPROBANTE NO EXISTE");
                }
            }
            else
            {
                MessageBox.Show("INGRESE UN NUMERO DE FACTURA");
            }
        }
    }
}
