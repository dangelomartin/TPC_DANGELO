using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FacturaVenta
    {
        public int idcliente { set; get; }
        public int idfact { set; get; }
//        public int numFact { set; get; }
        public List<DetalleArticulo> DetalleArticulos { set; get; } 
 

}
}
