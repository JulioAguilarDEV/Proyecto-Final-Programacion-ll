using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class OptometristaDatos
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // OptometristaDatos utiliza un objeto ConexionBaseDatos.
        // =====================================================

        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<OptometristaEntidad> MtdConsultar()
        {
            // Lista que guardará un objeto por cada fila de la tabla
            List<OptometristaEntidad> listaOptometrista = new List<OptometristaEntidad>();

            try
            {
                // Se crea la conexión (la tubería) entre C# y la base de datos
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryConsultar = @"
                                            Select
                                                CodigoOptometrista,
                                                Nombres,
                                                Apellidos,
                                                NumeroColegiado,
                                                Telefono,
                                                Correo,
                                                Estado
                                            From Optometrista;";

                    using (SqlCommand cmd = new SqlCommand(queryConsultar, conn))
                    {
                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            // Se lee fila por fila
                            while (rd.Read())
                            {
                                // POO: INSTANCIA DE UN OBJETO
                                OptometristaEntidad optometrista = new OptometristaEntidad(
                                    Convert.ToInt32(rd["CodigoOptometrista"]),
                                    rd["Nombres"].ToString(),
                                    rd["Apellidos"].ToString(),
                                    rd["NumeroColegiado"].ToString(),
                                    rd["Telefono"].ToString(),
                                    rd["Correo"].ToString(),
                                    rd["Estado"].ToString()
                                );

                                listaOptometrista.Add(optometrista);
                            }
                        }
                    }
                }

                return listaOptometrista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los optometristas: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(OptometristaEntidad optometristaEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryAgregar = @"
                                            Insert Into Optometrista
                                            (
                                                Nombres,
                                                Apellidos,
                                                NumeroColegiado,
                                                Telefono,
                                                Correo,
                                                Estado
                                            )
                                            Values
                                            (
                                                @Nombres,
                                                @Apellidos,
                                                @NumeroColegiado,
                                                @Telefono,
                                                @Correo,
                                                @Estado
                                            );";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", optometristaEntidad.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", optometristaEntidad.Apellidos);
                        cmd.Parameters.AddWithValue("@NumeroColegiado", optometristaEntidad.NumeroColegiado);
                        cmd.Parameters.AddWithValue("@Telefono", optometristaEntidad.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", optometristaEntidad.Correo);
                        cmd.Parameters.AddWithValue("@Estado", optometristaEntidad.Estado);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Error 2627 / 2601: se repitió un valor que debe ser único (UNIQUE)
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("Ya existe un optometrista con ese número de colegiado.", ex);
                }

                throw new Exception("Error al agregar el optometrista: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el optometrista: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(OptometristaEntidad optometristaEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEditar = @"
                                            Update Optometrista
                                            Set
                                                Nombres = @Nombres,
                                                Apellidos = @Apellidos,
                                                NumeroColegiado = @NumeroColegiado,
                                                Telefono = @Telefono,
                                                Correo = @Correo,
                                                Estado = @Estado
                                            Where CodigoOptometrista = @CodigoOptometrista;";

                    using (SqlCommand cmd = new SqlCommand(queryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoOptometrista", optometristaEntidad.CodigoOptometrista);
                        cmd.Parameters.AddWithValue("@Nombres", optometristaEntidad.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", optometristaEntidad.Apellidos);
                        cmd.Parameters.AddWithValue("@NumeroColegiado", optometristaEntidad.NumeroColegiado);
                        cmd.Parameters.AddWithValue("@Telefono", optometristaEntidad.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", optometristaEntidad.Correo);
                        cmd.Parameters.AddWithValue("@Estado", optometristaEntidad.Estado);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("Ya existe un optometrista con ese número de colegiado.", ex);
                }

                throw new Exception("Error al editar el optometrista: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el optometrista: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoOptometrista)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEliminar = @"
                                            Delete From Optometrista
                                            Where CodigoOptometrista = @CodigoOptometrista;";

                    using (SqlCommand cmd = new SqlCommand(queryEliminar, conn))
                    {
                        // Enviar el código como parámetro
                        cmd.Parameters.AddWithValue("@CodigoOptometrista", codigoOptometrista);

                        conn.Open();

                        // Devuelve true si eliminó al menos un registro
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Error 547: el registro se está usando en otra tabla (llave foránea)
                if (ex.Number == 547)
                {
                    throw new Exception("No se puede eliminar el optometrista porque tiene citas o exámenes registrados.", ex);
                }

                throw new Exception("Error al eliminar el optometrista: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el optometrista: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public OptometristaEntidad MtdBuscar(int codigoOptometrista)
        {
            // El objeto inicia vacío (null) por si no se encuentra
            OptometristaEntidad optometristaEncontrado = null;

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryBuscar = @"
                                            Select
                                                CodigoOptometrista,
                                                Nombres,
                                                Apellidos,
                                                NumeroColegiado,
                                                Telefono,
                                                Correo,
                                                Estado
                                            From Optometrista
                                            Where CodigoOptometrista = @CodigoOptometrista;";

                    using (SqlCommand cmd = new SqlCommand(queryBuscar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoOptometrista", codigoOptometrista);

                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            // Verificar si se encontró el registro
                            if (rd.Read())
                            {
                                // POO: Crear una instancia de la entidad
                                optometristaEncontrado = new OptometristaEntidad(
                                    Convert.ToInt32(rd["CodigoOptometrista"]),
                                    rd["Nombres"].ToString(),
                                    rd["Apellidos"].ToString(),
                                    rd["NumeroColegiado"].ToString(),
                                    rd["Telefono"].ToString(),
                                    rd["Correo"].ToString(),
                                    rd["Estado"].ToString()
                                );
                            }
                        }
                    }
                }

                // Devuelve el objeto encontrado o null
                return optometristaEncontrado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el optometrista: " + ex.Message, ex);
            }
        }
    }
}
