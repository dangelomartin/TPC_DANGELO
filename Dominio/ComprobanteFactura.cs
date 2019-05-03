using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ComprobanteFactura
    {
        public List<Articulo> ListaArticulos = new List<Articulo>();
        public decimal Cantidad { set; get; }
        public int NumComprobante { set; get; }
        public int NumPuesto { set; get; }
    }
}
