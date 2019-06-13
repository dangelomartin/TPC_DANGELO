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
    public partial class Factura2 : Form
    {
        private DataTable dt;


        public Factura2()
        {

            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio uni");
            dt.Columns.Add("total");
            dgvArticulos.DataSource = dt;

        }

        private void Factura2_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Rows.Add(txtCantidad.Text, txtDescripcion.Text, txtPrecioUni.Text, txtTotal.Text);
            dgvArticulos.DataSource = dt;
        }
    }
}
