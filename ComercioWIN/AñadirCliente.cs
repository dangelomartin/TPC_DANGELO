using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Dominio.Models;

namespace ComercioWIN
{
    public partial class AñadirCliente : Form
    {
        private Cliente ClienteLocal = null;
        public AñadirCliente()
        {
            InitializeComponent();

        }

        public AñadirCliente(Cliente cliente)
        {
            InitializeComponent();
            ClienteLocal = cliente;
        }

        private void AñadirCliente_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            ContribuyenteNegocio contribuyenteNegocio = new ContribuyenteNegocio();
            try
            {
                cboContribuyente.DataSource = contribuyenteNegocio.listarcontribuyente();
                cboProvincia.DataSource = provinciaNegocio.ListarProvincias();

                if (ClienteLocal != null)
                {
                    txtCuit.Text = ClienteLocal.Cuit;
                    txtNombre.Text = ClienteLocal.Nombre;
                    txtDireccion.Text = ClienteLocal.Direccion;
                    txtCP.Text = ClienteLocal.CP.ToString();
                    cboProvincia.SelectedItem = cboProvincia.FindString(ClienteLocal.Provincia.Nombre);
                    txtTelefono.Text = ClienteLocal.Telefono;
                    txtEmail.Text = ClienteLocal.Email;
                    cboContribuyente.SelectedItem = cboContribuyente.FindString(ClienteLocal.contribuyente.Descripcion);
                    txtObservaciones.Text = ClienteLocal.Observaciones;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateC())
            {
                ClienteNegocio negocio = new ClienteNegocio();
                try
                {
                    if (ClienteLocal == null)
                        ClienteLocal = new Cliente();
                    ClienteLocal.Nombre = txtNombre.Text.ToUpper();
                    ClienteLocal.Cuit = txtCuit.Text;
                    ClienteLocal.Direccion = txtDireccion.Text.ToUpper();
                    ClienteLocal.CP = int.Parse(txtCP.Text);
                    ClienteLocal.Provincia = (Provincia)cboProvincia.SelectedItem;
                    ClienteLocal.Telefono = txtTelefono.Text;
                    ClienteLocal.Email = txtEmail.Text.ToUpper();
                    ClienteLocal.contribuyente = (Contribuyente)cboContribuyente.SelectedItem;
                    ClienteLocal.Observaciones = txtObservaciones.Text.ToUpper();

                    if (ClienteLocal.id != 0)
                    {
                        negocio.ModificarCliente(ClienteLocal);
                    }
                    else
                    {
                        negocio.AgregarCliente(ClienteLocal);
                    }

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        ErrorProvider ErrorProvider = new ErrorProvider();
        private bool ValidateC()
        {
            bool Valid = true;

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

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetrasNumeros.validarNumeros(e);
        }
    }
}

