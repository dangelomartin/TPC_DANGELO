using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebComercio.Sesion
{
    public static class Sesion
    {
        public static bool estaActivo = false;

        public static void cambiarEstado(bool estado)
            {
            estaActivo = estado;
            }

    }
}