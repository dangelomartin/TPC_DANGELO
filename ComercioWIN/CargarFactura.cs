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
    public partial class CargarFactura : Form
    {
        
        private DataTable dt;
        Articulo ArtAgregar = new Articulo();
        FacturaCompra FacturaNueva = new FacturaCompra();
        public CargarFactura()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Cod");
            dt.Columns.Add("Descripcion");
            dgvDetalleArticulo.DataSource = dt;

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
            txtDescripcion.Text = ArtAgregar.Descripcion1;
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
                        row2.Cells["Cantidad"].Value = Convert.ToInt32(row2.Cells["Cantidad"].Value) + Convert.ToInt32(txtCantidad.Text.Replace(".", ","));
                        row2.Cells["Descripcion"].Value = ArtAgregar.Descripcion1;
                        existe = true;
                    }
                }
                if (existe == false)
                {
                    dt.Rows.Add(txtCantidad.Text, ArtAgregar.id, ArtAgregar.Descripcion1);
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

            ComprasNegocio agregar = new ComprasNegocio();
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
                Precaucion form = new Precaucion();
                form.ShowDialog();
            }



        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
