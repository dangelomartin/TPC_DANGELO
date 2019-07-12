using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticuloWeb
    {

        public int cant { set; get; }
        public int cod { set; get; }
        public string Descripcion { set; get; }
        public decimal PU { set; get; }
        public decimal Total { set; get; }
        public string cliente { set; get; }
        public string cuit { set; get; }
        public string fecha { set; get; }
    }
}
