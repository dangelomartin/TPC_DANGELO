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
    public class ComprasNegocio
    {
        public void AgregarCompra(FacturaCompra nuevo)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SET DATEFORMAT 'DMY' insert into Compras (idproveedor,fecha,monto,numcomprobante) values";
                comando.CommandText += "(" + nuevo.proveedor.id + ", '" + nuevo.fecha.ToShortDateString() + "', '" + nuevo.Total + "','" + nuevo.NumeroPuesto.ToString()+ ""+nuevo.NumeroComprobante.ToString()+"')";
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

        public bool NoExiste(FacturaCompra existe)
        {
            //int resultado = 0;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = String.Format("SELECT COUNT(*) AS conteo FROM Compras WHERE numcomprobante = '{0}' AND idproveedor = '{1}'", existe.NumeroPuesto + existe.NumeroComprobante, existe.proveedor.id);
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    if ((int)lector["conteo"] == 0)
                    {
                        return true;
                    }
                }
                
                return false;



                /*return Numero + 1;
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = ;
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                */

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



