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
                cboProveedor.DataSource = proveedorNegocio.ListarProveedores();

                if(articuloLocal!=null)
                {
                    txtDescri1.Text = articuloLocal.Descripcion;
                    txtCodBarras.Text = articuloLocal.codBarras.ToString();
                    cboMarca.SelectedItem = cboMarca.FindString(articuloLocal.Marca.Descripcion);
                    cboRubro.SelectedItem = cboRubro.FindString(articuloLocal.Rubro.Descripcion);
                    cboProveedor.SelectedItem = cboProveedor.FindString(articuloLocal.Proveedor.Nombre);
                    txtStockMin.Text = articuloLocal.StockMin.ToString();
                    txtStockMax.Text = articuloLocal.StockMax.ToString();
                    txtCosto.Text = articuloLocal.Costo.ToString();
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
                articuloLocal.Descripcion = txtDescri1.Text.ToUpper();
                articuloLocal.codBarras = (long.Parse(txtCodBarras.Text));
                articuloLocal.Marca = (Marca)cboMarca.SelectedItem;
                articuloLocal.Rubro = (Rubro)cboRubro.SelectedItem;
                articuloLocal.Proveedor = (Proveedor)cboProveedor.SelectedItem;
                articuloLocal.StockMin = int.Parse(txtStockMin.Text);
                articuloLocal.StockMax = int.Parse(txtStockMax.Text);
                articuloLocal.Costo = decimal.Parse(txtCosto.Text.Replace(".", ","));
                
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
            ValidarLetrasNumeros.validarNumeros(e);
         
        }

        private void txtDescri1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCodBarras_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStockMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStockMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }

        private void txtStockMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarDecimal(e);
        }

        private void txtGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }

        private void txtDescri1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
