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
    public partial class ListarProveedores : Form
    {
        public bool estadoventana = false;
        public List<Proveedor> ListaProveedorLocal;
        public ListarProveedores()
        {
            InitializeComponent();
        }

        private void ListarProveedores_Load(object sender, EventArgs e)
        {
            if (estadoventana == false)
            {
                btnBuscar.Enabled = false;
            }
            ProveedorNegocio proveedor = new ProveedorNegocio();
            

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
            ProveedorNegocio negocio = new ProveedorNegocio();
            
            try
            {
                ListaProveedorLocal = negocio.ListarProveedores();
                dgvLista.DataSource = ListaProveedorLocal;
                dgvLista.Columns[2].Visible = false;
                dgvLista.Columns[3].Visible = false;
                dgvLista.Columns[4].Visible = false;
                dgvLista.Columns[6].Visible = false;
                dgvLista.Columns[8].Visible = false;
                dgvLista.Columns[9].Visible = false;
                dgvLista.Columns[10].Visible = false;
                dgvLista.Columns[0].Width = 50;
                dgvLista.Columns[1].Width = 200;
                dgvLista.Columns[5].Width = 100;
                dgvLista.Columns[7].Width = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarListaComp()
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            
            try
            {
                ListaProveedorLocal = negocio.ListarProveedores();

                dgvLista.DataSource = ListaProveedorLocal;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AñadirProveedor añadirProveedor = new AñadirProveedor();
            añadirProveedor.ShowDialog();
            CargarLista();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            try
            {
            AñadirProveedor modificar = new AñadirProveedor((Proveedor)dgvLista.CurrentRow.DataBoundItem);
            modificar.ShowDialog();
            CargarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvLista.DataSource = ListaProveedorLocal;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 2)
                {
                    List<Proveedor> lista;
                    lista = ListaProveedorLocal.FindAll(X => X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvLista.DataSource = lista;
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Precaucion precaucion = new Precaucion();
            precaucion.ShowDialog();

            if (precaucion.DialogResult == DialogResult.OK)
            {
                ProveedorNegocio baja = new ProveedorNegocio();
                baja.Baja((Proveedor)dgvLista.CurrentRow.DataBoundItem);
                CargarLista();
            }

        }

        private void btnCompleto_Click(object sender, EventArgs e)
        {
            CompletoProveedor completoProveedor = new CompletoProveedor((Proveedor)dgvLista.CurrentRow.DataBoundItem);
            completoProveedor.ShowDialog();
        }

        Proveedor proveedorLocal = new Proveedor();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (null == this.dgvLista.CurrentRow)
            {
                proveedorLocal = null;
            }
            else
            {
                proveedorLocal = (Proveedor)this.dgvLista.CurrentRow.DataBoundItem;
            }
            this.Close();
        }
        public Proveedor ProveedorSelect(bool estado)
        {
            estadoventana = estado;
            try
            {
                this.ShowDialog();
                while(proveedorLocal == null)
                {
                    this.ShowDialog();
                }
                return proveedorLocal;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        //public Cliente ClienteSelect(bool estado)
        //{
        //    estadoventana = estado;
        //    try
        //    {
        //        this.ShowDialog();
        //        while (clienteLocal == null)
        //        {
        //            this.ShowDialog();
        //        }
        //        return clienteLocal;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
