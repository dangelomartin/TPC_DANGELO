using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProvinciaNegocio
    {

        public List<Provincia> ListarProvincias()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Provincia> listado = new List<Provincia>();
            Provincia nuevo;

            try
            {
                conexion.ConnectionString = "data source= (LOCAL); initial catalog=DANGELO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select p.id, p.nombre from provincias as p";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Provincia();
                    nuevo.id = (int)lector["id"];
                    nuevo.Nombre = (string)lector["Nombre"];
                    

                  






                    listado.Add(nuevo);
                }

                return listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}