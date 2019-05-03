using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int id { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public int CP { set; get; }
        public int idProvincia { set; get; }
        public string Telefono { set; get; }
        public string Email { set; get; }
        public int idContribuyente { set; get; }
        public string Cuit { set; get; }
        public string Observaciones { set; get; }
        public int estado { set; get; }

    }
}

