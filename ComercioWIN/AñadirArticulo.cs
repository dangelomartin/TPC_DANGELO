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
using System.Text.RegularExpressions;
using Dominio.Models;

namespace ComercioWIN
{
    public partial class AñadirArticulo : Form
    {
        private Articulo articuloLocal = null;

        public AñadirArticulo()
        {
            InitializeComponent();
        }

        public AñadirArticulo(Articulo articulo)
        {
            InitializeComponent();
            articuloLocal = articulo;
        }

        private void AñadirArticulo_Load(object sender, EventArgs e)
        {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                RubroNegocio rubroNegocio = new RubroNegocio();
                IvaNegocio ivaNegocio = new IvaNegocio();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.ListarMarcas();
                cboRubro.DataSource = rubroNegocio.ListarRubros();
                cboIva.DataSource = ivaNegocio.ListarIva();
                cboProveedor.DataSource = proveedorNegocio.ListarProveedores();

                if(articuloLocal!=null)
                {
                    txtDescri1.Text = articuloLocal.Descripcion1;
                    txtCodBarras.Text = articuloLocal.codBarras.ToString();
                    cboMarca.SelectedItem = cboMarca.FindString(articuloLocal.Marca.Descripcion);
                    cboRubro.SelectedItem = cboRubro.FindString(articuloLocal.Rubro.Descripcion);
                    cboProveedor.SelectedItem = cboProveedor.FindString(articuloLocal.Proveedor.Nombre);
                    txtStockMin.Text = articuloLocal.StockMin.ToString();
                    txtStockMax.Text = articuloLocal.StockMax.ToString();
                    txtCosto.Text = articuloLocal.Costo.ToString();
                    cboIva.SelectedItem = cboIva.FindString(articuloLocal.Iva.Descripcion);
                    txtDes1.Text = articuloLocal.Descuento1.ToString();
                    txtDes2.Text = articuloLocal.Descuento2.ToString();
                    txtDes3.Text = articuloLocal.Descuento3.ToString();
                    txtDes4.Text = articuloLocal.Descuento4.ToString();
                    txtGanancia.Text = articuloLocal.Ganancia.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

            ArticuloNegocio articulo = new ArticuloNegocio();
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            if(ValidateC())
            {
            try
            {   if (articuloLocal == null)
                    articuloLocal = new Articulo();
                    string costo = txtCosto.Text.Replace(".", ",");
                articuloLocal.Descripcion1 = txtDescri1.Text.ToUpper();
                articuloLocal.codBarras = (int.Parse(txtCodBarras.Text));
                articuloLocal.Marca = (Marca)cboMarca.SelectedItem;
                articuloLocal.Rubro = (Rubro)cboRubro.SelectedItem;
                articuloLocal.Proveedor = (Proveedor)cboProveedor.SelectedItem;
                articuloLocal.StockMin = int.Parse(txtStockMin.Text);
                articuloLocal.StockMax = int.Parse(txtStockMax.Text);
                articuloLocal.Costo = decimal.Parse(costo);
                articuloLocal.Iva = (Iva)cboIva.SelectedItem;
                articuloLocal.Descuento1 = int.Parse(txtDes1.Text);
                articuloLocal.Descuento2 = int.Parse(txtDes2.Text);
                articuloLocal.Descuento3 = int.Parse(txtDes3.Text);
                articuloLocal.Descuento4 = int.Parse(txtDes4.Text);
                articuloLocal.Ganancia = int.Parse(txtGanancia.Text);


                if (articuloLocal.id != 0)
                {
                    articulo.ModificarArticulo(articuloLocal);
                }
                else
                {
                    articulo.AgregarArticulo(articuloLocal);
                }

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        ErrorProvider ErrorProvider = new ErrorProvider();

        private bool ValidateC()
        {
            bool Valid = true;
            
            if (txtDescri1.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtDescri1, "Campo Incompleto");
            }
            if (txtCodBarras.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtCodBarras, "Campo Incompleto");
            }
            if (txtCosto.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtCosto, "Campo Incompleto");
            }
            if (txtDes1.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtDes1, "Campo Incompleto");
            }
            if (txtDes2.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtDes2, "Campo Incompleto");
            }
            if (txtDes3.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtDes3, "Campo Incompleto");
            }
            if (txtDes4.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtDes4, "Campo Incompleto");
            }
            if (txtGanancia.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtGanancia, "Campo Incompleto");
            }
            if (txtStockMax.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtStockMax, "Campo Incompleto");
            }
            if (txtStockMin.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtStockMin, "Campo Incompleto");
            }

            return Valid;

        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarDecimal(e);
        }

        private void txtDescri1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
