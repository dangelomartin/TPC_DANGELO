using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int id { set; get; }
        public string Descripcion1 { set; get; }
        public string Descripcion2 { set; get; }
        public long codBarras { set; get; }
        public int StockMin { set; get; }
        public int StockMax { set; get; }
        public Iva Iva { set; get; }
        public decimal Costo { set; get; }
        public decimal Descuento1 { set; get; }
        public decimal Descuento2 { set; get; }
        public decimal Descuento3 { set; get; }
        public decimal Descuento4 { set; get; }
        public int Ganancia { set; get; }
        public Marca Marca { set; get; }
        public Rubro Rubro { set; get; }
        public Proveedor Proveedor { set; get; }
        public bool estado { set; get; }

    }
}
