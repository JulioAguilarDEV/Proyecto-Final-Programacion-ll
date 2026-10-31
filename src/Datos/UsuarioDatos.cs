using Entidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class UsuarioDatos
    {
        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        // Comprueba las credenciales y obtiene el rol y sus accesos activos.
        public UsuarioEntidad MtdIniciarSesion(string nombreUsuario, string contrasena)
        {
            UsuarioEntidad usuario = null;

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT u.CodigoUsuario, u.CodigoSucursal, u.NombreCompleto, u.NombreUsuario, " +
                    "u.Rol, u.Estado " +
                    "FROM dbo.Usuario u INNER JOIN dbo.Rol r ON r.NombreRol = u.Rol " +
                    "WHERE u.NombreUsuario = @NombreUsuario AND u.Contrasena = @Contrasena " +
                    "AND u.Estado = 'Activo' AND r.Estado = 'Activo';", conn))
                {
                    cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = nombreUsuario;
                    cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar, 100).Value = contrasena;
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            usuario = new UsuarioEntidad
                            {
                                CodigoUsuario = Convert.ToInt32(rd["CodigoUsuario"]),
                                CodigoSucursal = Convert.ToInt32(rd["CodigoSucursal"]),
                                NombreCompleto = rd["NombreCompleto"].ToString(),
                                NombreUsuario = rd["NombreUsuario"].ToString(),
                                Rol = rd["Rol"].ToString(),
                                Estado = rd["Estado"].ToString()
                            };
                        }
                    }

                    if (usuario != null)
                    {
                        using (SqlCommand cmdAccesos = new SqlCommand(
                            "SELECT ra.CodigoAcceso FROM dbo.RolAcceso ra " +
                            "INNER JOIN dbo.Rol r ON r.CodigoRol = ra.CodigoRol " +
                            "WHERE r.NombreRol = @NombreRol AND r.Estado = 'Activo';", conn))
                        {
                            cmdAccesos.Parameters.Add("@NombreRol", SqlDbType.VarChar, 30).Value = usuario.Rol;
                            using (SqlDataReader rd = cmdAccesos.ExecuteReader())
                            {
                                while (rd.Read())
                                {
                                    usuario.Accesos.Add(rd["CodigoAcceso"].ToString());
                                }
                            }
                        }
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el acceso del usuario: " + ex.Message, ex);
            }
        }
    }
}
