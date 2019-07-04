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

                txtDescri1.Text = articuloLocal.Descripcion;
                txtCodBarras.Text = articuloLocal.codBarras.ToString();
                txtMarca.Text = articuloLocal.Marca.Descripcion;
                txtRubro.Text = articuloLocal.Rubro.Descripcion;
                txtProveedor.Text = articuloLocal.Proveedor.Nombre;
                txtStockmin.Text = articuloLocal.StockMin.ToString();
                txtStockmax.Text = articuloLocal.StockMax.ToString();
                txtCost.Text = articuloLocal.Costo.ToString();
                txtGanancia.Text = articuloLocal.Ganancia.ToString();
                txtPrecio.Text = articuloLocal.PrecioPublico.ToString();
                txtStockActual.Text = articuloLocal.StockActual.ToString();
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
