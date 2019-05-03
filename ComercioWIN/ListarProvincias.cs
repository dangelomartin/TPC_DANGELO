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
    public partial class ListarProvincias : Form
    {
        public ListarProvincias()
        {
            InitializeComponent();
        }

        private void ListarProvincias_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio negocio = new ProvinciaNegocio();

            try
            {
                dgvProvincias.DataSource = negocio.ListarProvincias();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
