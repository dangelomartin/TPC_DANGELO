using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FacturaVenta
    {
        public Cliente cliente { set; get; }
        public int idfact { set; get; }
        public DateTime fecha { set; get; }
        public decimal importe { set; get; }
    }
}
