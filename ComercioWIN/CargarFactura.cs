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
    public partial class CargarFactura : Form
    {
        
        private DataTable dt;
        Articulo ArtAgregar = new Articulo();
        FacturaCompra FacturaNueva = new FacturaCompra();
        public CargarFactura()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Cant");
            dt.Columns.Add("Cod");
            dt.Columns.Add("Descripcion");
            dgvDetalleArticulo.DataSource = dt;
            dgvDetalleArticulo.Columns[1].Width = 50;
            dgvDetalleArticulo.Columns[0].Width = 50;
            dgvDetalleArticulo.Columns[2].Width = 200;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public Proveedor proveedorLocal = new Proveedor();
        private void btnBuscarProo_Click(object sender, EventArgs e)
        {
            ListarProveedores buscarProveedor = new ListarProveedores();
            proveedorLocal = buscarProveedor.ProveedorSelect(true);

            if(proveedorLocal != null)
            {
                txtNombreproov.Text = proveedorLocal.Nombre;
            }else
            {
                proveedorLocal = buscarProveedor.ProveedorSelect(true);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarFactura_Load(object sender, EventArgs e)
        {
            ArtAgregar = null;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleArticulo.CurrentCell != null)
            {
                int rowIndex = dgvDetalleArticulo.CurrentCell.RowIndex;
                dgvDetalleArticulo.Rows.RemoveAt(rowIndex);
            }
        }

        private void btnAgregarArt_Click(object sender, EventArgs e)
        {
            ListarArticulosLite BuscarArt = new ListarArticulosLite();
            ArtAgregar = BuscarArt.ArtSelect(true);
            txtID.Text = ArtAgregar.id.ToString();
            txtDescripcion.Text = ArtAgregar.Descripcion;
            txtCostoActual.Text = ArtAgregar.Costo.ToString();
            
        }

        private void btnAñadirLista_Click(object sender, EventArgs e)
        {
            bool existe = false;
            if (txtCantidad.Text == "")
            {
                lblIngrCant.Visible= true;
                return;
            }
            if (txtID.Text == "" || txtID.Text == "0") 
            {
                lblSelecArt.Visible = true;
                return;
            }
            if (ArtAgregar != null )
            {
                foreach (DataGridViewRow row2 in dgvDetalleArticulo.Rows)
                {
                    if (row2.Cells["Cod"].Value.ToString() == ArtAgregar.id.ToString())
                    {
                        row2.Cells["Cant"].Value = Convert.ToInt32(row2.Cells["Cant"].Value) + Convert.ToInt32(txtCantidad.Text);
                        row2.Cells["Descripcion"].Value = ArtAgregar.Descripcion;
                        existe = true;
                    }
                }
                if (existe == false)
                {
                    dt.Rows.Add(txtCantidad.Text, ArtAgregar.id, ArtAgregar.Descripcion);
                }
                lblIngrCant.Visible = false;
                lblSelecArt.Visible = false;
            }
            else
            {}
            ArtAgregar = null;
            txtCantidad.Text = "";
            txtCostoActual.Text = "";
            txtDescripcion.Text = "";
            txtID.Text = "";

        }

        private void btnModificarCosto_Click(object sender, EventArgs e)
        {
            if(ArtAgregar!=null)
            {
            AñadirArticulo articulo = new AñadirArticulo(ArtAgregar);
            articulo.ShowDialog();
            }

        }

        private void txtCostoNuevo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(ValidateC())
            {

            ComprasNegocio agregar = new ComprasNegocio();
            Articulo articuloLista = new Articulo();
            ArticuloNegocio stock = new ArticuloNegocio();
            if (proveedorLocal != null)
            {
                FacturaNueva.NumeroPuesto = txtPuesto.Text;
                FacturaNueva.NumeroComprobante = txtComprobante.Text;
                FacturaNueva.fecha = dtpFecha.Value.Date;
                FacturaNueva.Total = txtMonto.Text.Replace(",",".");
                FacturaNueva.proveedor = new Proveedor();
                FacturaNueva.proveedor.id = proveedorLocal.id;

                
            }
            if(agregar.NoExiste(FacturaNueva)==true)
            {
                agregar.AgregarCompra(FacturaNueva);
            }else
            {
                MessageBox.Show("EL COMPROBANTE INGRESADO YA EXISTE");
                return;
            }

                foreach (DataGridViewRow row in dgvDetalleArticulo.Rows)
                {
                    articuloLista.id = Convert.ToInt32(row.Cells["Cod"].Value);
                    articuloLista.StockActual = Convert.ToInt32(row.Cells["Cant"].Value);
                    stock.SubirStock(articuloLista);
                }

                Close();


            }

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }

        private void txtPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }

        private void txtComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }

        ErrorProvider ErrorProvider = new ErrorProvider();

        private bool ValidateC()
        {
            bool Valid = true;

            if (txtMonto.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtMonto, "Campo Incompleto");
            }
            if (txtPuesto.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtPuesto, "Campo Incompleto");
            }
            if (txtComprobante.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtComprobante, "Campo Incompleto");
            }

            return Valid;
        }
        }
}
