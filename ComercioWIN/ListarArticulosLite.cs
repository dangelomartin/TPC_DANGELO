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
        public bool estadoventana = false;
        public List<Articulo> ListArticuloLocal;
        public ListarArticulosLite()
        
        {
            InitializeComponent();
        }

        private void ListarArticulos_Load(object sender, EventArgs e)
        {

            if (estadoventana == false)
            {
                btnSeleccionar.Enabled = false;
            }
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
                dgvListarArticulos.Columns[6].Visible = false;

                dgvListarArticulos.Columns[8].Visible = false;
                dgvListarArticulos.Columns[9].Visible = false;
                dgvListarArticulos.Columns[10].Visible = false;
                
                
                
                dgvListarArticulos.Columns[0].Width = 40;
                dgvListarArticulos.Columns[1].Width = 200;
                dgvListarArticulos.Columns[8].Width = 80;
                dgvListarArticulos.Columns[11].Width = 60;


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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (null == this.dgvListarArticulos.CurrentRow)
            {
                ArticuloLocal = null;
            }
            else
            {
                ArticuloLocal = (Articulo)this.dgvListarArticulos.CurrentRow.DataBoundItem;
            }
            this.Close();
        }

        public Articulo ArticuloLocal = new Articulo();

        public Articulo ArtSelect(bool estado)
        {
            estadoventana = estado;
            try
            {
                this.ShowDialog();
                while (ArticuloLocal == null)
                {
                    this.ShowDialog();
                }
                return ArticuloLocal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntcerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
