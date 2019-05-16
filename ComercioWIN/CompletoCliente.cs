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
    public partial class CompletoCliente : Form
    {

        private Cliente ClienteLocal = null;
        public CompletoCliente()
        {
            InitializeComponent();

        }

        public CompletoCliente(Cliente cliente)
        {
            InitializeComponent();
            ClienteLocal = cliente;
        }

      

        private void CompletoCliente_Load(object sender, EventArgs e)
        {
            
            try
            {
                    txtID.Text = ClienteLocal.id.ToString();
                    txtNombre.Text = ClienteLocal.Nombre;
                    txtDireccion.Text = ClienteLocal.Direccion;
                      txtCP.Text = ClienteLocal.CP.ToString();
                      txtProvincia.Text = ClienteLocal.Provincia.Nombre;
                      txtTelefono.Text = ClienteLocal.Telefono;
                      txtEmail.Text = ClienteLocal.Email;
                      txtCont.Text = ClienteLocal.contribuyente.Descripcion;
                      txtCUIT.Text = ClienteLocal.Cuit;
                      rtbObs.Text = ClienteLocal.Observaciones;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
