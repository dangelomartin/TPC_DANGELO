using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> ListarCliente()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Cliente> listado = new List<Cliente>();
            Cliente nuevo;

            try
            {
                conexion.ConnectionString = "data source= (LOCAL); initial catalog=DANGELO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select c.id, c.nombre, c.direccion, c.cp,c.idprovincia, c.telefono,c.email,c.cuit, c.observaciones from clientes as c";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Cliente();
                    nuevo.id = (int)lector["id"];
                    nuevo.Nombre = (string)lector["Nombre"];
                    nuevo.Direccion = (string)lector["Direccion"];
                    nuevo.CP = (int)lector["CP"];
                    nuevo.Telefono = (string)lector["Telefono"];
                    nuevo.Email = (string)lector["Email"];
                    nuevo.idProvincia = (int)lector["idprovincia"];
                    nuevo.Cuit = (string)lector["cuit"];
                    nuevo.Observaciones = (string)lector["observaciones"];

                    /*nuevo.Nombre = lector.GetString(1);
                    nuevo.Direccion = lector.GetString(2);
                    nuevo.CP = lector.GetInt32(3);              
                    nuevo.Telefono = lector.GetString(5);
                    nuevo.Email = lector.GetString(6);
                    nuevo.Cuit = lector.GetString(8);
                    nuevo.Observaciones = lector.GetString(9);
                    */
                    

                    
                    
                    


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