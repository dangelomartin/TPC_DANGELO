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
                comando.CommandText = "select p.id, p.nombre, p.direccion, pr.NOMBRE as Provincia, p.cp, co.DESCRIPCION as Contribuyente, p.CUIT,p.Contacto,p.telefono, p.email  from Proveedores as p, PROVINCIAS as pr, CONTRIBUYENTES as co where p.idProvincia=pr.ID and p.idContribuyente=co.ID and p.estado=1";
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
                    nuevo.Telefono = (string)lector["Telefono"];
                    nuevo.email = (string)lector["Email"];
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

        public void Baja(Proveedor baja)
        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {
                accesoDatos.setearConsulta("update Proveedores Set estado='0' where Id=" + baja.id.ToString());
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
        public void ModificarProveedor (Proveedor modificar)
        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {

                accesoDatos.setearConsulta("update Proveedores Set Nombre=@Nombre, direccion=@direccion, cp=@cp, idprovincia=@idprov, telefono=@telefono, email=@email, idcontribuyente=@idcont,cuit=@cuit,contacto=@contacto,estado=1 where Id=" + modificar.id.ToString());
                accesoDatos.Comando.Parameters.Clear();

                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Direccion", modificar.Direccion);
                accesoDatos.Comando.Parameters.AddWithValue("@cp", modificar.CP);
                accesoDatos.Comando.Parameters.AddWithValue("@idprov", modificar.Provincia.id);
                accesoDatos.Comando.Parameters.AddWithValue("@telefono", modificar.Telefono);
                accesoDatos.Comando.Parameters.AddWithValue("@email", modificar.email);
                accesoDatos.Comando.Parameters.AddWithValue("@idcont", modificar.Contribuyente.id);
                accesoDatos.Comando.Parameters.AddWithValue("@cuit", modificar.Cuit);
                accesoDatos.Comando.Parameters.AddWithValue("@contacto", modificar.Contacto);
                accesoDatos.Comando.Parameters.AddWithValue("@estado", modificar.estado);
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

        public void AgregaProveedor(Proveedor nuevo)

        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into Proveedores (Nombre, direccion,cp,idprovincia,telefono,email,idcontribuyente,cuit,contacto,estado) values";
                comando.CommandText += "('" + nuevo.Nombre + "', '" + nuevo.Direccion + "', '" + nuevo.CP + "', '" + nuevo.Provincia.id.ToString() + "', '" + nuevo.Telefono + "', '" + nuevo.email + "', '" + nuevo.Contribuyente.id.ToString() + "','" + nuevo.Cuit + "', '" + nuevo.Contacto + "', '" + nuevo.estado + "')";
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
