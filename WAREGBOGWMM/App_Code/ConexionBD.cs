using GrupoCoen.Corporativo.Libraries.ConexionBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WAREGBOGWMM.Models;

namespace WAREGBOGWMM.App_Code
{
    public class ConexionBD
    {
        MSSQLConnection ocon;
        internal bool mGetXML(int oOperacion, int oVariable, ref string oXML, ref string oError)
        {
            bool oResult = false;
            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;

            bool ob = false;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);
                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@operacion", oOperacion.ToString(), Parametros.SType.Int));
                oParam.Add(new Parametros("@variante", oVariable.ToString(), Parametros.SType.Int));
                try
                {
                    ob = ocon.executeSP("spc_get_OperationXML", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
                oDT = ocon.getDataset();

                if (oDT.Tables.Count == 0)
                {

                    oError = "La busqueda no obtuvo ningún XML de resultado";
                    return false;
                }

                oTable = oDT.Tables[0];

                if (oTable.Rows.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún XML resultado";
                    return false;
                }

                oXML = oTable.Rows[0]["Trama"].ToString().Trim();
                oResult = true;
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }

            return oResult;
        }


        /*
         * Inserción de usuarios.
         */
        internal bool mInsertUsuario(Usuario user, string usuario, int estado, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@NombreCompleto", user.nombreCompleto, Parametros.SType.Text));
                oParam.Add(new Parametros("@Contraseña", user.contra, Parametros.SType.Text));
                oParam.Add(new Parametros("@NumeroIdentificacion", user.documento, Parametros.SType.Text));
                oParam.Add(new Parametros("@NumeroDeTelefono", user.telefono, Parametros.SType.Text));
                oParam.Add(new Parametros("@Email", user.correo, Parametros.SType.Text));
                oParam.Add(new Parametros("@Direccion", user.direccion, Parametros.SType.Text));
                oParam.Add(new Parametros("@GeneroID", user.generoID, Parametros.SType.Int));
                oParam.Add(new Parametros("@FechaNacimiento", user.fechaNacimiento, Parametros.SType.DateTime));
                oParam.Add(new Parametros("@UsuarioCreacion", usuario, Parametros.SType.Text));
                oParam.Add(new Parametros("@RolID", user.rolID, Parametros.SType.Int));
                oParam.Add(new Parametros("@PaisID", user.paisID, Parametros.SType.Int));
                oParam.Add(new Parametros("@Estado", estado, Parametros.SType.Int));
                oParam.Add(new Parametros("@NombreUsuario", user.nombreUsuario, Parametros.SType.Text));

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_insert_GWMMUsuario]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }


        /*
         * Actualización de usuarios.
         */
        internal bool mUpdateUsuario(Usuario user, string usuario, int estado, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            //MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@NombreUsuario", user.nombreUsuario, Parametros.SType.Text));
                oParam.Add(new Parametros("@NombreCompleto", user.nombreCompleto, Parametros.SType.Text));
                oParam.Add(new Parametros("@NumeroIdentificacion", user.documento, Parametros.SType.Text));
                oParam.Add(new Parametros("@NumeroDeTelefono", user.telefono, Parametros.SType.Text));
                oParam.Add(new Parametros("@Email", user.correo, Parametros.SType.Text));
                oParam.Add(new Parametros("@Direccion", user.direccion, Parametros.SType.Text));
                oParam.Add(new Parametros("@GeneroID", user.generoID, Parametros.SType.Int));
                oParam.Add(new Parametros("@FechaNacimiento", user.fechaNacimiento, Parametros.SType.DateTime));
                oParam.Add(new Parametros("@RolID", user.rolID, Parametros.SType.Int));
                oParam.Add(new Parametros("@PaisID", user.paisID, Parametros.SType.Int));
                oParam.Add(new Parametros("@Estado", estado, Parametros.SType.Bit));
                oParam.Add(new Parametros("@Contraseña", user.contra, Parametros.SType.Text));
                oParam.Add(new Parametros("@UsuarioActualizacion", usuario, Parametros.SType.Text));
                //oParam.Add(new Parametros("@NombreUsuario", user.nombreUsuario, Parametros.SType.Text));

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_update_Usuario]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }

        //Consultar usuario
        internal DataTable mQueryUsuario(string username, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            //MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@nombreUsuario", username, Parametros.SType.Text));

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_select_GWMMUsuarios]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    //return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    //return false;
                }
                finally
                {
                    ocon.closeConnection();
                }

                oDT = ocon.getDataset();

                if (oDT.Tables.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }

                oTable = oDT.Tables[0];

                if (oTable.Rows.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }
                return oTable;
            }
            catch (Exception oex)
            {
                //oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return new DataTable();
        }

        //Listar generos
        internal DataTable mQueryGenre(ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            //MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_select_GWMMGeneros]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    //return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    //return false;
                }
                finally
                {
                    ocon.closeConnection();
                }

                oDT = ocon.getDataset();

                if (oDT.Tables.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }

                oTable = oDT.Tables[0];

                if (oTable.Rows.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }
                return oTable;
            }
            catch (Exception oex)
            {
                //oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return new DataTable();
        }

        //Listar roles
        internal DataTable mQueryRol(ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            //MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_select_GWMMRol]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    //return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    //return false;
                }
                finally
                {
                    ocon.closeConnection();
                }

                oDT = ocon.getDataset();

                if (oDT.Tables.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }

                oTable = oDT.Tables[0];

                if (oTable.Rows.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }
                return oTable;
            }
            catch (Exception oex)
            {
                //oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return new DataTable();
        }

        //Listar paises
        internal DataTable mQueryPais(ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            //MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_select_GWMMPais]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    //return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    //return false;
                }
                finally
                {
                    ocon.closeConnection();
                }

                oDT = ocon.getDataset();

                if (oDT.Tables.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }

                oTable = oDT.Tables[0];

                if (oTable.Rows.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }
                return oTable;
            }
            catch (Exception oex)
            {
                //oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return new DataTable();
        }

        /*
         * Altas y bajas de usuario
         */
        internal bool mEstateUsuario(Usuario user, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@NombreUsuario", user.nombreUsuario, Parametros.SType.Text));
                oParam.Add(new Parametros("@Estado", user.estado, Parametros.SType.Bit));

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_update_GWMMAltaBaja_Usuario]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }

        /*
         * Inserción de roles.
         */
        internal bool mInsertRol(Rol uRol, string usuario, int estado, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@NombreRol", uRol.nombreRol, Parametros.SType.Text));
                oParam.Add(new Parametros("@UsuarioCreacion", usuario, Parametros.SType.Text));
                oParam.Add(new Parametros("@Estado", estado, Parametros.SType.Int));
                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_insert_GWMMRol]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }

        //Modificación de roles
        internal bool mUpdateRol(Rol uRol, string usuario, int estado, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@RolID", uRol.rolID, Parametros.SType.Int));
                oParam.Add(new Parametros("@NombreRol", uRol.nombreRol, Parametros.SType.Text));
                oParam.Add(new Parametros("@UsuarioActualizacion", usuario, Parametros.SType.Text));
                oParam.Add(new Parametros("@Estado", estado, Parametros.SType.Bit));
                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_update_GWMMRol]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }

        //Consultar rol
        internal DataTable mQueryRol(string uRol, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            //MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@RolID", uRol, Parametros.SType.Int));

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_select_GWMMRolUpdate]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    //return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    //return false;
                }
                finally
                {
                    ocon.closeConnection();
                }

                oDT = ocon.getDataset();

                if (oDT.Tables.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }

                oTable = oDT.Tables[0];

                if (oTable.Rows.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }
                return oTable;
            }
            catch (Exception oex)
            {
                //oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return new DataTable();
        }

        //Alta/Baja de rol
        internal bool mEstateRol(Rol uRol, string usuario, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@RolID", uRol.rolID, Parametros.SType.Int));
                oParam.Add(new Parametros("@Estado", uRol.estadoActivo, Parametros.SType.Bit));
                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_update_GWMMAltaBaja_Rol]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }

        //Crear permiso
        internal bool mCreatePermiso(Permiso permit, string usuario, int permiso, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@Nombre", permit.nombrePermiso, Parametros.SType.Text));
                oParam.Add(new Parametros("@Descripcion", permit.descripcionPermiso, Parametros.SType.Text));
                oParam.Add(new Parametros("@Icono", permit.iconoPermiso, Parametros.SType.Text));
                oParam.Add(new Parametros("@RouterPagina", permit.routerPagina, Parametros.SType.Text));
                oParam.Add(new Parametros("@UsarioCreacion", usuario, Parametros.SType.Text));
                oParam.Add(new Parametros("@Estado", permiso, Parametros.SType.Int));
                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_insert_GWMMPermiso]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }

        //Modificar permiso
        internal bool mUpdatePermiso(Permiso permit, string usuario, int permiso, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@PermisoID", permit.permisoID, Parametros.SType.Int));
                oParam.Add(new Parametros("@Nombre", permit.nombrePermiso, Parametros.SType.Text));
                oParam.Add(new Parametros("@Descripcion", permit.descripcionPermiso, Parametros.SType.Text));
                oParam.Add(new Parametros("@Icono", permit.iconoPermiso, Parametros.SType.Text));
                oParam.Add(new Parametros("@RouterPagina", permit.routerPagina, Parametros.SType.Text));
                oParam.Add(new Parametros("@UsuarioActualizacion", usuario, Parametros.SType.Text));
                oParam.Add(new Parametros("@Estado", permiso, Parametros.SType.Bit));
                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_update_GWMMPermiso]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }

        //Consultar rol
        internal DataTable mQueryPermiso(string permit, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            //MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@PermisoID", permit, Parametros.SType.Int));

                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_select_GWMMPermisos]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    //return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    //return false;
                }
                finally
                {
                    ocon.closeConnection();
                }

                oDT = ocon.getDataset();

                if (oDT.Tables.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }

                oTable = oDT.Tables[0];

                if (oTable.Rows.Count == 0)
                {
                    oError = "La busqueda no obtuvo ningún parámetro de usuarios";
                }
                return oTable;
            }
            catch (Exception oex)
            {
                //oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return new DataTable();
        }

        //Alta/Baja permiso
        internal bool mEstatePermiso(Permiso permit, string usuario, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@PermisoID", permit.permisoID, Parametros.SType.Int));
                oParam.Add(new Parametros("@Estado", permit.estadoActivo, Parametros.SType.Bit));
                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_update_GWMMAltaBaja_Permiso]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }

        //Reiniciar contraseñas
        internal bool mRestartPassword(ReinicioContraseña pass, string usuario, ref string oError)
        {
            bool oResult = false;

            DataSet oDT = new DataSet();
            DataTable oTable = new DataTable();
            MSSQLConnection ocon;
            try
            {
                string oCS = new Utilerias().mCSH2H();
                ocon = new MSSQLConnection(oCS);

                List<Parametros> oParam = new List<Parametros>();
                oParam.Add(new Parametros("@UsuarioID", pass.usuarioID, Parametros.SType.Int));
                oParam.Add(new Parametros("@NuevaContraseña", pass.contraseñaNueva, Parametros.SType.Text));
                try
                {
                    oResult = ocon.executeSP("[remesadores].[sp_update_GWMMContraseña]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                }
                catch (SqlException oExQ)
                {
                    oError = oExQ.Message;
                    return false;
                }
                catch (Exception oEx)
                {
                    oError = oEx.Message;
                    return false;
                }
                finally
                {
                    ocon.closeConnection();
                    try
                    {
                        string oCSS = new Utilerias().mCSH2H();
                        ocon = new MSSQLConnection(oCS);

                        List<Parametros> oParams = new List<Parametros>();
                        oParams.Add(new Parametros("@Contraseña", pass.contraseñaNueva, Parametros.SType.Text));
                        oParams.Add(new Parametros("@UsuarioCreacion", usuario, Parametros.SType.Text));

                        oResult = ocon.executeSP("[remesadores].[sp_insert_GWMMHistorialContraseña]", oParam, MSSQLConnection.ReturnTypes.Dataset);
                    }
                    catch (SqlException oExQ)
                    {
                        oError = oExQ.Message;
                        //return false;
                    }
                    catch (Exception oEx)
                    {
                        oError = oEx.Message;
                        //return false;
                    }
                    finally
                    {
                        ocon.closeConnection();
                    }
                }
            }
            catch (Exception oex)
            {
                oResult = false;
                oError = oError + " / " + oex.Message;
            }
            return oResult;
        }
    }
}