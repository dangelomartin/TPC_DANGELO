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
    public partial class ListarClientesLite : Form
    {
        public List<Cliente> ListaClienteLocal;
        public ListarClientesLite()
        {
            InitializeComponent();
        }

        private void ListarClientesLite_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();

            try
            {
                CargarLista();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarLista()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                
                ListaClienteLocal = negocio.ListarCliente();
                dgvClientesLite.DataSource = ListaClienteLocal;
                dgvClientesLite.Columns[2].Visible = false;
                dgvClientesLite.Columns[3].Visible = false;
                dgvClientesLite.Columns[4].Visible = false;
                dgvClientesLite.Columns[5].Visible = false;
                dgvClientesLite.Columns[6].Visible = false;
                dgvClientesLite.Columns[7].Visible = false;
                dgvClientesLite.Columns[9].Visible = false;
                dgvClientesLite.Columns[10].Visible = false;
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarListaComp()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {

                ListaClienteLocal = negocio.ListarCliente();
                dgvClientesLite.DataSource = ListaClienteLocal;
           



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void txtBusquedaCliente_TextChanged(object sender, EventArgs e)
        {
            if(txtBusquedaCliente.Text =="")
            {
                dgvClientesLite.DataSource = ListaClienteLocal;

            }
            else
            {
                if(txtBusquedaCliente.Text.Length >=2)
                {
                    List<Cliente> lista;
                    lista = ListaClienteLocal.FindAll(X => X.Nombre.Contains(txtBusquedaCliente.Text));
                    dgvClientesLite.DataSource = lista;
                }
           
            }
           
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            AñadirCliente alta = new AñadirCliente();
            alta.ShowDialog();
            CargarLista();
        
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                AñadirCliente modificar = new AñadirCliente((Cliente)dgvClientesLite.CurrentRow.DataBoundItem);
                modificar.ShowDialog();
                CargarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

        private void btnCompleto_Click(object sender, EventArgs e)
        {
            CompletoCliente completo = new CompletoCliente((Cliente)dgvClientesLite.CurrentRow.DataBoundItem);
            completo.ShowDialog();
            CargarLista();
        }
    }
}
