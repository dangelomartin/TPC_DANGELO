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
using AccesoDatos;
using Negocio;

namespace ComercioWIN
{
    public partial class ListarMarcas : Form
    {
        public List<Marca> ListaMarcaLocal;
        public ListarMarcas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListarMarcas_Load(object sender, EventArgs e)
        {
            Cargarlista();
        }

        public void Cargarlista()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            ListaMarcaLocal = negocio.ListarMarcas();
            dgvLista.DataSource = ListaMarcaLocal;
            dgvLista.Columns[2].Visible = false;
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[1].Width = 250;
        }

        private void bntAgregar_Click(object sender, EventArgs e)
        {
            AñadirMarca alta = new AñadirMarca();
            alta.ShowDialog();
            Cargarlista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                AñadirMarca modificar = new AñadirMarca((Marca)dgvLista.CurrentRow.DataBoundItem);
                modificar.ShowDialog();
                Cargarlista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Precaucion precaucion = new Precaucion();
            precaucion.ShowDialog();
            if (precaucion.DialogResult == DialogResult.OK)
            {
                MarcaNegocio baja = new MarcaNegocio();
                baja.Baja((Marca)dgvLista.CurrentRow.DataBoundItem);
                Cargarlista();
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvLista.DataSource = ListaMarcaLocal;

            }
            else
            {
                if (txtBusqueda.Text.Length >= 2)
                {
                    List<Marca> lista;
                    lista = ListaMarcaLocal.FindAll(X => X.Descripcion.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvLista.DataSource = lista;
                }

            }
        }
    }
}
