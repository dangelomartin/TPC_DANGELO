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

namespace ComercioWIN
{
    public partial class ListarArticulosLite : Form
    {
        public List<Articulo> ListArticuloLocal;
        public ListarArticulosLite()
        {
            InitializeComponent();
        }

        private void ListarArticulos_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                CargarListaArt();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private void CargarListaArt()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {

                ListArticuloLocal = negocio.ListarArticulos();
                dgvListarArticulos.DataSource = ListArticuloLocal;
                dgvListarArticulos.Columns[2].Visible = false;
                dgvListarArticulos.Columns[3].Visible = false;
                dgvListarArticulos.Columns[4].Visible = false;
                dgvListarArticulos.Columns[5].Visible = false;
                dgvListarArticulos.Columns[7].Visible = false;
                dgvListarArticulos.Columns[8].Visible = false;
                dgvListarArticulos.Columns[9].Visible = false;
                dgvListarArticulos.Columns[10].Visible = false;
                dgvListarArticulos.Columns[11].Visible = false;
                dgvListarArticulos.Columns[14].Visible = false;
                dgvListarArticulos.Columns[15].Visible = false;
                






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CompletoArticulo completo = new CompletoArticulo((Articulo)dgvListarArticulos.CurrentRow.DataBoundItem);
            completo.ShowDialog();
            CargarListaArt();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AñadirArticulo alta = new AñadirArticulo();
            alta.ShowDialog();
            CargarListaArt();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Precaucion precaucion = new Precaucion();
            precaucion.ShowDialog();

            if (precaucion.DialogResult == DialogResult.OK)
            {
                ArticuloNegocio baja = new ArticuloNegocio();
                baja.BajaArticulo((Articulo)dgvListarArticulos.CurrentRow.DataBoundItem);
                CargarListaArt();
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            try
            {
            AñadirArticulo modificar = new AñadirArticulo((Articulo)dgvListarArticulos.CurrentRow.DataBoundItem);
            modificar.ShowDialog();
            CargarListaArt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
