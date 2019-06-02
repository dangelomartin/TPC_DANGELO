using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;
using System.Data.SqlClient;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> ListarProveedores()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Proveedor> listado = new List<Proveedor>();
            Proveedor nuevo;

            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select p.id, p.nombre, p.direccion, pr.NOMBRE as Provincia, p.cp, co.DESCRIPCION as Contribuyente, p.CUIT,p.Contacto  from Proveedores as p, PROVINCIAS as pr, CONTRIBUYENTES as co where p.idProvincia=pr.ID and p.idContribuyente=co.ID";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Proveedor();
                    nuevo.id = (int)lector["id"];
                    nuevo.Nombre = (string)lector["Nombre"];
                    nuevo.Direccion = (string)lector["Direccion"];
                    nuevo.Cuit = (string)lector["CUIT"];
                    nuevo.CP = (int)lector["CP"];
                    nuevo.Contribuyente = new Contribuyente();
                    nuevo.Contribuyente.Descripcion = (string)lector["Contribuyente"];
                    nuevo.Contacto = (string)lector["Contacto"];
                    nuevo.Provincia = new Provincia();
                    nuevo.Provincia.Nombre = (string)lector["Provincia"];
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
