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
    public partial class CompletoProveedor : Form
    {
        private Proveedor proveedorLocal = null;

        public CompletoProveedor()
        {
            InitializeComponent();
        }

        public CompletoProveedor(Proveedor proveedor)
        {
            InitializeComponent();
            proveedorLocal = proveedor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CompletoProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = proveedorLocal.id.ToString();
                txtNombre.Text = proveedorLocal.Nombre;
                txtEmail.Text = proveedorLocal.email;
                txtTelefono.Text = proveedorLocal.Telefono;
                txtCP.Text = proveedorLocal.CP.ToString();
                txtDireccion.Text = proveedorLocal.Direccion;
                txtCUIT.Text = proveedorLocal.Cuit;
                txtContacto.Text = proveedorLocal.Contacto;
                txtCont.Text = proveedorLocal.Contribuyente.Descripcion;
                txtProvincia.Text = proveedorLocal.Provincia.Nombre;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); 
            }
        }

        }

        
    }

