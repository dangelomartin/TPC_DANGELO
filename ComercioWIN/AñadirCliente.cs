﻿using System;
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
    public partial class AñadirCliente : Form
    {
        private Cliente ClienteLocal = null;
        public AñadirCliente()
        {
            InitializeComponent();
            
        }

         public AñadirCliente(Cliente cliente)
         {
             InitializeComponent();
             ClienteLocal = cliente;
         }

        private void AñadirCliente_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            ContribuyenteNegocio contribuyenteNegocio = new ContribuyenteNegocio();
            try
            {
                cboContribuyente.DataSource = contribuyenteNegocio.listarcontribuyente();
                cboProvincia.DataSource = provinciaNegocio.ListarProvincias();

                if(ClienteLocal != null)
                {
                    txtCuit.Text = ClienteLocal.Cuit;
                    txtNombre.Text = ClienteLocal.Nombre;
                    txtDireccion.Text = ClienteLocal.Direccion;
                    txtCP.Text = ClienteLocal.CP.ToString();
                    cboProvincia.SelectedItem = cboProvincia.FindString(ClienteLocal.Provincia.Nombre);
                    txtTelefono.Text = ClienteLocal.Telefono;
                    txtEmail.Text = ClienteLocal.Email;
                    cboContribuyente.SelectedItem = cboContribuyente.FindString(ClienteLocal.contribuyente.Descripcion);
                    txtObservaciones.Text = ClienteLocal.Observaciones;
                    ckbActivo.Checked = ClienteLocal.estado;

                }
                    
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                if (ClienteLocal == null)
                    ClienteLocal = new Cliente();

                ClienteLocal.Nombre = txtNombre.Text;
                ClienteLocal.Cuit = txtCuit.Text;
                ClienteLocal.Direccion = txtDireccion.Text;
                ClienteLocal.CP = int.Parse(txtCP.Text);
                ClienteLocal.Provincia = (Provincia)cboProvincia.SelectedItem;
                ClienteLocal.Telefono = txtTelefono.Text;
                ClienteLocal.Email = txtEmail.Text;
                ClienteLocal.contribuyente = (Contribuyente)cboContribuyente.SelectedItem;
                ClienteLocal.Observaciones = txtObservaciones.Text;
                ClienteLocal.estado = ckbActivo.Checked;

            
            if(ClienteLocal.id!=0)
            {
                    negocio.ModificarCliente(ClienteLocal);
            }
            else
            {
                negocio.AgregarCliente(ClienteLocal);
            }

            Close();

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
