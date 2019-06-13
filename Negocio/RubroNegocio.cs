using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class RubroNegocio
    {
        public List<Rubro> ListarRubros()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Rubro> listado = new List<Rubro>();
            Rubro nuevo;

            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select r.id, r.descripcion from rubros as r where estado=1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Rubro();
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
        public void Baja(Rubro baja)
        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {
                accesoDatos.setearConsulta("update Rubros Set estado='0' where Id=" + baja.id.ToString());
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
        public void Modificar(Rubro modificar)
        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {

                accesoDatos.setearConsulta("update Rubros Set Descripcion=@Descripcion where Id=" + modificar.id.ToString());
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

        public void Agrega(Rubro nuevo)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into Rubros (Descripcion,estado) values";
                comando.CommandText += "('" + nuevo.Descripcion + "', '" + 1 + "')";
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
