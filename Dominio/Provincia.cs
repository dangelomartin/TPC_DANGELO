﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Provincia
    {
        public int id { set; get; }
        public string Nombre { set; get; }

        public override string ToString()
        {
            return Nombre;
        }
    }

}
