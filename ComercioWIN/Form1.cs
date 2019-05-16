using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercioWIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarClientes frm = new ListarClientes();
            frm.Show();
            
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            ListarClientesLite frm = new ListarClientesLite();
            frm.Show();
        }

        private void btnListarProvincias_Click(object sender, EventArgs e)
        {
            ListarProvincias frm = new ListarProvincias();
            frm.Show();
            
        }
    }
}
