using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class CitaDatos
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // CitaDatos utiliza un objeto ConexionBaseDatos.
        // (Módulo de Diego: se creó para los ComboBox de Exámenes)
        // =====================================================

        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<CitaEntidad> MtdConsultar()
        {
            // Lista que guardará un objeto por cada fila de la tabla
            List<CitaEntidad> listaCita = new List<CitaEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryConsultar = @"
                                            Select
                                                CodigoCita,
                                                CodigoCliente,
                                                CodigoSucursal,
                                                CodigoOptometrista,
                                                Fecha,
                                                Hora,
                                                MotivoConsulta,
                                                Estado
                                            From Cita;";

                    using (SqlCommand cmd = new SqlCommand(queryConsultar, conn))
                    {
                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                // POO: INSTANCIA DE UN OBJETO
                                CitaEntidad cita = new CitaEntidad(
                                    Convert.ToInt32(rd["CodigoCita"]),
                                    Convert.ToInt32(rd["CodigoCliente"]),
                                    Convert.ToInt32(rd["CodigoSucursal"]),
                                    Convert.ToInt32(rd["CodigoOptometrista"]),
                                    Convert.ToDateTime(rd["Fecha"]),
                                    (TimeSpan)rd["Hora"],
                                    rd["MotivoConsulta"].ToString(),
                                    rd["Estado"].ToString()
                                );

                                listaCita.Add(cita);
                            }
                        }
                    }
                }

                return listaCita;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar las citas: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(CitaEntidad citaEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryAgregar = @"
                                            Insert Into Cita
                                            (
                                                CodigoCliente,
                                                CodigoSucursal,
                                                CodigoOptometrista,
                                                Fecha,
                                                Hora,
                                                MotivoConsulta,
                                                Estado
                                            )
                                            Values
                                            (
                                                @CodigoCliente,
                                                @CodigoSucursal,
                                                @CodigoOptometrista,
                                                @Fecha,
                                                @Hora,
                                                @MotivoConsulta,
                                                @Estado
                                            );";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, conn))
                    {
                        MtdAgregarParametros(cmd, citaEntidad);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la cita: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(CitaEntidad citaEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEditar = @"
                                            Update Cita
                                            Set
                                                CodigoCliente = @CodigoCliente,
                                                CodigoSucursal = @CodigoSucursal,
                                                CodigoOptometrista = @CodigoOptometrista,
                                                Fecha = @Fecha,
                                                Hora = @Hora,
                                                MotivoConsulta = @MotivoConsulta,
                                                Estado = @Estado
                                            Where CodigoCita = @CodigoCita;";

                    using (SqlCommand cmd = new SqlCommand(queryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoCita", citaEntidad.CodigoCita);
                        MtdAgregarParametros(cmd, citaEntidad);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la cita: " + ex.Message, ex);
            }
        }

        // =====================================================
        // PARÁMETROS DE AGREGAR Y EDITAR
        // =====================================================

        private void MtdAgregarParametros(SqlCommand cmd, CitaEntidad citaEntidad)
        {
            cmd.Parameters.AddWithValue("@CodigoCliente", citaEntidad.CodigoCliente);
            cmd.Parameters.AddWithValue("@CodigoSucursal", citaEntidad.CodigoSucursal);
            cmd.Parameters.AddWithValue("@CodigoOptometrista", citaEntidad.CodigoOptometrista);
            cmd.Parameters.AddWithValue("@Fecha", citaEntidad.Fecha);
            cmd.Parameters.AddWithValue("@Hora", citaEntidad.Hora);
            cmd.Parameters.AddWithValue("@MotivoConsulta", citaEntidad.MotivoConsulta);
            cmd.Parameters.AddWithValue("@Estado", citaEntidad.Estado);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoCita)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEliminar = @"
                                            Delete From Cita
                                            Where CodigoCita = @CodigoCita;";

                    using (SqlCommand cmd = new SqlCommand(queryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoCita", codigoCita);

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
                    throw new Exception("No se puede eliminar la cita porque tiene exámenes visuales registrados.", ex);
                }

                throw new Exception("Error al eliminar la cita: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la cita: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public CitaEntidad MtdBuscar(int codigoCita)
        {
            // El objeto inicia vacío (null) por si no se encuentra
            CitaEntidad citaEncontrada = null;

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryBuscar = @"
                                            Select
                                                CodigoCita,
                                                CodigoCliente,
                                                CodigoSucursal,
                                                CodigoOptometrista,
                                                Fecha,
                                                Hora,
                                                MotivoConsulta,
                                                Estado
                                            From Cita
                                            Where CodigoCita = @CodigoCita;";

                    using (SqlCommand cmd = new SqlCommand(queryBuscar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoCita", codigoCita);

                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                citaEncontrada = new CitaEntidad(
                                    Convert.ToInt32(rd["CodigoCita"]),
                                    Convert.ToInt32(rd["CodigoCliente"]),
                                    Convert.ToInt32(rd["CodigoSucursal"]),
                                    Convert.ToInt32(rd["CodigoOptometrista"]),
                                    Convert.ToDateTime(rd["Fecha"]),
                                    (TimeSpan)rd["Hora"],
                                    rd["MotivoConsulta"].ToString(),
                                    rd["Estado"].ToString()
                                );
                            }
                        }
                    }
                }

                // Devuelve el objeto encontrado o null
                return citaEncontrada;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la cita: " + ex.Message, ex);
            }
        }
    }
}
