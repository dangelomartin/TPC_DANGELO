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
        public bool estado { get; set; }
        public int StockActual { set; get; }
        public decimal PrecioPublico
        {
            
          get
            {
                decimal precio;
                decimal ganancia = 1 + (Convert.ToDecimal(this.Ganancia) / 100);
                decimal descuento1 = ((100 - Convert.ToDecimal(this.Descuento1)) / 100);
                decimal descuento2 = ((100 - Convert.ToDecimal(this.Descuento2)) / 100);
                decimal descuento3 = ((100 - Convert.ToDecimal(this.Descuento3)) / 100);
                decimal descuento4 = ((100 - Convert.ToDecimal(this.Descuento4)) / 100);
                decimal costo = (decimal)this.Costo;


                precio = costo * descuento1 * descuento2 * descuento3 * descuento4 * ganancia;
                return precio;
            }
            set
            {
                PrecioPublico = this.PrecioPublico;
            }
            
        }

    }
}
