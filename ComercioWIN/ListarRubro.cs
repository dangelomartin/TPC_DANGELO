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
    public partial class ListarRubro : Form
    {
        public List<Rubro> ListaRubroLocal;
        public ListarRubro()
        {
            InitializeComponent();
        }

        private void ListarRubro_Load(object sender, EventArgs e)
        {
            Cargarlista();
        }

        public void Cargarlista()
        {
            RubroNegocio negocio = new RubroNegocio();
            ListaRubroLocal = negocio.ListarRubros();
            dgvLista.DataSource = ListaRubroLocal;
            dgvLista.Columns[2].Visible = false;
        }

        private void bntAgregar_Click(object sender, EventArgs e)
        {
            AñadirRubro alta = new AñadirRubro();
            alta.ShowDialog();
            Cargarlista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                AñadirRubro modificar = new AñadirRubro((Rubro)dgvLista.CurrentRow.DataBoundItem);
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
                RubroNegocio baja = new RubroNegocio();
                baja.Baja((Rubro)dgvLista.CurrentRow.DataBoundItem);
                Cargarlista();
            }

        }
    }
}
