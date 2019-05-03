using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public string id { set; get; }
        public string Descripcion1 { set; get; }
        public string Descripcion2 { set; get; }
        public int codBarras { set; get; }
        public int StockMin { set; get; }
        public int StockMax { set; get; }
        public Iva Iva { set; get; }
        public float Costo { set; get; }
        public VentaPublico VentaPublico { set; get; }
        public Marca Marca { set; get; }
        public Rubro Rubro { set; get; }
        public Medida Medida { set; get; }
        public Color Color { set; get; }
        public Proveedor Proveedor { set; get; }
        public bool estado { set; get; }

    }
}
