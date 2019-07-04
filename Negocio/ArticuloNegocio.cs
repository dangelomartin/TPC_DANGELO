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
    public class ArticuloNegocio
    {
        public Articulo articulolocal = null;
        public object MessageBox { get; private set; }

        public List<Articulo> ListarArticulos()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> listado = new List<Articulo>();
            Articulo nuevo;
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "select a.id, a.descripcion1, a.CodBarras, isnull(a.stockMin,'') as StockMin, isnull(a.stockMax,'') as StockMax,a.stockactual, i.Porcentaje as IVA,a.costo, a.ganancia, m.descripcion as Marca, r.descripcion as Rubro, p.Nombre as Proveedor,a.estado  from articulo as a, IVA as i,Marcas as m,Rubros as r, Proveedores as p where a.idIva=i.id and a.idMarca=m.id and a.idProveedores=p.id and a.idRubro=r.id and a.estado=1";
                comando.CommandText = "select * from VW_Articulo";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Articulo();
                    nuevo.id = (int)lector["ID"];
                    nuevo.Descripcion = (string)lector["Descripcion"];
                    nuevo.codBarras = (long)lector["CodBarras"];
                    nuevo.StockMin = (int)lector["StockMin"];
                    nuevo.StockMax = (int)lector["StockMax"];
                    nuevo.StockActual = (int)lector["StockActual"];
                    nuevo.Costo = (decimal)lector["Costo"];
                    nuevo.Ganancia = (int)lector["Ganancia"];
                    nuevo.Marca = new Marca();
                    nuevo.Marca.Descripcion = lector["Marcar"].ToString();
                    nuevo.Rubro = new Rubro();
                    nuevo.Rubro.Descripcion = lector["Rubro"].ToString();
                    nuevo.Proveedor = new Proveedor();
                    nuevo.Proveedor.Nombre = lector["Proveedor"].ToString();
                    nuevo.PrecioPublico = (decimal)lector["PrecioPublico"];
                    listado.Add(nuevo);

                    /*nuevo.Descuento1 = Convert.ToDecimal(lector["Descuento1"]);
                    nuevo.Descuento2 = Convert.ToDecimal(lector["Descuento2"]);
                    nuevo.Descuento3 = Convert.ToDecimal(lector["Descuento3"]);
                    nuevo.Descuento4 = Convert.ToDecimal(lector["Descuento4"]);*/
                    //nuevo.estado = (bool)lector["estado"];
                    /*nuevo.Iva = new Iva();
                    nuevo.Iva.Descripcion = lector["IVA"].ToString();*/
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

        public void AgregarArticulo(Articulo nuevo)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into articulo (Descripcion1,CodBarras,StockMin,StockMax,Costo,ganancia,IdMarca,IdRubro,IdProveedores,stockactual) values";
                comando.CommandText += "('" + nuevo.Descripcion + "', '" + nuevo.codBarras + "', '" + nuevo.StockMin + "', '" + nuevo.StockMax + "', '" + nuevo.Costo + "', '" + nuevo.Ganancia + "', '" + nuevo.Marca.id.ToString() + "', '" + nuevo.Rubro.id.ToString() + "', '" + nuevo.Proveedor.id.ToString() + "','" +nuevo.StockActual+ "')";
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
        public void ModificarArticulo(Articulo modificar)
      {
        AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
        try
        {

            accesoDatos.setearConsulta("update articulo Set Descripcion1=@Descripcion, codBarras=@CodBarras, StockMin=@StockMin, StockMax=@StockMax,  costo=@Costo, ganancia=@Ganancia,IdMarca=@IdMarca, idrubro=@IdRubro, idproveedores=@IdProveedores where Id=" + modificar.id.ToString());
            accesoDatos.Comando.Parameters.Clear();

            accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", modificar.Descripcion);
            accesoDatos.Comando.Parameters.AddWithValue("@CodBarras", modificar.codBarras);
            accesoDatos.Comando.Parameters.AddWithValue("@StockMin", modificar.StockMin);
            accesoDatos.Comando.Parameters.AddWithValue("@StockMax", modificar.StockMax);
            
            accesoDatos.Comando.Parameters.AddWithValue("@costo", modificar.Costo);
           
            accesoDatos.Comando.Parameters.AddWithValue("@Ganancia", modificar.Ganancia);
            accesoDatos.Comando.Parameters.AddWithValue("@IdMarca", modificar.Marca.id);
            accesoDatos.Comando.Parameters.AddWithValue("@IdRubro", modificar.Rubro.id);
            accesoDatos.Comando.Parameters.AddWithValue("@IdProveedores", modificar.Proveedor.id);
            accesoDatos.abrirConexion();
            accesoDatos.ejecutarAccion();

                //accesoDatos.Comando.Parameters.AddWithValue("@Desc1", modificar.Descuento1);
                //accesoDatos.Comando.Parameters.AddWithValue("@Desc2", modificar.Descuento2);
                //accesoDatos.Comando.Parameters.AddWithValue("@Desc3", modificar.Descuento3);
                //accesoDatos.Comando.Parameters.AddWithValue("@Desc4", modificar.Descuento4);
                //accesoDatos.Comando.Parameters.AddWithValue("@IdIva", modificar.Iva.id);
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



        public void BajaArticulo (Articulo baja)

        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {
                accesoDatos.setearConsulta("update Articulo Set estado='0' where Id=" + baja.id.ToString());
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

        public void SubirStock(Articulo Stock)

        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {
                accesoDatos.setearConsulta("update Articulo Set stockactual=stockactual+"+Stock.StockActual +" where Id=" + Stock.id.ToString());
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

        public void bajarStock(Articulo Stock)

        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {
                accesoDatos.setearConsulta("update Articulo Set stockactual=stockactual-" + Stock.StockActual + " where Id=" + Stock.id.ToString());
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
        public Articulo BuscarID(int id)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            Articulo nuevo = null;
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "select a.id, a.descripcion1, a.CodBarras, isnull(a.stockMin,'') as StockMin, isnull(a.stockMax,'') as StockMax,a.stockactual, i.Porcentaje as IVA,a.costo,a.desc1 as Descuento1,a.desc2 as Descuento2,a.desc3 as Descuento3,a.desc4 as Descuento4, a.ganancia, m.descripcion as Marca, r.descripcion as Rubro, p.Nombre as Proveedor,a.estado  from articulo as a, IVA as i,Marcas as m,Rubros as r, Proveedores as p where a.idIva=i.id and a.idMarca=m.id and a.idProveedores=p.id and a.idRubro=r.id and a.estado=1 and a.id =" + id.ToString();
                comando.CommandText = "select * from VW_Articulo";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                bool validar = false;

                while (lector.Read() && validar == false)
                {
                    if((int)lector["id"]==id)
                    {
                        nuevo = new Articulo();
                        nuevo.id = (int)lector["ID"];
                        nuevo.Descripcion = (string)lector["Descripcion"];
                        nuevo.codBarras = (long)lector["CodBarras"];
                        nuevo.StockMin = (int)lector["StockMin"];
                        nuevo.StockMax = (int)lector["StockMax"];
                        nuevo.StockActual = (int)lector["StockActual"];
                        nuevo.Costo = (decimal)lector["Costo"];
                        nuevo.Ganancia = (int)lector["Ganancia"];
                        nuevo.Marca = new Marca();
                        nuevo.Marca.Descripcion = lector["Marca"].ToString();
                        nuevo.Rubro = new Rubro();
                        nuevo.Rubro.Descripcion = lector["Rubro"].ToString();
                        nuevo.Proveedor = new Proveedor();
                        nuevo.Proveedor.Nombre = lector["Proveedor"].ToString();
                        nuevo.PrecioPublico = (decimal)lector["PrecioPublico"];
                        nuevo.estado = (bool)lector["estado"];
                        nuevo.StockActual = (int)lector["stockActual"];
                        validar = true;
                    }

                }
                    
                
                 return nuevo;

                
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



