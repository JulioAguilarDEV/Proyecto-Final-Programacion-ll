using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class TipoProductoDatos
    {
        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        public List<TipoProductoEntidad> MtdConsultar()
        {
            List<TipoProductoEntidad> listaTipoProducto = new List<TipoProductoEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT CodigoTipoProducto, Nombre, Descripcion, Estado FROM dbo.TipoProducto ORDER BY CodigoTipoProducto;", conn))
                {
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            listaTipoProducto.Add(new TipoProductoEntidad(
                                Convert.ToInt32(rd["CodigoTipoProducto"]),
                                rd["Nombre"].ToString(),
                                rd["Descripcion"].ToString(),
                                rd["Estado"].ToString()));
                        }
                    }
                }

                return listaTipoProducto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los tipos de producto: " + ex.Message, ex);
            }
        }

        public bool MtdAgregar(TipoProductoEntidad tipoProducto)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.TipoProducto (Nombre, Descripcion, Estado) VALUES (@Nombre, @Descripcion, @Estado);", conn))
                {
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 80).Value = tipoProducto.Nombre;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = tipoProducto.Descripcion;
                    cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = tipoProducto.Estado;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el tipo de producto: " + ex.Message, ex);
            }
        }

        public bool MtdEditar(TipoProductoEntidad tipoProducto)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE dbo.TipoProducto SET Nombre = @Nombre, Descripcion = @Descripcion, Estado = @Estado WHERE CodigoTipoProducto = @CodigoTipoProducto;", conn))
                {
                    cmd.Parameters.Add("@CodigoTipoProducto", SqlDbType.Int).Value = tipoProducto.CodigoTipoProducto;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 80).Value = tipoProducto.Nombre;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = tipoProducto.Descripcion;
                    cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = tipoProducto.Estado;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el tipo de producto: " + ex.Message, ex);
            }
        }

        public TipoProductoEntidad MtdBuscar(int codigoTipoProducto)
        {
            TipoProductoEntidad tipoProductoEncontrado = null;

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT CodigoTipoProducto, Nombre, Descripcion, Estado FROM dbo.TipoProducto WHERE CodigoTipoProducto = @CodigoTipoProducto;", conn))
                {
                    cmd.Parameters.Add("@CodigoTipoProducto", SqlDbType.Int).Value = codigoTipoProducto;
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            tipoProductoEncontrado = new TipoProductoEntidad(
                                Convert.ToInt32(rd["CodigoTipoProducto"]),
                                rd["Nombre"].ToString(),
                                rd["Descripcion"].ToString(),
                                rd["Estado"].ToString());
                        }
                    }
                }

                return tipoProductoEncontrado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el tipo de producto: " + ex.Message, ex);
            }
        }

        public bool MtdEliminar(int codigoTipoProducto)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM dbo.TipoProducto WHERE CodigoTipoProducto = @CodigoTipoProducto;", conn))
                {
                    cmd.Parameters.Add("@CodigoTipoProducto", SqlDbType.Int).Value = codigoTipoProducto;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new Exception("No se puede eliminar el tipo de producto porque está asociado a productos ópticos.", ex);
                }

                throw new Exception("Error al eliminar el tipo de producto: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el tipo de producto: " + ex.Message, ex);
            }
        }

    }
}