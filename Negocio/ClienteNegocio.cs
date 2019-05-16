using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using AccesoaDatos;


namespace Negocio
{
      public class ClienteNegocio
    {
        public List<ClienteLite> ListarCliente()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<ClienteLite> listado = new List<ClienteLite>();
            ClienteLite nuevo;

            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select c.id, c.nombre, c.cuit, c.observaciones from clientes as c";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new ClienteLite();
                    nuevo.id = (int)lector["id"];
                    nuevo.Nombre = (string)lector["Nombre"];
                    nuevo.Cuit = (string)lector["cuit"];
                    

                    /*nuevo.Nombre = lector.GetString(1);
                    nuevo.Direccion = lector.GetString(2);
                    nuevo.CP = lector.GetInt32(3);              
                    nuevo.Telefono = lector.GetString(5);
                    nuevo.Email = lector.GetString(6);
                    nuevo.Cuit = lector.GetString(8);
                    nuevo.Observaciones = lector.GetString(9);
                    */
                    

                    
                    
                    


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

        public void AgregarCliente(Cliente nuevo)
        
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into CLIENTES (Nombre, direccion,cp,idprovincia,telefono,email,idcontribuyente,cuit,observaciones,estado) values";
                comando.CommandText += "('" + nuevo.Nombre + "', '" + nuevo.Direccion + "', '" + nuevo.CP + "', '" + nuevo.Provincia.id.ToString() + "', '" + nuevo.Telefono + "', '" + nuevo.Email + "', '" + nuevo.contribuyente.id.ToString() + "','" + nuevo.Cuit + "', '" + nuevo.Observaciones + "', '" + nuevo.estado + "')";
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

        public void ModificarCliente(Cliente modificar)
        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {
                
                accesoDatos.setearConsulta("update Clientes Set Nombre=@Nombre, direccion=@direccion, cp=@cp, idprovincia=@idprov, telefono=@telefono, email=@email, idcontribuyente=@idcont,cuit=@cuit,observaciones=@obs, Where Id=" + modificar.id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Direccion", modificar.Direccion);
                accesoDatos.Comando.Parameters.AddWithValue("@cp", modificar.CP);
                accesoDatos.Comando.Parameters.AddWithValue("@idprov", modificar.Provincia.id);
                accesoDatos.Comando.Parameters.AddWithValue("@telefono", modificar.Telefono);
                accesoDatos.Comando.Parameters.AddWithValue("@email", modificar.Email);
                accesoDatos.Comando.Parameters.AddWithValue("@idcont", modificar.contribuyente.id);
                accesoDatos.Comando.Parameters.AddWithValue("@cuit", modificar.Cuit);
                accesoDatos.Comando.Parameters.AddWithValue("@obs", modificar.Observaciones);
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
    }
    
    
}