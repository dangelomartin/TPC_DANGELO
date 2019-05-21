using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor
    {
        public int id { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        Provincia Provincia { set; get; }
        public int CP { set; get; }
        public string Telefono { set; get; }
        public Contribuyente Contribuyente { set; get; }
        public string Cuit { set; get; }
        public string Contacto { set; get; }
        public override string ToString()
        {
            return Nombre;
        }
    }

}
