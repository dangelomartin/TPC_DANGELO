using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuarios
    {
        public string user { set; get; }
        public string pass { set; get; }
        public int tipo { set; get; }
        public int intentos { set; get; }
    }
}
