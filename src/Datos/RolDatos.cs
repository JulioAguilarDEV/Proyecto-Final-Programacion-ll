using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class RolDatos
    {
        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        // Consulta los roles y carga sus accesos relacionados.
        public List<RolEntidad> MtdConsultar()
        {
            List<RolEntidad> roles = new List<RolEntidad>();
            Dictionary<int, RolEntidad> rolesPorCodigo = new Dictionary<int, RolEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT CodigoRol, NombreRol, Descripcion, Estado FROM dbo.Rol ORDER BY CodigoRol; " +
                    "SELECT CodigoRol, CodigoAcceso FROM dbo.RolAcceso ORDER BY CodigoRol, CodigoAcceso;", conn))
                {
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            RolEntidad rol = new RolEntidad(
                                Convert.ToInt32(rd["CodigoRol"]),
                                rd["NombreRol"].ToString(),
                                rd["Descripcion"].ToString(),
                                rd["Estado"].ToString());
                            roles.Add(rol);
                            rolesPorCodigo.Add(rol.CodigoRol, rol);
                        }

                        if (rd.NextResult())
                        {
                            while (rd.Read())
                            {
                                int codigoRol = Convert.ToInt32(rd["CodigoRol"]);
                                if (rolesPorCodigo.ContainsKey(codigoRol))
                                {
                                    rolesPorCodigo[codigoRol].Accesos.Add(rd["CodigoAcceso"].ToString());
                                }
                            }
                        }
                    }
                }

                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los roles: " + ex.Message, ex);
            }
        }

        // Inserta el rol y sus accesos dentro de una transacción.
        public bool MtdAgregar(RolEntidad rol)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    conn.Open();
                    SqlTransaction transaccion = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO dbo.Rol (NombreRol, Descripcion, Estado) " +
                            "VALUES (@NombreRol, @Descripcion, @Estado); SELECT CAST(SCOPE_IDENTITY() AS INT);",
                            conn, transaccion))
                        {
                            MtdAgregarParametros(cmd, rol);
                            rol.CodigoRol = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        MtdGuardarAccesos(conn, transaccion, rol.CodigoRol, rol.Accesos);
                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al agregar el rol: " + ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el rol: " + ex.Message, ex);
            }
        }

        // Actualiza el rol, los usuarios asociados por nombre y sus accesos.
        public bool MtdEditar(RolEntidad rol, string nombreAnterior)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    conn.Open();
                    SqlTransaction transaccion = conn.BeginTransaction();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE dbo.Rol SET NombreRol = @NombreRol, Descripcion = @Descripcion, Estado = @Estado " +
                            "WHERE CodigoRol = @CodigoRol;", conn, transaccion))
                        {
                            cmd.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = rol.CodigoRol;
                            MtdAgregarParametros(cmd, rol);
                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                throw new Exception("No se encontró el rol que desea editar.");
                            }
                        }

                        if (!string.Equals(nombreAnterior, rol.NombreRol, StringComparison.Ordinal))
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "UPDATE dbo.Usuario SET Rol = @NombreNuevo WHERE Rol = @NombreAnterior;",
                                conn, transaccion))
                            {
                                cmd.Parameters.Add("@NombreNuevo", SqlDbType.VarChar, 30).Value = rol.NombreRol.Trim();
                                cmd.Parameters.Add("@NombreAnterior", SqlDbType.VarChar, 30).Value = nombreAnterior;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MtdGuardarAccesos(conn, transaccion, rol.CodigoRol, rol.Accesos);
                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al editar el rol: " + ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el rol: " + ex.Message, ex);
            }
        }

        // Busca un rol por código utilizando la consulta general.
        public RolEntidad MtdBuscar(int codigoRol)
        {
            foreach (RolEntidad rol in MtdConsultar())
            {
                if (rol.CodigoRol == codigoRol)
                {
                    return rol;
                }
            }

            return null;
        }

        // Evita eliminar roles que todavía están asignados a usuarios.
        public bool MtdEliminar(int codigoRol)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    conn.Open();
                    SqlTransaction transaccion = conn.BeginTransaction();

                    try
                    {
                        string nombreRol;
                        using (SqlCommand cmd = new SqlCommand(
                            "SELECT NombreRol FROM dbo.Rol WHERE CodigoRol = @CodigoRol;",
                            conn, transaccion))
                        {
                            cmd.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = codigoRol;
                            object resultado = cmd.ExecuteScalar();
                            if (resultado == null || resultado == DBNull.Value)
                            {
                                throw new Exception("No se encontró el rol que desea eliminar.");
                            }

                            nombreRol = resultado.ToString();
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.Usuario WHERE Rol = @NombreRol;",
                            conn, transaccion))
                        {
                            cmd.Parameters.Add("@NombreRol", SqlDbType.VarChar, 30).Value = nombreRol;
                            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                            {
                                throw new Exception("No se puede eliminar el rol porque está asignado a uno o más usuarios.");
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "DELETE FROM dbo.Rol WHERE CodigoRol = @CodigoRol;",
                            conn, transaccion))
                        {
                            cmd.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = codigoRol;
                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rol: " + ex.Message, ex);
            }
        }

        // Agrega los parámetros con sus tipos y longitudes de SQL.
        private void MtdAgregarParametros(SqlCommand cmd, RolEntidad rol)
        {
            cmd.Parameters.Add("@NombreRol", SqlDbType.VarChar, 30).Value = rol.NombreRol.Trim();
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = rol.Descripcion.Trim();
            cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = rol.Estado;
        }

        // Reemplaza la lista de accesos del rol por la seleccionada en el CRUD.
        private void MtdGuardarAccesos(SqlConnection conn, SqlTransaction transaccion, int codigoRol, List<string> accesos)
        {
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo.RolAcceso WHERE CodigoRol = @CodigoRol;", conn, transaccion))
            {
                cmd.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = codigoRol;
                cmd.ExecuteNonQuery();
            }

            foreach (string acceso in accesos)
            {
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.RolAcceso (CodigoRol, CodigoAcceso) VALUES (@CodigoRol, @CodigoAcceso);",
                    conn, transaccion))
                {
                    cmd.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = codigoRol;
                    cmd.Parameters.Add("@CodigoAcceso", SqlDbType.VarChar, 30).Value = acceso;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
