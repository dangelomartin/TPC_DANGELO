using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace WebComercio
{
    public partial class Gestion_de_Clientes : System.Web.UI.Page
    {
            Cliente clientelocal = new Cliente();
            //clientelocal = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Sesion.Sesion.estaActivo)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {

                ContribuyenteNegocio contribuyente = new ContribuyenteNegocio();
                ListContri.DataSource = contribuyente.listarcontribuyente();
                ListContri.DataTextField = "Descripcion";
                ListContri.DataBind();

                ProvinciaNegocio provincia = new ProvinciaNegocio();
                ListProvincia.DataSource = provincia.ListarProvincias();
                ListProvincia.DataTextField = "Nombre";
                ListProvincia.DataBind();
                if(clientelocal !=null)
                {
                     
                }
            }

        }


        
        private void ClienteValues()
        {
        

        }
        private Cliente clienteweb()
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Nombre = txtNombre.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Email = txtEmail.Text;
                cliente.CP = Convert.ToInt32(txtCP.Text);
                cliente.contribuyente = new Contribuyente();
                cliente.contribuyente.id = ListContri.SelectedIndex;
                cliente.Provincia = new Provincia();
                cliente.Provincia.id = ListProvincia.SelectedIndex;
                cliente.Observaciones = txtObs.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Cuit = txtTelefono.Text;
                cliente.estado = true;

                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio clientenuevo = new ClienteNegocio();
                clientenuevo.AgregarCliente(clienteweb());
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ListContri_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        protected void ListProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clientelocal = new ClienteNegocio();
            ListaCliente.DataSource = clientelocal.BuscarClientes(txtClienteABuscar.Text);
            ListaCliente.DataTextField = "Nombre";
            ListaCliente.DataBind();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            //clientelocal.id = ListaCliente.SelectedIndex
        }
    }
}