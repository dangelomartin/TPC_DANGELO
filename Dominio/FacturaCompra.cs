using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FacturaCompra
    {

        public int NumeroPuesto;
        public int NumeroComprobante;
        public float Total;
        public float subTotal;
        public Iva Tipoiva;
        public float iva;
        public float PercIIBB;
        public float PercGan;
        public float NoGraba;
        public float PercIva;
        public Fecha fecha;
        public Proveedor proveedor;
        
    }
}
