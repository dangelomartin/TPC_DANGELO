using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleArticulo
    {
        public decimal cantidad { set; get; }
        public Articulo articulo { set; get; }
        public decimal preciounit { set; get; }
        
        public decimal total
            {   get
                {
                    decimal tot;
                    tot = cantidad * articulo.PrecioPublico;
                    return tot;
                }
                set
            {

            }
            
            }
        public int idfactura { set; get; }
        
    }
}
