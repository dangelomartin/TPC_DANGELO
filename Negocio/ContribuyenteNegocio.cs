using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ContribuyenteNegocio
    {
        public List<Contribuyente> listarcontribuyente()
        {
            List<Contribuyente> listado = new List<Contribuyente>();
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            Contribuyente cont;
            try
            {
                accesoDatos.setearConsulta("select id, descripcion from contribuyentes");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    cont = new Contribuyente();
                    cont.id = (int)accesoDatos.Lector["id"];
                    cont.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                    //cont.IVA = (int)accesoDatos.Lector["IDIVA"];
                    listado.Add(cont);
                }
                return listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

        }
     
    }
}
