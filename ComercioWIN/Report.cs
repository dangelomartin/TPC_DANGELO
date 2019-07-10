using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercioWIN
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DANGELO_DBDataSet.Reporte' Puede moverla o quitarla según sea necesario.
            //this.ReporteTableAdapter.Fill(this.DANGELO_DBDataSet.Reporte,3);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
