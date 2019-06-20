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
    public class DetalleVentaNegocio
    {
        public void AgregarArticulo(DetalleArticulo nuevo, int idf)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into DetalleArticulo (cantidad, idarticulo, PrecioUni, idfactura) values";
                comando.CommandText += "('" + nuevo.cantidad + "', '" + nuevo.articulo.id + "', '" + nuevo.preciounit + "', '" + nuevo.idfactura + "')";
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

        public void AgregarVenta(FacturaVenta nuevo)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into Detalleventa (idfactura,idCliente) values";
                comando.CommandText += "('" + nuevo.idfact.ToString() + "', '" + nuevo.idcliente.ToString() + "')";
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

        public int NumFactura()
        {
            int Numero=0;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select isnull(max(idFactura),0)as NumFactura from DetalleVenta";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Numero = (int)lector["NumFactura"];
                }

                return Numero+1;
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
