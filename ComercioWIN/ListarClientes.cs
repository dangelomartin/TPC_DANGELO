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

namespace ComercioWIN
{
    public partial class ListarClientes : Form
    {
        public ListarClientes()
        {
            InitializeComponent();
        }

        private void ListarClientes_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();

            try
            {
                dgvListarClientes.DataSource = negocio.ListarCliente();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
