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
    public class UsuarioNegocio
    {
        public int Datos(Usuarios Userlocal, int tipo=1)
        {
            if (ValidarUsuarioypass(Userlocal, tipo))
            {
                return 0;
            }
            else if (ValidarUsuario(Userlocal, tipo))
            {
                BajaUsuario(Userlocal);
                return 1;
            }
            else if (bloqueado(Userlocal))
            {
                return 2;
            }
            return -1;

        }

        public bool ValidarUsuarioypass(Usuarios user, int tipo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = String.Format("select count(*) as conteo from Users as u where Usuario = '{0}' and Pass = '{1}' and intentos < 3 and Tipo={2}", user.user, user.pass, tipo);
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
        public bool ValidarUsuario(Usuarios user, int tipo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = String.Format("select count(*) as conteo from Users as u where Usuario = '{0}' and intentos < 3 and Tipo = {1}", user.user,tipo);
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

        public void BajaUsuario(Usuarios user)

        {
            AccesoDatos.AccesoDatosMaster accesoDatos = new AccesoDatos.AccesoDatosMaster();
            try
            {
                accesoDatos.setearConsulta("update Users Set intentos=intentos+1 where Usuario like '" + user.user.ToString() + "'");
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

        public bool bloqueado(Usuarios user)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = String.Format("select count(*) as conteo from Users as u where Usuario = '{0}' and intentos = 3", user.user);
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
        public Usuarios BuscarUsuario(string nombre)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            

            try
            {
                conexion.ConnectionString = AccesoDatos.AccesoDatosMaster.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = string.Format("select Usuario, Pass, Intentos, Tipo from users where usuario='admin'");
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                Usuarios nuevo;
                nuevo = null;

                while (lector.Read())
                {
                    nuevo.user = (string)lector["Usuario"];
                    nuevo.pass = (string)lector["Pass"];
                    nuevo.tipo = (int)lector["Intentos"];
                    nuevo.intentos = (int)lector["Tipo"];
                    
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

