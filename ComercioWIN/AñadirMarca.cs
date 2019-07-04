using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Models;
using Dominio;
using Negocio;

namespace ComercioWIN
{
    public partial class AñadirMarca : Form
    {

        private Marca local = null;
        public AñadirMarca()
        {
            InitializeComponent();
        }


        public AñadirMarca(Marca Marca)
        {
            InitializeComponent();
            local = Marca;
        }


        private void AñadirMarca_Load(object sender, EventArgs e)
        {

            try
            {
                if (local != null)
                {
                    txtDescripcion.Text = local.Descripcion;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if(ValidateC())
            {
            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                if (local == null)
                    local = new Marca();

                local.Descripcion = txtDescripcion.Text.ToUpper();

                if (local.id != 0)
                {
                    negocio.ModificarMarca(local);
                }
                else
                {
                    negocio.AgregaMarca(local);
                }
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            }
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
        ErrorProvider ErrorProvider = new ErrorProvider();
        private bool ValidateC()
        {
            bool Valid = true;

            if (txtDescripcion.Text == "")
            {
                Valid = false;
                ErrorProvider.SetError(txtDescripcion, "Campo Incompleto");
            }

            return Valid;
        }
    }
}
