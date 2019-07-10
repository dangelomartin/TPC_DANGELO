using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using System.Data.SqlClient;
using System.Data;

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
            //ListarClientes frm = new ListarClientes();
            //frm.Show();
            
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            ListarClientesLite frm = new ListarClientesLite();
            frm.ShowDialog();
        }

        private void btnListarProvincias_Click(object sender, EventArgs e)
        {
            ListarArticulosLite frm = new ListarArticulosLite();
            frm.ShowDialog();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Factura frmfactura = new Factura();
            frmfactura.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListarRubro frmRubro = new ListarRubro();
            frmRubro.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListarProveedores frmproveedores = new ListarProveedores();
            frmproveedores.ShowDialog();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            ListarMarcas frm = new ListarMarcas();
            frm.ShowDialog();
        }

        private void btnCargarFactura_Click(object sender, EventArgs e)
        {
            CargarFactura frm = new CargarFactura();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            Factura frmfactura = new Factura();
            frmfactura.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Visible = true;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reimprimir frm = new Reimprimir();
            frm.ShowDialog();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if  (e.KeyCode == Keys.F1)
            {
            btnFactura_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.F2)
            {
                btnListarClientes_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.F3)
            {
                btnCargarFactura_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.F4)
            {
                btnListarProvincias_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.F5)
            {
                button6_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.F6)
            {
                button3_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.F7)
            {
                button2_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.F8)
            {
                btnMarca_Click(this, new EventArgs());
            }
        }
    }
}
