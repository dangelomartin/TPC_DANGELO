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
    public partial class CompletoArticulo : Form
    {
        private Articulo articuloLocal = null;        
        public CompletoArticulo()
        {
            InitializeComponent();
        }
        public CompletoArticulo(Articulo articulo)
        {
            InitializeComponent();
            articuloLocal = articulo;
        }

        private void CompletoArticulo_Load(object sender, EventArgs e)
        {
            try
            {

                txtDescri1.Text = articuloLocal.Descripcion1;
                txtCodBarras.Text = articuloLocal.codBarras.ToString();
                txtMarca.Text = articuloLocal.Marca.Descripcion;
                txtRubro.Text = articuloLocal.Rubro.Descripcion;
                txtProveedor.Text = articuloLocal.Proveedor.Nombre;
                txtStockmin.Text = articuloLocal.StockMin.ToString();
                txtStockmax.Text = articuloLocal.StockMax.ToString();
                txtCost.Text = articuloLocal.Costo.ToString();
                txtIva.Text = articuloLocal.Iva.Descripcion;
                txtDesc1.Text = articuloLocal.Descuento1.ToString();
                txtDesc2.Text = articuloLocal.Descuento2.ToString();
                txtDesc3.Text = articuloLocal.Descuento3.ToString();
                txtDesc4.Text = articuloLocal.Descuento4.ToString();
                txtGanancia.Text = articuloLocal.Ganancia.ToString();
                txtPrecio.Text = articuloLocal.PrecioPublico.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bntAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
