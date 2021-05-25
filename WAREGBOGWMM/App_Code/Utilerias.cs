using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAREGBOGWMM.Models;
using System.Data;
using System.Web.Mvc;

namespace WAREGBOGWMM.App_Code
{
    public class Utilerias
    {
        internal string mCSH2H()
        {
            string Key = "";
            try
            {
                Key = System.Configuration.ConfigurationManager.AppSettings["dbalias"];

                if (string.IsNullOrEmpty(Key))
                    Key = "db_h2h";
            }
            catch
            {
                try
                {
                    Key = "db_h2h";
                }
                catch { throw new Exception("key no found"); }
            }
            return Key;
        }

        //Crear usuario
        internal void CreateUser(Usuario user, ref string error)
        {
            new ConexionBD().mInsertUsuario(user, "edwin.ruano", 1, ref error);
        }


        //Modificar usuario
        internal void UpdateUser(Usuario user, ref string error)
        {
            new ConexionBD().mUpdateUsuario(user, "edwin.ruano", 1, ref error);
        }

        //Alta/Baja usuario
        internal void UpDownUser(Usuario user, ref string error)
        {
            new ConexionBD().mEstateUsuario(user, ref error);
        }

        //Consultar usuario
        internal Usuario QueryUser(string username, ref string error)
        {
            var tabla = new ConexionBD().mQueryUsuario(username, ref error);

            var user = (from query in tabla.AsEnumerable()
                        select new Usuario
                        {
                            //nombreUsuario = query.Field<string>("NombreUsuario"),
                            nombreCompleto = query.Field<string>("NombreCompleto"),
                            documento = query.Field<string>("NumeroIdentificacion"),
                            telefono = query.Field<string>("NumeroDeTelefono"),
                            correo = query.Field<string>("Email"),
                            direccion = query.Field<string>("Direccion"),
                            contra = query.Field<string>("Contraseña"),
                            estado = Convert.ToString(query.Field<Boolean>("Estado")),
                            generoID = Convert.ToString(query.Field<int>("GeneroID")),
                            fechaNacimiento = Convert.ToString(query.Field<DateTime>("FechaNacimiento")),
                            rolID = Convert.ToString(query.Field<int>("RolID")),
                            paisID = Convert.ToString(query.Field<int>("PaisID"))
                        }).FirstOrDefault();
            return user;
        }

        //Lista de generos
        internal List<SelectListItem> QueryGenre()
        {
            string error = "";
            
            var tabla = new ConexionBD().mQueryGenre(ref error);

            var user = (from query in tabla.AsEnumerable()
                        select new SelectListItem
                        {
                            Value = Convert.ToString(query.Field<int>("GeneroID")),
                            Text = query.Field<string>("Descripcion")
                        }).ToList();
          
            return user;
        }

        //Lista de roles
        internal List<SelectListItem> QueryRol()
        {
            string error = "";

            var tabla = new ConexionBD().mQueryRol(ref error);

            var user = (from query in tabla.AsEnumerable()
                        select new SelectListItem
                        {
                            Value = Convert.ToString(query.Field<int>("RolID")),
                            Text = query.Field<string>("NombreRol")
                        }).ToList();

            return user;
        }

        //Lista de paises
        internal List<SelectListItem> QueryPais()
        {
            string error = "";

            var tabla = new ConexionBD().mQueryPais(ref error);

            var user = (from query in tabla.AsEnumerable()
                        select new SelectListItem
                        {
                            Value = Convert.ToString(query.Field<int>("PaisID")),
                            Text = query.Field<string>("Nombre")
                        }).ToList();

            return user;
        }

        //Crear rol
        internal void CreateRol(Rol uRol, ref string error)
        {
            new ConexionBD().mInsertRol(uRol, "edwin.ruano", 1, ref error);
        }

        //Modificar rol
        internal void UpdateRol(Rol urol, ref string error)
        {
            new ConexionBD().mUpdateRol(urol, "edwin.ruano", 1, ref error);
        }

        //Habilitar/Inhabilitar rol
        internal void UpDownRol(Rol uRol, ref string error)
        {
            new ConexionBD().mEstateRol(uRol, "edwin.ruano", ref error);
        }

        //Consultar rol
        internal Rol QueryRol1(string uRol, ref string error)
        {
            var tabla = new ConexionBD().mQueryRol(uRol, ref error);

            var uROL = (from query in tabla.AsEnumerable()
                    select new Rol
                    {
                        nombreRol = query.Field<string>("NombreRol"),
                        estadoActivo = Convert.ToString(query.Field<Boolean>("Estado"))
                    }).FirstOrDefault();
            return uROL;
        }

        //Crear permiso
        internal void CreatePermiso(Permiso permit, ref string error)
        {
            new ConexionBD().mCreatePermiso(permit, "edwin.ruano", 1, ref error);
        }

        //Modificar permiso
        internal void UpdatePermiso(Permiso permit, ref string error)
        {
            new ConexionBD().mUpdatePermiso(permit, "edwin.ruano", 1, ref error);
        }

        //Alta/Baja permiso
        internal void UpDownPermiso(Permiso permit, ref string error)
        {
            new ConexionBD().mEstatePermiso(permit, "edwin.ruano", ref error);
        }

        //Consultar Permiso
        internal Permiso QueryPermiso(string permiso, ref string error)
        {
            var tabla = new ConexionBD().mQueryPermiso(permiso, ref error);

            var permit = (from query in tabla.AsEnumerable()
                    select new Permiso
                    {
                        nombrePermiso = query.Field<string>("Nombre"),
                        descripcionPermiso = query.Field<string>("Descripcion"),
                        iconoPermiso = query.Field<string>("Icono"),
                        routerPagina = query.Field<string>("RouterPagina"),
                        estadoActivo = Convert.ToString(query.Field<Boolean>("Estado"))
                    }).FirstOrDefault();
            return permit;
        }

        //Reiniciar contraseñas
        internal void RestartPassword(ReinicioContraseña password, ref string error)
        {
            new ConexionBD().mRestartPassword(password, "edwin.ruano", ref error);
        }
    }
}