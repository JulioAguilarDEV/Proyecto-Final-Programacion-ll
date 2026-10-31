using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class OrdenDatos
    {
        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();
        private const string ConsultaOrdenes =
            "SELECT o.CodigoOrden, d.CodigoDetalle, o.CodigoCliente, c.Nombres + ' ' + c.Apellidos AS NombreCliente, " +
            "o.CodigoSucursal, s.Nombre AS NombreSucursal, o.Fecha, o.Estado, " +
            "d.CodigoProducto, p.Nombre AS NombreProducto, d.Cantidad, d.PrecioUnitario, d.Subtotal " +
            "FROM dbo.Orden o " +
            "INNER JOIN dbo.Cliente c ON c.CodigoCliente = o.CodigoCliente " +
            "INNER JOIN dbo.Sucursal s ON s.CodigoSucursal = o.CodigoSucursal " +
            "LEFT JOIN dbo.DetalleOrden d ON d.CodigoOrden = o.CodigoOrden " +
            "LEFT JOIN dbo.ProductoOptico p ON p.CodigoProducto = d.CodigoProducto ";

        public List<OrdenEntidad> MtdConsultar()
        {
            List<OrdenEntidad> listaOrdenes = new List<OrdenEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(ConsultaOrdenes + "ORDER BY o.CodigoOrden, d.CodigoDetalle;", conn))
                {
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            listaOrdenes.Add(MtdCrearOrdenDesdeReader(rd));
                        }
                    }
                }

                return listaOrdenes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar las órdenes y sus detalles: " + ex.Message, ex);
            }
        }

        public List<OrdenEntidad> MtdBuscar(string filtro)
        {
            List<OrdenEntidad> listaOrdenes = new List<OrdenEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    ConsultaOrdenes +
                    "WHERE CONVERT(VARCHAR(11), o.CodigoOrden) LIKE @Filtro " +
                    "OR CONVERT(VARCHAR(11), o.CodigoCliente) LIKE @Filtro " +
                    "OR c.Nombres + ' ' + c.Apellidos LIKE @Filtro " +
                    "OR CONVERT(VARCHAR(11), o.CodigoSucursal) LIKE @Filtro " +
                    "OR s.Nombre LIKE @Filtro OR o.Estado LIKE @Filtro " +
                    "ORDER BY o.CodigoOrden, d.CodigoDetalle;", conn))
                {
                    cmd.Parameters.Add("@Filtro", SqlDbType.VarChar, 102).Value = "%" + filtro.Trim() + "%";
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            listaOrdenes.Add(MtdCrearOrdenDesdeReader(rd));
                        }
                    }
                }

                return listaOrdenes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar órdenes: " + ex.Message, ex);
            }
        }

        public bool MtdAgregar(OrdenEntidad orden)
        {
            using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
            {
                conn.Open();
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    int codigoOrden;

                    using (SqlCommand cmdOrden = new SqlCommand(
                        "INSERT INTO dbo.Orden (CodigoCliente, CodigoSucursal, Fecha, Estado) " +
                        "VALUES (@CodigoCliente, @CodigoSucursal, @Fecha, @Estado); " +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, transaccion))
                    {
                        MtdAgregarParametrosOrden(cmdOrden, orden);
                        codigoOrden = Convert.ToInt32(cmdOrden.ExecuteScalar());
                    }

                    using (SqlCommand cmdDetalle = new SqlCommand(
                        "INSERT INTO dbo.DetalleOrden " +
                        "(CodigoOrden, CodigoProducto, Cantidad, PrecioUnitario, Subtotal) " +
                        "VALUES (@CodigoOrden, @CodigoProducto, @Cantidad, @PrecioUnitario, @Subtotal);",
                        conn,
                        transaccion))
                    {
                        MtdAgregarParametrosDetalle(cmdDetalle, codigoOrden, orden);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    transaccion.Rollback();
                    throw MtdCrearErrorSql("agregar la orden", ex);
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al agregar la orden: " + ex.Message, ex);
                }
            }
        }

        public bool MtdEditar(OrdenEntidad orden)
        {
            using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
            {
                conn.Open();
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    int filasOrden;

                    using (SqlCommand cmdOrden = new SqlCommand(
                        "UPDATE dbo.Orden SET CodigoCliente = @CodigoCliente, CodigoSucursal = @CodigoSucursal, " +
                        "Fecha = @Fecha, Estado = @Estado WHERE CodigoOrden = @CodigoOrden;",
                        conn,
                        transaccion))
                    {
                        MtdAgregarParametrosOrden(cmdOrden, orden);
                        cmdOrden.Parameters.Add("@CodigoOrden", SqlDbType.Int).Value = orden.CodigoOrden;
                        filasOrden = cmdOrden.ExecuteNonQuery();
                    }

                    if (filasOrden == 0)
                    {
                        transaccion.Rollback();
                        return false;
                    }

                    int filasDetalle;
                    if (orden.CodigoDetalle > 0)
                    {
                        using (SqlCommand cmdDetalle = new SqlCommand(
                            "UPDATE dbo.DetalleOrden SET CodigoProducto = @CodigoProducto, Cantidad = @Cantidad, " +
                            "PrecioUnitario = @PrecioUnitario, Subtotal = @Subtotal " +
                            "WHERE CodigoDetalle = @CodigoDetalle AND CodigoOrden = @CodigoOrden;",
                            conn,
                            transaccion))
                        {
                            MtdAgregarParametrosDetalle(cmdDetalle, orden.CodigoOrden, orden);
                            cmdDetalle.Parameters.Add("@CodigoDetalle", SqlDbType.Int).Value = orden.CodigoDetalle;
                            filasDetalle = cmdDetalle.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand cmdDetalle = new SqlCommand(
                            "INSERT INTO dbo.DetalleOrden " +
                            "(CodigoOrden, CodigoProducto, Cantidad, PrecioUnitario, Subtotal) " +
                            "VALUES (@CodigoOrden, @CodigoProducto, @Cantidad, @PrecioUnitario, @Subtotal);",
                            conn,
                            transaccion))
                        {
                            MtdAgregarParametrosDetalle(cmdDetalle, orden.CodigoOrden, orden);
                            filasDetalle = cmdDetalle.ExecuteNonQuery();
                        }
                    }

                    if (filasDetalle == 0)
                    {
                        transaccion.Rollback();
                        return false;
                    }

                    transaccion.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    transaccion.Rollback();
                    throw MtdCrearErrorSql("editar la orden", ex);
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al editar la orden: " + ex.Message, ex);
                }
            }
        }

        public bool MtdEliminar(int codigoOrden)
        {
            using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
            {
                conn.Open();
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmdDetalle = new SqlCommand(
                        "DELETE FROM dbo.DetalleOrden WHERE CodigoOrden = @CodigoOrden;",
                        conn,
                        transaccion))
                    {
                        cmdDetalle.Parameters.Add("@CodigoOrden", SqlDbType.Int).Value = codigoOrden;
                        cmdDetalle.ExecuteNonQuery();
                    }

                    int filasOrden;
                    using (SqlCommand cmdOrden = new SqlCommand(
                        "DELETE FROM dbo.Orden WHERE CodigoOrden = @CodigoOrden;",
                        conn,
                        transaccion))
                    {
                        cmdOrden.Parameters.Add("@CodigoOrden", SqlDbType.Int).Value = codigoOrden;
                        filasOrden = cmdOrden.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    return filasOrden > 0;
                }
                catch (SqlException ex)
                {
                    transaccion.Rollback();
                    throw MtdCrearErrorSql("eliminar la orden", ex);
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al eliminar la orden: " + ex.Message, ex);
                }
            }
        }

        private OrdenEntidad MtdCrearOrdenDesdeReader(SqlDataReader rd)
        {
            return new OrdenEntidad(
                Convert.ToInt32(rd["CodigoOrden"]),
                rd["CodigoDetalle"] == DBNull.Value ? 0 : Convert.ToInt32(rd["CodigoDetalle"]),
                Convert.ToInt32(rd["CodigoCliente"]),
                rd["NombreCliente"].ToString(),
                Convert.ToInt32(rd["CodigoSucursal"]),
                rd["NombreSucursal"].ToString(),
                Convert.ToDateTime(rd["Fecha"]),
                rd["Estado"].ToString(),
                rd["CodigoProducto"] == DBNull.Value ? 0 : Convert.ToInt32(rd["CodigoProducto"]),
                rd["NombreProducto"].ToString(),
                rd["Cantidad"] == DBNull.Value ? 0 : Convert.ToInt32(rd["Cantidad"]),
                rd["PrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(rd["PrecioUnitario"]),
                rd["Subtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(rd["Subtotal"]));
        }

        private void MtdAgregarParametrosOrden(SqlCommand cmd, OrdenEntidad orden)
        {
            cmd.Parameters.Add("@CodigoCliente", SqlDbType.Int).Value = orden.CodigoCliente;
            cmd.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = orden.CodigoSucursal;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = orden.Fecha.Date;
            cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = orden.Estado;
        }

        private void MtdAgregarParametrosDetalle(SqlCommand cmd, int codigoOrden, OrdenEntidad orden)
        {
            cmd.Parameters.Add("@CodigoOrden", SqlDbType.Int).Value = codigoOrden;
            cmd.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = orden.CodigoProducto;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = orden.Cantidad;

            SqlParameter parametroPrecio = cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
            parametroPrecio.Precision = 10;
            parametroPrecio.Scale = 2;
            parametroPrecio.Value = orden.PrecioUnitario;

            SqlParameter parametroSubtotal = cmd.Parameters.Add("@Subtotal", SqlDbType.Decimal);
            parametroSubtotal.Precision = 10;
            parametroSubtotal.Scale = 2;
            parametroSubtotal.Value = orden.Subtotal;
        }

        private Exception MtdCrearErrorSql(string operacion, SqlException ex)
        {
            if (ex.Number == 547)
            {
                return new Exception(
                    "No se pudo " + operacion +
                    " porque existe una relación que lo impide. Verifique los códigos de cliente, sucursal y producto; " +
                    "si intenta eliminar, revise también si la orden tiene una entrega asociada.",
                    ex);
            }

            return new Exception("Error SQL al " + operacion + ": " + ex.Message, ex);
        }
    }
}
