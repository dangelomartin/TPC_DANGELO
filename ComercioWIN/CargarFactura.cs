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
    public partial class CargarFactura : Form
    {
        
        public CargarFactura()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public Proveedor proveedorLocal = new Proveedor();
        private void btnBuscarProo_Click(object sender, EventArgs e)
        {
            ListarProveedores buscarProveedor = new ListarProveedores();
            proveedorLocal = buscarProveedor.ProveedorSelect(true);

            if(proveedorLocal != null)
            {
                txtNombreproov.Text = proveedorLocal.Nombre;
            }else
            {
                proveedorLocal = buscarProveedor.ProveedorSelect(true);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
