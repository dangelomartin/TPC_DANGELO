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

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
