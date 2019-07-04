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
    public partial class AñadirProveedor : Form
    {
        public Proveedor proveedorLocal = null; 
        public AñadirProveedor()
        {
            InitializeComponent();
        }

        public AñadirProveedor(Proveedor proveedor)
        {
            InitializeComponent();
            proveedorLocal = proveedor;
        }

        private void AñadirProveedor_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            ContribuyenteNegocio contribuyenteNegocio = new ContribuyenteNegocio();
            try
            {
                cboContribuyente.DataSource = contribuyenteNegocio.listarcontribuyente();
                cboProvincia.DataSource = provinciaNegocio.ListarProvincias();
                if(proveedorLocal != null)
                {
                        txtCuit.Text = proveedorLocal.Cuit;
                        txtNombre.Text = proveedorLocal.Nombre;
                        txtDireccion.Text = proveedorLocal.Direccion;
                        txtCP.Text = proveedorLocal.CP.ToString();
                        cboProvincia.SelectedItem = cboProvincia.FindString(proveedorLocal.Provincia.Nombre);
                        txtTelefono.Text = proveedorLocal.Telefono;
                        txtEmail.Text = proveedorLocal.email;
                        cboContribuyente.SelectedItem = cboContribuyente.FindString(proveedorLocal.Contribuyente.Descripcion);
                        txtContacto.Text = proveedorLocal.Contacto;
                       
                        

                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            ProveedorNegocio negocio = new ProveedorNegocio();
            if (ValidateC())
            {
            try
            {

                if (proveedorLocal == null)
                    proveedorLocal = new Proveedor();

                proveedorLocal.Nombre = txtNombre.Text.ToUpper();
                proveedorLocal.Cuit = txtCuit.Text;
                proveedorLocal.Direccion = txtDireccion.Text.ToUpper();
                proveedorLocal.CP = int.Parse(txtCP.Text);
                proveedorLocal.Provincia = (Provincia)cboProvincia.SelectedItem;
                proveedorLocal.Telefono = txtTelefono.Text;
                proveedorLocal.email = txtEmail.Text.ToUpper();
                proveedorLocal.Contribuyente = (Contribuyente)cboContribuyente.SelectedItem;
                proveedorLocal.Contacto = txtContacto.Text.ToUpper();
                proveedorLocal.estado = true;
                


                if (proveedorLocal.id != 0)
                {
                    negocio.ModificarProveedor(proveedorLocal);
                }
                else
                {
                    negocio.AgregaProveedor(proveedorLocal);
                }

                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            }
        }


        ErrorProvider ErrorProvider = new ErrorProvider();

        private bool ValidateC()
        {
            bool Valid = true;

            if (txtContacto.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtContacto, "Campo Incompleto");
            }
            if (txtCP.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtCP, "Campo Incompleto");
            }
            if (txtCuit.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtCuit, "Campo Incompleto");
            }
            if (txtDireccion.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtDireccion, "Campo Incompleto");
            }
            if (txtEmail.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtEmail, "Campo Incompleto");
            }
            if (txtNombre.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtNombre, "Campo Incompleto");
            }
            if (txtTelefono.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtTelefono, "Campo Incompleto");
            }

            return Valid;
        }

            private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }
    }
}
