using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class ExamenVisualDatos
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // ExamenVisualDatos utiliza un objeto ConexionBaseDatos.
        // =====================================================

        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<ExamenVisualEntidad> MtdConsultar()
        {
            // Lista que guardará un objeto por cada fila de la tabla
            List<ExamenVisualEntidad> listaExamenVisual = new List<ExamenVisualEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryConsultar = @"
                                            Select
                                                CodigoExamen,
                                                CodigoCliente,
                                                CodigoOptometrista,
                                                CodigoCita,
                                                Fecha,
                                                Observaciones,
                                                ResultadoGeneral,
                                                Estado
                                            From ExamenVisual;";

                    using (SqlCommand cmd = new SqlCommand(queryConsultar, conn))
                    {
                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                // POO: INSTANCIA DE UN OBJETO
                                // CodigoCita puede venir NULL: en ese caso se guarda 0
                                ExamenVisualEntidad examen = new ExamenVisualEntidad(
                                    Convert.ToInt32(rd["CodigoExamen"]),
                                    Convert.ToInt32(rd["CodigoCliente"]),
                                    Convert.ToInt32(rd["CodigoOptometrista"]),
                                    rd["CodigoCita"] == DBNull.Value ? 0 : Convert.ToInt32(rd["CodigoCita"]),
                                    Convert.ToDateTime(rd["Fecha"]),
                                    rd["Observaciones"].ToString(),
                                    rd["ResultadoGeneral"].ToString(),
                                    rd["Estado"].ToString()
                                );

                                listaExamenVisual.Add(examen);
                            }
                        }
                    }
                }

                return listaExamenVisual;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los exámenes visuales: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(ExamenVisualEntidad examenVisualEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryAgregar = @"
                                            Insert Into ExamenVisual
                                            (
                                                CodigoCliente,
                                                CodigoOptometrista,
                                                CodigoCita,
                                                Fecha,
                                                Observaciones,
                                                ResultadoGeneral,
                                                Estado
                                            )
                                            Values
                                            (
                                                @CodigoCliente,
                                                @CodigoOptometrista,
                                                @CodigoCita,
                                                @Fecha,
                                                @Observaciones,
                                                @ResultadoGeneral,
                                                @Estado
                                            );";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, conn))
                    {
                        MtdAgregarParametros(cmd, examenVisualEntidad);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el examen visual: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(ExamenVisualEntidad examenVisualEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEditar = @"
                                            Update ExamenVisual
                                            Set
                                                CodigoCliente = @CodigoCliente,
                                                CodigoOptometrista = @CodigoOptometrista,
                                                CodigoCita = @CodigoCita,
                                                Fecha = @Fecha,
                                                Observaciones = @Observaciones,
                                                ResultadoGeneral = @ResultadoGeneral,
                                                Estado = @Estado
                                            Where CodigoExamen = @CodigoExamen;";

                    using (SqlCommand cmd = new SqlCommand(queryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoExamen", examenVisualEntidad.CodigoExamen);
                        MtdAgregarParametros(cmd, examenVisualEntidad);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el examen visual: " + ex.Message, ex);
            }
        }

        // =====================================================
        // PARÁMETROS DE AGREGAR Y EDITAR
        // Se usan en los dos métodos, por eso están en uno solo.
        // =====================================================

        private void MtdAgregarParametros(SqlCommand cmd, ExamenVisualEntidad examenVisualEntidad)
        {
            cmd.Parameters.AddWithValue("@CodigoCliente", examenVisualEntidad.CodigoCliente);
            cmd.Parameters.AddWithValue("@CodigoOptometrista", examenVisualEntidad.CodigoOptometrista);

            // La cita es opcional: 0 significa que no tiene cita
            if (examenVisualEntidad.CodigoCita <= 0)
            {
                cmd.Parameters.AddWithValue("@CodigoCita", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CodigoCita", examenVisualEntidad.CodigoCita);
            }

            cmd.Parameters.AddWithValue("@Fecha", examenVisualEntidad.Fecha);

            // Observaciones permite valores nulos en la base de datos
            if (string.IsNullOrWhiteSpace(examenVisualEntidad.Observaciones))
            {
                cmd.Parameters.AddWithValue("@Observaciones", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observaciones", examenVisualEntidad.Observaciones);
            }

            cmd.Parameters.AddWithValue("@ResultadoGeneral", examenVisualEntidad.ResultadoGeneral);
            cmd.Parameters.AddWithValue("@Estado", examenVisualEntidad.Estado);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoExamen)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEliminar = @"
                                            Delete From ExamenVisual
                                            Where CodigoExamen = @CodigoExamen;";

                    using (SqlCommand cmd = new SqlCommand(queryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoExamen", codigoExamen);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Error 547: el registro se está usando en otra tabla (llave foránea)
                if (ex.Number == 547)
                {
                    throw new Exception("No se puede eliminar el examen visual porque tiene recetas registradas.", ex);
                }

                throw new Exception("Error al eliminar el examen visual: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el examen visual: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public ExamenVisualEntidad MtdBuscar(int codigoExamen)
        {
            // El objeto inicia vacío (null) por si no se encuentra
            ExamenVisualEntidad examenEncontrado = null;

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryBuscar = @"
                                            Select
                                                CodigoExamen,
                                                CodigoCliente,
                                                CodigoOptometrista,
                                                CodigoCita,
                                                Fecha,
                                                Observaciones,
                                                ResultadoGeneral,
                                                Estado
                                            From ExamenVisual
                                            Where CodigoExamen = @CodigoExamen;";

                    using (SqlCommand cmd = new SqlCommand(queryBuscar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoExamen", codigoExamen);

                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                // POO: Crear una instancia de la entidad
                                examenEncontrado = new ExamenVisualEntidad(
                                    Convert.ToInt32(rd["CodigoExamen"]),
                                    Convert.ToInt32(rd["CodigoCliente"]),
                                    Convert.ToInt32(rd["CodigoOptometrista"]),
                                    rd["CodigoCita"] == DBNull.Value ? 0 : Convert.ToInt32(rd["CodigoCita"]),
                                    Convert.ToDateTime(rd["Fecha"]),
                                    rd["Observaciones"].ToString(),
                                    rd["ResultadoGeneral"].ToString(),
                                    rd["Estado"].ToString()
                                );
                            }
                        }
                    }
                }

                // Devuelve el objeto encontrado o null
                return examenEncontrado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el examen visual: " + ex.Message, ex);
            }
        }
    }
}
