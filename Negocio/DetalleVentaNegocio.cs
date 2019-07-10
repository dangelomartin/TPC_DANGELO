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
                comando.CommandText += "(" + nuevo.cantidad.ToString().Replace(",", ".") + ", " + nuevo.articulo.id + ", '" + nuevo.preciounit.ToString().Replace(",",".") + "', " + nuevo.idfactura + ")";
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

        
            public List<FacturaVenta> ListarVentas()
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                List<FacturaVenta> listado = new List<FacturaVenta>();
                FacturaVenta nuevo;

                try
                {
                    conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "select d.idFactura as NumFactura, d.Fecha, c.nombre as Cliente, d.importe from DetalleVenta as d inner join CLIENTES as c on c.id=d.IdCliente";
                    comando.Connection = conexion;
                    conexion.Open();
                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        nuevo = new FacturaVenta();
                        nuevo.idfact = (int)lector["NumFactura"];
                        nuevo.cliente = new Cliente();
                        nuevo.cliente.Nombre = (string)lector["Cliente"];
                        nuevo.fecha = (DateTime)lector["fecha"];
                        nuevo.importe = (decimal)lector["importe"];
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
        public List<FacturaVenta> VentasXfecha(string desde, string hasta)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<FacturaVenta> listado = new List<FacturaVenta>();
            FacturaVenta nuevo;

            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = string.Format("set dateformat dmy select d.idFactura as NumFactura, d.Fecha, c.nombre as Cliente, d.importe from DetalleVenta as d inner join CLIENTES as c on c.id=d.IdCliente where d.fecha BETWEEN '{0}' AND '{1}'", desde, hasta);
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new FacturaVenta();
                    nuevo.idfact = (int)lector["NumFactura"];
                    nuevo.cliente = new Cliente();
                    nuevo.cliente.Nombre = (string)lector["Cliente"];
                    nuevo.fecha = (DateTime)lector["fecha"];
                    nuevo.importe = (decimal)lector["importe"];
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


        public void AgregarVenta(FacturaVenta nuevo)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into Detalleventa (idfactura,idCliente,importe) values";
                comando.CommandText += "(" + nuevo.idfact + ", " + nuevo.cliente.id.ToString() + ", '" + nuevo.importe.ToString().Replace(",", ".") +"')";
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

        public List<ArticuloWeb> ArticulosXComprobante(int id)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<ArticuloWeb> listado = new List<ArticuloWeb>();
            ArticuloWeb nuevo;

            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "exec sp_ReporteFactura "+ id;
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new ArticuloWeb();
                    nuevo.cant = (int)lector["Cant"];
                    nuevo.cod = (int)lector["Cod"];
                    nuevo.Descripcion = (string)lector["Descripcion"];
                    nuevo.PU = (decimal)lector["P.U."];
                    nuevo.Total = (decimal)lector["Total"];
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

        public bool ValidarFactura(int factura)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = String.Format("select count(*) as conteo from DetalleVenta where idFactura = '{0}' ", factura.ToString());
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    if ((int)lector["conteo"] == 1)
                    {
                        return true;
                    }
                }

                return false;
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
