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
                comando.CommandText = "insert into Compras (idproveedor,monto,fecha,numcomprobante) values";
                comando.CommandText += "(" + nuevo.proveedor.id + ", " + nuevo.Total + "," + nuevo.NumeroPuesto+ ""+nuevo.NumeroComprobante+")";
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
