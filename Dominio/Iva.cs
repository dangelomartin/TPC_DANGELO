﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Iva
    {
        public int id { set; get; }
        public string Descripcion { set; get; }
        public decimal Porcentaje { set; get; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
