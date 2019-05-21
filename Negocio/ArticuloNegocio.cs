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
                comando.CommandText = "select a.id, a.descripcion1, isnull(a.descripcion2,'') as Descripcion2, isnull(a.codBarras,'') as CodBarras, isnull(a.stockMin,'') as StockMin, isnull(a.stockMax,'') as StockMax, i.Porcentaje as IVA,a.costo,a.desc1 as Descuento1,a.desc2 as Descuento2,a.desc3 as Descuento3,a.desc4 as Descuento4, a.ganancia, m.descripcion as Marca, r.descripcion as Rubro, p.Nombre as Proveedor,a.estado  from articulo as a, IVA as i,Marcas as m,Rubros as r, Proveedores as p where a.idIva=i.id and a.idMarca=m.id and a.idProveedores=p.id and a.idRubro=r.id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Articulo();
                    nuevo.id = (int)lector["id"];
                    nuevo.Descripcion1 = (string)lector["Descripcion1"];
                    nuevo.Descripcion2 = (string)lector["Descripcion2"];
                    nuevo.codBarras = (long)lector["codBarras"];
                    nuevo.StockMin = (int)lector["StockMin"];
                    nuevo.StockMax = (int)lector["StockMax"];
                    nuevo.Iva = new Iva();
                    nuevo.Iva.Descripcion = lector["IVA"].ToString();
                    nuevo.Costo = (decimal)lector["Costo"];
                    nuevo.Descuento1 = Convert.ToDecimal(lector["Descuento1"]);
                    nuevo.Descuento2 = Convert.ToDecimal(lector["Descuento2"]);
                    nuevo.Descuento3 = Convert.ToDecimal(lector["Descuento3"]);
                    nuevo.Descuento4 = Convert.ToDecimal(lector["Descuento4"]);
                    nuevo.Ganancia = (int)lector["Ganancia"];
                    nuevo.Marca = new Marca();
                    nuevo.Marca.Descripcion = lector["Marca"].ToString();
                    nuevo.Rubro = new Rubro();
                    nuevo.Rubro.Descripcion = lector["Rubro"].ToString();
                    nuevo.Proveedor = new Proveedor();
                    nuevo.Proveedor.Nombre = lector["Proveedor"].ToString();
                    nuevo.estado = (bool)lector["estado"];

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



