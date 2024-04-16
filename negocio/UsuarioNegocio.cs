﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using static System.Collections.Specialized.BitVector32;

namespace negocio
{
    public class UsuarioNegocio
    {
        public int insertarUserNuevo(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@urlImagenPerfil", usuario.ImagenPerfil);

                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Login(Usuario usuario)
        {
            AccesoDatos datos =new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, email, pass, admin, urlImagenPerfil FROM USERS Where email = @email And pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull)) 
                    {
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    }
                    //if (!(datos.Lector["nombre"] is DBNull))
                    //{
                    //    usuario.Nombre = (string)datos.Lector["nombre"];
                    //}
                    //if (!(datos.Lector["apellido"] is DBNull))
                    //{
                    //    usuario.Apellido = (string)datos.Lector["apellido"];
                    //}
                    return true;

                }
                return false; //no hay user logueado
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizar(Usuario usuario)
        {
            AccesoDatos datos =new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USERS set urlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido Where Id = @id");
                datos.setearParametro("@imagen", usuario.ImagenPerfil);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);

                datos.setearParametro("@id", usuario.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            { 

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
