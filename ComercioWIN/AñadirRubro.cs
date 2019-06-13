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
    public partial class AñadirRubro : Form
    {
        private Rubro   local = null;
        
        public AñadirRubro()
        {
            InitializeComponent();
        }

        public AñadirRubro(Rubro rubro)
        {
            InitializeComponent();
            local = rubro;
        }

        private void AMGenerico_Load(object sender, EventArgs e)
        {

            try
            {
            if(local != null)
            {
                txtDescripcion.Text = local.Descripcion;
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            try
            {
                RubroNegocio negocio = new RubroNegocio();
                            if (local == null)
                                local = new Rubro();

                            local.Descripcion = txtDescripcion.Text.ToUpper();

                            if(local.id != 0)
                            {
                                negocio.Modificar(local);
                            }
                            else
                            {
                                negocio.Agrega(local);
                            }
                            Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
