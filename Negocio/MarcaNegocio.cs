using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Marca> listado = new List<Marca>();
            Marca nuevo;

            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select m.id, m.descripcion from marcas as m";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Marca();
                    nuevo.id = (int)lector["id"];
                    nuevo.Descripcion = (string)lector["Descripcion"];
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

        public void Baja(Marca baja)
        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {
                accesoDatos.setearConsulta("update Marcas Set estado='0' where Id=" + baja.id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
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
        public void ModificarMarca(Marca modificar)
        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {

                accesoDatos.setearConsulta("update Marcas Set Descripcion=@Descripcion where Id=" + modificar.id.ToString());
                accesoDatos.Comando.Parameters.Clear();

                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", modificar.Descripcion);
                
          
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();

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

        public void AgregaMarca(Marca nuevo)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into Marcas (Descripcion,estado) values";
                comando.CommandText += "('" + nuevo.Descripcion + "', '" + nuevo.estado + "')";
                comando.Connection = conexion;
                conexion.Open();

                comando.ExecuteNonQuery();

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
