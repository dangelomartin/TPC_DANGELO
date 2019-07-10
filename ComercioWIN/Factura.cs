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
using Dominio.Models;

namespace ComercioWIN
{
    public partial class Factura : Form
    {
        private DataTable dt;

        public List<DetalleArticulo> detalleArticulos = new List<DetalleArticulo>();
        public Factura()
        {
            DetalleVentaNegocio DVN = new DetalleVentaNegocio();
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Cod");
            dt.Columns.Add("Cant");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("P.U.");
            dt.Columns.Add("total");


            dgvDetalleArticulo.DataSource = dt;
            dgvDetalleArticulo.Columns[0].Width = 50;
            dgvDetalleArticulo.Columns[1].Width = 50;
            dgvDetalleArticulo.Columns[2].Width = 200;
            dgvDetalleArticulo.Columns[3].Width = 50;
            dgvDetalleArticulo.Columns[4].Width = 50;
            txtNumFactura.Text = DVN.NumFactura().ToString();

        }
        Articulo ArtAgregar = new Articulo();
        Cliente clienteLocal = new Cliente();
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarClientesLite BuscarCliente = new ListarClientesLite();
            clienteLocal = BuscarCliente.ClienteSelect(true);

            if (clienteLocal != null)

            {
                txtcliente.Text = clienteLocal.Nombre;
                txtCantidad.Enabled = true;
            }
            else
            {
                clienteLocal = BuscarCliente.ClienteSelect(true);
            }
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregaArt_Click(object sender, EventArgs e)
        {

            ListarArticulosLite BuscarArt = new ListarArticulosLite();
            ArtAgregar = BuscarArt.ArtSelect(true);
            bool existe = false;
            if (ArtAgregar.id != 0)
            {
                //txtCodigo.Text = ArtAgregar.id.ToString();
                //txtDescri.Text = ArtAgregar.Descripcion1;
                foreach (DataGridViewRow row2 in dgvDetalleArticulo.Rows)
                {
                    if (row2.Cells["Cod"].Value.ToString() == ArtAgregar.id.ToString())
                    {
                        row2.Cells["Cant"].Value = Convert.ToInt32(row2.Cells["Cant"].Value) + Convert.ToInt32(txtCantidad.Text.Replace(".",","));
                        row2.Cells["total"].Value = Convert.ToDecimal(row2.Cells["Cant"].Value) * Convert.ToDecimal(row2.Cells["P.U."].Value);
                        existe = true;
                    }
                }
                if (existe == false)
                {
                    decimal total = (decimal.Parse(txtCantidad.Text.Replace(".", ",")) * ArtAgregar.PrecioPublico);
                    dt.Rows.Add(ArtAgregar.id, txtCantidad.Text, ArtAgregar.Descripcion, ArtAgregar.PrecioPublico, total.ToString());
                }
                decimal final = 0;
                foreach (DataGridViewRow row in dgvDetalleArticulo.Rows)
                {
                    if (row.Cells["total"].Value != null)
                        final += Convert.ToDecimal(row.Cells["total"].Value);

                }
                txtFinal.Text = final.ToString();
                txtCantidad.Text = "";
            }
            else
            {

            }


        }



        private void Factura_Load(object sender, EventArgs e)
        {

        }

        private void dgvDetalleArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFinal.Text != "")
                {
                    DetalleArticulo ArticuloVendido = new DetalleArticulo();
                    DetalleVentaNegocio negocio = new DetalleVentaNegocio();
                    FacturaVenta factura = new FacturaVenta();
                    Articulo ART = new Articulo();
                    ArticuloNegocio articulonegocio = new ArticuloNegocio();

                    factura.cliente = clienteLocal;
                    factura.idfact = negocio.NumFactura();
                    factura.importe = Convert.ToDecimal(txtFinal.Text);
                    negocio.AgregarVenta(factura);

                    foreach (DataGridViewRow row3 in dgvDetalleArticulo.Rows)
                    {
                        ArticuloVendido.articulo = new Articulo();
                        ArticuloVendido.articulo.id = Convert.ToInt32(row3.Cells["Cod"].Value);
                        ArticuloVendido.preciounit = Convert.ToDecimal(row3.Cells["P.U."].Value);
                        ArticuloVendido.cantidad = Convert.ToInt32(row3.Cells["Cant"].Value);
                        ArticuloVendido.idfactura = factura.idfact;
                        ART.id = Convert.ToInt32(row3.Cells["Cod"].Value);
                        ART.StockActual = Convert.ToInt32(row3.Cells["Cant"].Value);
                        negocio.AgregarArticulo(ArticuloVendido, factura.idfact);
                        //articulonegocio.bajarStock(ART);
                    }
                        AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
                        DataSet ds = accesoDatos.dataSet("exec reporte "+ factura.idfact);
                        Report rp = new Report();
                        rp.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];
                        rp.ShowDialog();
                    Close();
                    
                    
          
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            

            }
        

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                
                btnAgregaArt.Enabled = false;
                
            }
            else btnAgregaArt.Enabled = true;
           
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }

        private void txtcliente_TextChanged(object sender, EventArgs e)
        {
            if(txtcliente.Text == "")
            {
                lblSelec.Visible = true;
            }else
            {
                lblSelec.Visible = false;
            }
        }

        private void btnBorrarArt_Click(object sender, EventArgs e)
        {
            if (dgvDetalleArticulo.CurrentCell != null)
            {
                int rowIndex = dgvDetalleArticulo.CurrentCell.RowIndex;
                dgvDetalleArticulo.Rows.RemoveAt(rowIndex);
            }
        }

        private void txtNumFactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
