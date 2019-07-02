using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FacturaCompra
    {

        public string NumeroPuesto;
        public string NumeroComprobante;
        public string Total;
        public float subTotal;
        public Iva Tipoiva;
        public float iva;
        public float PercIIBB;
        public float PercGan;
        public float NoGraba;
        public float PercIva;
        public DateTime fecha;
        public Proveedor proveedor;
        
    }
}
