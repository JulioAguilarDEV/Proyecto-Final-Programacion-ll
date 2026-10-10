using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class RecetaDatos
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // RecetaDatos utiliza un objeto ConexionBaseDatos.
        // =====================================================

        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<RecetaEntidad> MtdConsultar()
        {
            // Lista que guardará un objeto por cada fila de la tabla
            List<RecetaEntidad> listaReceta = new List<RecetaEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryConsultar = @"
                                            Select
                                                CodigoReceta,
                                                CodigoExamen,
                                                EsferaOD,
                                                CilindroOD,
                                                EjeOD,
                                                EsferaOI,
                                                CilindroOI,
                                                EjeOI,
                                                Adicion,
                                                DistanciaPupilar,
                                                FechaEmision,
                                                Observaciones,
                                                Estado
                                            From Receta;";

                    using (SqlCommand cmd = new SqlCommand(queryConsultar, conn))
                    {
                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                // POO: INSTANCIA DE UN OBJETO
                                RecetaEntidad receta = MtdLeerReceta(rd);

                                listaReceta.Add(receta);
                            }
                        }
                    }
                }

                return listaReceta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar las recetas: " + ex.Message, ex);
            }
        }

        // =====================================================
        // LEER UNA FILA
        // Convierte la fila actual del SqlDataReader en una receta.
        // Se usa en Consultar y en Buscar.
        // =====================================================

        private RecetaEntidad MtdLeerReceta(SqlDataReader rd)
        {
            return new RecetaEntidad(
                Convert.ToInt32(rd["CodigoReceta"]),
                Convert.ToInt32(rd["CodigoExamen"]),
                Convert.ToDecimal(rd["EsferaOD"]),
                Convert.ToDecimal(rd["CilindroOD"]),
                Convert.ToInt32(rd["EjeOD"]),
                Convert.ToDecimal(rd["EsferaOI"]),
                Convert.ToDecimal(rd["CilindroOI"]),
                Convert.ToInt32(rd["EjeOI"]),
                Convert.ToDecimal(rd["Adicion"]),
                Convert.ToDecimal(rd["DistanciaPupilar"]),
                Convert.ToDateTime(rd["FechaEmision"]),
                rd["Observaciones"].ToString(),
                rd["Estado"].ToString()
            );
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(RecetaEntidad recetaEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryAgregar = @"
                                            Insert Into Receta
                                            (
                                                CodigoExamen,
                                                EsferaOD,
                                                CilindroOD,
                                                EjeOD,
                                                EsferaOI,
                                                CilindroOI,
                                                EjeOI,
                                                Adicion,
                                                DistanciaPupilar,
                                                FechaEmision,
                                                Observaciones,
                                                Estado
                                            )
                                            Values
                                            (
                                                @CodigoExamen,
                                                @EsferaOD,
                                                @CilindroOD,
                                                @EjeOD,
                                                @EsferaOI,
                                                @CilindroOI,
                                                @EjeOI,
                                                @Adicion,
                                                @DistanciaPupilar,
                                                @FechaEmision,
                                                @Observaciones,
                                                @Estado
                                            );";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, conn))
                    {
                        MtdAgregarParametros(cmd, recetaEntidad);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la receta: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(RecetaEntidad recetaEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEditar = @"
                                            Update Receta
                                            Set
                                                CodigoExamen = @CodigoExamen,
                                                EsferaOD = @EsferaOD,
                                                CilindroOD = @CilindroOD,
                                                EjeOD = @EjeOD,
                                                EsferaOI = @EsferaOI,
                                                CilindroOI = @CilindroOI,
                                                EjeOI = @EjeOI,
                                                Adicion = @Adicion,
                                                DistanciaPupilar = @DistanciaPupilar,
                                                FechaEmision = @FechaEmision,
                                                Observaciones = @Observaciones,
                                                Estado = @Estado
                                            Where CodigoReceta = @CodigoReceta;";

                    using (SqlCommand cmd = new SqlCommand(queryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoReceta", recetaEntidad.CodigoReceta);
                        MtdAgregarParametros(cmd, recetaEntidad);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la receta: " + ex.Message, ex);
            }
        }

        // =====================================================
        // PARÁMETROS DE AGREGAR Y EDITAR
        // Se usan en los dos métodos, por eso están en uno solo.
        // =====================================================

        private void MtdAgregarParametros(SqlCommand cmd, RecetaEntidad recetaEntidad)
        {
            cmd.Parameters.AddWithValue("@CodigoExamen", recetaEntidad.CodigoExamen);
            cmd.Parameters.AddWithValue("@EsferaOD", recetaEntidad.EsferaOD);
            cmd.Parameters.AddWithValue("@CilindroOD", recetaEntidad.CilindroOD);
            cmd.Parameters.AddWithValue("@EjeOD", recetaEntidad.EjeOD);
            cmd.Parameters.AddWithValue("@EsferaOI", recetaEntidad.EsferaOI);
            cmd.Parameters.AddWithValue("@CilindroOI", recetaEntidad.CilindroOI);
            cmd.Parameters.AddWithValue("@EjeOI", recetaEntidad.EjeOI);
            cmd.Parameters.AddWithValue("@Adicion", recetaEntidad.Adicion);
            cmd.Parameters.AddWithValue("@DistanciaPupilar", recetaEntidad.DistanciaPupilar);
            cmd.Parameters.AddWithValue("@FechaEmision", recetaEntidad.FechaEmision);

            // Observaciones permite valores nulos en la base de datos
            if (string.IsNullOrWhiteSpace(recetaEntidad.Observaciones))
            {
                cmd.Parameters.AddWithValue("@Observaciones", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observaciones", recetaEntidad.Observaciones);
            }

            cmd.Parameters.AddWithValue("@Estado", recetaEntidad.Estado);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoReceta)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEliminar = @"
                                            Delete From Receta
                                            Where CodigoReceta = @CodigoReceta;";

                    using (SqlCommand cmd = new SqlCommand(queryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoReceta", codigoReceta);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la receta: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public RecetaEntidad MtdBuscar(int codigoReceta)
        {
            // El objeto inicia vacío (null) por si no se encuentra
            RecetaEntidad recetaEncontrada = null;

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryBuscar = @"
                                            Select
                                                CodigoReceta,
                                                CodigoExamen,
                                                EsferaOD,
                                                CilindroOD,
                                                EjeOD,
                                                EsferaOI,
                                                CilindroOI,
                                                EjeOI,
                                                Adicion,
                                                DistanciaPupilar,
                                                FechaEmision,
                                                Observaciones,
                                                Estado
                                            From Receta
                                            Where CodigoReceta = @CodigoReceta;";

                    using (SqlCommand cmd = new SqlCommand(queryBuscar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoReceta", codigoReceta);

                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                recetaEncontrada = MtdLeerReceta(rd);
                            }
                        }
                    }
                }

                // Devuelve el objeto encontrado o null
                return recetaEncontrada;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la receta: " + ex.Message, ex);
            }
        }
    }
}
